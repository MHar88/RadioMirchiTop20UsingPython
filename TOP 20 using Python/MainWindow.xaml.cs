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
       
       
        public System.Data.DataTable readJson(string filePath)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
            {
                string strLine = sr.ReadLine();

                string[] strArray = strLine.Split(',');
              
                    dt.Columns.Add("Song List");
                   
                System.Data.DataRow dr = dt.NewRow();

               
                   
                   
                    foreach (string s in strArray)
                    {
                        string[] value = s.Split(':');
                        dt.Rows.Add(value[1].Replace("</h2>",null).Replace("<h2>",null));
                    }
                
            }
            return dt;
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

                DataTable datasource = readJson(file);

                person.Clear();


                foreach (DataRow dr in datasource.Rows)
                    {
                   


                    person.Add(new Songs { Name = dr[0].ToString() });
                            

                        

                       
                   }
                grdNames.ItemsSource = person;
            }

            




        }
    }
    public class Songs
    {
        public string Name { get; set; }
    }
}

 