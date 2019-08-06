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
            Random randomNumber = new Random();

            using (var dbPasswordContext = new PasswordsDbContext())
            {
                var userNamePassword = new Password() { Name = name, UserName = userName, NewPass = password };

                dbPasswordContext.Passwords.Add(userNamePassword);
                dbPasswordContext.SaveChanges();

            }

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
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
    }
}
