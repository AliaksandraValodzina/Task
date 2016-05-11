using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System;
using System.Linq;

namespace Part9_WPF_Application
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

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            var path = string.Empty;

            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
            }

            if (path != string.Empty)
            {
                // Get path to .dll files 
                var fileArray = Directory.GetFiles(path, "*.dll");

                // Add path to textBox
                tbPath.Text = path;

                // Get fileName and add to ListBox
                foreach (var file in fileArray)
                {
                    var fileName = Path.GetFileName(file);
                    lbAssembles.Items.Add(fileName);

                    //Assembly assembly = Assembly.ReflectionOnlyLoadFrom(file);
                    
                    //var listOfTypes = assembly.ExportedTypes.ToList();

                    //var typeName = typeof();

                    //var methods = typeName.GetMethods().ToList();
                }
            }
        }

        /*private void lbAssembles_SelectionChanged(object sender, System.EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string curItem = listBox1.SelectedItem.ToString();

            // Find the string in ListBox2.
            int index = listBox2.FindString(curItem);
            // If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
            if (index == -1)
                MessageBox.Show("Item is not available in ListBox2");
            else
                listBox2.SetSelected(index, true);
        }*/

        private void lbAssembles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Current item
            string currentItem = lbAssembles.SelectedItem.ToString();

            
        }
    }
}
