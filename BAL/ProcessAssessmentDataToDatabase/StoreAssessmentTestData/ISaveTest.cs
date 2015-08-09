using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
namespace ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData
{
  public interface  ISaveTest
    {
      void Save(List<TestAssessmentMeasurmentCollection> testMeasures, List<TestAssessmentHeaderCollection> headerData);
    }
}
