using DiaryApp.Controlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp
{
    public class EditHelper
    {
        public void Edit(string line, string L, string D, string t, string file)
        {
            string[] lines = File.ReadAllLines(file);
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                foreach (var l in lines)
                {
                    string[] p = l.Split(';');
                    if (p[0] != line)
                    {
                        string d = $"{p[0]};{p[1]};{p[2]};{p[3]};";
                        sw.WriteLine(d);
                        Debug.WriteLine($"Old values:\n {d}");
                    }
                    else
                    {
                        string d = $"{p[0]};{L};{D};{t};";
                        sw.WriteLine(d);
                        Debug.WriteLine($"New values:\n {d}");
                    }
                }
            }
            
        }
        public void DeleteLine(string file, string line)
        {
            string[] lines = File.ReadAllLines(file);
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                int i = 1;
                foreach (var l in lines)
                {
                    string[] p = l.Split(';');
                    if (p[0] != line)
                    {
                        string d = $"{i};{p[1]};{p[2]};{p[3]};";
                        sw.WriteLine(d);
                        i++;
                    }
                }
            }
        }
        public void Add(string label, string desc, string file)
        {
            var l = Read(file);
            var i = l.Last();
            if (i.Label == "Default")
            {
                Model m = new Model(1, label, desc, DateTime.Now.ToString("yyyy dd.MM HH:mm"));
                string data = $"{m.Line};{m.Label};{m.Desc};{m.Time};\n";
                File.AppendAllText(file, data);
            }
            else
            {
                Model m = new Model(
                    i.Line + 1,
                    label, desc,
                    DateTime.Now.ToString("yyyy dd.MM HH:mm")
                    );
                string data = $"{m.Line};{m.Label};{m.Desc};{m.Time};\n";
                File.AppendAllText(file, data);
            }

        }
        public List<Model> Read(string file)
        {
            var FL = new FileInfo(file).Length;
            if (FL != 0)
            {
                List<Model> values = File.
                ReadAllLines(file)
                    .Select(v => FromCsv(v))
                    .ToList();
                return values;
            }
            else
            {
                List<Model> M = new List<Model>();
                M.Add(new Model(
                    1,
                    "Default",
                    "File doesn't have content yet.",
                    DateTime.Now.ToString("yyyy dd.MM HH:mm"))
                );
                return M;
            }
        }

        public static Model FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Model M = new Model(
                Convert.ToInt16(values[0]),
                values[1],
                values[2],
                values[3]
                );
            return M;
        }

    }
}
