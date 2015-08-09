using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.ProcessAssessmentDataToDatabase.TestCollections
{
   public  class TestCatagoryCollection
    {
        public String testLabel { get; set; }
       
        public String catagory { get; set; }
       

        public static List<TestCatagoryCollection> ScoreCatagoryTable = new List<TestCatagoryCollection>
            {
     new TestCatagoryCollection() {testLabel = "SS", catagory = "StandardizedTest"},
    new TestCatagoryCollection() {testLabel = "RS", catagory = "StandardizedTest"},
    new TestCatagoryCollection() {testLabel = "rs", catagory = "StandardizedTest"},
    new TestCatagoryCollection() {testLabel = "Txt", catagory = "TextTest"},
     new TestCatagoryCollection() {testLabel = "txt", catagory = "TextTest"},
     new TestCatagoryCollection() {testLabel = "[SS]", catagory = "StandardizedTest"},
     new TestCatagoryCollection() {testLabel = "(SS)", catagory = "StandardizedTest"},
      new TestCatagoryCollection() {testLabel = "(ss)", catagory = "StandardizedTest"},
      new TestCatagoryCollection() {testLabel = "ss", catagory = "StandardizedTest"}
            };
    }
}
