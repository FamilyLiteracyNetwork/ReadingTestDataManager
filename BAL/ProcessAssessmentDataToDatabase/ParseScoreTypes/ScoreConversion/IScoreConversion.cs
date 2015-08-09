using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes;
namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreConversion
{

  public interface IScoreConverter
    {
      Dictionary<String, String> Convert(string scoretype, string _scoreValue);
    }

}
