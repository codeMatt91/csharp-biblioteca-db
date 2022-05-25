using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    internal class Libro : Documento
    {
        public int NumeroPagine { get; set; }

        public Libro(string Codice, string Titolo, int Anno, string Settore, int NumeroPagine, string Scaffale) : base(Codice, Titolo, Anno, Settore,Scaffale)
        {
            this.NumeroPagine = NumeroPagine;
            

            // Inserisco nel DB
            DB.libroAdd(this);
        }

        public override string ToString()
        {
            return string.Format("{0}\nNumeroPagine:{1}",
                base.ToString(),
                this.NumeroPagine);
        }
    }
}
