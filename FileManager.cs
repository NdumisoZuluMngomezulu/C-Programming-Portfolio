using System;
using System.IO;

public class SimpleFileManager
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Simple File Manager");
        Console.WriteLine("-------------------");

        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine($"Current Directory: {currentDirectory}\n");

        DisplayDirectoryContents(currentDirectory);

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }

    public static void DisplayDirectoryContents(string path)
    {
        try
        {
            Console.WriteLine("Directories:");
            string[] directories = Directory.GetDirectories(path);
            foreach (string dir in directories)
            {
                Console.WriteLine($"  <DIR> {Path.GetFileName(dir)}");
            }

            Console.WriteLine("\nFiles:");
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                Console.WriteLine($"  {fileInfo.Name} ({fileInfo.Length} bytes)");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied to this directory.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
