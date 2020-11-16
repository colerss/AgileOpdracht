using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileWinkellijst_DAL
{
    public partial class Locatie 
    {
        public override string ToString()
        {
                    
            return this.LocatieNaam;          
        }

        public static implicit operator string(Locatie v)
        {
            throw new NotImplementedException();
        }
    }
}
