using System.IO;
using System.Text;

namespace VisionLabCSVReformattingTool
{
    class Program
    {
        public static readonly string folderPath = @"C:\\Users\\jenanderson\\Downloads\\8CPD";
        static void Main(string[] args)
        {
            var origFiles = new DirectoryInfo(folderPath).GetFiles("*.csv");

            foreach (var file in origFiles)
            {
                
                var str = new StringBuilder();
                var csv = new StringBuilder();
                csv.Append("Angle,Location,Correct\n");
            
                using (var reader = new StreamReader(file.FullName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        foreach(var v in values)
                        {
                           var element = v.Trim().Replace(' ', ',');
                            str.Append(element+",");
                        }

                        string[] elements = str.ToString().Split(',');

                        

                        int i = 0;
                        foreach (var e in elements)
                        {
                            i++;
                            csv.Append(e+",");
                            if (i % 3 == 0)
                            {
                                csv.Append("\n");
                            }
                            
                        }

                    }
                }
                string outpath = folderPath + "\\Reformatted\\";
                Directory.CreateDirectory(Path.GetDirectoryName(outpath));
                File.WriteAllText(outpath+""+file.Name, csv.ToString());


            }
        }
    }
}
