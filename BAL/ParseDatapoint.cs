using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public interface IFormatTestAttributes
    {
        string Format(string dataPoint);
    }

    public class FormatScoreType : IFormatTestAttributes
    {
        public  string Format(string dataPoint)
        {
            string _point = dataPoint;
   
             if (dataPoint.Contains("-"))
             {
                 _point = dataPoint.Remove(2);
             }
            if (dataPoint.Contains("["))
             {

             }
            if (dataPoint.Contains("]"))
             {

             }
            if (dataPoint.Contains("("))
             {

             }
             if (dataPoint.Contains(")"))
             {

             }
          
            return _point;
        }
    }


    public class FormatScore:IFormatTestAttributes
    {
        public String Format(string dataPoint)
        {
            string _point = dataPoint;
            return _point;
        }

    }
}
