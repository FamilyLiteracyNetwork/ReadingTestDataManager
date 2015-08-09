using ReadingTestScores.ProcessAssessmentDataToDatabase.TestCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreTestCatagoryFilter
{
    public class ScoreTestCatagoryScanner : ScoreLabelFilter, IGetScoreTestCatagory
    {
        public Dictionary<String, String> GetTestCatagory(string _scoreLabel)
     {
         Dictionary<String, String> ScoreTypes = new Dictionary<string, string>();
         String scoreTestCatagory = string.Empty;


        
         _scoreLabel=Filter(_scoreLabel);

         // Determine the Test Catagory of the test score 
        var testCatagory = (from q in TestCatagoryCollection.ScoreCatagoryTable.ToList()
                              where q.testLabel == _scoreLabel
                              select q).FirstOrDefault();
       
         if (testCatagory!=null)
         {
        scoreTestCatagory = Convert.ToString(testCatagory.catagory);
       
         }
         ScoreTypes.Add("Score_Test_Catagory", scoreTestCatagory);
         ScoreTypes.Add("Score_Label_Parsed", _scoreLabel);
        
         return ScoreTypes;
     }

 }

}