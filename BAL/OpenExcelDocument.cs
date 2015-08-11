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

    public class AssessmentTestDataParser : ProcessingAssessmentTest
    {
        public override List<TestAssessmentMeasurmentCollection> GetTestMeasures(string studentFile)
        {
            // Open Excel Workbook.
            String filename = string.Empty;
          
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbooks tmp = excelApp.Workbooks;

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

            String fullname="";
            var range1 = range.Cells[2, 2] as Excel.Range;
            if (range1 != null)
                fullname = Convert.ToString(range1.Value2);
            IStudentProfile getStudentAttribute = new GetStudentID();
            int studentNumber=0;
            studentNumber=getStudentAttribute.StudentID(fullname);

        /*Parse Student Assessment Data from Excel Open Excel Document*/

            IEnumerateExcelTestAssessmentData processStudentAssessmentData = new AssessmentTestDataEnumerator();


            var testAttribute = processStudentAssessmentData.EnumerateAllTestData(studentNumber.ToString(), range);
      
     
            
            /*Close Excel Workbook*/

            excelWorkbook.Close(0);
            excelApp.Application.Quit(); 
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(tmp);
            Marshal.ReleaseComObject(excelWorksheet);
            Marshal.ReleaseComObject(excelWorkbook);
            Marshal.ReleaseComObject(excelApp);

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



