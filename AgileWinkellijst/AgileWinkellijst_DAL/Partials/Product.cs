using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileWinkellijst_DAL
{ 
    public partial class Product
    {

        public override string ToString()
        {
            if (Hoeveelheid != null)
            {
                string waardeTeken = "g";
                if (this.LocatieId == 4 || this.LocatieId == 5)
                {
                    waardeTeken = "ml";
                }
                return this.Naam + " " + this.Hoeveelheid + " " + waardeTeken;
            }
            return this.Naam;
            
        }
    }
}
