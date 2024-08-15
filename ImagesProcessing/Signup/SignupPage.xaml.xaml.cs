using DataLayer;
using DataLayer.Context;
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
using System.Windows.Shapes;

namespace ImagesProcessing.Signup
{
    /// <summary>
    /// Interaction logic for SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Window
    {
        private bool isHidden = true;
        public SignupPage()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void hiddenBtn_Click(object sender, RoutedEventArgs e)
        {
            loadButtonImage();
            setPasswordInCorrectFormatInBox();
        }

        private void loadButtonImage()
        {
            var brush = new ImageBrush();
            if (isHidden)
            {
                brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ImagesProcessing;component/Resources/closeeye.png"));
                isHidden = false;
            }
            else
            {
                brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ImagesProcessing;component/Resources/eye.png"));
                isHidden = true;
            }
            hiddenBtn.Background = brush;
        }

        private void setPasswordInCorrectFormatInBox()
        {
            if (!isHidden)
            {
                string passwordContent = pbPassword.Password.ToString();
                string repeatPasswordContent = pbRepeatPassword.Password.ToString();
                pbPassword.Visibility = Visibility.Collapsed;
                pbRepeatPassword.Visibility = Visibility.Collapsed;
                tbPassword.Visibility = Visibility.Visible;
                tbRepeatPassword.Visibility = Visibility.Visible;
                tbPassword.Text = passwordContent;
                tbRepeatPassword.Text = repeatPasswordContent;
            }
            else
            {
                string passwordContent = tbPassword.Text.ToString();
                string repeatPasswordContent = tbRepeatPassword.Text.ToString();
                tbPassword.Visibility = Visibility.Collapsed;
                tbRepeatPassword.Visibility = Visibility.Collapsed;
                pbPassword.Visibility = Visibility.Visible;
                pbRepeatPassword.Visibility = Visibility.Visible;
                pbPassword.Password = passwordContent;
                pbRepeatPassword.Password = repeatPasswordContent;
            }
        }

        private void showLoginPage()
        {
            MainWindow loginPage = new MainWindow();
            this.Close();
            loginPage.ShowDialog();
        }

        private void loginLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showLoginPage();
        }

        private bool checkTheInputs()
        {
            string fullName = tbFullName.Text.Trim();
            string[] email = tbEmail.Text.Trim().Split('@');
            string password = getUserPassword().Trim();
            string repeatPassword = getRepeatPassword().Trim();
            string userName = tbUsername.Text.Trim();
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Full name is empty", "wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (email.Length != 2 || email[1].ToLower() != "gmail.com")
            {
                MessageBox.Show("Email is incorrect", "wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User name is empty", "wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is empty", "wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (repeatPassword != password)
            {
                MessageBox.Show("Password and it's repetition don't match", "wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;

        }

        private string getUserPassword()
        {
            if (isHidden)
            {
                return pbPassword.Password.ToString();
            }
            return tbPassword.Text;
        }

        private string getRepeatPassword()
        {
            if (isHidden)
            {
                return pbRepeatPassword.Password.ToString();
            }
            return tbRepeatPassword.Text;
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!checkTheInputs())
                return;
            Login_DT person = new Login_DT()
            {
                Email = tbEmail.Text,
                FullName = tbFullName.Text,
                Password = getUserPassword(),
                UserName = tbUsername.Text
            };
            DependencyInjection db = new DependencyInjection();
            if (db.GetLoginRepository.AddNewPerson(person))
            {
                MessageBox.Show("Registering was successful", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                showLoginPage();
                db.Save();
            }
            db.Dispose();
        }
    }
}
