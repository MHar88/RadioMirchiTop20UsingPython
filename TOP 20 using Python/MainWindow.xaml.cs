using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections;
using System.Collections.ObjectModel;


namespace TOP_20_using_Python
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string file = null;
        public static ObservableCollection<Songs> person=new ObservableCollection<Songs>();
        public MainWindow()
        {
            InitializeComponent();
        }
   private void Button_Click(object sender, RoutedEventArgs e)
        {
            string file = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = "Json";
            dlg.Filter = "Json Files (*.Json)|*.Json";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
               // Open document 
                file = dlg.FileName;
            }         
         if (file.Length != 0)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string json = reader.ReadToEnd();                 
                    var res = JsonConvert.DeserializeObject<ResRoot>(File.ReadAllText(file));
                    foreach (var item in res.Files)
                    {
                        person.Add(new Songs { Movie = item.Value.Movie , SongTitle = item.Value.SongTitle, Artist = item.Value.Artist, Rank = item.Value.Rank });                    
                    }
                }
                grdNames.ItemsSource = person;
            }           
        }
    }
    
    public class Songs
    {
        public string Movie { get; set; }
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Rank { get; set; }
    }
    public class ResRoot
    {
        public Dictionary<string, Songs> Files { set; get; }
    }
}

 
