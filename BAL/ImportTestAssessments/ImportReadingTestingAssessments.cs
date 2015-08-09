using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using DAL;
using System.ComponentModel;
/*
namespace BAL.ImportTestAssessments
{
    /// <summary>
    /// Capture Excel Row Values and store them to a collection'
    /// Row Index value identifies the starting row location of a particular test
    /// </summary>

    public interface TestingAssessments
    {
        List<DAL.ReadingTestScores> Assessments(int studentNo, Excel.Range _range, int currentRow, Int32 excelIndexNo,
            BackgroundWorker bgworker);
    }


    public class TestingAssessment1 : TestTypes, TestingAssessments
    {
        public List<DAL.ReadingTestScores> Assessments(int studentNo, Excel.Range _range, int currentRow,
            Int32 excelIndexNo, BackgroundWorker bgworker)
        {

            List<DAL.ReadingTestScores> readingScores = new List<DAL.ReadingTestScores>();

            switch (excelIndexNo)
            {

                case 500:
                    readingScores = TestingRangeValues(studentNo, _range, 500, 501, 506, currentRow, "Connors 48",
                        bgworker);
                    break;
                case 1000:
                    readingScores = TestingRangeValues(studentNo, _range, 1000, 1005, 1046, currentRow, "AWMA", bgworker);
                    break;
                case 1100:
                    readingScores = TestingRangeValues(studentNo, _range, 1100, 1101, 1306, currentRow,
                        "CBCL_1_Age 6-18", bgworker);
                    break;
                case 1310:
                    readingScores = TestingRangeValues(studentNo, _range, 1310, 1311, 1466, currentRow, "TRF_1_Age 6-18",
                        bgworker);
                    break;
                case 1470:
                    readingScores = TestingRangeValues(studentNo, _range, 1470, 1472, 1696, currentRow,
                        "YSR_1_Age 11-18", bgworker);
                    break;
                case 2000:
                    readingScores = TestingRangeValues(studentNo, _range, 2000, 2001, 2106, currentRow,
                        "BRIEF  (parent reporting form)", bgworker);
                    break;
                case 5000:
                    readingScores = TestingRangeValues(studentNo, _range, 5000, 5002, 5006, currentRow,
                        "PPVT_4_A_Recept vocab", bgworker);
                    break;
                case 5010:
                    readingScores = TestingRangeValues(studentNo, _range, 5010, 5012, 5016, currentRow,
                        "PPVT_4_B_Recept vocab", bgworker);
                    break;
                case 5020:
                    readingScores = TestingRangeValues(studentNo, _range, 5020, 5022, 5026, currentRow,
                        "PPVT_III_A_Recept vocab", bgworker);
                    break;
                case 5030:
                    readingScores = TestingRangeValues(studentNo, _range, 5030, 5032, 5036, currentRow,
                        "PPVT_III_B_Recept vocab", bgworker);
                    break;
                case 5070:
                    readingScores = TestingRangeValues(studentNo, _range, 5070, 5072, 5076, currentRow,
                        "EVT_2_ _Express vocab form A", bgworker);
                    break;
                case 5080:
                    readingScores = TestingRangeValues(studentNo, _range, 5080, 5082, 5086, currentRow,
                        "EVT_2_ _Express vocab form B", bgworker);
                    break;
                case 5040:
                    readingScores = TestingRangeValues(studentNo, _range, 5040, 5042, 5046, currentRow,
                        "EVT_1_ _Express vocab", bgworker);
                    break;
                case 5050:
                    readingScores = TestingRangeValues(studentNo, _range, 5050, 5052, 5066, currentRow, "OWLS_1",
                        bgworker);
                    break;

                case 5200:
                    readingScores = TestingRangeValues(studentNo, _range, 5200, 5202, 5408, currentRow,
                        "Woodcock-Johnson III Tests of Cognitive Abilities", bgworker);
                    break;
                case 5500:
                    readingScores = TestingRangeValues(studentNo, _range, 5500, 5502, 5648, currentRow,
                        "W Language Proficiency Battery-Revised", bgworker);
                    break;
                case 6000:
                    readingScores = TestingRangeValues(studentNo, _range, 6000, 6002, 6086, currentRow, "CELF_RNU_5-7",
                        bgworker);
                    break;
                case 6090:
                    readingScores = TestingRangeValues(studentNo, _range, 6090, 6092, 6186, currentRow, "CELF_RNU_8-16",
                        bgworker);
                    break;
                case 6200:
                    readingScores = TestingRangeValues(studentNo, _range, 6200, 6202, 6316, currentRow, "TOLD_P3_4-811",
                        bgworker);
                    break;
                case 6700:
                    readingScores = TestingRangeValues(studentNo, _range, 6700, 6702, 6316, currentRow, "TOLD_P4_4-811",
                        bgworker);
                    break;
                case 6400:
                    readingScores = TestingRangeValues(studentNo, _range, 6400, 6402, 6456, currentRow,
                        "TOLD_I3_8-1111_TestOfLangDev-Intermediate", bgworker);
                    break;
                case 6600:
                    readingScores = TestingRangeValues(studentNo, _range, 6600, 6602, 6676, currentRow,
                        "TOAL_3_12_2411_TestOfAdolAdultLanguage", bgworker);
                    break;
                case 8000:
                    readingScores = TestingRangeValues(studentNo, _range, 8000, 8002, 8006, currentRow,
                        "TONI_2_ _Non-verbal", bgworker);
                    break;
                case 8010:
                    readingScores = TestingRangeValues(studentNo, _range, 8010, 8012, 8027, currentRow, "WRAT-Math_III",
                        bgworker);
                    break;
                case 10010:
                    readingScores = TestingRangeValues(studentNo, _range, 10010, 10036, 10034, currentRow, "Digit span",
                        bgworker);
                    break;
                case 12000:
                    readingScores = TestingRangeValues(studentNo, _range, 12000, 12002, 12017, currentRow,
                        "Blending sounds", bgworker);
                    break;
                case 12030:
                    readingScores = TestingRangeValues(studentNo, _range, 12030, 12032, 12047, currentRow,
                        "Segmenting words", bgworker);
                    break;
                case 12060:
                    readingScores = TestingRangeValues(studentNo, _range, 12060, 12062, 12067, currentRow,
                        "Eliding sounds", bgworker);
                    break;
                case 12100:
                    readingScores = TestingRangeValues(studentNo, _range, 12100, 12102, 12136, currentRow,
                        "Test of Preschool Early Literacy (TOPEL, Lonigan et al, 2007)", bgworker);
                    break;
                case 12200:
                    readingScores = TestingRangeValues(studentNo, _range, 12200, 12202, 12306, currentRow,
                        "CTOPP_1_Age 5-6", bgworker);
                    break;
                case 12310:
                    readingScores = TestingRangeValues(studentNo, _range, 12310, 12312, 12476, currentRow,
                        "CTOPP_1_Age 7-24", bgworker);
                    break;
                case 14000:
                    readingScores = TestingRangeValues(studentNo, _range, 14000, 14002, 14010, currentRow,
                        "Names for letters", bgworker);
                    break;
                case 14010:
                    readingScores = TestingRangeValues(studentNo, _range, 14010, 14012, 14016, currentRow,
                        "Orientation test (Jordon L-R Reversal)", bgworker);
                    break;
                case 14020:
                    readingScores = TestingRangeValues(studentNo, _range, 14020, 14022, 14032, currentRow,
                        "ReadSymbols_1_RA", bgworker);
                    break;
                case 14040:
                    readingScores = TestingRangeValues(studentNo, _range, 14040, 14042, 14046, currentRow, "DIBELS",
                        bgworker);
                    break;
                case 14120:
                    readingScores = TestingRangeValues(studentNo, _range, 14120, 14122, 14198, currentRow,
                        "WRMT_R (NOTE: WRMT_R_NU is after WRMT_R)", bgworker);
                    break;
                case 23020:
                    readingScores = TestingRangeValues(studentNo, _range, 23020, 23022, 23098, currentRow,
                        "WRMT_RNU (NOTE GE will not be correct yet)", bgworker);
                    break;
                case 14200:
                    readingScores = TestingRangeValues(studentNo, _range, 14200, 14202, 14256, currentRow, "TOWRE_1",
                        bgworker);
                    break;
                case 14300:
                    readingScores = TestingRangeValues(studentNo, _range, 14300, 14302, 14666, currentRow,
                        "WJ_III_Achievement", bgworker);
                    break;
                case 14700:
                    readingScores = TestingRangeValues(studentNo, _range, 14700, 14702, 14916, currentRow,
                        "Diagnostic Achievement Battery (Ed. III) DAB", bgworker);
                    break;
                case 18100:
                    readingScores = TestingRangeValues(studentNo, _range, 18100, 18102, 18196, currentRow, "GORT_IV",
                        bgworker);
                    break;
                case 18200:
                    readingScores = TestingRangeValues(studentNo, _range, 18200, 18202, 18296, currentRow, "GORT_5",
                        bgworker);
                    break;
                case 18300:
                    readingScores = TestingRangeValues(studentNo, _range, 18300, 18302, 18496, currentRow,
                        "Nelson Denny_1", bgworker);
                    break;
                case 18500:
                    readingScores = TestingRangeValues(studentNo, _range, 18500, 18502, 18724, currentRow,
                        "Curriculum-based measurement (CBM)", bgworker);
                    break;
                case 18600:
                    readingScores = TestingRangeValues(studentNo, _range, 18600, 18602, 18679, currentRow,
                        "Phonics-BasedReadingTest (PRT)", bgworker);
                    break;
                case 22000:
                    readingScores = TestingRangeValues(studentNo, _range, 22000, 22002, 22006, currentRow,
                        "SpellSounds_1_Lind", bgworker);
                    break;
                case 22010:
                    readingScores = TestingRangeValues(studentNo, _range, 22010, 22012, 22026, currentRow,
                        "SpellNonwords_1_Lind", bgworker);
                    break;
                case 22030:
                    readingScores = TestingRangeValues(studentNo, _range, 22030, 22032, 22042, currentRow,
                        "SpellNonWordsExamples", bgworker);
                    break;
                case 22150:
                    readingScores = TestingRangeValues(studentNo, _range, 22150, 22152, 22176, currentRow, "TWS_III",
                        bgworker);
                    break;
                case 22180:
                    readingScores = TestingRangeValues(studentNo, _range, 22180, 22182, 22196, currentRow, "TWS_4",
                        bgworker);
                    break;
                case 22300:
                    readingScores = TestingRangeValues(studentNo, _range, 22300, 22302, 22316, currentRow,
                        "Spelling examples", bgworker);
                    break;
                case 22400:
                    readingScores = TestingRangeValues(studentNo, _range, 22400, 22402, 25142, currentRow,
                        "Test of Orthographic Competence (TOC)", bgworker);
                    break;

            }
            return readingScores;
        }

    }


    /// <summary>
    /// Import all testing values of the current test and store them into a genric collection. 
    /// Then return the to the interface to be stored into the datastore
    /// </summary>
    /// 

    #region Parse RS, SS,[SS],(ss),t,ND
    public interface IMatchingTestIndex
    {

        String Locate(string indexNo);
    }

    public class TestTypes : CollectAllIndicies.DetectCorruptData
    {
        public static int progressPercentage;
        private BackgroundWorker bgworker = new BackgroundWorker();

        public List<DAL.ReadingTestScores> TestingRangeValues(int studentNo, Excel.Range range, Int32 parentTestindex,
            int _startRange, int _stopRange, int currentRow, string parentTestTitle, BackgroundWorker bgworker)
        {

            string testMethod = string.Empty,
                scoreType = string.Empty,
                testName = string.Empty,
                ndScore = string.Empty,
                ssScore = string.Empty,
                parsedssScore = string.Empty,
                standardScore = string.Empty,
                parsedtScore = string.Empty,
                parsedRawScore = string.Empty;
            string _scoreType = string.Empty,
                _excelminDataRange = string.Empty,
                _excelmaxDataRange = string.Empty,
                corruptData = string.Empty,
                rawScore = string.Empty;
            int subTestIndex = 0, index = _startRange, rCnt = currentRow, intresult;
            Dictionary<string, string> badValue = new Dictionary<string, string>();
            List<DAL.ReadingTestScores> storeScore = new List<DAL.ReadingTestScores>();
            //  IParseDataPoint DashEndofString = new ParseDash();
            IMatchingTestIndex LocateTestIndex = new CollectAllIndicies.LocateTestIndex();
            String indexfound = string.Empty;
            //StandardScoreLookupTable convertStandardScore = new StandardScoreLookupTable();


            try
            {

                while (index != _stopRange)
                {
                    index = (int) ((range.Cells[currentRow, 1] as Excel.Range).Value2);
                    scoreType = ((range.Cells[currentRow, 3] as Excel.Range).Value2);
                    subTestIndex = (int) (range.Cells[currentRow, 1] as Excel.Range).Value;
                    testName = (range.Cells[currentRow, 2] as Excel.Range).Value;
                    _excelminDataRange = String.Empty;
                    _excelmaxDataRange = String.Empty;
                    _excelminDataRange = Convert.ToString((range.Cells[currentRow, 8] as Excel.Range).Text);
                    _excelmaxDataRange = Convert.ToString((range.Cells[currentRow, 9] as Excel.Range).Text);
                    parsedtScore = string.Empty;
                    standardScore = string.Empty;
                    parsedRawScore = string.Empty;
                    indexfound = string.Empty;
                    if ((string) (range.Cells[currentRow, 4] as Excel.Range).Text != null &&
                        (string) (range.Cells[currentRow, 4] as Excel.Range).Text != "")
                    {
                        switch (scoreType)
                        {

                            case "SS":

                                standardScore = (string) (range.Cells[currentRow, 4] as Excel.Range).Text;
                                //////////////////////////////////
                                ////   Validate Data Point   /////
                                //////////////////////////////////

                                if (int.TryParse(standardScore, out intresult))
                                {
                                    if (_excelminDataRange != "" && _excelmaxDataRange != "")
                                    {
                                        badValue = Evaluate(standardScore, _excelminDataRange, _excelmaxDataRange);
                                        corruptData = badValue["faulty"];
                                    }
                                }



                                storeScore.Add(new DAL.ReadingTestScores(studentNo, parentTestindex, parentTestTitle,
                                    subTestIndex, testName, parsedRawScore, parsedtScore, standardScore, string.Empty,
                                    string.Empty, currentRow, _excelminDataRange, _excelmaxDataRange, corruptData,
                                    indexfound));

                                break;
                            case "[SS]":
                                standardScore = (string) (range.Cells[currentRow, 4] as Excel.Range).Text;
                                //////////////////////////////////
                                ////   Validate Data Point   /////
                                //////////////////////////////////

                                if (int.TryParse(standardScore, out intresult))
                                {
                                    if (_excelminDataRange != "" && _excelmaxDataRange != "")
                                    {
                                        badValue = Evaluate(standardScore, _excelminDataRange, _excelmaxDataRange);
                                        corruptData = badValue["faulty"];
                                    }
                                }
                                storeScore.Add(new DAL.ReadingTestScores(studentNo, parentTestindex, parentTestTitle,
                                    subTestIndex, testName, parsedRawScore,
                                    parsedtScore, string.Empty, standardScore, string.Empty, currentRow,
                                    _excelminDataRange, _excelmaxDataRange, corruptData, indexfound));

                                break;

                            case "RS":

                                rawScore = (string) (range.Cells[currentRow, 4] as Excel.Range).Text;
                                parsedRawScore = rawScore;
                                // parsedRawScore = DashEndofString.Parse(rawScore.Trim()).Trim();
                                /////////////////////////////////
                                ////   Validate Data Point   ////
                                /////////////////////////////////

                                if (int.TryParse(parsedRawScore, out intresult))
                                {
                                    if (_excelminDataRange != "" && _excelmaxDataRange != "")
                                    {
                                        badValue = Evaluate(parsedRawScore, _excelminDataRange, _excelmaxDataRange);
                                        corruptData = badValue["faulty"];
                                    }
                                }
                                storeScore.Add(new DAL.ReadingTestScores(studentNo, parentTestindex, parentTestTitle,
                                    subTestIndex, testName, parsedRawScore, parsedtScore,
                                    string.Empty, string.Empty, string.Empty, currentRow, _excelminDataRange,
                                    _excelmaxDataRange, corruptData, indexfound));

                                break;

                            case "t":


                                try
                                {
                                    // Double tScore;
                                    String tValue;
                                    tValue = (range.Cells[currentRow, 4] as Excel.Range).Text;

                                    // parsedtScore = DashEndofString.Parse(tValue.ToString().Trim()).Trim();
                                    // tScore = Convert.ToDouble(parsedScore);

                                    ////////////////////////////////////////
                                    //Convert 't' Score to Standard Score///
                                    ////////////////////////////////////////
                                    //     var convertedValue = (from q in StandardScoreLookupTable.StandardScoreTable.ToList()
                                    //        where q.t == tScore
                                    //      select q).FirstOrDefault();
                                    //   standardScore = Convert.ToString(convertedValue.SS);

                                    //////////////////////////////////
                                    ////   Validate Data Point   /////
                                    //////////////////////////////////
                                    if (_excelminDataRange != "" && _excelmaxDataRange != "")
                                    {
                                        badValue = Evaluate(parsedtScore, _excelminDataRange, _excelmaxDataRange);
                                        corruptData = badValue["faulty"];
                                    }
                                }
                                catch
                                {
                                }


                                storeScore.Add(new DAL.ReadingTestScores(studentNo, parentTestindex, parentTestTitle,
                                    subTestIndex, testName, parsedRawScore, parsedtScore,
                                    standardScore, string.Empty, string.Empty, currentRow, _excelminDataRange,
                                    _excelmaxDataRange, corruptData, indexfound));


                                break;
                            case "(ss)":

                                standardScore = Convert.ToString((range.Cells[currentRow, 4] as Excel.Range).Value);

                                //parsedssScore = DashEndofString.Parse(ssScore.Trim()).Trim();
                                /////////////////////////////////////////
                                //Convert (ss) Score to Standard Score///
                                /////////////////////////////////////////
                                //  var convertedValue = (from q in StandardScoreLookupTable.StandardScoreTable.ToList()
                                //  where q._ss == ssScore
                                //  select q).FirstOrDefault();

                                // standardScore = Convert.ToString(convertedValue.SS);
                                //////////////////////////////////
                                ////   Validate Data Point   /////
                                //////////////////////////////////
                                if (int.TryParse(standardScore, out intresult))
                                {
                                    if (_excelminDataRange != null && _excelmaxDataRange != null)
                                    {
                                        badValue = Evaluate(standardScore, _excelminDataRange, _excelmaxDataRange);
                                        corruptData = badValue["faulty"];
                                        storeScore.Add(new DAL.ReadingTestScores(studentNo, parentTestindex,
                                            parentTestTitle, subTestIndex, testName, parsedRawScore, parsedtScore,
                                            string.Empty, string.Empty, standardScore, currentRow, _excelminDataRange,
                                            _excelmaxDataRange, corruptData, indexfound));
                                    }
                                }
                                break;

                            case "ND":


                                ndScore = Convert.ToString((range.Cells[currentRow, 4] as Excel.Range).Value);

                                ////////////////////////////////////////
                                //Convert 'ND' Score to Standard Score//
                                ////////////////////////////////////////

                                //Save the standard Score into the collection//
                                storeScore.Add(new DAL.ReadingTestScores(studentNo, parentTestindex, parentTestTitle,
                                    subTestIndex, testName, ndScore,
                                    string.Empty, string.Empty, string.Empty, string.Empty, currentRow,
                                    _excelminDataRange, _excelmaxDataRange, corruptData, indexfound));

                                break;
                        }
                    }
                    currentRow = currentRow + 1;

                }
                if (storeScore.Count == 0)
                {
                    storeScore.Add(new DAL.ReadingTestScores(studentNo, parentTestindex, parentTestTitle,
                        parentTestindex, "NoTest", string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty, currentRow, string.Empty, string.Empty,
                        "", indexfound));

                }
            }
            catch
            {
                Exception ex = null;
                throw ex;
            }
            //Purpose of this line is to mark the last row in the test collection
            storeScore.Add(new DAL.ReadingTestScores(studentNo, 0, string.Empty, 0, "Last_Row", string.Empty,
                string.Empty, string.Empty, string.Empty, string.Empty, currentRow - 1,
                string.Empty, string.Empty, "", indexfound));
            return storeScore;
        }


    }
}

#endregion

  */
 