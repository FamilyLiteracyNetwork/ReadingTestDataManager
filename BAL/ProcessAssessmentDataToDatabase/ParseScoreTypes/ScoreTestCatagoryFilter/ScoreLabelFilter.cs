using ReadingTestScores.ProcessAssessmentDataToDatabase.TestCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreTestCatagoryFilter
{
    public class ScoreLabelFilter
    {
        public String Filter(string _scoreLabel)
        {
            //Parse any captured label into SS,RS,Txt etc. that is not a standard SS,RS,Txt etc.

            TestCatagoryCollection convertStandardScore = new TestCatagoryCollection();
            String[] labelPart = { "SS", "ss", "RS", "Txt", "rs", "txt", "(ss)", "[SS]", "(SS)" }; //various possible score label format types

            var part = (from q in labelPart
                        where _scoreLabel.Contains(q) == true
                        select q).FirstOrDefault();

            if (part != null)
            {
                _scoreLabel = part.ToString();
            }

            return _scoreLabel;

        }

    }
}
