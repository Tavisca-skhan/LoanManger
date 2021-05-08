using Geektrust.Services;
using System;
using System.IO;

namespace Geektrust
{
    partial class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = string.Empty;
                if (args != null && args.Length > 0)
                {
                     filename = args[0];
                   
                }
                else
                {
                    string rootPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + @"\sample_io";
                    string[] filePaths = Directory.GetFiles(rootPath, "*.txt", SearchOption.TopDirectoryOnly);
                    filename = filePaths[0];
                }
                var lines = File.ReadAllLines(filename);
                var bankingService = new BankingService();
                var bankingManager = new BankingManager(bankingService);
                bankingManager.Executes(lines);
                //Console.ReadKey();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFound Exception :{ex.ToString()}");
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }

}
