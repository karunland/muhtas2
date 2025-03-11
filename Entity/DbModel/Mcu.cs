using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DbModel
{
    public class Mcu : BaseEntity
    {
        public UInt32 Red { get; set; }
        public UInt32 Green { get; set; }
        public UInt32 Blue { get; set; }
        public UInt32 Distance { get; set; }
    }

}
