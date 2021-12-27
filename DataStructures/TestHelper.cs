using System.Collections.Generic;
using System.IO;

namespace DataStructures.TestTxt
{
    //辅助测试类
    public class TestHelper
    {
        //读取名为fileName的文件，并将它分词，分词后存入list中，最后返回使用
        public static List<string> ReadFile(string fileName)
        {
            //使用FileStream类打开fileName文件
            var fs = new FileStream(fileName, FileMode.Open);
            //使用StreamReader类读取fileName文件信息
            var sr = new StreamReader(fs);
            //将读取的单词存入words动态数组中
            var words = new List<string>();

            //分词操作，这是一个非常简陋的分词方式
            //只要单词拼写不一样，我们就认为是不同的单词（不考虑单词的词性和时态）
            //没有读取到fileName的末尾，就while继续读取
            while (!sr.EndOfStream)
            {
                //读取一行字符串并除去字符串的头部和尾部的空白符号，存储在contents中
                var contents = sr.ReadLine()?.Trim();
                //寻找contents第一个字母的位置
                var start = FirstChacaterIndex(contents, 0);
                //开始分词逻辑，将一个个单词存储在动态数组words中
                if (contents == null) continue;
                for (var i = start + 1; i < contents.Length;)
                {
                    if (i == contents.Length || !char.IsLetter(contents[i]))
                    {
                        var word = contents.Substring(start, i - start).ToLower();
                        words.Add(word);
                        start = FirstChacaterIndex(contents, i);
                        i = start + 1;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            //关闭流对象，释放资源
            sr.Close();
            fs.Close();
            return words;
        }

        //在字符串str中，寻找从start位置开始的第一个字母字符的位置
        private static int FirstChacaterIndex(string str, int start)
        {
            for (var i = start; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    return i;
                }
            }

            return str.Length;
        }
    }
}