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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool preFilesDropped = false;
        LinkedList<String> preFilePaths;
        LinkedList<String> postFilePaths;
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

            LinkedList<String> csvFiles = new LinkedList<string>();
            LinkedList<String> nonCsvFiles = new LinkedList<string>();
            foreach (string file in files)
            {
                if (System.IO.Path.HasExtension(file) && System.IO.Path.GetExtension(file).Equals("csv"))
                {
                    csvFiles.AddLast(file);
                }else
                {
                    nonCsvFiles.AddLast(file);
                }
               
            }



            if (!preFilesDropped)
            {
                preFilePaths = csvFiles;
                dropInstructions.Content = "Drag and Drop Post-SemesterSurvey Files";
                preFilesDropped = true;
            }
            else
            {
                postFilePaths = csvFiles;

                validateFilePairs(preFilePaths, postFilePaths);
            }
        }

        private void validateFilePairs(LinkedList<String> preFilePaths, LinkedList<String> postFilePaths)
        {
            // TODO: Find files based on the course number associated with the survey
            // that are present in both the preFile set and the postFile set
            
        }


    }
}
