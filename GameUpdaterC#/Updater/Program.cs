using System;
using System.Diagnostics;

namespace Updater
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            MessageBox.Show("Updater Sucsesfully Opened");


            if (Directory.GetFileSystemEntries("./GameFiles").Length == 0)
            {
                Process p = new Process();
                p.Exited += new EventHandler(p_DownloadSuccess);
                p.StartInfo.FileName = @"./PullFirstTime.exe";
                p.EnableRaisingEvents = true;
                p.Start();

                void p_DownloadSuccess(object sender, EventArgs e)
                {
                    MessageBox.Show("Game Download Success");
                }
            }
            else
            {
                Process x = new Process();
                x.Exited += new EventHandler(p_updateSuccess);
                x.StartInfo.FileName = @"./Update.exe";
                x.EnableRaisingEvents = true;
                x.Start();

                void p_updateSuccess(object sender, EventArgs e)
                {
                    MessageBox.Show("Game Updated Success");
                }
            }



            Application.Run(new Form1());

         
        }
    }
}