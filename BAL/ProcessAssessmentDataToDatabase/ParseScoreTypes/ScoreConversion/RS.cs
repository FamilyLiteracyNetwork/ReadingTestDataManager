﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreTypes
{
    class RS : IScoreFilter
    {
        public Dictionary<String, String> Conversion(string scoretype, string _scoreValue)
        {
            Dictionary<String, String> FilteredScore = new Dictionary<String, String>();
            FilteredScore.Add("Primary_Score", _scoreValue);
            FilteredScore.Add("Secondary_Score", "");
            
            return FilteredScore;
        }
    }
}