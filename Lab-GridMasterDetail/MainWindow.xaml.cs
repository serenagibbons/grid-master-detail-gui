using Microsoft.Win32;
using System;
using System.Collections;
using System.IO;
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

namespace Lab_GridMasterDetail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string filename = "MovieDataFile3.txt";

            //ReadFromFile(filename);
        }

        private void ListBoxMovie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // clear listview
            listActors.Items.Clear();

            // get the item selected
            IList items = (IList) e.AddedItems;

            // cast as a movie object
            Movie m = (Movie) items[0];

            // set text fields
            txtName.Text = m.Name;
            txtRTS.Text = m.RottenTomatoScore;
            txtReview.Text = m.Review;

            // display poster images
            string fullPathFileName = Environment.CurrentDirectory + "\\" + m.ImageFile;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullPathFileName);
            bitmap.EndInit();
            imagePoster.Source = bitmap;

            // add actors to listview
            for (int i = 0; i < 2; ++i)
            {
                listActors.Items.Add(m.Actors[i]);
            }

        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                ReadFromFile(filename);
            }
        }

        private void SaveAsMenu_Handler(object sender, RoutedEventArgs e)
        {

        }

        private void ExitMenu_Handler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ReadFromFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                // create movie instance
                Movie movie = new Movie();

                movie.Name = sr.ReadLine();
                movie.RottenTomatoScore = sr.ReadLine();
                movie.Review = sr.ReadLine();
                movie.ImageFile = sr.ReadLine();

                // add actors to movie.Actors
                for (int i = 0; i < 2; ++i)
                {
                    Actor a = new Actor();
                    a.FirstName = sr.ReadLine();
                    a.LastName = sr.ReadLine();
                    movie.Actors.Add(a);
                }

                // add movie to listbox
                listBoxMovie.Items.Add(movie);
            }
            sr.Close();
        }
    }
}
