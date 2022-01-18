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

namespace DiaryApp.Controlers
{
    /// <summary>
    /// Interaction logic for ContentControl.xaml
    /// </summary>
    public partial class ContentControl : UserControl
    {
        string Path { get; set; }
        string L { get; set; }
        string T { get; set; }
        EditHelper edit = new EditHelper();
        public ContentControl(string path)
        {
            InitializeComponent();
            Paths P = new Paths();
            P.CreateFile(path);
            MyGrid.ItemsSource = edit.Read(path);
            Path = path;
            L = "";
            T = "";
            string e = path.Substring(0, path.Length-4);
            string s = e.Substring(37);
            C_header.Text = $"{s.ToUpper()}";
            E_label.Height = 0;
            E_desc.Height = 0;
            Edit.Height = 0;
            Delete.Height = 0;
        }
        public void MyGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Model S = (Model)MyGrid.SelectedItem;
            E_label.Text = S.Label;
            E_desc.Text = S.Desc;
            L = S.Line.ToString();
            T = S.Time;
            E_label.Height = 30;
            E_desc.Height = Double.NaN;
            Edit.Height = 30;
            Delete.Height = 30;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (T_label.Text != "" && T_desc.Text != "")
            {
                edit.Add(T_label.Text, T_desc.Text, Path);
                MyGrid.ItemsSource = edit.Read(Path);
                CollectionViewSource.GetDefaultView(MyGrid.ItemsSource).Refresh();
                T_desc.Text = "";
                T_label.Text = "";
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (E_label.Text != "" && E_desc.Text != "")
            {
                edit.Edit(L, E_label.Text, E_desc.Text, T, Path);
                MyGrid.ItemsSource = edit.Read(Path);
                CollectionViewSource.GetDefaultView(MyGrid.ItemsSource).Refresh();
                E_desc.Text = "";
                E_label.Text = "";
                E_label.Height = 0;
                E_desc.Height = 0;
                Edit.Height = 0;
                Delete.Height = 0;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (E_label.Text != "" && E_desc.Text != "")
            {
                edit.DeleteLine(Path, L);
                MyGrid.ItemsSource = edit.Read(Path);
                CollectionViewSource.GetDefaultView(MyGrid.ItemsSource).Refresh();
                E_desc.Text = "";
                E_label.Text = "";
                E_label.Height = 0;
                E_desc.Height = 0;
                Edit.Height = 0;
                Delete.Height = 0;
            }
        }
    }
}
