using Bogus;
using PropertyChanged;
using SQLITEDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLITEDemo.MVVM.ModelViews
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        #region PROPERTIES
        public List<Customer> Customers { get; set; }
        public Customer CurrentCustomer { get; set; }

        public ICommand AddOrUpdateCommand => new Command(() =>
        {
            //App.CustomerRepository.SaveItem(CurrentCustomer);
            App.CustomerRepository.SaveItemWithChildren(CurrentCustomer);
            Console.WriteLine(App.CustomerRepository.StatusMessage);
            GenerateNewCustomer();
            Refresh();
        });

        public ICommand DeleteCommand => new Command(() =>
        {
            App.CustomerRepository.DeleteItem(CurrentCustomer);
            Refresh();
        });
        #endregion

        #region CONSTRUCTORS

        public MainViewModel()
        {
            Refresh();
            GenerateNewCustomer();
        }

        #endregion


        #region PRIVATE METHODS
        public void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Address, f => f.Person.Address.Street)
                .Generate();

            //CurrentCustomer.Passport = new Passport
            //{
            //    ExpirationDate = DateTime.Now.AddDays(30)
            //};
            CurrentCustomer.Passports = new List<Passport>
            {
                new Passport
                {
                    ExpirationDate = DateTime.Now.AddDays(30)
                },
                new Passport
                {
                    ExpirationDate = DateTime.Now.AddDays(15)
                }
            };
        }

        private void Refresh()
        {
            // Customers = App.CustomerRepository.GetItems();
            Customers = App.CustomerRepository.GetItemsWithChildren();
            var passports = App.PassportRepository.GetItems();
            //Customers = App.CustomerRepository.GetAll(c => c.Name.StartsWith("A"));
        }
        #endregion
    }
}
