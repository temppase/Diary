using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DiaryApp.Controlers
{
    /// <summary>
    /// Interaction logic for YearControl.xaml
    /// </summary>
    public partial class YearControl : UserControl
    {
        string y = "";
        Paths P = new Paths();
        YearClock clock = new YearClock();
        int W = 0;
        public YearControl()
        {
            InitializeComponent();
            FirstLine();
            aText.Height = 0;
            OK.Height = 0;
            Cancel.Height = 0;
            List<string> years = new List<string>();
            for (int i = 2020; i <= DateTime.Now.Year +1; i++)
            {
                years.Add(i.ToString());
            }
            Y_Select.ItemsSource = years;
        }

        private void Y_Select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = Y_Select.SelectedValue;
            y = $"{p}";
            FirstLine();
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            aText.Height = 40;
            OK.Height = 40;
            Cancel.Height = 40;
            if (!File.Exists(P.YearClock + $"year-{y}.csv"))
            {
                aText.Text = $"Create year {y}";
                //clock.CreateYear(y); 
            }
            else
            {
                aText.Text = $"Delete year {y}";
                //File.Delete(P.YearClock + $"year-{y}.csv");
            }
            FirstLine();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            YearModel S = new YearModel(W, U_Text.Text);
            clock.EditWeek(y, S);
            Y_Select.Height = 0;
            Update.Height = 0;
            FirstLine();
        }
        private void MyGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YearModel M;
            M = (YearModel)MyGrid.SelectedItem;
            U_Text.Text = M.Note;
            U_Text.Height = double.NaN;
            Update.Height = 40;
            Update.Content = $"Week:{M.Week}";
            Action.Height = 0;
            Y_Select.Height = 0;
            W = M.Week;
        }
        public void FirstLine()
        {
            if (Y_Select.SelectedItem == null)
            {
                Action.Height = 0;
            }
            else
            {
                Action.Height = 40;
            }
            Y_Select.Height = 40;
            if (!File.Exists(P.YearClock + $"year-{y}.csv"))
            {
                Action.Content = $"Create: {y}";
                Action.Background = Brushes.LightBlue;
                MyGrid.Height = 0;
            }
            else
            {
                Action.Content = $"Delete: {y}";
                Action.Background = Brushes.Salmon;
                MyGrid.Height = double.NaN;
            }
            U_Text.Height = 0;
            MyGrid.ItemsSource = clock.ReadYear(y);
            CollectionViewSource.GetDefaultView(MyGrid.ItemsSource).Refresh();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            aText.Height = 0;
            OK.Height = 0;
            Cancel.Height = 0;
            if (!File.Exists(P.YearClock + $"year-{y}.csv"))
            {
                aText.Text = $"";
                clock.CreateYear(y); 
            }
            else
            {
                aText.Text = $"";
                File.Delete(P.YearClock + $"year-{y}.csv");
            }
            FirstLine();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            aText.Height = 0;
            OK.Height = 0;
            Cancel.Height = 0;
            aText.Text = $"";
        }
    }
}
