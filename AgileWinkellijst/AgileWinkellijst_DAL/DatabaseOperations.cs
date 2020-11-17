using System;
using AgileWinkellijst_DAL;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace AgileWinkellijst_DAL
{
    public static class DatabaseOperations
    {
        public static void ErrorLogging(Exception ex)
        {
            //Bryant Suiskens: Foutenlog code; overgenomen vanuit vorig project. 
            string strPath = @"Log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Error: " + ex.GetType().Name);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

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

        public static int AddWinkellijst(Winkellijst winkellijst)
        {
            try
            {
                using(PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    entities.Winkellijst.Add(winkellijst);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteWinkellijst(Winkellijst winkellijst)
        {
            try
            {
                using(PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    entities.Entry(winkellijst).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int AddLijstItem(LijstItem product)
        {
            try
            {
                using (PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    if (ContainsProduct(product, out LijstItem oldItem))
                    {
                        oldItem.Aantal += product.Aantal;
                        entities.Entry(oldItem).State = EntityState.Modified;
                    }
                    else
                    {
                        entities.LijstItem.Add(product);
                    }
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool ContainsProduct(LijstItem item, out LijstItem matchedItem)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                var query = entities.LijstItem;
                List<LijstItem> items = query.ToList();
                var matches = items.Where(p => p.ProductID == item.ProductID).SingleOrDefault();
                matchedItem = matches;
                return matches != null;
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

        public static int CurrentWinkellijst()
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                DbSet<Winkellijst> query = entities.Winkellijst;

                return query.ToList().Max(x => x.WinkellijstId);
            }
        }
        public static int CurrentListItem()
        {

            try
            {
                using (PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    DbSet<LijstItem> query = entities.LijstItem;

                    return query.ToList().Max(x => x.LijstItemId);
                }
            }
            catch (Exception)
            {

                return 0;
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

        public static List<LijstItem> GetLijstItems(int WinkellijstID)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                var query = entities.LijstItem
                    .Where(x => x.WinkellijstId == WinkellijstID)
                    .Include("Product")
                    .OrderBy(x => x.Product.Naam);
                return query.ToList();
            }
        }
        public static int RemoveProduct(Product product)
        {
            try
            {
                using (PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    entities.Entry(product).State = EntityState.Deleted;

                    return entities.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Gebruiker SelectGebruikerById(int gebruikerId)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                IQueryable<Gebruiker> query = entities.Gebruiker
                    .Include("Winkellijst")
                    .Where(x => x.GebruikerId == gebruikerId);
                return query.ToList().SingleOrDefault();
            }
        }
        public static int RemoveLijstItem(LijstItem lijstItem)
        {
            try
            {
                using (PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    entities.Entry(lijstItem).State = EntityState.Deleted;

                    return entities.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int EditLijstItem(LijstItem lijstItem)
        {
            try
            {
                using (PR_r0739290Entities entities = new PR_r0739290Entities())
                {
                    entities.Entry(lijstItem).State = EntityState.Modified;

                    return entities.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static LijstItem OphalenLijstItemViaLijstItemID(int LijstItemID)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                var query = entities.LijstItem
                    .Where(x => x.LijstItemId == LijstItemID);
                return query.SingleOrDefault();
            }
        }
        public static List<Winkellijst> GetWinkellijstenByGebruikerId(int GebruikerID)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                IQueryable<Winkellijst> query = entities.Winkellijst
                    .Where(x => x.GebruikerId == GebruikerID)
                    .OrderBy(x => x.Naam);
                return query.ToList();
            }
        }
        public static List<LijstItem> OphalenLijstItemViaWinkelLijstItemID(int WinkellijstID)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                var query = entities.LijstItem
                    .Where(x => x.WinkellijstId == WinkellijstID);
                return query.ToList();
            }
        }
        public static List<Product> GetAssortimentSearched(string searchstring)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                var query = entities.Product
                    .Where(x => x.Naam.ToString().Contains(searchstring))
                    .Include("Locatie")
                    .OrderBy(x => x.Locatie.Volgnummer);

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

        public static List<Product> ListProductsByLocation(Locatie afdeling)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                IQueryable<Product> query = entities.Product
                    .OrderBy(p => p.ProductId)
                    .Where(p => p.LocatieId == afdeling.LocatieId);

                return query.ToList();
            }
        }

        public static List<Product> ListProductsByLocationSearched(Locatie afdeling, string searchstring)
        {
            using (PR_r0739290Entities entities = new PR_r0739290Entities())
            {
                IQueryable<Product> query = entities.Product
                    .Where(p => p.LocatieId == afdeling.LocatieId)
                    .Where(x => x.Naam.ToString().Contains(searchstring))
                    .Include("Locatie")
                    .OrderBy(p => p.ProductId);

                return query.ToList();
            }
        }
    }
}
