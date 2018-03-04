using System;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace CarParser0.Logger
{
    public class LoggerToExcel : ILogger
    {
        private Workbook    wb;
        private Application app;
        private Worksheet   ws;
        private Int32       line;

        private String path;
        private ITimeProvider timer;

        public LoggerToExcel(string path, ITimeProvider timer)
        {
            this.timer = timer;

            this.path = path;

            //always recreate log file
            app = new Application();
            app.Visible = false;
            
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            wb = app.Workbooks.Add();
            wb.SaveAs(path);
            ws = (Worksheet)wb.Sheets[1];

            line = 1;
        }

        ~LoggerToExcel()
        {
            try
            {
                wb.Close();
                app.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (ws != null)
                Marshal.ReleaseComObject(ws);

            if (wb != null)
                Marshal.ReleaseComObject(wb);

            if (app != null)
                Marshal.ReleaseComObject(app);
        }

        public void Log(string message)
        {
            string datetime = timer.getCurrentTime();
            string[] arr = datetime.Split('|');

            ws.Cells[line, 1]   = arr[0]; //rows columns
            ws.Cells[line, 2]   = arr[1];
            ws.Cells[line++, 3] = message;

            wb.Save();

            Console.WriteLine("{0}|{1}|{2}", arr[0], arr[1], message);
        }
    }
}
