using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DbModel
{
    public class BaseEntity
    {
        public DateTime CreatedTime { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public bool IsDeleted { get; set; } = false;
    }
}
