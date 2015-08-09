using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class StandardizedTest
    {
      public abstract void Score(String studentID,String _score,String _date);
    }

    class RawScore : StandardizedTest
    {

        public override void Score(String studentID, String _score, String _date)
        {
            return;
        }
    }


   class StandardScore : StandardizedTest
    {

       public override void Score(String studentID, String _score, String _date)
        {
            return;
        }
    }


// public class StandardAssessment
  //  {
     // public static StandardizedTest SaveTest(String _testScores)
     //   {
        
     //   Assembly currentAssembly = Assembly.GetExecutingAssembly();
       // var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == _testScores);
       // return (StandardizedTest)Activator.CreateInstance(currentType);
   //     }
 //   }
}
