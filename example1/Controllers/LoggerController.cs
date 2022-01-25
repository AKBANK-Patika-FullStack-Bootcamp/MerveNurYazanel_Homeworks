using Microsoft.AspNetCore.Mvc;

namespace example1.Controllers
{

    public class LoggerController: ControllerBase
    {
        string _path = @"E:\PROJECTS\akbank_bootcamp\dersler\h1\others\example1 - Copy\example1\log\";
        string _fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

        public void createLog(string message)
        {
            FileStream fs = new FileStream(_path+_fileName, FileMode.Append,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() +": "+ message);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
