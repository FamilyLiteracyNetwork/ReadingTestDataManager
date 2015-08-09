using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;

namespace DAL
{


public class ExcelSections
{

}
    public abstract class GenerateExcelDocParseScores
    {
       
       public abstract void Create(int firstRow, int totalRecords, Excel.Range range, Excel.Worksheet xlswrkSheet, IList<ReadingTestScores> testScores,BackgroundWorker bgworker);

    }

    public abstract class GenerateExcelDocParseIndicies 
    {

        public abstract void Create(int firstRow, int totalRecords, Excel.Range range, Excel.Worksheet xlswrkSheet, IList<EntireTestCollection> testindex,BackgroundWorker bgworker);

    }

    public interface IHeader
    {
        void Create(int firstRow, int totalRecords, Excel.Range range, Excel.Worksheet xlswrkSheet);

    }


    public class GenerateExcelHeader : GenerateHeader,IHeader
    {
        public void Create(int firstRow, int totalRecords, Excel.Range range, Excel.Worksheet xlswrkSheet)
         {
      

            List<ExcelHeaderInfo> headerBlockData = null;
            headerBlockData = Header(range);

          
            int rCnt = 0;
          

    //Create and format Header

           xlswrkSheet.Cells[1, 1] = "item#";
           xlswrkSheet.Cells[1, 2] = "Description";
           xlswrkSheet.Cells[1, 3] = "Score Type";

           xlswrkSheet.Cells[1, 4] = "Value";
           xlswrkSheet.Cells[1, 5] = "Min";
           xlswrkSheet.Cells[1, 6] = "Max";
           xlswrkSheet.Cells[1, 7] = "Faulty Data";
    
          xlswrkSheet.Cells[1, 1].EntireColumn.ColumnWidth = "20";
           xlswrkSheet.Cells[1, 2].EntireColumn.ColumnWidth = "60";
           xlswrkSheet.Cells[1, 3].EntireColumn.ColumnWidth = "10";
           xlswrkSheet.Cells[1, 4].EntireColumn.ColumnWidth = "10";
           xlswrkSheet.Cells[1, 7].EntireColumn.ColumnWidth = "15";

           range = xlswrkSheet.Range["A1", "G1"];
            range.Interior.Color = System.Drawing.Color.LightBlue;

          // Store each row and column value to excel sheet



            xlswrkSheet.Cells[2, 2] = headerBlockData[3].Name + " " + headerBlockData[4].Name;
            range = xlswrkSheet.Range["A2", "G2"];
              range.Interior.Color = System.Drawing.Color.Yellow;
              xlswrkSheet.Cells[2, 2].EntireRow.Font.Bold = true;   
              int startColor = 3;
              int startindex = 0;
              for (rCnt = firstRow+2; rCnt < 9; rCnt++)
            {


                xlswrkSheet.Cells[rCnt, 1] = headerBlockData[startindex].IndexNo;

                xlswrkSheet.Cells[rCnt, 2] = headerBlockData[startindex].Description;

                xlswrkSheet.Cells[rCnt, 3] = string.Empty;

                xlswrkSheet.Cells[rCnt, 4] = headerBlockData[startindex].AssessedDate;

                xlswrkSheet.Cells[rCnt, 5] = String.Empty;

                xlswrkSheet.Cells[rCnt, 6] = string.Empty;

                xlswrkSheet.Cells[rCnt, 7] = string.Empty;
              
                    String strtCell = "A" + startColor.ToString();
                    String endCell = "G" + startColor.ToString();

                    range = xlswrkSheet.Range[strtCell, endCell];
                    range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                     startColor++;
                     startindex++;
            }
              Excel.Borders border = xlswrkSheet.Cells.Borders;
              border.LineStyle = Excel.XlLineStyle.xlContinuous;
              border.Weight = 2d;
              xlswrkSheet.Range["B1", "B1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
              xlswrkSheet.Range["C1", "G1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
             
     

        return;
         }
    }


    public class GenerateBody :GenerateExcelDocParseScores
   {
        public override void Create(int firstRow, int totalRecords, Excel.Range range, Excel.Worksheet xlswrkSheet, IList<ReadingTestScores> testScores,BackgroundWorker bgworker)
         {

            
                 int rCnt = 0;
                 

                 //Create Parent title Row
                 xlswrkSheet.Cells[firstRow, 1] = Convert.ToString(testScores[0].ParentTestID);
                 (xlswrkSheet.Cells[firstRow, 1]).Interior.Color = System.Drawing.Color.Pink;
                 xlswrkSheet.Cells[firstRow, 2] = testScores[0].ParentTest;
                 (xlswrkSheet.Cells[firstRow, 2]).Interior.Color = System.Drawing.Color.Pink;
                 xlswrkSheet.Cells[firstRow, 3] = string.Empty;
                 (xlswrkSheet.Cells[firstRow, 3]).Interior.Color = System.Drawing.Color.Pink;
                 xlswrkSheet.Cells[firstRow, 4] = string.Empty;
                 (xlswrkSheet.Cells[firstRow, 4]).Interior.Color = System.Drawing.Color.Pink;
                 xlswrkSheet.Cells[firstRow, 5] = string.Empty;
                 (xlswrkSheet.Cells[firstRow, 5]).Interior.Color = System.Drawing.Color.Pink;
                 xlswrkSheet.Cells[firstRow, 6] = string.Empty;
                 (xlswrkSheet.Cells[firstRow, 6]).Interior.Color = System.Drawing.Color.Pink;
                 xlswrkSheet.Cells[firstRow, 7] = string.Empty;
                 (xlswrkSheet.Cells[firstRow, 7]).Interior.Color = System.Drawing.Color.Pink;

                 if (testScores[0].TestMethod!="NoTest")
                 {

                 // Store each row and column value to excel sheet
                     Int32 percentageComplete = 1;
                     bgworker.ReportProgress(percentageComplete);
                     System.Threading.Thread.Sleep(1);
                 var value = 0;
                 var lastRow = 0;
                 lastRow = firstRow + totalRecords;
                 for (rCnt = firstRow + 1; rCnt < lastRow; rCnt++)
                 {


                     xlswrkSheet.Cells[rCnt, 1] = testScores[value].SubTestID;
                     xlswrkSheet.Cells[rCnt, 2] = testScores[value].TestMethod;
                     if (testScores[value].StandardScore1 != string.Empty)
                     {
                         xlswrkSheet.Cells[rCnt, 3] = "SS";
                        xlswrkSheet.Cells[rCnt, 4] = testScores[value].StandardScore1;
                     }
                     else if (testScores[value].RawScore != string.Empty)
                     {
                         xlswrkSheet.Cells[rCnt, 3] = "RS";
                         xlswrkSheet.Cells[rCnt, 4] = testScores[value].RawScore;
                     }
                     else if (testScores[value].tScore != string.Empty)
                     {
                         xlswrkSheet.Cells[rCnt, 3] = "t";
                         xlswrkSheet.Cells[rCnt, 4] = testScores[value].tScore;
                     }
                     else if (testScores[value].StandardScore2 != string.Empty)
                     {
                         xlswrkSheet.Cells[rCnt, 3] = "[SS]";
                         xlswrkSheet.Cells[rCnt, 4] = testScores[value].StandardScore2;
                     }
                     else if (testScores[value].StandardScore3 != string.Empty)
                     {
                         xlswrkSheet.Cells[rCnt, 3] = "(ss)";
                         xlswrkSheet.Cells[rCnt, 4] = testScores[value].StandardScore3;
                     }



                     xlswrkSheet.Cells[rCnt, 5] = testScores[value].LowerBound;
                     xlswrkSheet.Cells[rCnt, 6] = testScores[value].UpperBound;
                     String outofRange = Convert.ToString(testScores[value].BadDataPoint);
                     if (outofRange != string.Empty)
                     {
                         xlswrkSheet.Cells[rCnt, 7] = outofRange;
                         (xlswrkSheet.Cells[rCnt, 7]).Interior.Color = System.Drawing.Color.Red;
                     }else
                     {
                         (xlswrkSheet.Cells[rCnt, 7]).Interior.Color = System.Drawing.Color.White;
                     }

                     value++;
                     percentageComplete = percentageComplete > 0 ? Convert.ToInt32(value: ((double)rCnt + 1 / lastRow) * 100) : 1;
                   
                     bgworker.ReportProgress(percentageComplete,"Generating Excel Document");
                     System.Threading.Thread.Sleep(1);
                 }

         


             }
        return;

         }
   }



    public class GenerateExcelBodyReject :GenerateExcelDocParseIndicies
    {
        public override void Create(int firstRow, int totalRecords, Excel.Range range, Excel.Worksheet xlswrkSheet, IList<EntireTestCollection> testindex,BackgroundWorker bgworker)
        {

            var extract = from p in testindex.ToList()
                          where p.IndexStatus == "Extract_Index"
                          select p;
            int rCnt = firstRow;

                // Store each row and column value to excel sheet
            Int32 percentageComplete = 1;
            bgworker.ReportProgress(percentageComplete);
            System.Threading.Thread.Sleep(1);
                int lastRow = 0;
                lastRow = firstRow + totalRecords;
               
                    foreach (var test in extract)
                    {
                        if (test.MatchingTestIndex != string.Empty)
                        {
                            if (rCnt < lastRow)
                            {
                                xlswrkSheet.Cells[rCnt, 1] = test.MatchingTestIndex;
                                xlswrkSheet.Cells[rCnt, 2] = test.TestMethod;
                                xlswrkSheet.Cells[rCnt, 3] = test.DataType;
                                xlswrkSheet.Cells[rCnt, 4] = test.Value;
                                xlswrkSheet.Cells[rCnt, 5] = test.MinRange;
                                xlswrkSheet.Cells[rCnt, 6] = test.MaxRange;
                                if (test.CorruptData!=string.Empty)
                                {
                                    xlswrkSheet.Cells[rCnt, 7] = test.CorruptData;
                                    (xlswrkSheet.Cells[rCnt, 7]).Interior.Color = System.Drawing.Color.Red;
                                }
                                rCnt++;
                                Marshal.FinalReleaseComObject(xlswrkSheet.Cells);
                            }
                           
                        }
                        if (percentageComplete > 0)
                        {
                            percentageComplete = Convert.ToInt32(((double)rCnt / lastRow) * 100);
                        }
                        else
                        {
                            percentageComplete = 1;

                        }
                      
                        bgworker.ReportProgress(percentageComplete, "Generating Excel Document");
                        System.Threading.Thread.Sleep(1);
                     }

          
          
            return;

        }
    }
    public class GenerateExcelBodyRetain : GenerateExcelDocParseIndicies
    {
        public override void Create(int firstRow, int totalRecords, Excel.Range range, Excel.Worksheet xlswrkSheet, IList<EntireTestCollection> testindex,BackgroundWorker bgworker)
        {
            var percentageComplete = 1;
            bgworker.ReportProgress(percentageComplete);
            System.Threading.Thread.Sleep(1);

            var extract = from p in testindex.ToList()
                          where p.IndexStatus == "Retain_Index"
                          select p;
            int rCnt = firstRow;

            // Store each row and column value to excel sheet
            var lastRow = 0;
            lastRow = firstRow + totalRecords;

            foreach (var test in extract)
            {
               
                if (test.MatchingTestIndex != string.Empty)
                {
                    //Check for last row
                 
                     xlswrkSheet.Cells[rCnt, 1] = test.MatchingTestIndex;
                    xlswrkSheet.Cells[rCnt, 2] = test.TestMethod;
                    xlswrkSheet.Cells[rCnt, 3] = test.DataType;
                    xlswrkSheet.Cells[rCnt, 4] = test.Value;
                    xlswrkSheet.Cells[rCnt, 5] = test.MinRange;
                    xlswrkSheet.Cells[rCnt, 6] = test.MaxRange;
                    if (test.CorruptData != string.Empty)
                    {
                        xlswrkSheet.Cells[rCnt, 7] = test.CorruptData;
                        (xlswrkSheet.Cells[rCnt, 7]).Interior.Color = System.Drawing.Color.Red;
                    }
                    rCnt++;

                    percentageComplete = percentageComplete > 0 ? Convert.ToInt32(((double)rCnt / lastRow) * 100) : 1;
                    bgworker.ReportProgress(percentageComplete, "Generating Excel Document");
                    System.Threading.Thread.Sleep(1);
                }

               
                
            }


            Marshal.FinalReleaseComObject(xlswrkSheet.Cells);

            return;

        }
    }
    public class GenerateHeader 
    {
     
        private string _indexNo = string.Empty;
        private string _description = string.Empty;
        private string _value = string.Empty;
        private string _enter = string.Empty;
        public  List<ExcelHeaderInfo> Header(Excel.Range excelRange)
        {
            List <ExcelHeaderInfo> headerData=new List <ExcelHeaderInfo>();
            for(int rCnt=4; rCnt < 10; rCnt++)
            {
                _indexNo = Convert.ToString(((Excel.Range) excelRange.Cells[rCnt, 1]).Text);
                _description = Convert.ToString(((Excel.Range) excelRange.Cells[rCnt, 2]).Text);
                _value = Convert.ToString(((Excel.Range) excelRange.Cells[rCnt, 4]).Text);
                _enter = Convert.ToString(((Excel.Range) excelRange.Cells[rCnt, 7]).Text);
                headerData.Add(new ExcelHeaderInfo(_indexNo,_description,_value,_enter));
                Marshal.FinalReleaseComObject(excelRange.Cells);
            }
            Marshal.FinalReleaseComObject(excelRange.Cells);
            return headerData;
        }
    }

    public class ExcelHeaderInfo
    {
        private String _index=string.Empty;
        private String _description = string.Empty;
        private String _dateAssessed = string.Empty;
        private String _studentname = string.Empty;
        public ExcelHeaderInfo(string index, string description, string dateAssessed, string studentname)
        {
            this.IndexNo = index;
            this.Description = description;
            this.AssessedDate = dateAssessed;
             this.Name=studentname;
        }

      public string IndexNo { get; set; }

      public string Description { get; set; }
    
      public string Name { get; set; }

      public string AssessedDate { get; set; }
    }
}
