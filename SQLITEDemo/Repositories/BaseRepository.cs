using SQLite;
using SQLITEDemo.Abstractions;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        #region PRIVATE METHODS
        private SQLiteConnection connection;
        #endregion

        #region PUBLIC PROPERTIES
        public string StatusMessage { get; set; }
        #endregion

        #region CONSTRUCTORS
        public BaseRepository()
        {
            connection = new SQLiteConnection(Constants.DB_PATH, Constants.FLAGS);
            connection.CreateTable<T>(); // Only if not exist
        }

        #endregion

        #region PUBLIC METHODS
        public List<T> GetItems()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }

        public T GetItem(int id)
        {
            try
            {
                return connection.Table<T>().FirstOrDefault(c => c.Id == id);
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }
            
        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }

        public void DeleteItem(T item)
        {
            try
            {
                connection.Delete(item, true);
                StatusMessage = $"One rows deleted";
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
        }


        public void SaveItem(T item)
        {
            try
            {
                int result;
                if (item.Id != 0)
                {
                    result = connection.Update(item);
                    StatusMessage = $"{result} rows updated";
                }
                else
                {
                    result = connection.Insert(item);
                    StatusMessage = $"{result} rows added";
                }
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void SaveItemWithChildren(T item, bool recursive = false)
        {
            try
            {
                if (item.Id != 0)
                {
                    connection.UpdateWithChildren(item);
                    StatusMessage = $"One rows updated";
                }
                else
                {
                    connection.InsertWithChildren(item, recursive);
                    StatusMessage = $"One rows added";
                }
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
        }

        public List<T> GetItemsWithChildren()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }
        #endregion
    }
}
