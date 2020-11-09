using System;
using AgileWinkellijst_DAL;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

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

        public static int AddProduct(Product product)
        {
            try
            {
                using (PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    entities.Product.Add(product);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
           
        }

        public static int CurrentProducts()
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                DbSet<Product> query = entities.Product;

                return query.ToList().Max(x => x.ProductId);
            }
        }

        public static int CurrentItems()
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                DbSet<LijstItem> query = entities.LijstItem;
                return query.ToList().Max(x => x.LijstItemId);
            }
        }
    }

}
