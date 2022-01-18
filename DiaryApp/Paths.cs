using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp
{
    internal class Paths
    { 
        public string AppFolder = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\Diary";
        public string NotesFile = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\Diary\notes.csv";
        public string FoodFile = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\Diary\food.csv";
        public string MusicFile = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\Diary\music.csv";
        public string SportFile = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\Diary\sport.csv";
        public string WorkFile = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\Diary\work.csv";
        public string SleepFile = Environment.GetFolderPath(
           Environment.SpecialFolder.ApplicationData) + @"\Diary\sleep.csv";
        public string YearClock = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\Diary\";
        public void CreateFolder()
        {
            if (!Directory.Exists(AppFolder))
            {
                Directory.CreateDirectory(AppFolder);
            }
        }
        public void CreateFile(string file)
        {
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }
        }
    }
}
