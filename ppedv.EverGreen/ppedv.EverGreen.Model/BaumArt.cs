using System.Collections.Generic;

namespace ppedv.EverGreen.Model
{
    public class BaumArt : Entity
    {
        public string Name { get; set; }
        public string Farbe { get; set; }
        public string Form { get; set; }
        public virtual HashSet<Tannenbaum> Trees { get; set; } = new HashSet<Tannenbaum>();
    }
}
