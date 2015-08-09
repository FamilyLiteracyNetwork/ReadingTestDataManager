using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreConversion
{
   public class StandardScoreConversions
    {
       public String ConvertStandardScore(string ssScore)
       {
           String standardScore = string.Empty;
           StandardScoreLookupTable convertStandardScore = new StandardScoreLookupTable();

         
           /////////////////////////////////////////
           //Convert (ss) Score to Standard Score///
           /////////////////////////////////////////
             var convertedValue = (from q in StandardScoreLookupTable.StandardScoreTable.ToList()
             where q._ss == ssScore
            select q).FirstOrDefault();

            standardScore = Convert.ToString(convertedValue.SS);

           return standardScore;
       }
    }
}
