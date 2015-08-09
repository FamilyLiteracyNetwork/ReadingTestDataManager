using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTestScores.StudentProfile
{
  public  interface IStudentProfile
    {
      Int32 StudentID(string fullName);
    }
}
