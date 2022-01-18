
using DiaryApp.Controlers;
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
using ContentControl = DiaryApp.Controlers.ContentControl;

namespace DiaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Paths P = new Paths();
        Main main = new Main();
        public MainWindow()
        {
            InitializeComponent();
            View.Content = main;
            Info.Text = "Home button refresh the window.";
        }

        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            View.Content = new ContentControl(P.NotesFile);
            Info.Text = "Home button refresh the window. Just basic notificationss here.";
        }
    

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            View.Content = new ContentControl(P.FoodFile);
            Info.Text = "Home button refresh the window. Something about diet.";
        }

        private void Sport_Click(object sender, RoutedEventArgs e)
        {
            View.Content = new ContentControl(P.SportFile);
            Info.Text = "Home button refresh the window. Sport exercise page. You can make it " +
                "diary about your exercises.";
        }

        private void Music_Click(object sender, RoutedEventArgs e)
        {
            View.Content = new ContentControl(P.MusicFile);
            Info.Text = "Home button refresh the window. Music exercise page.";
        }

        private void Work_Click(object sender, RoutedEventArgs e)
        {
            View.Content = new ContentControl(P.WorkFile);
            Info.Text = "Home button refresh the window. Work notifications here.";
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            Close();
        }

        private void Y_Clock_Click(object sender, RoutedEventArgs e)
        {
            View.Content = new YearControl();
            Info.Text = "Week calendar";
        }

        private void Sleep_Click(object sender, RoutedEventArgs e)
        {
            View.Content = new ContentControl(P.SleepFile);
            Info.Text = "Home button refresh the window. This page you can use sleeping or dream diary.";
        }
    }
}
