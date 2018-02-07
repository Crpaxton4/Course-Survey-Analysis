using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ABETAnalysisApplication
{

    /**
     * TODO: Make this into a MVVM program so that functional 
     * programming is not imposted on this program that cannot be 
     * functional without being absolute cancer.
     * 
     * This is a terrible program right now. 
     */
     
    /// <summary>
    /// Interaction logic for MainWindow.xaml and file path parsing to create complementary pairs of pre-semester and post-semester survey result csv files
    /// </summary>
    public partial class MainWindow : Window
    {

        bool preFilesDropped = false;
        List<String> preFilePaths = new List<string>();
        List<String> postFilePaths = new List<string>();
        Label dropInstructions = new Label();
        public MainWindow()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(MainWindow_DragEnter);
            this.Drop += new DragEventHandler(MainWindow_DragDrop);

            dropInstructions.Name = "DropInstructions";
            dropInstructions.HorizontalContentAlignment = HorizontalAlignment.Center;
            dropInstructions.Content = "Drag and Drop Pre-SemesterSurvey Files";
            MainPanel.Children.Add(dropInstructions);
            
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs evArgs)
        {
            if (evArgs.Data.GetDataPresent(DataFormats.FileDrop)) evArgs.Effects = DragDropEffects.Copy;

        }

        private void MainWindow_DragDrop(object sender, DragEventArgs evArgs)
        {

            // TODO: verify that the csv files also have a course number associated with them
            string[] files = (string[])evArgs.Data.GetData(DataFormats.FileDrop);

            List<String> nonCsvFiles = new List<string>();
            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (System.IO.Path.HasExtension(file) && System.IO.Path.GetExtension(file).Equals(".csv"))
                {
                    Console.WriteLine(file + " is valid csv file path");
                    if (!preFilesDropped)
                    {
                        preFilePaths.Add(file);
                    }
                    else
                    {
                        postFilePaths.Add(file);
                    }

                }
                else
                {
                    nonCsvFiles.Add(file);
                }
               
            }

            // Log the invalid files to the console
            Console.WriteLine("Invalid Files:");
            if (nonCsvFiles.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (string file in nonCsvFiles)
                {
                    Console.WriteLine(file);
                }
            }

            // if post files need to be dropped do that
            // else check the entered file paths and parse them for analysis
            if (!preFilesDropped)
            {
                preFilesDropped = true;
                dropInstructions.Content = "Drag and Drop Post-SemesterSurvey Files";

            }
            else
            {
                validateFilePairs();

            }

            
        }

        private void validateFilePairs()
        {

            Console.WriteLine("Validation | Number of pre files: " + preFilePaths.Count);
            Console.WriteLine("Validation | Number of post files: " + postFilePaths.Count);

            List<string> singletonFiles = new List<string>();
            List<PathPair> pathPairs = new List<PathPair>();

            for(int i = 0; i < preFilePaths.Count; i++)
            {
                int preFileIndex = i;
                int postFileIndex = postFilePaths.IndexOf(preFilePaths.ElementAt(preFileIndex));

                // postFileIndex = -1 when not in postFilePaths list
                if(postFileIndex < 0)
                {
                    singletonFiles.Add(preFilePaths.ElementAt(preFileIndex));
                    break;
                }

                pathPairs.Add(new PathPair(preFilePaths.ElementAt(preFileIndex), postFilePaths.ElementAt(postFileIndex)));

                postFilePaths.RemoveAt(postFileIndex);

            }

            Console.WriteLine("Done");

            foreach(PathPair pair in pathPairs)
            {
                Console.WriteLine("Pair | Pre File: " + pair.prePath + " -- Post File: " + pair.postPath);
            }
        }


    }
}
