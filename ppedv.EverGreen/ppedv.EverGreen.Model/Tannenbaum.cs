using System;

namespace ppedv.EverGreen.Model
{
    public class Tannenbaum : Entity
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public decimal Price { get; set; }
        public virtual Herkunft Herkunft { get; set; }
        public virtual BaumArt BaumArt { get; set; }
        public DateTime Fällzeit { get; set; } = DateTime.Now;
    }
}
