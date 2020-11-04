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



        public static List<LijstItem> LijstLoad()
        {
            using(PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                IOrderedQueryable<LijstItem> query = entities.LijstItem
                    .Include("Winkellijst")
                    .Include("Product")
                    .OrderBy(x => x.LijstItemId);
                return query.ToList();
            }
        }

        public static List<LijstItem> SelectLijstitemsByWinkellijstId(int selectedWinkellijst)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                IQueryable<LijstItem> query = entities.LijstItem
                    .Include("Winkellijst")
                    .Include("Product")
                    .Where(x => x.WinkellijstId == selectedWinkellijst)
                    .OrderBy(x => x.ProductID);
                return query.ToList();
            }
        }
    }
}
