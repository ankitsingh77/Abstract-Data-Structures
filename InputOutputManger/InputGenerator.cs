using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace InputOutputManger
{
    public class InputGenerator
    {
        public int MaxContentLength = UInt16.MaxValue;
        public int MinContentLength = 1;

        public string GenerateIntegerInputFile(string filePath = "")
        {
            return GenerateIntegerInputFile(0, Int32.MaxValue, filePath);
        }

        public string GenerateIntegerInputFile(int MaxValue, string filePath = "")
        {
            return GenerateIntegerInputFile(0, MaxValue, filePath);
        }
        public string GenerateIntegerInputFile(int minvalue, int MaxValue, string filePath = "")
        {
            bool createFile = false;
            if (filePath == string.Empty)
            {
                createFile = true;
                string codeBaseLoaction = Assembly.GetExecutingAssembly().Location;
                string dirPath = codeBaseLoaction.Substring(0, codeBaseLoaction.LastIndexOf('\\')) + "\\InputFiles\\";
                if(!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                filePath = dirPath + DateTime.Now.ToString("ddMMyyyyHHmmss_fff") + ".bin";
            }
            Random randomNumberGenerator = new Random();
            int fileInputLength = randomNumberGenerator.Next(MinContentLength,MaxContentLength);
            StringBuilder builder = new StringBuilder();
            builder.Append(randomNumberGenerator.Next(minvalue,MaxValue));
            for (int i = 0; i < fileInputLength; i++)
            {
                builder.Append(",");
                builder.Append(randomNumberGenerator.Next(minvalue,MaxValue));
            }
            byte[] data = ASCIIEncoding.ASCII.GetBytes(builder.ToString());
            if (createFile)
            {
                using (FileStream stream = File.Create(filePath))
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }
            else
            {
                using (FileStream stream = File.Open(filePath,FileMode.Create,FileAccess.Write))
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }
            return filePath;
        }
    }
}
