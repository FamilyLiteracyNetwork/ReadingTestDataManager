using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using BAL;
using ReadingTestScores.ProcessAssessmentDataToDatabase;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
using ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData.Save;
namespace ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData
{
    public abstract class StoreAssessmentTest
    {
        public abstract void SaveData(List<TestAssessmentMeasurmentCollection> measures, List<TestAssessmentHeaderCollection> headerData);
    }
    public class StoreAssessmentTestDataFactory : StoreAssessmentTest
    {
 
      public override void SaveData(List<TestAssessmentMeasurmentCollection> measures,List<TestAssessmentHeaderCollection > headerData)
      {
          Assembly currentAssembly = Assembly.GetExecutingAssembly();
              IEnumerable currentType = currentAssembly.GetTypes().Where(t => t.Namespace == "ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData.Save");
       
              foreach (Type p in currentType)
              {
                  ISaveTest obj = (ISaveTest)Activator.CreateInstance(p);
                  MethodInfo method = p.GetMethod("Save");
                  object[] assessmentCollectionParameters = new object[] { measures, headerData };
                  method.Invoke(obj, assessmentCollectionParameters);
                
              }
              return;
      }
    }
}
