using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_4
{
    internal class TeDoen
    {
        public delegate void Meedelen(string titel, string inhoud, bool dringend);
        private int _autnummer = 0;
        private int Id {
            get { _autnummer++; return _autnummer; }
            set { _autnummer = value; }
        }
        public DateTime? Tijdstip;
        public string Titel { get; set; }
        public string[] Informatie { get; set; }

        public TeDoen(string Titel, string[] Informatie)
        {
                  this.Titel = Titel;
            this.Informatie = Informatie;
        }

        public TeDoen(DateTime Tijdstip, string Titel, string[] Informatie)
        {
            this.Tijdstip = Tijdstip;
            this.Titel = Titel;
            this.Informatie = Informatie;
        }

        public override string ToString()
        {
            string text = "";
            foreach (string info in Informatie)
            {
                text = info.ToString() + "\r\n";
            }
            return text;
        }

    }
}
