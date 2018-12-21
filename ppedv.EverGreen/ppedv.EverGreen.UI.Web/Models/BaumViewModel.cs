using ppedv.EverGreen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ppedv.EverGreen.UI.Web.Models
{
    public class BaumViewModel
    {
        public Tannenbaum Baum { get; set; }
        public IEnumerable<BaumArt> BaumArten { get; set; }
        public IEnumerable<Herkunft> Herkünften { get; set; }
    }
}