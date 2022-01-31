using System;
using System.IO;

namespace TaskA
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;

            while (exit == 0)
            {
                Console.Write("Please enter a directory path: ");
                string dir = Console.ReadLine();

                Console.Write("Please enter a date, any text files older than this date will be deleted: ");
                string date = Console.ReadLine();

                try
                {
                    string[] fileList = Directory.GetFiles(dir, "*.txt");
                    DateTime comparedDate = DateTime.Parse(date);

                    if (fileList.Length == 0)
                        Console.WriteLine("There is no text file found.");
                    else
                    {
                        foreach (var file in fileList)
                        {
                            DeleteFile(comparedDate, file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("");
                Console.Write("Try again? (Press n to exit.) ");
                if (Console.ReadKey().Key == ConsoleKey.N)
                    exit = 1;
                else
                    Console.WriteLine("");
            }
        }

        static void DeleteFile(DateTime date, string file)
        {
            FileInfo fileInfo = new FileInfo(file);

            if (fileInfo.CreationTime < date && fileInfo.Extension == ".txt")
            {
                try
                {
                    File.Delete(file);
                    Console.WriteLine($"File {fileInfo.FullName} has been deleted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured.", ex);
                }
            }
        }
    }
}
