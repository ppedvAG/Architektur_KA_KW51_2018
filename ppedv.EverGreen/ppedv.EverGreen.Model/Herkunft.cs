using System.Collections.Generic;

namespace ppedv.EverGreen.Model
{
    public class Herkunft : Entity
    {
        public string Beschreibung { get; set; }
        public virtual HashSet<Tannenbaum> Trees { get; set; } = new HashSet<Tannenbaum>();
    }
}
