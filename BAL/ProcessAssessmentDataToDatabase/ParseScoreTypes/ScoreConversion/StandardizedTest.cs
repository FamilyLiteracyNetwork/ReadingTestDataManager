using ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreConversion
{
    class StandardizedTest : StandardScoreConversions,IScoreConverter
    {
        public Dictionary<String, String> Convert(string scoretype, string _scoreValue)
        {
            String convertScore = string.Empty;
            Dictionary<String, String> FilteredScore = new Dictionary<String, String>();

            if (scoretype == "(ss)")
            {
                convertScore = ConvertStandardScore(_scoreValue);
            }else
            {
                convertScore = _scoreValue;
            }
            FilteredScore.Add("Primary_Score", convertScore);
            FilteredScore.Add("Secondary_Score", "");
           

            return FilteredScore;
        }
    }
}
