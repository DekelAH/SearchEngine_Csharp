using Search_Method_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 dll = new Class1(); // dll connection
            const int SearchByFile = 1;
            const int SearchByParentDirectory = 2;
            const int ExitProgram = 3;

            string _direction = "C:\\";
            string _file; // file name
            int _choice; // user choice
            bool _exit = false; // quit program

            do
            {
                dll.FilesFound += Dll_filesFound;
                dll.AlertMsg += Dll_AlertMsg;
                dll.FileNotFound += Dll_FileNotFound;

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine("Welcom to File Searcher!\nProbably the best search engine in the world.\n");
                    Console.WriteLine("Please choose one of the following actions:\n1.Search by file name.\n2.Search by parent directory & folder name.\n3.Exit");
                    _choice = int.Parse(Console.ReadLine());

                    switch (_choice)
                    {
                        case SearchByFile:
                            Console.Clear();
                            Console.Write("Please enter the file name: ");
                            _file = Console.ReadLine();
                            Console.WriteLine("The search has begun!\n");
                            dll.SaveSearchData(_direction, _file);
                            Console.WriteLine("\nThe search has ended..");
                            System.Threading.Thread.Sleep(4200);
                            break;
                        case SearchByParentDirectory:
                            Console.Clear();
                            Console.Write("Please enter the parent directory name: ");
                            _direction = _direction + Console.ReadLine();
                            Console.Write("Please enter the file name: ");
                            _file = Console.ReadLine();
                            Console.WriteLine("The search has begun!\n");
                            dll.SaveSearchData(_direction, _file);
                            Console.WriteLine("\nThe search has ended..");
                            System.Threading.Thread.Sleep(4200);
                            break;
                        case ExitProgram:
                            _exit = true;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception inputError)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + inputError.Message + "\nPlease insert one of the options at the menu.");
                    System.Threading.Thread.Sleep(3200);
                }

            } while (!_exit);
        }


        private static void Dll_FileNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("We're sorry, we could'nt find your desired files... :/\nPlease try again :)"); ;
        }

        private static void Dll_AlertMsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error!\nWe have encounterd a serious issue, someone entered an empty string or an invalid input.\nLet's try again. ");
        }

        private static void Dll_filesFound(string result)
        {
            Console.WriteLine($"File found: {result}");
        }
    }
}
