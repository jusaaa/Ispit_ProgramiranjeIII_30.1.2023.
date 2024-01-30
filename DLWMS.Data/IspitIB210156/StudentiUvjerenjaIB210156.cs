using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitIB210156
{
    public class StudentiUvjerenjaIB210156
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public string VrstaUvjerenja { get; set; }
        public string SvrhaUvjerenja { get; set; }
        public byte[] Uplatnica { get; set; }
        public int Printano { get; set; }
    }
}
