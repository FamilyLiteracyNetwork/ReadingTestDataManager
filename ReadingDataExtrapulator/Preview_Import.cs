using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using DAL;
namespace BAL
{
    public partial class Preview_Import : Form
    {
        public Preview_Import()
        {
            InitializeComponent();
        }

        private void Preview_Import_Load(object sender, EventArgs e)
        {
            RunPreview();
          
        }

        public void RunPreview()
        {

            var _excelApp = new Excel.Application();
            Excel.Workbook _excelWorkbook;
            Excel.Worksheet _excelWorksheet;
            Excel.Range range;

            // Open Excel spreadsheet.
            _excelWorkbook = _excelApp.Workbooks.Open(@"C:\ExcelTestFiles\ZacRya140814.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing);





            string fName, lName,testDate;
            // int rCnt = 0;
            // int cCnt = 0;



            _excelWorksheet = (Excel.Worksheet)_excelWorkbook.Worksheets.get_Item(1);
            range = _excelWorksheet.UsedRange;

            fName = Convert.ToString((range.Cells[7, 7] as Excel.Range).Value2);
            lName = Convert.ToString((range.Cells[8, 7] as Excel.Range).Value2);
            testDate = Convert.ToString((range.Cells[4, 4] as Excel.Range).Value2);
            //Check to see if name exist in the student profile table
            ReadingDataEntities db = new ReadingDataEntities();

            /////////////////////////////////////////////////////////
            //           Check to see if student exist             //
            //        Otherwise and the student to the database    //
            /////////////////////////////////////////////////////////
            int studentNo;
            var queryStudent = (from p in db.StudentProfiles.ToList()
                               where p.First_Name==fName.Trim() && p.Last_Name==lName.Trim()
                           select p).Count();
            //Insert student into the student profile table 
         if(queryStudent<1)
         {
             StudentProfile _student = new StudentProfile();
             _student.First_Name=fName;
             _student.Last_Name=lName;
         }
         var studentAttributes = (from p in db.StudentProfiles
                                  where p.First_Name == fName && p.Last_Name == lName
                                  select p).FirstOrDefault();
            ////////////////////////////////////////////////////////////
            //                Generate Excel Header                   //
            ////////////////////////////////////////////////////////////
         var _excelAppGenerate = new Excel.Application();
         Excel.Workbook _excelWorkbookGenerate;
         Excel.Worksheet _excelWorksheetGenerate = null;

         // creating new WorkBook within Excel application

         _excelWorkbookGenerate = _excelAppGenerate.Workbooks.Add(Type.Missing);
         // see the excel sheet behind the program

         _excelAppGenerate.Visible = true;



         // get the reference of first sheet. By default its name is Sheet1.

         // store its reference to worksheet

         _excelWorksheetGenerate = _excelWorkbookGenerate.Sheets["Sheet1"];

         _excelWorksheetGenerate = _excelWorkbookGenerate.ActiveSheet;

         _excelWorksheetGenerate.Name = "Student Reading Assessment";

         // changing the name of active sheet

         _excelWorksheet.Name = "Student Reading Assessment";
         List<ReadingTestScores> readingScores = new List<ReadingTestScores>();
         ExcelSections.Header(1, 10, range,_excelWorksheetGenerate, readingScores);

       


    ///////////////////////////////////////////////////////////////////////////////////////////////////
    ////   Evaluate each Data Point Standard Score Raw Score t Scor and (ss) for a given student   ////
    ///////////////////////////////////////////////////////////////////////////////////////////////////

         studentNo=studentAttributes.StudentID;
         int excelIndexNo;
         int bookmark = 9;
         for (int rowCnt = 11 ; rowCnt <= 25132; rowCnt++)
         {
             excelIndexNo = Convert.ToInt32((range.Cells[rowCnt, 1] as Excel.Range).Value2);

             readingScores=ExcelDataMultiplexer.Multiplexer(studentNo, range, rowCnt, excelIndexNo);


            
                 var _currentRow = (from p in readingScores.ToList()
                                    select p).LastOrDefault();
                 if (_currentRow != null )
                 {
                     if (_currentRow.ExcelLastRowIndex != 0)
                     {
                         rowCnt = _currentRow.ExcelLastRowIndex;
                         //Add to Reading Scores to Database

                         ExcelSections.Body(bookmark, readingScores.Count, range, _excelWorksheetGenerate, readingScores);
                     //    ReadingDataEntities dbTestScores= new ReadingDataEntities();
                         bookmark = bookmark + readingScores.Count;
                         _currentRow.ExcelLastRowIndex = 0;
                     }
                   
                   }
           
         }
        }
    }
}
