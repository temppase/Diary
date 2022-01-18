using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Controlers
{
    public class YearModel
    {
        public int Week { get; set; }
        public string Note { get; set; }
        public YearModel(int week, string note)
        {
            Week = week;
            Note = note;
        }
    }
}
