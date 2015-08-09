using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using DAL;
using BAL;
using System.Runtime.InteropServices;
using ReadingTestScores.ProcessAssessmentDataToDatabase;
using ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
using System.Collections;
using ReadingTestScores;


namespace ReadingDataExtrapulator
{
    public partial class Main : Form
    {
        BackgroundWorker bgwrkTest = new BackgroundWorker();
        BackgroundWorker bgwrkParseExcelFile = new BackgroundWorker();
        List<Files> GetFile = new List<Files>();
        public Main()
        {
            InitializeComponent();
         

        }

        private void Form1_Load(object sender, EventArgs e)
        {


         

        }


        private void button1_Click(object sender, EventArgs e)
        {
            /* bgwrkTest.WorkerReportsProgress = true;
            bgwrkTest.DoWork += bgwrkTest_DoWork;
            bgwrkTest.ProgressChanged += bgwrkTest_ProgressChanged;
            bgwrkTest.RunWorkerCompleted += bgwrkTest_RunWorkerCompleted;
            bgwrkTest.RunWorkerAsync();*/

          
           ProcessingAssessmentTest GetTest = new AssessmentTestDataParser();
           List<TestAssessmentMeasurmentCollection> testData = new List<TestAssessmentMeasurmentCollection>();
           List<TestAssessmentHeaderCollection> headerData = new List<TestAssessmentHeaderCollection>();

            // Open,Extract and parse Assessment Test Data//
       testData = GetTest.GetTestMeasures(@"C:\AssessmentXLSfiles\AssesmentAudit\SavedAssessments\Andres Soto_Keep.xls");
//
       headerData = GetTest.GetHeader(@"C:\AssessmentXLSfiles\AssesmentAudit\SavedAssessments\Andres Soto_Keep.xls");

            // Save Assesment Test data to the data store //
            StoreAssessmentTest AssesmentTest = new StoreAssessmentTestDataFactory();
            AssesmentTest.SaveData(testData, headerData);
            
        }

       

       

       
       

        private void bgwrkTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void bgwrkTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }



        private void bgwrkTest_DoWork(object sender, DoWorkEventArgs e)
        {
          

        }

 

        private void button2_Click(object sender, EventArgs e)
        {

           

        }
       

        private void button3_Click(object sender, EventArgs e)
        {

                bgwrkParseExcelFile.WorkerReportsProgress = true;
                bgwrkParseExcelFile.DoWork += bgwrkParseExcelFile_DoWork;
                bgwrkParseExcelFile.ProgressChanged += bgwrkParseExcelFile_ProgressChanged;
                bgwrkParseExcelFile.RunWorkerCompleted += bgwrkParseExcelFile_RunWorkerCompleted;
                bgwrkParseExcelFile.RunWorkerAsync();
                dataGridView1.Columns.Add("File_Path", "File");
                dataGridView1.Columns.Add("Status", "State");
                dataGridView1.Columns[0].Width = 220;
              

        }

        private void bgwrkParseExcelFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // The user canceled the operation.
                MessageBox.Show("Operation was canceled");
            }
            else if (e.Error != null)
            {
                // There was an error during the operation. 
                string msg = String.Format("An error occurred: {0}", e.Error.Message);
                MessageBox.Show(msg);
            }
            else
            {
                // The operation completed normally. 
                string msg = String.Format("Result = {0}", e.Result);
                MessageBox.Show(msg);
            }
        }

        private void bgwrkParseExcelFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            String status = (String)e.UserState;
            if (e.ProgressPercentage == 0 && status != "Completed")
            {

                var rows = dataGridView1.Rows;
                rows.Add(status,"Loading Data");
                label2.Text = "Importing Excel File";
            }
            else if (e.ProgressPercentage > 0 && e.ProgressPercentage<=100)
            {
                progressBar1.Value = e.ProgressPercentage;
                label1.Text = e.ProgressPercentage.ToString() + "%";
                label2.Text = status;
            }else if(e.ProgressPercentage==0 && status=="Completed")
            {
                dataGridView1.Rows[dataGridView1.RowCount-2].Cells[1].Value = "Completed";
            }
        }

        private void bgwrkParseExcelFile_DoWork(object sender, DoWorkEventArgs e)
        {
            try{
            ParseAssessmentTest ExtractIndex = new RejectTestIndex();
            ParseAssessmentTest RetainIndex = new RetainTestIndex();
            List<EntireTestCollection> indicies = new List<EntireTestCollection>();
            var files = from file in Directory.EnumerateFiles(@"C:\AssessmentXLSfiles", "*.xls", SearchOption.AllDirectories)
                        from line in File.ReadLines(file)
                        where line.Contains(".xls")
                        select new
                        {
                            File = file,
                        };

           foreach (var excelFile in files)
              {
                  bgwrkParseExcelFile.ReportProgress(0, excelFile.File);
                //Create assessment data to keep
                  bgwrkParseExcelFile.ReportProgress(1, "Preparing to Parse Good Data");
              indicies = RetainIndex.Open(excelFile.File, indicies, bgwrkParseExcelFile);
                //Create Rejection
              bgwrkParseExcelFile.ReportProgress(1, "Preparing to Parse Rejected Data");
              indicies = ExtractIndex.Open(excelFile.File, indicies, bgwrkParseExcelFile);
              bgwrkParseExcelFile.ReportProgress(0, "Completed");
             
              }

           if (bgwrkParseExcelFile.CancellationPending)
           {
               e.Cancel = true;
           }
            Console.WriteLine("{0} files found.", files.Count().ToString());
              }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
         
        }
     
       
      
    }
    public class Files
    {
        private String _filepath = string.Empty;
        private String _state = string.Empty;
        public Files(string _filepath, string _state)
        {
            Filepath = _filepath;
            Status = _state;
        }


        public string Filepath { get; set; }

        public string Status { get; set; }
    }
    
}
