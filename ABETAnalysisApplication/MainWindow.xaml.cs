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

        private Label dropInstructions = new Label();
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

            List<string> nonCsvFiles = new List<string>();
            List<string> csvFiles = new List<string>();

            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (System.IO.Path.HasExtension(file) && System.IO.Path.GetExtension(file).Equals(".csv"))
                {
                    Console.WriteLine(file + " is valid csv file path");
                    csvFiles.Add(file);

                }
                else
                {
                    nonCsvFiles.Add(file);
                }
               
            }

            
        }

    }
}
