using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace Portfolio_generator_console {
    public class HtmlGenerator {

        public static string templateDir = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "templates");
        public static string targetDir = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "portfolio");

        private const string Document = @"---
            phoneNum:    111-111-111
            date:        2007-08-06
            customer:
                given:   Dorothy
                family:  Gale

            skills:
                - language:   C++
                  descrip:   Water Bucket (Filled)

                - language:   Java
                  descrip:   High Heeled ""Ruby"" Slippers

            bill-to:  &id001
                street: |
                        123 Tornado Alley
                        Suite 16
                city:   East Westville
                state:  KS

            ship-to:  *id001

            specialDelivery:  >
                Follow the Yellow Brick
                Road to the Emerald City.
                Pay no attention to the
                man behind the curtain.
...";
        public static void SelectTemplate () {

            // Display the available templates under 'templates' directory
            DirectoryInfo dir = null;
            string[] files = Directory.GetDirectories (templateDir);

            foreach (string s in files) {
                dir = new DirectoryInfo (s);
                Console.Write (dir.Name + " ");
            }

            Console.WriteLine ();

            // Prompt the user to enter the template name
            Console.Write ("Please enter the template you want to use : ");
            var templateName = Console.ReadLine ();
            // var templateName = "template1";

            var selectedTemplatePath = Path.Combine (templateDir, templateName);

            try {
                Console.WriteLine ("\nYou selected '" + templateName + "'.");
                CopyFiles (selectedTemplatePath, targetDir);
            } catch (Exception ex) {
                throw ex;
            }

        }

        /// <summary>
        /// Delete all files and directories if exists.
        /// </summary>
        /// <param name="path">Directory path for delete</param>
        public static void DeleteFiles (string path) {
            if (Directory.Exists (path)) {

                //Delete all files in the Directory
                foreach (string file in Directory.GetFiles (path)) {
                    File.Delete (file);
                }

                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories (path)) {
                    DeleteFiles (directory);
                }

                //Delete a Directory
                Directory.Delete (path);
            }
        }

        /// <summary>
        /// Copy files if source path files exist; raise the exception if not.
        /// </summary>
        /// <param name="src">Source path of the directory</param>
        /// <param name="dest">Destination path of the directory</param>
        public static void CopyFiles (string src, string dest) {

            if (Directory.Exists (src)) {

                DeleteFiles (dest);

                if (!Directory.Exists (dest)) {
                    Directory.CreateDirectory (dest);
                }

                string[] tempFiles = Directory.GetFiles (src);
                string[] tempDirs = Directory.GetDirectories (src);

                string fileName = string.Empty;
                DirectoryInfo dirName = null;
                string destFile = string.Empty;

                // Copy all files to destination
                foreach (string f in tempFiles) {
                    fileName = Path.GetFileName (f);
                    destFile = Path.Combine (dest, fileName);
                    File.Copy (f, destFile, true);
                }

                // Copy all directories to destination
                foreach (string d in tempDirs) {
                    dirName = new DirectoryInfo (d);

                    var srcDirPath = Path.Combine (src, dirName.Name);
                    var destDirPath = Path.Combine (dest, dirName.Name);

                    Directory.CreateDirectory (destDirPath);
                    CopyFiles (srcDirPath, destDirPath);
                }
            } else {
                throw new Exception ("Source path does not exist!");
            }
        }

        /// <summary>
        /// Generate HTML file
        /// </summary>
        public static void GenerateHtml () {

            try {
                SelectTemplate ();

                string templatePath = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "templates", "template1", "index.html");
                string newFilePath = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "portfolio", "index.html");

                // Read HTML from file
                var content = File.ReadAllText (templatePath);

                Console.WriteLine ();
                Console.Write ("Please enter your name : ");
                var yourName = Console.ReadLine ();


                var input = new StringReader(Document);

			    // Load the stream
			    var yaml = new YamlStream();
			    yaml.Load(input);


			    // Examine the stream
			    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

			    foreach (var entry in mapping.Children){
				    Console.WriteLine(((YamlScalarNode)entry.Key).Value);
			    }

			    // List all the items
			    var skills = (YamlSequenceNode)mapping.Children[new YamlScalarNode("skills")];
			    foreach (YamlMappingNode skill in skills){
				    Console.WriteLine(
					    "{0}\t{1}",
					    skill.Children[new YamlScalarNode("language")],
					    skill.Children[new YamlScalarNode("descrip")]
				    );
			    }



                //Replace all values in the HTML
                content = content.Replace ("{YOUR_NAME}", yourName);
                content = content.Replace ("{skill}", skills.ToString());


                //Write new HTML string to file
                File.WriteAllText (newFilePath, content);

                Console.WriteLine ("\nNew Portfolio html file is successfully generated at : " + newFilePath);
            } catch (Exception e) {
                Console.WriteLine (e.Message);
            }
        }
    }
}