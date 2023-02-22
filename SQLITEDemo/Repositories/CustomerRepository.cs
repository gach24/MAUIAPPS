using SQLite;
using SQLITEDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.Repositories
{
    public class CustomerRepository
    {
        #region PRIVATE METHODS
        private SQLiteConnection connection;
        #endregion

        #region PUBLIC PROPERTIES
        public string StatusMessage { get; set; }
        #endregion

        #region CONSTRUCTORS
        public CustomerRepository()
        {
            connection = new SQLiteConnection(Constants.DB_PATH, Constants.FLAGS);
            connection.CreateTable<Customer>(); // Only if not exist
        }
        #endregion

        #region PUBLIC METHODS
        public void AddOrUpdate(Customer customer)
        {
            int result = 0;
            try
            {
                if (customer.Id != 0)
                {
                    result = connection.Update(customer);
                    StatusMessage = $"{result} rows updated";
                } 
                else
                {
                    result = connection.Insert(customer);
                    StatusMessage = $"{result} rows added";
                }

            } catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return connection.Table<Customer>().ToList();
            } catch(Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }


        public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
        {
            try
            {
                return connection.Table<Customer>().Where(predicate).ToList();
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }

        public Customer Get(int id)
        {
            try
            {
                return connection.Table<Customer>().FirstOrDefault(c => c.Id == id);
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }

        public List<Customer> GetAllQuery()
        {
            var sql = "SELECT * FROM Customers";
            try
            {
                return connection.Query<Customer>(sql).ToList();
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
            return null;
        }

        public void Delete(int id)
        {
            int result = 0;
            try
            {
                var customer = Get(id);
                result = connection.Delete(customer);
                StatusMessage = $"{result} rows deleted";
            }
            catch (Exception e)
            {
                StatusMessage = $"Error: {e.Message}";
            }
        }


        #endregion

    }
}
