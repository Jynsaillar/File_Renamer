using System;
using System.Collections.Generic;
using System.IO;

namespace File_Renamer.Classes {
    public static class BaseFunctions {
        /// <summary>
        ///     Returns a list of files with full path names as strings.
        /// </summary>
        /// <param name="dir">Root directory pointing to the location of the files to be returned.</param>
        /// <returns></returns>
        public static List<string> GetFiles(string dir) {
            var files = new List<string>();

            try {
                // If a valid path parameter has been passed into the function
                if (!string.IsNullOrEmpty(dir))
                    if (Directory.Exists(Path.GetDirectoryName(dir)))
                        files.AddRange(Directory.GetFiles(Path.GetDirectoryName(dir)));
            }
            catch (Exception E) {
                Console.WriteLine(E.Message, "Error - no files found");
            }

            return files;
        }

        /// <summary>
        ///     Method to trim part of a file's name for all files in a list.
        /// </summary>
        /// <param name="partToRemove">String to be removed.</param>
        /// <param name="files">A list containing all valid files.</param>
        public static void RemovePartOfFilename(string partToRemove, List<string> files) {
            // If the list isn't empty, do...
            if (files != null) {
                // Counter needed to display how many invalid/non-matching files were skipped after renaming all valid files
                var skipped = 0;

                // Loop through all given files
                foreach (var file in files)
                    // If part of a files' name matches partToRemove: Print debug information to the console (current file path and modified file path)
                    if (file.Contains(partToRemove)) {
                        Console.WriteLine("Current path:\n{0}", file);

                        var newPath = Path.GetDirectoryName(file) + "\\" + Path.GetFileName(file).Replace(partToRemove, "");

                        Console.WriteLine("New path:\n{0}", newPath);

                        File.Move(file, newPath);
                    }
                    // Increment counter of skipped files
                    else {
                        skipped++;
                    }

                // Debug feedback/confirmation
                Console.WriteLine("\nFile count: {0}, {1} skipped -- Task complete.", files.Count, skipped);
            }
            else {
                Console.WriteLine("Task failed.");
            }
        }
    }
}