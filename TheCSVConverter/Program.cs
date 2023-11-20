using System.IO;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string directory = @"" + Console.ReadLine();
        directory = directory.Trim('"');        

        try
        {           

            var csvFiles = Directory.EnumerateFiles(directory, "*.csv");

            foreach (string file in csvFiles)
            {
                var fileContent = File.ReadAllText(file);
                if (fileContent.Contains('|')) fileContent = fileContent.Replace('|', ',');
                if (fileContent.Contains("User8,")) fileContent = fileContent.Replace("User8,", "");
                if (fileContent.Contains(",,")) fileContent = fileContent.Replace(",,", ",");
                File.WriteAllText(file, fileContent);
            }

        } catch (Exception e)
        {
            throw new Exception(e.Message);
        }        
    }
}