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
        //[Key]
        //[BsonId]
        //public BsonObjectId Id { get; set; }
        public UInt32 Red { get; set; }
        public UInt32 Green { get; set; }
        public UInt32 Blue { get; set; }
        public UInt32 Distance { get; set; }

        //private int _red; // Kırmızı kanal değeri
        //private int _green; // Yeşil kanal değeri
        //private int _blue; // Mavi kanal değeri
        //public int Red
        //{
        //    get => _red;
        //    set => _red = ValidateChannelValue(value);
        //}
        //public int Green
        //{
        //    get => _green;
        //    set => _green = ValidateChannelValue(value);
        //}
        //public int Blue
        //{
        //    get => _blue;
        //    set => _blue = ValidateChannelValue(value);
        //}

        //private int ValidateChannelValue(int value)
        //{
        //    if (value < 0 || value > int.MaxValue)
        //        throw new ArgumentOutOfRangeException($"RGB channel value must be between 0 and {int.MaxValue}. Given value: {value}");

        //    return value;
        //}
    }

}
