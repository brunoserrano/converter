using System;
using System.Collections.Generic;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using Word.Converters;

namespace WpfApp1
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

        private void Button_ToBase64_Click(object sender, RoutedEventArgs e)
        {
            var filePath = AskForFile();
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            var converter = new WordToBase64();

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    TextBoxResult.Text = converter.ConvertFile(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string AskForFile()
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = false
            };

            dialog.ShowDialog(this);
            try
            {
                if (string.IsNullOrEmpty(dialog?.FileName))
                {
                    return null;
                }

                return dialog.FileName;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
