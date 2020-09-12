using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace CodeScanner
{
    public class CodeItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public CodeItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(CodeItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(CodeItem)).ConfigureAwait(false);                    
                }
                initialized = true;
            }
        }

        public Task<List<CodeItem>> GetItemsAsync()
        {
            return Database.Table<CodeItem>().ToListAsync();
        }

        public Task<List<CodeItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<CodeItem>("SELECT * FROM [CodeItem] WHERE [Sync] = 0");
        }

        public Task<CodeItem> GetItemAsync(int id)
        {
            return Database.Table<CodeItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CodeItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(CodeItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

