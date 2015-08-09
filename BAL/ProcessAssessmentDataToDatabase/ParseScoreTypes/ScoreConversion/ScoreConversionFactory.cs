using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreConversion
{
   public static class ScoreConversionFactory
    {
       public static Dictionary<String, String> GetConversion(string _scoreCatagory,string _scoreType, string _scoreValue)
       {
           Dictionary<String, String> ScoreAttributes = new Dictionary<string, string>();
           
       
           Assembly currentAssembly = Assembly.GetExecutingAssembly();
           var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == _scoreCatagory && t.Namespace == "ReadingTestScores.ProcessAssessmentDataToDatabase.ParseScoreTypes.ScoreConversion");

           IScoreConverter obj = (IScoreConverter)Activator.CreateInstance(currentType);
           MethodInfo method = currentType.GetMethod("Convert");
           object[] AssessmentValues = new object[] { _scoreType,_scoreValue };
           ScoreAttributes = (Dictionary<String, String>)method.Invoke(obj, AssessmentValues);

           return ScoreAttributes;
        
       }
    }

}
