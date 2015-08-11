using System;
using System.Windows.Forms;

namespace ReadingTestScores
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          
            var startUpForm = new Main();
           Application.Run(startUpForm);
          startUpForm.Show();
        }
    }
}
