using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DbModel
{
    public class DistanceSensor
    {
        [Key]
        public int Id { get; set; }
        public int Distance { get; set; }
    }
}
