using System;
using File_Renamer.Classes;

// DISCLAIMER: This program only works if it is called through the CMD passing the desired root directory as (first) parameter!
namespace File_Renamer {
    internal class Program {
        private static void Main(string[] args) {
            // If a file has been loaded...
            if (args.Length > 0) {
                Console.WriteLine("Enter the string you want to remove:");


                //Load files and, if any, rename files using the given string
                BaseFunctions.RemovePartOfFilename(Console.ReadLine(), BaseFunctions.GetFiles(args[0]));
            }
            else {
                Console.WriteLine("Error - no files found.");
            }

            //Keep the console window open to let the user read the output state (task completed OR failed)
            Console.ReadKey();
        }
    }
}