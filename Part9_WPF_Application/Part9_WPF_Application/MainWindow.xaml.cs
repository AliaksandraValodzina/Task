using System.Windows;
using System.Windows.Forms;
using System.IO;

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
                }
            }


        }
    }
}
