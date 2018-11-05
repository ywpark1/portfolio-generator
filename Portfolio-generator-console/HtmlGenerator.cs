using System;
using System.IO;

namespace Portfolio_generator_console {
    public class HtmlGenerator {

        public static string templateDir = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "templates");
        public static string targetDir = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "portfolio");

        public static void SelectTemplate () {

            // Display the available templates under 'templates' directory
            DirectoryInfo dir = null;
            string[] files = Directory.GetDirectories (templateDir);

            foreach (string s in files) {
                dir = new DirectoryInfo (s);
                System.Console.Write (dir.Name + " ");
            }

            System.Console.WriteLine ();

            // Prompt the user to enter the template name
            // Console.Write ("Please enter the template you want to use : ");
            // var templateName = Console.ReadLine ();
            var templateName = "template1";

            var selectedTemplatePath = Path.Combine (templateDir, templateName);

            // System.Console.WriteLine (targetDir);

            try {
                CopyFiles (selectedTemplatePath, targetDir);
            } catch (Exception ex) {

                System.Console.WriteLine (ex.Message);
            }

            // string[] tempFiles = Directory.GetFiles (sourcePath);
            // string[] tempDirs = Directory.GetDirectories (sourcePath);

            // // System.Console.WriteLine (tempDirs[0]);

            // string fileName = string.Empty;
            // string destFile = string.Empty;

            // foreach (string s in tempFiles) {
            //     // Use static Path methods to extract only the file name from the path.
            //     fileName = Path.GetFileName (s);
            //     destFile = Path.Combine (targetDir, fileName);
            //     File.Copy (s, destFile, true);

            //     System.Console.WriteLine (fileName);
            // }

            // try {
            //     // Copy the files and overwrite destination files if they already exist.
            //     foreach (string s in files) {
            //         // Use static Path methods to extract only the file name from the path.
            //         fileName = Path.GetFileName (s);
            //         // destFile = Path.Combine (targetDir, fileName);
            //         // File.Copy (s, destFile, true);

            //         System.Console.WriteLine (fileName);
            //     }
            // } catch (System.Exception e) {
            //     System.Console.WriteLine (e.Message);
            // }

            // System.Console.WriteLine ("Source path Exists!!");

        }

        // public static void DeleteAllFiles (string path) {
        //     if (Directory.Exists (path)) {
        //         //Delete all files from the Directory
        //         foreach (string file in Directory.GetFiles (path)) {
        //             File.Delete (file);
        //         }
        //         //Delete all child Directories
        //         foreach (string directory in Directory.GetDirectories (path)) {
        //             DeleteAllFiles (directory);
        //         }
        //         //Delete a Directory
        //         Directory.Delete (path);
        //     } else {
        //         Directory.CreateDirectory (path);
        //     }
        // }

        public static void CopyFiles (string src, string dest) {

            if (Directory.Exists (src)) {

                // DeleteAllFiles (dest);

                string[] tempFiles = Directory.GetFiles (src);
                string[] tempDirs = Directory.GetDirectories (src);

                string fileName = string.Empty;
                DirectoryInfo dirName = null;
                string destFile = string.Empty;

                // System.Console.WriteLine ();

                // Copy all files to destination
                foreach (string f in tempFiles) {
                    fileName = Path.GetFileName (f);
                    destFile = Path.Combine (dest, fileName);
                    File.Copy (f, destFile, true);

                    // System.Console.WriteLine (fileName + " is copied to " + dest);
                }
                // System.Console.WriteLine ();

                foreach (string d in tempDirs) {
                    dirName = new DirectoryInfo (d);

                    var srcDirPath = Path.Combine (src, dirName.Name);
                    var destDirPath = Path.Combine (dest, dirName.Name);

                    Directory.CreateDirectory (destDirPath);
                    CopyFiles (srcDirPath, destDirPath);

                    // if (Directory.Exists (destDirPath)) Directory.Delete (destDirPath);

                    // Directory.CreateDirectory (destDirPath);

                    // if (!Directory.Exists (destDirPath)) throw new Exception ("Could not create the directory");

                    // // Copy the files under the sub-directory recursively
                    // CopyFiles (srcDirPath, destDirPath);
                }
            } else {
                throw new Exception ("Source path does not exist!");
            }
        }

        public static void GenerateHtml () {

            // string templatePath = Path.Combine (Directory.GetParent (".").ToString (), "template1", "index.html");
            string templatePath = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "templates", "template1", "index.html");

            // string newFilePath = Path.Combine (Directory.GetParent (".").ToString (), "portfolio", "index.html");
            string newFilePath = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "portfolio", "index.html");

            // System.Console.WriteLine (templatePath);

            // Read HTML from file
            var content = File.ReadAllText (templatePath);

            Console.Write ("Please enter your name : ");
            var yourName = Console.ReadLine ();

            //Replace all values in the HTML
            content = content.Replace ("{YOUR_NAME}", yourName);

            //Write new HTML string to file
            File.WriteAllText (newFilePath, content);

            Console.WriteLine ("\nNew Portfolio html file is successfully generated at : " + newFilePath);

            // System.Diagnostics.Process.Start ("cmd", newFilePath);

        }
    }
}