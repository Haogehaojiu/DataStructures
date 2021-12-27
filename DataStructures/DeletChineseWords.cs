using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace DataStructures
{
    public class DeletChineseWords
    {
        public void WriteContext(string Context, string path)
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
        //删除汉字
        public static string Del(string str)
        {
            var retValue = str;
            if (System.Text.RegularExpressions.Regex.IsMatch(str, @"[\u4e00-\u9fa5]"))
            {
                retValue = string.Empty;
                var strsStrings = str.ToCharArray();
                for (var index = 0; index < strsStrings.Length; index++)
                {
                    if (strsStrings[index] >= 0x4e00 && strsStrings[index] <= 0x9fa5)
                    {
                        continue;
                    }

                    retValue += strsStrings[index];
                }
            }

            return retValue;
        }
    }
}