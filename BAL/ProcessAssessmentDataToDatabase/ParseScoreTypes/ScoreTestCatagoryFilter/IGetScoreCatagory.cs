using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreTestCatagoryFilter
{
    interface IGetScoreTestCatagory
    {
        Dictionary<String, String> GetTestCatagory(string _scoreLabel);
    }
}
