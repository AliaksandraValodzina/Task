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
        string path = string.Empty;
        string currentItem = string.Empty;
        Assembly assembly;

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
                }
            }
        }

        private void lbAssembles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Current file
            currentItem = lbAssembles.SelectedItem.ToString();

            // Get all classes
            /*var classes = (from t in Assembly.LoadFile(path + @"\" + currentItem).GetTypes()
                          where t.IsClass
                          select t).ToList();*/

            // Get all classes
            assembly = Assembly.LoadFile(path + @"\" + currentItem);
            var classes = assembly.GetTypes()
                                .Where(t => t.IsClass)
                                .ToList();

            // Add class name to listBox
            foreach (var oneClass in classes)
            {
                lbClasses.Items.Add(oneClass);
            }
        }

        private void lbClasses_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Delete all items from listBox
            lbMethods.Items.Clear();

            // Current class
            var currentItem = lbClasses.SelectedItem.ToString();

            // Get type of current class
            var currentClass = assembly.GetTypes()
                                .Where(t => t.FullName.Equals(currentItem))
                                .First();

            // Get fields from current class
            var fields = currentClass.GetFields().ToList();

            // Add field to listBox
            foreach (var field in fields)
            {
                lbMethods.Items.Add(field);
            }

            // Get properties from current class
            var properties = currentClass.GetProperties().ToList();

            // Add properties to listBox
            foreach (var prop in properties)
            {
                lbMethods.Items.Add(prop);
            }

            // Get methods from current class
            var methods = currentClass.GetMethods().ToList();

            // Add methods to listBox
            foreach (var method in methods)
            {
                lbMethods.Items.Add(method);
            }
        }
    }
}
