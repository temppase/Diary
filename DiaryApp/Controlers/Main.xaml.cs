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

namespace DiaryApp.Controlers
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        Paths P = new Paths();
        EditHelper H = new EditHelper();
        public Main()
        {
            InitializeComponent();
            double iN = Amount(P.NotesFile);
            NText.Text = $"Notes: {iN}";
            double iF = Amount(P.FoodFile);
            FText.Text = $"Food: {iF}";
            double iS = Amount(P.SportFile);
            SText.Text = $"Sport: {iS}";
            double iM = Amount(P.MusicFile);
            MText.Text = $"Music: {iM}";
            double iW = Amount(P.WorkFile);
            WText.Text = $"Work: {iW}";
            double A = iW + iM + iS + iN + iF;
            AText.Text = $"All: {A}";
            NPros.Text = Percent(A, iN);
            FPros.Text = Percent(A, iF);
            SPros.Text = Percent(A, iS);
            MPros.Text = Percent(A, iM);
            WPros.Text = Percent(A, iW);
            Lasts();
        }
        public string Percent(double Whole, double Part)
        {
            double Percent = Part / Whole * 100;
            return $" {Percent.ToString("#.##")} %";
        }
        public double Amount(string file)
        {
            return H.Read(file).Count();
        }
        public void Lasts()
        {
            NLast.Text = LastText(P.NotesFile);
            FLast.Text = LastText(P.FoodFile);
            SLast.Text = LastText(P.SportFile);
            MLast.Text = LastText(P.MusicFile);
            WLast.Text = LastText(P.WorkFile);
        }
        public string LastText(string f)
        {
            var r = H.Read(f);
            Model m = r.Last();
            return $" Last:\n {m.Label}\n\n{m.Desc}";
        }
    }
}
