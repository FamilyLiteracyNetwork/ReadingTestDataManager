using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase
{
    public class TestAssessmentMeasurmentCollection 
    {
       private string _testScore1=string.Empty;
       private string _testScore2 = string.Empty;
       private string _scoreType=string.Empty;
       private string _parsedScoreType = string.Empty;
       private string _testName = string.Empty;
       private string _testCatagory = string.Empty;

       public TestAssessmentMeasurmentCollection(string _studentNo,string _testName, string _testIndex, string _testscore1, string _testscore2, string _scoreType, string _parsedScoreType, string _testCatagory)
        {
            StudentID = _studentNo;
            PrimaryScore = _testscore1;
            SecondaryScore = _testscore2;
            ScoreType = _scoreType;
            ParsedScoreType = _parsedScoreType;
            TestCatagory = _testCatagory;
            TestName = _testName;
            TestIndex = _testIndex;
           
        }

        public String StudentID { get; set; }
        public String TestIndex { get; set; }
        public String TestCatagory { get; set; }
        public String TestName { get; set; }
        public String ScoreType { get; set; }
        public String ParsedScoreType { get; set; }
        public String PrimaryScore { get; set; }
        public String SecondaryScore { get; set; }



        
    }

    public class TestAssessmentHeaderCollection 
    {

      public  TestAssessmentHeaderCollection(string _studentNo,string _dateOfBirth,string _assesssmentDate,string _assessmentAge)
        {
            StudentID = _studentNo;
            Date_Of_Birth= _dateOfBirth;
            AssessmentDate = _assesssmentDate;
            AssessmentAge = _assessmentAge;
        }

        public String StudentID { get; set; }

        public String Date_Of_Birth { get; set; }

        public String AssessmentDate { get; set; }

        public String AssessmentAge { get; set; }
    }

  
}
