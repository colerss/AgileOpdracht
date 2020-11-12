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

        public static List<Product> Products(string selectedItem)
        {
            using(PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                DbSet<Product> query = entities.Product;
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

        public static List<LijstItem> LijstLoad()
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
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

        public static List<Locatie> GetLocaties()
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                IOrderedQueryable<Locatie> query = entities.Locatie
                    .OrderBy(x => x.LocatieNaam);

                return query.ToList();
            }
        }
    }
}
