using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingTestScores.TestCollections.ProcessAssessmentDataToDatabase;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace ReadingTestScores.ProcessAssessmentDataToDatabase.StoreAssessmentTestData.Save
{
    class TextTest:ISaveTest
    {
        public void Save(List<TestAssessmentMeasurmentCollection> testMeasures, List<TestAssessmentHeaderCollection> headerData)
        {
            var TextTestAttributes = from p in testMeasures
                        where p.TestCatagory == "TextTest"
                        select p;


        var connectionString = ConfigurationManager.ConnectionStrings["Familyliteracy"].ConnectionString;

       
       SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd  = new SqlCommand();

       cmd.Connection = conn;
       cmd.CommandType = CommandType.StoredProcedure;
     
       foreach (var attribute in TextTestAttributes)
       {
           cmd.CommandText = "sp_TextTest";
           cmd.Parameters.AddWithValue("@Score1", attribute.PrimaryScore);
            cmd.Parameters.AddWithValue("@Score2", attribute.SecondaryScore);
       }
       }
        }
    }

