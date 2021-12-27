using System.IO;

namespace DataStructures
{
    public class EditTxt
    {
        public void WriteContext(string Context,string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(Context);
            sw.Close();
            sw.Dispose();
        }
        private string ReadContext(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string context = sr.ReadToEnd();
            fs.Close();
            sr.Close();
            sr.Dispose();
            fs.Dispose();
            return context;
        }
    }
}