using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
namespace ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData.Save
{
    public class StandardizedTest:ISaveTest
    {
       public  void Save(List<TestAssessmentMeasurmentCollection> testMeasures, List<TestAssessmentHeaderCollection> headerData)
       {
           String StudentId, testCatagory, dob, dateOfAssessment, index, testTitle, score1, score2;
           //Capture Information
           var StandardizedTestAttributes = from measures in testMeasures
                        where measures.TestCatagory == "StandardizedTest"
                        join header in headerData on measures.StudentID equals header.StudentID
                        select new { header.StudentID, measures.TestCatagory, header.Date_Of_Birth, header.AssessmentDate, measures.TestIndex, measures.TestName, measures.PrimaryScore, measures.ScoreType, measures.ParsedScoreType, measures.SecondaryScore };

     //   var connectionString = ConfigurationManager.ConnectionStrings["Familyliteracy"].ConnectionString;

       
      /* SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd  = new SqlCommand();

       cmd.Connection = conn;
       cmd.CommandType = CommandType.StoredProcedure; */
     
       foreach (var attribute in StandardizedTestAttributes)
       {
           StudentId = attribute.StudentID;
           testCatagory = attribute.TestCatagory;
           dob = attribute.Date_Of_Birth;
           dateOfAssessment = attribute.AssessmentDate;
           index = attribute.TestIndex;
           score1 = attribute.PrimaryScore;
           score2 = attribute.SecondaryScore;
           testTitle = attribute.TestName;

         //  cmd.CommandText = "sp_StandardizedTest_Insert";
          // cmd.Parameters.AddWithValue("@MeasuredScore", attribute.PrimaryScore);
          // cmd.Parameters.AddWithValue("@ScoreType", attribute.ScoreType);
       }
       }
    }

   
}
