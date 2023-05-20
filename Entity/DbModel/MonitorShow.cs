using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DbModel
{
    public class MonitorShow
    {
        public int Id { get; set; }
        public bool RgbSection { get; set; }
        public bool DistanceSection { get; set; }
        public bool DetailsSection { get; set; }
    }
}
