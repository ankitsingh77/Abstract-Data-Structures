using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Abstract_Data_Structures;

namespace InputOutputManger
{
    public class InputStream
    {
        public static List<string> GetInputFiles()
        {
            string executionPath = Assembly.GetExecutingAssembly().Location;
            List<string> filePaths = new List<string>();
            if (Directory.Exists(executionPath + "\\InputFiles\\"))
            {
                DirectoryInfo dir = new DirectoryInfo(executionPath + "\\InputFiles");
                var filesList = dir.GetFiles();
                foreach (var file in filesList ?? Enumerable.Empty<FileInfo>())
                {
                    filePaths.Add(file.FullName);
                }
            }
            return filePaths;
        }

        public static MyList<int> ReadFileAsMyList(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            MyList<int> list = new MyList<int>();
            using (FileStream inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] inputArray = new byte[inputStream.Length];
                inputStream.Read(inputArray, 0, inputArray.Length);
                string inputvalues = ASCIIEncoding.ASCII.GetString(inputArray);
                string[] values = inputvalues.Split(',');
                foreach (var value in values ?? Enumerable.Empty<string>())
                {
                    int number;
                    if (int.TryParse(value, out number))
                    {
                        list.AddNodeAtEnd(new Node<int> { NodeContent = number });
                    }
                }
            }
            return list;
        }

        public static DLL<int> ReadFileAsDLL(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            DLL<int> list = new DLL<int>();
            using (FileStream inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] inputArray = new byte[inputStream.Length];
                inputStream.Read(inputArray, 0, inputArray.Length);
                string inputvalues = ASCIIEncoding.ASCII.GetString(inputArray);
                string[] values = inputvalues.Split(',');
                foreach (var value in values ?? Enumerable.Empty<string>())
                {
                    int number;
                    if (int.TryParse(value, out number))
                    {
                        list.Add(number);
                    }
                }
            }
            return list;
        }

        public static CLL<int> ReadFileAsCLL(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            CLL<int> list = new CLL<int>();
            using (FileStream inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] inputArray = new byte[inputStream.Length];
                inputStream.Read(inputArray, 0, inputArray.Length);
                string inputvalues = ASCIIEncoding.ASCII.GetString(inputArray);
                string[] values = inputvalues.Split(',');
                foreach (var value in values ?? Enumerable.Empty<string>())
                {
                    int number;
                    if (int.TryParse(value, out number))
                    {
                        list.Insert(number,false);
                    }
                }
            }
            return list;
        }
    }
}
