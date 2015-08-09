using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using DAL;

namespace ReadingTestScores.ImportTestAssessments
{
     public interface ICollectIndices
    {
       List<EntireTestCollection> Collect(Microsoft.Office.Interop.Excel.Range range,BackgroundWorker bgWorker);
    }
     public interface IMatchingTestIndex
     {

         string Locate(string indexNo);
     }
    public class CollectAllIndicies : DetectCorruptData, ICollectIndices
    {
        public List<EntireTestCollection> Collect(Microsoft.Office.Interop.Excel.Range range, BackgroundWorker bgWorker)
        {
            List<EntireTestCollection> indicies = new List<EntireTestCollection>();
            String testMethod = string.Empty;
            IMatchingTestIndex locateTestIndex = new LocateTestIndex();
            Dictionary<string, string> badValue = new Dictionary<string, string>();

            for (var currentRow = 11; currentRow < 25144; currentRow++)
            {
                //Debug.Assert(currentRow != 25143);
                var corruptData = string.Empty;
                var minDataRange = String.Empty;
                var maxDataRange = String.Empty;
                string capturedIndex = (((Microsoft.Office.Interop.Excel.Range) range.Cells[currentRow, 1]).Text);

                ////  Check for last cell value  ////
                string testName;
                string scoreType;
                string score;
                //Check for last row and thenn insert last row flag of -1
                String indexfound;

                if (currentRow < 25143)
                {
                    if (capturedIndex != string.Empty && currentRow > 10)
                    {
                        testName = ((Microsoft.Office.Interop.Excel.Range) range.Cells[currentRow, 2]).Text;
                        scoreType = ((Microsoft.Office.Interop.Excel.Range) range.Cells[currentRow, 3]).Text;
                        score = ((Microsoft.Office.Interop.Excel.Range) range.Cells[currentRow, 4]).Text;
                        minDataRange = Convert.ToString(((Microsoft.Office.Interop.Excel.Range) range.Cells[currentRow, 8]).Text);
                        maxDataRange = Convert.ToString(((Microsoft.Office.Interop.Excel.Range) range.Cells[currentRow, 9]).Text);

                        indexfound = string.Empty;
                        indexfound = locateTestIndex.Locate(capturedIndex);
                        if ((indexfound == string.Empty) || (score == string.Empty) || (score == " "))
                        {
                            indexfound = "Extract_Index";

                        }
                        else
                        {
                            indexfound = "Retain_Index";
                        }

                        if (minDataRange != "" && maxDataRange != "") //Detect minimum and maximum score range exist
                        {
                            int intresult;
                            if (int.TryParse(score, out intresult) && int.TryParse(minDataRange, out intresult) &&
                                int.TryParse(maxDataRange, out intresult))
                            {
                                badValue = Evaluate(score, minDataRange, maxDataRange);
                                corruptData = badValue["faulty"];
                            }
                        }
                        indicies.Add(new EntireTestCollection(testName, capturedIndex, indexfound, scoreType, score,
                            minDataRange, maxDataRange, corruptData));

                    }
                }
                else
                {
                    capturedIndex = "-1";
                    testName = "Last Row";
                    scoreType = "Last Row";
                    score = "Last Row";
                    minDataRange = "Last Row";
                    maxDataRange = "Last Row";
                    indexfound = "Retain_Index";
                    indicies.Add(new EntireTestCollection(testName, capturedIndex, indexfound, scoreType, score,
                        minDataRange, maxDataRange, corruptData));
                }
                {
                    var progress = Convert.ToInt32(((double) currentRow/25132)*100);
                    if (progress <= 0)
                    {
                        progress = 1;
                    }
                    bgWorker.ReportProgress(progress, "Processing Indicies");
                    Thread.Sleep(1);
                }
            
            }
            return indicies;
        }
    }

    #region Data Range
public class DetectCorruptData
{
    public Dictionary<string,string> Evaluate(string value,string min, string max)
    {
        Dictionary<string, string> badValue = new Dictionary<string, string>();
        int dataPoint = Convert.ToInt16(value);
        int minValue = Convert.ToInt16(min);
        int maxValue = Convert.ToInt16(max);
        if (dataPoint<minValue)
        {

            badValue.Add("faulty", dataPoint.ToString());
        }
        else if (dataPoint>maxValue)
        {
            badValue.Add("faulty", dataPoint.ToString());

        }else
        {

            badValue.Add("faulty", string.Empty);
        }
            return badValue;
    }

}
# endregion

public class LocateTestIndex : IMatchingTestIndex
    {
       public String Locate(string indexNo)
        {

            String indexValue = string.Empty; 
           
            var indicies = from line in File.ReadAllLines(@"C:\AssessmentXLSfiles\AssesmentReferenceIndicies.txt")
                            where line == indexNo
                          select line;
          
              foreach(var index in indicies)
              {
                  indexValue = index;
                  
              }
              return indexValue;
        }
    }

}

