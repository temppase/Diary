using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Controlers
{
    public class Model
    {
        public int Line { get; set; }
        public string Label { get; set; }
        public string Desc { get; set; }
        public string Time { get; set; }
        public Model(int line, string label, string desc, string time)
        {
            Line = line;
            Label = label;
            Desc = desc;
            Time = time;
        }
    }
}
