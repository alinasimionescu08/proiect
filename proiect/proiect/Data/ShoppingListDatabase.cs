using proiect.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace proiect.Data
{
    // crearea, citirea, scrierea si stergerea datelor
    public class ShoppingListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ShoppingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShopList>().Wait();
            _database.CreateTableAsync<ShopList>().Wait();
            _database.CreateTableAsync<Burger>().Wait();
            _database.CreateTableAsync<ListProduct>().Wait();
        }
        public Task<int> SaveProductAsync(Burger product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Burger product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Burger>> GetProductsAsync()
        {
            return _database.Table<Burger>().ToListAsync();
        }
        public Task<List<ShopList>> GetShopListsAsync()
        {
            return _database.Table<ShopList>().ToListAsync();
        }
        public Task<ShopList> GetShopListAsync(int id)
        {
            return _database.Table<ShopList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ShopList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(ShopList slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveListProductAsync(ListProduct listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }

        public Task<List<Burger>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Burger>(
            "select P.ID, P.Name, P.Description, P.Price, P.Image from Product P"
            + " inner join ListProduct LP"
            + " on P.ID = LP.ProductID where LP.ShopListID = ?",
            shoplistid);
        }
    }
}
