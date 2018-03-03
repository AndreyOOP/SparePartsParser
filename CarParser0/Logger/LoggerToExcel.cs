using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CarParser0.Logger
{
    public class LoggerToExcel : ILogger //, IDisposable
    {
        Workbook wb;
        Application app;
        Worksheet ws;
        string path;

        ITimeProvider timer;
        int line = 1;

        public LoggerToExcel(string path, ITimeProvider timer)
        {
            this.timer = timer;

            this.path = path;


            app = new Application();

            app.Visible = false;

            wb = app.Workbooks.Open(path);

            ws = (Worksheet)wb.Sheets[1];
        }

        ~LoggerToExcel()
        {
            //Dispose();
            try
            {
                wb.Close();
                app.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (ws != null) Marshal.ReleaseComObject(ws);
            if (wb != null) Marshal.ReleaseComObject(wb);
            if (app != null) Marshal.ReleaseComObject(app);
        }

        //public void Dispose()
        //{
        //    wb.Close();
        //    app.Quit();

        //    if (ws != null) Marshal.ReleaseComObject(ws);
        //    if (wb != null) Marshal.ReleaseComObject(wb);
        //    if (app != null) Marshal.ReleaseComObject(app);
        //}

        //public void Dispose2()
        //{
        //    wb.Close();
        //    app.Quit();

        //    if (ws != null) Marshal.ReleaseComObject(ws);
        //    if (wb != null) Marshal.ReleaseComObject(wb);
        //    if (app != null) Marshal.ReleaseComObject(app);
        //}

        public void Log(string message)
        {
            
            string datetime = timer.getCurrentTime();
            string[] arr = datetime.Split('|');

            ws.Cells[line, 1] = arr[0]; //rows columns
            ws.Cells[line, 2] = arr[1]; //rows columns
            ws.Cells[line++, 3] = message; //rows columns

            wb.Save();
        }
    }
}
