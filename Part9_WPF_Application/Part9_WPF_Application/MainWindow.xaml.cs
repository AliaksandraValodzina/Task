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
            // Clear all boxes
            cbItems.Items.Clear();
            tbPath.Clear();
            lbAssembles.Items.Clear();
            lbClasses.Items.Clear();
            lbAttributes.Items.Clear();

            // Folder path
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

            // Add text to comboBox
            cbItems.Items.Add("All");
            cbItems.Items.Add("Fields");
            cbItems.Items.Add("Properties");
            cbItems.Items.Add("Methods");
        }

        private void lbAssembles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Delete all items from listBox
            lbClasses.Items.Clear();

            // Current file
            if (lbAssembles.SelectedItem != null)
            {
                currentItem = lbAssembles.SelectedItem.ToString();
            }

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
            lbAttributes.Items.Clear();

            // Current class
            if (lbClasses.SelectedItem != null)
            {
                var currentClass = lbClasses.SelectedItem as Type;

                this.GetFields(currentClass);
                this.GetMethods(currentClass);
                this.GetProperties(currentClass);
            }
        }

        private void cbItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbItems.SelectedItem != null && lbClasses.SelectedItem != null)
            {
                // Current item
                var currentItem = cbItems.SelectedItem.ToString();

                // Get type of current class
                var currentClass = lbClasses.SelectedItem as Type;

                switch (currentItem)
                {
                    case "All":
                        lbAttributes.Items.Clear();
                        this.GetFields(currentClass);
                        this.GetMethods(currentClass);
                        this.GetProperties(currentClass);
                        break;
                    case "Properties":
                        lbAttributes.Items.Clear();
                        this.GetProperties(currentClass);
                        break;
                    case "Methods":
                        lbAttributes.Items.Clear();
                        this.GetMethods(currentClass);
                        break;
                    case "Fields":
                        lbAttributes.Items.Clear();
                        this.GetFields(currentClass);
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetFields(Type currentClass)
        {
            // Get fields from current class
            var fields = currentClass.GetFields().ToList();

            // Add field to listBox
            foreach (var field in fields)
            {
                lbAttributes.Items.Add(field);
            }
        }

        public void GetProperties(Type currentClass)
        {
            // Get properties from current class
            var properties = currentClass.GetProperties().ToList();

            // Add properties to listBox
            foreach (var prop in properties)
            {
                lbAttributes.Items.Add(prop);
            }
        }

        public void GetMethods(Type currentClass)
        {
            // Get methods from current class
            var methods = currentClass.GetMethods().ToList();

            // Add methods to listBox
            foreach (var method in methods)
            {
                lbAttributes.Items.Add(method);
            }
        }
    }
}
