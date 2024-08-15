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
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Media.Imaging;
using System.IO;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Drawing;
using DataLayer;
using DataLayer.Context;
using DataLayer.Repositories;
using ImagesProcessing.Images;

namespace ImagesProcessing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isHidden = true;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
                pbPassword.Visibility = Visibility.Collapsed;
                tbPassword.Visibility = Visibility.Visible;
                tbPassword.Text = passwordContent;
            }
            else
            {
                string passwordContent = tbPassword.Text.ToString();
                tbPassword.Visibility = Visibility.Collapsed;
                pbPassword.Visibility = Visibility.Visible;
                pbPassword.Password = passwordContent;
            }
        }

        private void hiddenBtn_Click(object sender, RoutedEventArgs e)
        {
            loadButtonImage();
            setPasswordInCorrectFormatInBox();
        }

        private void signupLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Signup.SignupPage signupPage = new Signup.SignupPage();
            this.Close();
            signupPage.Show();
        }

        private string getUserPassword()
        {
            if (isHidden)
            {
                return pbPassword.Password.ToString();
            }
            return tbPassword.Text;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            using (DependencyInjection db = new DependencyInjection())
            {
                if (!db.GetLoginRepository.tryToLogin(tbUserName.Text.ToString(), getUserPassword()))
                    MessageBox.Show("User name or password is incorrect", "Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    ImagesPage imagesPage = new ImagesPage();
                    this.Close();
                    imagesPage.ShowDialog();
                }
            }
        }
    }
}