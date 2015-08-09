
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using DAL;
using BAL;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
using ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreConversion;
using ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreTestCatagoryFilter;
using ReadingTestScores.ProcessAssessmentDataToDatabase.TestCollections;
using ReadingTestScores.StudentProfile;
namespace ReadingTestScores.ProcessAssessmentDataToDatabase
{
    public interface IEnumerateExcelTestAssessmentData
    {
        List<TestAssessmentMeasurmentCollection> EnumerateAllTestData(String studentNo, Excel.Range range);
        List<TestAssessmentHeaderCollection>EnumerateHeaderData(Excel.Range range);
    }


    public class AssessmentTestDataEnumerator : IEnumerateExcelTestAssessmentData
    {

    public List<TestAssessmentMeasurmentCollection> EnumerateAllTestData(String studentNo, Excel.Range range)
        {
            List<TestAssessmentMeasurmentCollection> testParameters = new List<TestAssessmentMeasurmentCollection>();




        string score2;
        score2 = string.Empty;

        var testIndexNo = 0;
        for (var rowCnt = 11; rowCnt <= 22306 && testIndexNo >= 0; rowCnt++)
            {
                testIndexNo  = Convert.ToInt32(((Excel.Range) range.Cells[rowCnt, 1]).Value2);
                string testName = ((Excel.Range) range.Cells[rowCnt, 2]).Value2;
                string testDate = Convert.ToString(((Excel.Range) range.Cells[4, 4]).Value2);
                string scoreType = (((Excel.Range) range.Cells[rowCnt, 3]).Text);
                 string score1 = Convert.ToString(((Excel.Range) range.Cells[rowCnt, 4]).Text);
                 score2 = Convert.ToString(((Excel.Range) range.Cells[rowCnt, 5]).Text);
            
                // convert the extracted score type into a unique test catagory name 

                
              
               if (scoreType!=null && scoreType!="")
                {
                    IGetScoreTestCatagory testCatagory = new ScoreTestCatagoryScanner();
                    var scoreCatagory = testCatagory.GetTestCatagory(scoreType);
                    var scoreTypeCatagory=scoreCatagory["Score_Test_Catagory"];
                    var filteredScoreType=scoreCatagory["Score_Label_Parsed"];

                var filteredScore = ScoreConversionFactory.GetConversion(scoreTypeCatagory,scoreType.Trim(), score1);
                 
                  score1 = filteredScore["Primary_Score"];
                  score2 = filteredScore["Secondary_Score"];
                  testParameters.Add(new TestAssessmentMeasurmentCollection(studentNo,testName, testIndexNo.ToString(), score1, score2, scoreType, filteredScoreType, scoreTypeCatagory));
                
                 
                }
            }


            return testParameters;
      
        }

    public List<TestAssessmentHeaderCollection> EnumerateHeaderData(Excel.Range range)
    {
        var headerData = new List<TestAssessmentHeaderCollection>();
        String fullname = "";
        fullname = Convert.ToString(((Excel.Range) range.Cells[2, 2]).Value2);
        string dob = Convert.ToString(((Excel.Range) range.Cells[3, 3]).Value2);
        string assessmentdate = Convert.ToString(((Excel.Range) range.Cells[4, 3]).Value2);
        string assesssmentAge = Convert.ToString(((Excel.Range) range.Cells[5, 3]).Value2);
        IStudentProfile getStudentAttribute = new GetStudentID();
        var studentNumber = 0;
        studentNumber = getStudentAttribute.StudentID(fullname);
        headerData.Add(new TestAssessmentHeaderCollection(studentNumber.ToString(), dob, assessmentdate, assesssmentAge));
        return headerData;
    }
    }
}
