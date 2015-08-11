using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DAL;
using Microsoft.Practices.Unity;
using ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
using System.Collections;

namespace ReadingTestScores
{
    public partial class Main : Form
    {
        BackgroundWorker _bgwrkTest = new BackgroundWorker();
        readonly BackgroundWorker _bgwrkParseExcelFile = new BackgroundWorker();
        List<Files> _getFile = new List<Files>();
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

          
           ProcessingAssessmentTest getTest = new AssessmentTestDataParser();
           List<TestAssessmentMeasurmentCollection> testData=null;
           List<TestAssessmentHeaderCollection> headerData=null;

            // Open,Extract and parse Assessment Test Data//
       testData = getTest.GetTestMeasures(@"C:\AssessmentXLSfiles\AssesmentAudit\SavedAssessments\Andres Soto_Keep.xls");
//
       headerData = getTest.GetHeader(@"C:\AssessmentXLSfiles\AssesmentAudit\SavedAssessments\Andres Soto_Keep.xls");

            // Save Assesment Test data to the data store //
            StoreAssessmentTest assesmentTest = new StoreAssessmentTestDataFactory();
            assesmentTest.SaveData(testData, headerData);
            
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

                _bgwrkParseExcelFile.WorkerReportsProgress = true;
                _bgwrkParseExcelFile.DoWork += bgwrkParseExcelFile_DoWork;
                _bgwrkParseExcelFile.ProgressChanged += bgwrkParseExcelFile_ProgressChanged;
                _bgwrkParseExcelFile.RunWorkerCompleted += bgwrkParseExcelFile_RunWorkerCompleted;
                _bgwrkParseExcelFile.RunWorkerAsync();
                dataGridView1.Columns.Add("File_Path", "File");
                dataGridView1.Columns.Add("Status", "State");
                dataGridView1.Columns[0].Width = 220;
              

        }

        private void bgwrkParseExcelFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // The user canceled the operation.
                MessageBox.Show(@"Operation was canceled");
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
                label2.Text = @"Importing Excel File";
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
                IUnityContainer objOpen = new UnityContainer();
                objOpen.RegisterType<ParseAssessmentTest, RejectTestIndex>();
                objOpen.RegisterType<ParseAssessmentTest, RetainTestIndex>();
         
            var indicies = new List<EntireTestCollection>();
            var files = from file in Directory.EnumerateFiles(@"C:\AssessmentXLSfiles", "*.xls", SearchOption.AllDirectories)
                        from line in File.ReadLines(file)
                        where line.Contains(".xls")
                        select new
                        {
                            File = file,
                        };

             
              
           foreach (var excelFile in files)
              {

                  _bgwrkParseExcelFile.ReportProgress(0, excelFile.File);
                //Create assessment data file to keep//
                  _bgwrkParseExcelFile.ReportProgress(1, "Preparing to Parse Good Data");
                  var keep = objOpen.Resolve<RetainTestIndex>();
         
                  indicies = keep.Open(excelFile.File, indicies, _bgwrkParseExcelFile);
                //Create Rejected assessment data file//
              _bgwrkParseExcelFile.ReportProgress(1, "Preparing to Parse Rejected Data");
           
              var reject = objOpen.Resolve<RejectTestIndex>();
             indicies=reject.Open(excelFile.File, indicies, _bgwrkParseExcelFile);
              _bgwrkParseExcelFile.ReportProgress(0, "Completed");
             
              }

           if (_bgwrkParseExcelFile.CancellationPending)
           {
               e.Cancel = true;
           }
          
              }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.WriteLine(uaEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }
         
        }
     
       
      
    }
    public class Files
    {
        private String _filepath = string.Empty;
        private String _state = string.Empty;
        public Files(string filepath, string state)
        {
            Filepath = filepath;
            Status = state;
        }


        public string Filepath { get; set; }

        public string Status { get; set; }
    }
    
}
