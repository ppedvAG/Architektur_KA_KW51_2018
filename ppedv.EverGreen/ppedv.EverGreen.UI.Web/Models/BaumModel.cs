using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ppedv.EverGreen.UI.Web.Models
{
    public class BaumModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaumArtID { get; set; }
        public int Höhe { get; set; }
        public int Breite { get; set; }
        public decimal Preis { get; set; }
        public DateTime Fällung { get; set; }
    }
}