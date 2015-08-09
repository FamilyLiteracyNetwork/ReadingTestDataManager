using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Stored Test Values
    /// </summary>

    public class ReadingTestScores
    {

        private String _parentTestName = string.Empty;
        private String _testMethod = string.Empty;
        private String _rawScore = string.Empty;
        private String _standardScore1 = string.Empty;
        private String _standardScore2 = string.Empty;
        private String _standardScore3 = string.Empty;
        private String _tScore = string.Empty;
        private String _minRange = string.Empty;
        private String _maxRange = string.Empty;
        private String _corruptData = string.Empty;
        
        private String _umatchedTestIndex = string.Empty;
        public ReadingTestScores(Int32 _studentNo, Int32 _parentID, String _parentTestName, Int32 _subtestID, String _testMethod, String _rawScore, String _tScore, 
            String _standardScore1, String _standardScore2, String _standardScore3, Int32 _lRow,String _minRange,String _maxRange ,String _corruptData,String _umatchedTestIndex)
        {
            // TODO: Complete member initialization
            this.StudentNo = _studentNo;
            this.SubTestID = _subtestID;
            this.ParentTestID = _parentID;
            this.ParentTest = _parentTestName;
            this.TestMethod = _testMethod;
            this.StandardScore1 = _standardScore1;
            this.StandardScore2 = _standardScore2;
            this.StandardScore3 = _standardScore3;
            this.RawScore = _rawScore;
            this.tScore = _tScore;
            this.ExcelLastRowIndex = _lRow;
            this.BadDataPoint = _corruptData;
            this.LowerBound=_minRange;
            this.UpperBound=_maxRange;
            this.MatchingTestIndex = _umatchedTestIndex;

        }

        public Int32 StudentNo { get; set; }
        public Int32 ParentTestID { get; set; }
        public String ParentTest { get; set; }
        public Int32 SubTestID { get; set; }
        public String TestMethod { get; set; }
        public String StandardScore1 { get; set; }
        public String StandardScore2 { get; set; }
        public String StandardScore3 { get; set; }
        public String RawScore { get; set; }
        public String tScore { get; set; }
        public Int32 ExcelLastRowIndex { get; set; }
        public String BadDataPoint { get; set; }



        public string LowerBound { get; set; }

        public string UpperBound { get; set; }
     
        public string MatchingTestIndex { get; set; }
    }


    public class EntireTestCollection
    {

        private String _testMethod = string.Empty;
        private String _indexState=string.Empty;
        private String _testIndex = string.Empty;
        private String _datatype = string.Empty;
        private String _score = string.Empty;
        private String _lowerBound = string.Empty;
        private String _upperBound = string.Empty;
        private String _badValue = string.Empty;
        public EntireTestCollection(string _testMethod,string _testIndex, string _indexState,string _datatype,string _score,string _lowerBound,string _upperBound,string _badValue)
        {
            // TODO: Complete member initialization

            this.TestMethod = _testMethod;
            this.MatchingTestIndex = _testIndex;
            this.IndexStatus = _indexState;
            this.DataType = _datatype;
            this.Value = _score;
            this.MinRange = _lowerBound;
            this.MaxRange = _upperBound;
            this.CorruptData = _badValue;
        }

        public String TestMethod { get; set; }
        public String MatchingTestIndex { get; set; }
        public String IndexStatus { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public string MinRange { get; set; }

        public string MaxRange { get; set; }

        public string CorruptData { get; set; }
    }
}
