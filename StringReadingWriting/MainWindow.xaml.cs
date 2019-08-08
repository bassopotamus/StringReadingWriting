using System;
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
using System.Data.Entity;
using StringReadingWriting;
using Microsoft.Win32;
using System.Data.Linq;
using System.IO;

namespace StringReadingWriting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtName.Focus();
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var userName = txtUserName.Text;
            var password = txtPassword.Text;

            FileOperations fileWriter = new FileOperations();

            fileWriter.writeToFile(name, userName, password);

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }

        private void BtnReadFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            var dataOpsClass = new DataOperations();

            var allDataFromDB = dataOpsClass.ReturnEntireDatabase();

            tbxUnformattedText.Text = allDataFromDB;

        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            var writeToFile = new DataOperations();

            writeToFile.WriteToFile();

        }

        private void BtnDropTable_Click(object sender, RoutedEventArgs e)
        {
            string okToDropMessage = "Are you sure you want to drop the database table?";
            string msgBoxTitle = "Sure to delete?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult deleteMessage = MessageBox.Show(okToDropMessage, msgBoxTitle, buttons);

            var deleteRows = new DataOperations();
            if(deleteMessage == MessageBoxResult.Yes)
            {
                deleteRows.DropTables();
            }            

        }

        private void BtnOutputSQL_Click(object sender, RoutedEventArgs e)
        {
            var dataOpsClass = new DataOperations();

            var allDataFromDB = dataOpsClass.ReturnEntireDatabase();

            FileOperations fileOps = new FileOperations();

            txtSQL.Text = fileOps.returnSQL(allDataFromDB);
        }

        private void BtnLoadDatabase_Click(object sender, RoutedEventArgs e)
        {
            DataOperations createTable = new DataOperations();
            FileOperations fileInputForSQL = new FileOperations();
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }

            var textForSQL = fileInputForSQL.readFromFile(filePath);

            var sQLForNewDB = fileInputForSQL.returnSQL(textForSQL);

            createTable.WriteToNewDatabase(sQLForNewDB);

        }

        private void BtnReadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                txtFromFile.Text = File.ReadAllText(openFileDialog.FileName);
            }

        }
    }
}
