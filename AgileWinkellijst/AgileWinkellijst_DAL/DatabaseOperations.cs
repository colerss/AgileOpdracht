using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileWinkellijst_DAL
{
    public static class DatabaseOperations
    {


        public static List<Product> GetAssortimentOrderByAfdeeling()
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                var query = entities.Product
                    .Include("Locatie")
                    .OrderBy(x => x.Locatie.Volgnummer);
                return query.ToList();
            }
        }
    }
}
