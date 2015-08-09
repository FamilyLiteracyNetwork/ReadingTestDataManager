using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace ReadingTestScores.StudentProfile
{
    class GetStudentID: IStudentProfile
    {
       public Int32 StudentID(string fullName)
        {
        string fName, lName;
          string[] _divideStudentName = new String[2];
            _divideStudentName = fullName.Split(' ');
            fName = _divideStudentName[0];
            lName = _divideStudentName[1];

            /////////////////////////////////////////////////////////
            //           Check to see if student exist             //
            //        Otherwise and the student to the database    //
            /////////////////////////////////////////////////////////


            DAL.ReadingDataEntities db = new DAL.ReadingDataEntities();

            var studentAttributes = (from p in db.StudentProfiles
                                     where p.First_Name == fName && p.Last_Name == lName
                                     select p).FirstOrDefault();

            return studentAttributes.StudentID;
        }
    }
}
