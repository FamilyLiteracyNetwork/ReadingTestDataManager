using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{

    public class StandardScoreLookupTable
    {

        //public int SS;
        //public double t;
        //public string _ss;
        //double percentile=0.00;
        public int SS { get; set; }
        public string _ss { get; set; }
        public double percentile { get; set; }
        public double t { get; set; }
    

       
    ///////////////////////////////////////////////////////////////////////
    ////                  Standard Score Lookup table                   ///
    ////                         SS range 1-100                         ///             
    ////                   Value types are SS,(ss),%,T                  ///
    ///////////////////////////////////////////////////////////////////////
        public static List<StandardScoreLookupTable> StandardScoreTable = new List<StandardScoreLookupTable>
            {
     new StandardScoreLookupTable() {SS = 1, _ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable () {SS = 2, _ss="" ,percentile = 0.01,t=1.0},  
     new StandardScoreLookupTable(){SS = 3,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 4, _ss="" ,percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 5, _ss="" ,percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 6,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 7, _ss="" ,percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 8,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 9, _ss="" ,percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 10,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 11,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 12,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 13,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 14,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 15,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 16,_ss="" , percentile = 0.01,t=1.0}, 
     new StandardScoreLookupTable(){SS = 17, _ss="" ,percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 18,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 19,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 20,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 21, _ss="" ,percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 22,_ss="" , percentile = 0.01,t=1.0}, 
     new StandardScoreLookupTable(){SS = 23,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 24, _ss="" ,percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 25,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 26,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 27,_ss="" , percentile = 0.01,t=1.0},
     new StandardScoreLookupTable(){SS = 28,_ss="" , percentile = 0.01,t=2.0},
     new StandardScoreLookupTable(){SS = 29,_ss="" , percentile = 0.01,t=3.0},
     new StandardScoreLookupTable(){SS = 30,_ss="" , percentile = 0.01,t=3.0},
     new StandardScoreLookupTable(){SS = 31, _ss="" , percentile = 0.01,t=4.0},
     new StandardScoreLookupTable(){SS = 32, _ss="" ,percentile = 0.01,t=5.0}, 
     new StandardScoreLookupTable(){SS = 33,_ss="" , percentile = 0.01,t=5.0},
     new StandardScoreLookupTable(){SS = 34, _ss="" ,percentile = 0.01,t=6.0},
     new StandardScoreLookupTable(){SS = 35, _ss="" ,percentile = 0.01,t=7.0},
     new StandardScoreLookupTable(){SS = 36,_ss="" , percentile = 0.01,t=7.0},
     new StandardScoreLookupTable(){SS = 37, _ss="" ,percentile = 0.01,t=8.0},
     new StandardScoreLookupTable(){SS = 38,_ss="" , percentile = 0.01,t=9.0},
     new StandardScoreLookupTable(){SS = 39, _ss="" ,percentile = 0.01,t=9.0},
     new StandardScoreLookupTable(){SS = 40,_ss="" , percentile = 0.01,t=10.0},
     new StandardScoreLookupTable(){SS = 41,_ss="" , percentile = 0.01,t=11.0},
     new StandardScoreLookupTable(){SS = 42,_ss="" , percentile = 0.01,t=11.0},
     new StandardScoreLookupTable(){SS =43,_ss="" , percentile = 0.01,t=12.0},
     new StandardScoreLookupTable(){SS = 44,_ss="" , percentile = 0.01,t=13.0},
     new StandardScoreLookupTable(){SS = 45,_ss="" , percentile = 0.01,t=13.5},
     new StandardScoreLookupTable(){SS = 46,_ss="" , percentile = 0.01,t=14.0}, 
     new StandardScoreLookupTable(){SS = 47, _ss="" ,percentile = 0.02,t=14.5},
       new StandardScoreLookupTable(){SS = 48,_ss="" , percentile = 0.02,t=15},
     new StandardScoreLookupTable(){SS = 48,_ss="" , percentile = 0.00,t=15.5},
     new StandardScoreLookupTable(){SS = 49,_ss="" , percentile = 0.02,t=16.0},
     new StandardScoreLookupTable(){SS = 50,_ss="0" , percentile = 0.03,t=16.5},
     new StandardScoreLookupTable(){SS = 51, _ss="" ,percentile = 0.03,t=17.0},
     new StandardScoreLookupTable(){SS = 51,_ss="" , percentile = 0.00,t=17.5}, 
     new StandardScoreLookupTable(){SS = 52,_ss="" , percentile = 0.07,t=18.0},
     new StandardScoreLookupTable(){SS = 53, _ss="" ,percentile = 0.08,t=18.5},
     new StandardScoreLookupTable(){SS = 54,_ss="" , percentile = 0.09,t=19.0},
     new StandardScoreLookupTable(){SS = 54,_ss="" , percentile = 0.00,t=19.5},
     new StandardScoreLookupTable(){SS = 55,_ss="1" , percentile = 0.01,t=20.0},
     new StandardScoreLookupTable(){SS = 56,_ss="" , percentile = 0.02,t=21.0},
      new StandardScoreLookupTable(){SS = 57,_ss="" , percentile = 0.02,t=21.0},
     new StandardScoreLookupTable(){SS = 58,_ss="" , percentile = 0.03,t=22.0},
       new StandardScoreLookupTable(){SS = 59,_ss="" , percentile = 0.03,t=23.0},
     new StandardScoreLookupTable(){SS = 60,_ss="2" , percentile = 0.04,t=23.0},

      new StandardScoreLookupTable(){SS = 61,_ss="" , percentile = 0.05,t=24.0},
     new StandardScoreLookupTable(){SS = 62,_ss="" , percentile = 1.0,t=25.0},
       new StandardScoreLookupTable(){SS = 63,_ss="" , percentile = 1.0,t=25.0},
        new StandardScoreLookupTable(){SS = 64,_ss="" , percentile = 1.0,t=26.0},
     new StandardScoreLookupTable(){SS = 65,_ss="3" , percentile = 1.0,t=27.0},
       new StandardScoreLookupTable(){SS = 66,_ss="" , percentile = 1.0,t=27.0},
        new StandardScoreLookupTable(){SS = 67,_ss="" , percentile = 1.0,t=28.0},
     new StandardScoreLookupTable(){SS = 68,_ss="" , percentile = 2.0,t=29.0},
       new StandardScoreLookupTable(){SS = 69,_ss="" , percentile = 2.0,t=29.0},
        new StandardScoreLookupTable(){SS = 70,_ss="4" , percentile = 2.0,t=30.0},
     new StandardScoreLookupTable(){SS = 71,_ss="" , percentile = 3.0,t=31.0},
       new StandardScoreLookupTable(){SS = 72,_ss="" , percentile = 3.0,t=31.0},
         new StandardScoreLookupTable(){SS = 73,_ss="" , percentile = 4.0,t=32.0},
     new StandardScoreLookupTable(){SS = 74,_ss="" , percentile = 4.0,t=33.0},
       new StandardScoreLookupTable(){SS = 75,_ss="5" , percentile = 5.0,t=33.0},
        new StandardScoreLookupTable(){SS = 76,_ss="" , percentile = 5.0,t=34.0},
     new StandardScoreLookupTable(){SS = 77,_ss="3" , percentile = 6.0,t=35.0},
       new StandardScoreLookupTable(){SS = 78,_ss="" , percentile = 7.0,t=35.0},
        new StandardScoreLookupTable(){SS = 79,_ss="" , percentile = 8.0,t=36.0},
     new StandardScoreLookupTable(){SS = 80,_ss="6" , percentile = 9.0,t=37.0},
       new StandardScoreLookupTable(){SS = 81,_ss="" , percentile = 10.0,t=37.0},
        new StandardScoreLookupTable(){SS = 82,_ss="" , percentile = 12.0,t=38.0},
     new StandardScoreLookupTable(){SS = 83,_ss="" , percentile = 13.0,t=39.0},
       new StandardScoreLookupTable(){SS = 84,_ss="" , percentile = 14.0,t=39.0},
         new StandardScoreLookupTable(){SS = 85,_ss="7" , percentile = 16.0,t=40.0},
     new StandardScoreLookupTable(){SS = 86,_ss="" , percentile = 18.0,t=41.0},
       new StandardScoreLookupTable(){SS = 87,_ss="" , percentile = 19.0,t=41.0},
        new StandardScoreLookupTable(){SS = 88,_ss="" , percentile = 21.0,t=42.0},
     new StandardScoreLookupTable(){SS = 89,_ss="" , percentile = 23.0,t=43.0},
       new StandardScoreLookupTable(){SS = 90,_ss="8" , percentile = 25.0,t=43.0},
        new StandardScoreLookupTable(){SS = 91,_ss="" , percentile = 27.0,t=44.0},
     new StandardScoreLookupTable(){SS = 92,_ss="" , percentile = 30.0,t=45.0},
       new StandardScoreLookupTable(){SS = 93,_ss="" , percentile = 32.0,t=45.0},
        new StandardScoreLookupTable(){SS = 94,_ss="" , percentile = 34.0,t=46.0},
     new StandardScoreLookupTable(){SS = 95,_ss="9" , percentile = 37.0,t=47.0},
       new StandardScoreLookupTable(){SS = 96,_ss="" , percentile = 40.0,t=47.0},
        new StandardScoreLookupTable(){SS = 97,_ss="" , percentile = 30.0,t=48.0},
       new StandardScoreLookupTable(){SS = 98,_ss="" , percentile = 32.0,t=49.0},
        new StandardScoreLookupTable(){SS = 99,_ss="" , percentile = 34.0,t=49.0},
     new StandardScoreLookupTable(){SS = 100,_ss="10" , percentile = 37.0,t=50.0},
   

    //////////////////////////////////////////////////////////////////////////
    ////                  Standard Score Lookup table                      ///
    ////                         SS range 101-191                          ///             
    ////                   Value types are SS,(ss),%,T                     ///
    //////////////////////////////////////////////////////////////////////////
      new StandardScoreLookupTable(){SS = 101, _ss="" , percentile = 53,t=51.0},
    new StandardScoreLookupTable(){SS = 102, _ss="" ,percentile = 55,t=51.0},  
     new StandardScoreLookupTable(){SS = 103,_ss="" , percentile = 58,t=52.0},
     new StandardScoreLookupTable(){SS = 104, _ss="" ,percentile = 61,t=53.0},
     new StandardScoreLookupTable(){SS = 105, _ss="11" ,percentile = 63,t=53.0},
     new StandardScoreLookupTable(){SS = 106,_ss="" , percentile = 66,t=54.0},
     new StandardScoreLookupTable(){SS = 107, _ss="" ,percentile = 68,t=55.0},
     new StandardScoreLookupTable(){SS = 108,_ss="" , percentile = 70,t=55.0},
     new StandardScoreLookupTable(){SS = 109, _ss="" ,percentile = 73,t=56.0},
     new StandardScoreLookupTable(){SS = 110,_ss="12" , percentile = 75,t=57.0},
     new StandardScoreLookupTable(){SS = 111,_ss="" , percentile = 77,t=57.0},
     new StandardScoreLookupTable(){SS = 112,_ss="" , percentile = 79,t=58.0},
     new StandardScoreLookupTable(){SS = 113,_ss="" , percentile = 81,t=59.0},
     new StandardScoreLookupTable(){SS = 114,_ss="" , percentile = 83,t=59.0},
     new StandardScoreLookupTable(){SS = 115,_ss="13" , percentile = 84,t=60},
     new StandardScoreLookupTable(){SS = 116,_ss="" , percentile = 86,t=61.0}, 
     new StandardScoreLookupTable(){SS = 117, _ss="" ,percentile = 87,t=61.0},
     new StandardScoreLookupTable(){SS = 118,_ss="" , percentile = 89,t=62.0},
     new StandardScoreLookupTable(){SS = 119,_ss="" , percentile = 90,t=63.0},
     new StandardScoreLookupTable(){SS = 120,_ss="14" , percentile = 91,t=63},
     new StandardScoreLookupTable(){SS = 121, _ss="" ,percentile = 92,t=64.0},
     new StandardScoreLookupTable(){SS = 122,_ss="" , percentile = 93,t=65.0}, 
     new StandardScoreLookupTable(){SS = 123,_ss="" , percentile = 94,t=65.0},
     new StandardScoreLookupTable(){SS = 124, _ss="" ,percentile = 95,t=66.0},
     new StandardScoreLookupTable(){SS = 125,_ss="15" , percentile = 95,t=67.0},
     new StandardScoreLookupTable(){SS = 126,_ss="" , percentile = 96,t=67.0},
     new StandardScoreLookupTable(){SS = 127,_ss="" , percentile = 96,t=68.0},
     new StandardScoreLookupTable(){SS = 128,_ss="" , percentile = 97,t=69.0},
      new StandardScoreLookupTable(){SS = 129,_ss="" , percentile = 97,t=69.0},
     new StandardScoreLookupTable(){SS = 130,_ss="16" , percentile = 98,t=70.0},
      new StandardScoreLookupTable(){SS = 131, _ss="" , percentile = 98,t=71.0},
    new StandardScoreLookupTable(){SS = 132, _ss="" ,percentile = 99,t=71.0}, 
     new StandardScoreLookupTable(){SS = 133,_ss="" , percentile = 99,t=72.0},
     new StandardScoreLookupTable(){SS = 134, _ss="" ,percentile = 99,t=73.0},
     new StandardScoreLookupTable(){SS = 135, _ss="17" ,percentile = 99,t=73.0},
     new StandardScoreLookupTable(){SS = 136,_ss="" , percentile = 99,t=74.0},
     new StandardScoreLookupTable(){SS = 137, _ss="" ,percentile = 99,t=75.0},
     new StandardScoreLookupTable(){SS = 138,_ss="" , percentile = 99,t=75.0},
     new StandardScoreLookupTable(){SS = 139, _ss="" ,percentile = 99,t=76.0},
     new StandardScoreLookupTable(){SS = 140,_ss="18" , percentile = 99,t=77.0},
     new StandardScoreLookupTable(){SS = 141,_ss="" , percentile = 99.1,t=77.0},
     new StandardScoreLookupTable(){SS = 142,_ss="" , percentile = 99.2,t=78.0},
     new StandardScoreLookupTable(){SS =143,_ss="" , percentile = 99.3,t=79.0},
     new StandardScoreLookupTable(){SS = 144,_ss="" , percentile = 99.4,t=13.0},
     new StandardScoreLookupTable(){SS = 145,_ss="19" , percentile = 99.5,t=79.0},
     new StandardScoreLookupTable(){SS = 146,_ss="" , percentile = 99.6,t=80.0}, 
     new StandardScoreLookupTable(){SS = 147, _ss="" ,percentile = 99.7,t=81.0},
       new StandardScoreLookupTable(){SS = 148,_ss="" , percentile = 99.8,t=82.0},
     new StandardScoreLookupTable(){SS = 148,_ss="" , percentile = 99.9,t=83.0},
     new StandardScoreLookupTable(){SS = 149,_ss="" , percentile = 99.99,t=84.0},
     new StandardScoreLookupTable(){SS = 150,_ss="20" , percentile = 99.9,t=85.0},
     new StandardScoreLookupTable(){SS = 151, _ss="" ,percentile = 99.9,t=86.0},
    
     new StandardScoreLookupTable(){SS = 152,_ss="" , percentile = 99.9,t=87.0},
     new StandardScoreLookupTable(){SS = 153, _ss="" ,percentile = 99.9,t=88.0},
     new StandardScoreLookupTable(){SS = 154,_ss="" , percentile = 99.9,t=89.0},
  
     new StandardScoreLookupTable(){SS = 155,_ss="1" , percentile = 99.9,t=90.0},
     new StandardScoreLookupTable(){SS = 156,_ss="" , percentile = 99.9,t=91.0},
      new StandardScoreLookupTable(){SS = 157,_ss="" , percentile = 99.9,t=92.0},
     new StandardScoreLookupTable(){SS = 158,_ss="" , percentile = 99.9,t=93.0},
       new StandardScoreLookupTable(){SS = 159,_ss="" , percentile = 99.9,t=94.0},
     new StandardScoreLookupTable(){SS = 160,_ss="" , percentile = 99.9,t=95.0},

      new StandardScoreLookupTable(){SS = 161,_ss="" , percentile = 99.9,t=96.0},
     new StandardScoreLookupTable(){SS = 162,_ss="" , percentile = 99.9,t=97.0},
       new StandardScoreLookupTable(){SS = 163,_ss="" , percentile = 99.9,t=98.0},
        new StandardScoreLookupTable(){SS = 164,_ss="" , percentile = 99.9,t=99.0},
     new StandardScoreLookupTable(){SS = 165,_ss="" , percentile = 99.9,t=100.0},
       new StandardScoreLookupTable(){SS = 166,_ss="" , percentile = 99.9,t=101.0},
        new StandardScoreLookupTable(){SS = 167,_ss="" , percentile = 99.9,t=102.0},
     new StandardScoreLookupTable(){SS = 168,_ss="" , percentile = 99.9,t=103.0},
       new StandardScoreLookupTable(){SS = 169,_ss="" , percentile = 99.9,t=104.0},
        new StandardScoreLookupTable(){SS = 170,_ss="" , percentile = 99.9,t=105.0},
     new StandardScoreLookupTable(){SS = 171,_ss="" , percentile = 99.9,t=106.0},
       new StandardScoreLookupTable(){SS = 172,_ss="" , percentile = 99.9,t=107.0},
         new StandardScoreLookupTable(){SS = 173,_ss="" , percentile = 99.9,t=108.0},
     new StandardScoreLookupTable(){SS = 174,_ss="" , percentile = 99.9,t=109.0},
       new StandardScoreLookupTable(){SS = 175,_ss="" , percentile = 99.9,t=110.0},
        new StandardScoreLookupTable(){SS = 176,_ss="" , percentile = 99.9,t=111.0},
     new StandardScoreLookupTable(){SS = 177,_ss="" , percentile = 99.9,t=112.0},
       new StandardScoreLookupTable(){SS = 178,_ss="" , percentile = 99.9,t=113.0},
        new StandardScoreLookupTable(){SS = 179,_ss="" , percentile = 99.9,t=114.0},
     new StandardScoreLookupTable(){SS = 180,_ss="" , percentile = 99.9,t=115.0},
       new StandardScoreLookupTable(){SS = 181,_ss="" , percentile = 99.9,t=116.0},
        new StandardScoreLookupTable(){SS = 182,_ss="" , percentile = 99.9,t=117.0},
     new StandardScoreLookupTable(){SS = 183,_ss="" , percentile = 99.9,t=118.0},
       new StandardScoreLookupTable(){SS = 184,_ss="" , percentile = 99.9,t=119.0},
         new StandardScoreLookupTable(){SS = 185,_ss="" , percentile = 99.9,t=120.0},
     new StandardScoreLookupTable(){SS = 186,_ss="" , percentile = 99.9,t=121.0},
       new StandardScoreLookupTable(){SS = 187,_ss="" , percentile = 99.9,t=122.0},
        new StandardScoreLookupTable(){SS = 188,_ss="" , percentile = 99.9,t=123.0},
     new StandardScoreLookupTable(){SS = 189,_ss="" , percentile = 99.9,t=124.0},
       new StandardScoreLookupTable(){SS = 190,_ss="" , percentile = 99.9,t=125.0},
        new StandardScoreLookupTable(){SS = 191,_ss="" , percentile = 99.9,t=126.0},
   

};
          
        }
       
    }


      
    

