using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using BAL;
using DAL;
using ReadingTestScores.ImportTestAssessments;
using ReadingTestScores.ProcessAssessmentDataToDatabase;
using ReadingTestScores.StudentProfile;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReadingTestScores
{
    public abstract class ParseAssessmentTest
    {
        public abstract List<EntireTestCollection> Open(string studentFile, List<EntireTestCollection> indicies, BackgroundWorker bgWorker);

    }

  
    /*
    public class OpenExcelDocument : AssessmentTest
    {
        public override Excel.Range Open(string studentFile, BackgroundWorker bgworker)
        {

            var _excelApp = new Excel.Application();
            Excel.Workbook _excelWorkbook=null;
            Excel.Worksheet _excelWorksheet=null;
            Excel.Range range;

            // Open Excel spreadsheet.
            _excelWorkbook = _excelApp.Workbooks.Open(studentFile, Type.Missing, false, Type.Missing, Type.Missing,
           Type.Missing, Type.Missing, Type.Missing, Type.Missing,
           Type.Missing, Type.Missing, Type.Missing, Type.Missing,
           Type.Missing, Type.Missing);

          



            string fName, lName, testDate;
            int studentNo;



            _excelWorksheet = (Excel.Worksheet)_excelWorkbook.Worksheets.get_Item(1);

            range = _excelWorksheet.UsedRange;
            Marshal.ReleaseComObject(_excelWorksheet);
            Marshal.ReleaseComObject(_excelWorkbook);
            Marshal.ReleaseComObject(_excelApp);
            fName = Convert.ToString((range.Cells[7, 7] as Excel.Range).Value2);
            lName = Convert.ToString((range.Cells[8, 7] as Excel.Range).Value2);
            testDate = Convert.ToString((range.Cells[4, 4] as Excel.Range).Value2);
            //Check to see if name exist in the student profile table
            DAL.ReadingDataEntities db = new DAL.ReadingDataEntities();

            /////////////////////////////////////////////////////////
            //           Check to see if student exist             //
            //        Otherwise and the student to the database    //
            /////////////////////////////////////////////////////////
          
           
            var queryStudent = (from p in db.StudentProfiles
                                where p.First_Name == fName.Trim() && p.Last_Name == lName.Trim()
                                select p).Count();
            //Insert student into the student profile table 
            if (queryStudent < 1)
            {
                StudentProfile _student = new StudentProfile();
                _student.First_Name = fName;
                _student.Last_Name = lName;
            }
            var studentAttributes = (from p in db.StudentProfiles
                                     where p.First_Name == fName && p.Last_Name == lName
                                     select p).FirstOrDefault();
            ////////////////////////////////////////////////////////////
            //                Generate Excel Header                   //
            ////////////////////////////////////////////////////////////
            var _excelAppGenerate = new Excel.Application();
            Excel.Workbook _excelWorkbookGenerate=null;
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
            List<DAL.ReadingTestScores> readingScores = new List<DAL.ReadingTestScores>();
            GenerateExcelDocParseScores GenerateExcelDoc = new GenerateBody();
            IHeader BuildHeader = new GenerateExcelHeader();
           BuildHeader.Create(1, 10, range, _excelWorksheetGenerate);

            TestingAssessments ReadingAssessments = new TestingAssessment1();


            ///////////////////////////////////////////////////////////////////////////////////////////////////
            ////   Evaluate each Data Point Standard Score Raw Score t Scor and (ss) for a given student   ////
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            studentNo = studentAttributes.StudentID;
            int excelIndexNo;
            int bookmark = 9;
            Int32 percentageComplete=0;
            bgworker.ReportProgress(percentageComplete);
            System.Threading.Thread.Sleep(1);
            for (int rowCnt = 11; rowCnt <= 25132; rowCnt++)
            {
                excelIndexNo = Convert.ToInt32((range.Cells[rowCnt, 1] as Excel.Range).Value2);
                string scoreType =   scoreType = ((range.Cells[rowCnt, 3] as Excel.Range).Value2);
               readingScores = ReadingAssessments.Assessments(studentNo, range, rowCnt, excelIndexNo,bgworker);
           


                var _currentRow = (from p in readingScores.ToList()
                                   select p).LastOrDefault();
                if (_currentRow != null)
                {
                    if (_currentRow.ExcelLastRowIndex != 0)
                    {
                        rowCnt = _currentRow.ExcelLastRowIndex;
                        //Scan to verify Index

                        //Add to Reading Scores to Database
                        GenerateExcelDocParseScores BuildAssessmentDoc = new GenerateBody();
                        BuildAssessmentDoc.Create(bookmark, readingScores.Count, range, _excelWorksheetGenerate, readingScores, bgworker);
                       // StandardAssessment.SaveTest(scoreType);
                      
                        //    ReadingDataEntities dbTestScores= new ReadingDataEntities();
                        bookmark = bookmark + readingScores.Count;
                        _currentRow.ExcelLastRowIndex = 0;
                    }

                }
                percentageComplete = Convert.ToInt32(((double)rowCnt / 25132) * 100);
                bgworker.ReportProgress(percentageComplete);
                System.Threading.Thread.Sleep(1);
            }
        }
    }

    */


    public class RejectTestIndex : ParseAssessmentTest
    {
        public override List<EntireTestCollection> Open(string studentFile, List<EntireTestCollection> indicies,BackgroundWorker bgWorker)
        {
            String filename = string.Empty;
            Excel.Application excelApp = new Excel.Application();

            Excel.Workbooks tmp = excelApp.Workbooks;
         
            // Open Excel spreadsheet.


            var excelWorkbook = tmp.Open(@studentFile, Type.Missing, true, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);

            excelApp.Visible = true;

            excelApp.DisplayAlerts = false;
            String activeworksheet = "Entry";
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[activeworksheet];
            excelWorksheet.Select(true);
            excelWorksheet.Unprotect();
            excelApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
            
           
            var range = excelWorksheet.UsedRange;
            
          
       
            excelWorksheet.Cells[1, 1].EntireColumn.ColumnWidth = 15;
            excelWorksheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;

            string fName = Convert.ToString(((Excel.Range) range.Cells[7, 7]).Value2);
            string lName = Convert.ToString(((Excel.Range) range.Cells[8, 7]).Value2);

            string testDate = Convert.ToString(((Excel.Range) range.Cells[4, 4]).Value2);
            var fullname = fName + " " + lName;
            //Check to see if name exist in the student profile table
            DAL.ReadingDataEntities db = new DAL.ReadingDataEntities();

            /////////////////////////////////////////////////////////
            //           Check to see if student exist             //
            //        Otherwise and the student to the database    //
            /////////////////////////////////////////////////////////


            var queryStudent = (from p in db.StudentProfiles
                                where p.First_Name == fName.Trim() && p.Last_Name == lName.Trim()
                                select p).Count();
            //Insert student into the student profile table 
            if (queryStudent < 1)
            {
                var student = new DAL.StudentProfile
                {
                    First_Name = fName,
                    Last_Name = lName
                };
            }
            var studentAttributes = (from p in db.StudentProfiles
                                     where p.First_Name == fName && p.Last_Name == lName
                                     select p).FirstOrDefault();

            
            
           
            ////////////////////////////////////////////////////////////
            //                Generate Excel Header                   //
            ////////////////////////////////////////////////////////////
            var excelAppGenerate = new Excel.Application();
            Excel.Workbook excelWorkbookGenerate = null;
            Excel.Worksheet excelWorksheetGenerate = null;
            Excel.Workbooks tmp2 = excelAppGenerate.Workbooks;
            // creating new WorkBook within Excel application

            excelWorkbookGenerate = tmp2.Add(Type.Missing);
            // see the excel sheet behind the program

            excelAppGenerate.Visible = true;



            // get the reference of first sheet. By default its name is Sheet1.

            // store its reference to worksheet

            excelWorksheetGenerate = excelWorkbookGenerate.Sheets["Sheet1"];

            excelWorksheetGenerate = excelWorkbookGenerate.ActiveSheet;

            excelWorksheetGenerate.Name = "Rejected Test Indicies";

            excelAppGenerate.DisplayAlerts = false;
            // changing the name of active sheet

          


            List<DAL.ReadingTestScores> headerInformation = new List<DAL.ReadingTestScores>();
          
            IHeader buildHeader = new GenerateExcelHeader();
            buildHeader.Create(1, 10, range, excelWorksheetGenerate);
            
            ///////////////////////////////////////////////////////////////////////////
            ////////       Check to see if test matches template                   ////
            ///////////////////////////////////////////////////////////////////////////
     

           // _excelApp.Visible = false;
            bgWorker.ReportProgress(1, "Processing Generating File of Rejected Data");
            GenerateExcelDocParseIndicies generateBody = new GenerateExcelBodyReject();
            generateBody.Create(11, indicies.Count, range, excelWorksheetGenerate, indicies, bgWorker);

            bgWorker.ReportProgress(75, "Saving File with Rejected Data");


            var fileName = fullname+"_Reject.xls";
            var fi = new FileInfo(@"C:\AssessmentXLSfiles\AssesmentAudit\RejectedAssessments\" + fileName);
            if (fi.Exists) File.Delete(@"C:\AssessmentXLSfiles\AssesmentAudit\RejectedAssessments\" + fileName);
            excelWorkbookGenerate.SaveAs(@"C:\AssessmentXLSfiles\AssesmentAudit\RejectedAssessments\" + fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            
     
            excelWorkbook.Close(0);
            excelApp.Application.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(tmp);
            Marshal.ReleaseComObject(excelWorksheet);
            Marshal.ReleaseComObject(excelWorkbook);
            Marshal.ReleaseComObject(excelApp);
         
           
    excelWorkbookGenerate.Close(0);
         excelAppGenerate.Quit();
         GC.Collect();
         GC.WaitForPendingFinalizers();    
             Marshal.ReleaseComObject(tmp2);
                  Marshal.ReleaseComObject(excelWorksheetGenerate);
             Marshal.ReleaseComObject(excelWorkbookGenerate) ;
              Marshal.ReleaseComObject(excelAppGenerate);

           //   System.Threading.Thread.Sleep(500);
            return indicies;
                }

            
        }

    public class RetainTestIndex : ParseAssessmentTest
    {
        public override List<EntireTestCollection> Open(string studentFile, List<EntireTestCollection> indicies, BackgroundWorker bgWorker)
        {
            if (indicies == null) throw new ArgumentNullException("indicies");
            var excelApp = new Excel.Application();
            var tmp = excelApp.Workbooks;
           
          
        
            // Open Excel spreadsheet.
            var excelWorkbook = tmp.Open(@studentFile, Type.Missing, true, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);


            excelApp.Visible = true;


            var activeworksheet = "Entry";
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[activeworksheet];
          excelWorksheet.Select(true);
           excelWorksheet.Unprotect();
          excelApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable; 
          excelApp.DisplayAlerts = false;
               
           var range = excelWorksheet.UsedRange;
        
         

           excelWorksheet.Cells[1, 1].EntireColumn.ColumnWidth = 15;
           excelWorksheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;
        
            string fName = Convert.ToString(((Excel.Range) range.Cells[7, 7]).Value2);
            string lName = Convert.ToString(((Excel.Range) range.Cells[8, 7]).Value2);

            string testDate = Convert.ToString(((Excel.Range) range.Cells[4, 4]).Value2);

          
            var fullname = fName + " " + lName;
            
            //Check to see if name exist in the student profile table
            var db = new DAL.ReadingDataEntities();

            /////////////////////////////////////////////////////////
            //           Check to see if student exist             //
            //        Otherwise and the student to the database    //
            /////////////////////////////////////////////////////////


            var queryStudent = (from p in db.StudentProfiles
                                where p.First_Name == fName.Trim() && p.Last_Name == lName.Trim()
                                select p).Count();
            //Insert student into the student profile table 
            if (queryStudent < 1)
            {
                var student = new DAL.StudentProfile
                {
                    First_Name = fName,
                    Last_Name = lName
                };
            }
            var studentAttributes = (from p in db.StudentProfiles
                                     where p.First_Name == fName && p.Last_Name == lName
                                     select p).FirstOrDefault();
           
           
            ////////////////////////////////////////////////////////////
            //                Generate Excel Header                   /
            ////////////////////////////////////////////////////////////
            var excelAppGenerate = new Excel.Application();
            Excel.Workbook excelWorkbookGenerate=null;
            Excel.Worksheet excelWorksheetGenerate = null;

            // creating new WorkBook within Excel application
            var tmp2 = excelAppGenerate.Workbooks;
            // creating new WorkBook within Excel application

            excelWorkbookGenerate = tmp2.Add(Type.Missing);
            // see the excel sheet behind the program

            excelAppGenerate.Visible = true;



            // get the reference of first sheet. By default its name is Sheet1.

            // store its reference to worksheet

            excelWorksheetGenerate = excelWorkbookGenerate.Sheets["Sheet1"];

            excelWorksheetGenerate = excelWorkbookGenerate.ActiveSheet;

            excelWorksheetGenerate.Name = "Accepted Test Indicies";

            excelAppGenerate.DisplayAlerts = false;

           
            List<DAL.ReadingTestScores> headerInformation = new List<DAL.ReadingTestScores>();
        
            IHeader buildHeader = new GenerateExcelHeader();
            buildHeader.Create(1, 10, range, excelWorksheetGenerate);

            ///////////////////////////////////////////////////////////////////////////
            ////////       Check to see if test matches template                   ////
            ///////////////////////////////////////////////////////////////////////////
            bgWorker.ReportProgress(1, "Processing Useable Data");
            ICollectIndices captureIndicies = new CollectAllIndicies();

   

          indicies = captureIndicies.Collect(range,bgWorker);
          // _excelApp.Visible = false;
            bgWorker.ReportProgress(1, "Processing Generating File of Good Data");
            GenerateExcelDocParseIndicies generateExcelDoc = new GenerateExcelBodyRetain();
         
            generateExcelDoc.Create(11, indicies.Count, range, excelWorksheetGenerate, indicies,bgWorker);
            bgWorker.ReportProgress(100, "Processed");

            var fileName = fullname + "_Keep.xls";
            bgWorker.ReportProgress(99, "Saving File of Good Data");
            var fi = new FileInfo(@"C:\AssessmentXLSfiles\AssesmentAudit\SavedAssessments\" + fileName);
            if (fi.Exists)
            {
                File.Delete(@"C:\AssessmentXLSfiles\AssesmentAudit\SavedAssessments\" + fileName);
            }
            excelWorkbookGenerate.SaveAs(@"C:\AssessmentXLSfiles\AssesmentAudit\SavedAssessments\" + fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            bgWorker.ReportProgress(100, "Saved");
          
           
           excelWorkbook.Close(0);
           excelApp.Application.Quit();
           GC.Collect();
         GC.WaitForPendingFinalizers();
             Marshal.ReleaseComObject(tmp);
            Marshal.ReleaseComObject(excelWorksheet);
             Marshal.ReleaseComObject(excelWorkbook);
             Marshal.ReleaseComObject(excelApp);
         



            excelWorkbookGenerate.Close(0);
            excelAppGenerate.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(tmp2);
            Marshal.ReleaseComObject(excelWorksheetGenerate);
            Marshal.ReleaseComObject(excelWorkbookGenerate);
            Marshal.ReleaseComObject(excelAppGenerate);

            System.Threading.Thread.Sleep(500);
       
         
            return indicies;
        }


    }


    public abstract class ProcessingAssessmentTest
    {
        public abstract List<TestAssessmentMeasurmentCollection> GetTestMeasures(string studentFile);
        public abstract List<TestAssessmentHeaderCollection> GetHeader(string studentFile);
    }

   
    public abstract class StoreAssessmentTest
    {
        public abstract void SaveData(List<TestAssessmentMeasurmentCollection> measures, List<TestAssessmentHeaderCollection> headerData);
    }


    public class AssessmentTestDataParser : ProcessingAssessmentTest
    {
        public override List<TestAssessmentMeasurmentCollection> GetTestMeasures(string studentFile)
        {
            // Open Excel Workbook.
            String filename = string.Empty;
          
            Excel.Application _excelApp = new Excel.Application();
            Excel.Workbook _excelWorkbook;
            Excel.Worksheet _excelWorksheet;          
            Excel.Workbooks tmp = _excelApp.Workbooks;

            _excelWorkbook = tmp.Open(@studentFile, Type.Missing, true, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);

            Excel.Range range;
        

            _excelApp.Visible = true;

            _excelApp.DisplayAlerts = false;
            //String activeworksheet = "Accepted Test Indicies";
            _excelWorksheet = (Excel.Worksheet)_excelWorkbook.Worksheets.get_Item(1);
            _excelWorksheet.Select(true);
            _excelWorksheet.Unprotect();
            _excelApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
            
           
            range = _excelWorksheet.UsedRange;

            _excelWorksheet.Cells[1, 1].EntireColumn.ColumnWidth = 15;
            _excelWorksheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;

       /*
        *Capture Student fullname from Excel file and then get their student number form the data store.
        * If student if no number is return then they does not exist therefore add the student fullname to the datastore.
        */

            String fullname="";
            fullname = Convert.ToString((range.Cells[2, 2] as Excel.Range).Value2);
            IStudentProfile GetStudentAttribute = new GetStudentID();
            int studentNumber=0;
            studentNumber=GetStudentAttribute.StudentID(fullname);

        /*Parse Student Assessment Data from Excel Open Excel Document*/

            IEnumerateExcelTestAssessmentData ProcessStudentAssessmentData = new AssessmentTestDataEnumerator();
            List<TestAssessmentMeasurmentCollection> testAttribute = new List<TestAssessmentMeasurmentCollection>();
         
          
          testAttribute =ProcessStudentAssessmentData.EnumerateAllTestData(studentNumber.ToString(), range);
      
     
            
            /*Close Excel Workbook*/

            _excelWorkbook.Close(0);
            _excelApp.Application.Quit(); 
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(tmp);
            Marshal.ReleaseComObject(_excelWorksheet);
            Marshal.ReleaseComObject(_excelWorkbook);
            Marshal.ReleaseComObject(_excelApp);

            return testAttribute;
    }
 public override List<TestAssessmentHeaderCollection>  GetHeader(string studentFile)
    {

        // Open Excel Workbook.
        var filename = string.Empty;

     var excelApp = new Excel.Application();
     var tmp = excelApp.Workbooks;

        var excelWorkbook = tmp.Open(@studentFile, Type.Missing, true, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);


     excelApp.Visible = true;

        excelApp.DisplayAlerts = false;
        //String activeworksheet = "Accepted Test Indicies";
        var excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.Item[1];
        excelWorksheet.Select(true);
        excelWorksheet.Unprotect();
        excelApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;


        var range = excelWorksheet.UsedRange;

        excelWorksheet.Cells[1, 1].EntireColumn.ColumnWidth = 15;
        excelWorksheet.Cells[1, 3].EntireColumn.ColumnWidth = 20;

        /*
         *Capture Student fullname from Excel file and then get their student number form the data store.
         * If student if no number is return then they does not exist therefore add the student fullname to the datastore.
         */

     

     List<TestAssessmentHeaderCollection> headerAttribute=null;
     IEnumerateExcelTestAssessmentData processStudentAssessmentData = new AssessmentTestDataEnumerator();
     headerAttribute = processStudentAssessmentData.EnumerateHeaderData(range);

     /*Close Excel Workbook*/

     excelWorkbook.Close(0);
     excelApp.Application.Quit();
     GC.Collect();
     GC.WaitForPendingFinalizers();
     Marshal.ReleaseComObject(tmp);
     Marshal.ReleaseComObject(excelWorksheet);
     Marshal.ReleaseComObject(excelWorkbook);
     Marshal.ReleaseComObject(excelApp);


        return headerAttribute;
    }

 }
}



