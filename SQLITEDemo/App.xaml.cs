using SQLITEDemo.MVVM.Models;
using SQLITEDemo.MVVM.Views;
using SQLITEDemo.Repositories;

namespace SQLITEDemo
{
    public partial class App : Application
    {
        // public static CustomerRepository CustomerRepository { get; private set; }
        public static BaseRepository<Customer> CustomerRepository { get; private set; }
        public static BaseRepository<Order> OrderRepository { get; private set; }
        public static BaseRepository<Passport> PassportRepository { get; private set; }
        public App(BaseRepository<Customer> cr, BaseRepository<Order> or, BaseRepository<Passport> pr)
        {
            InitializeComponent();
            CustomerRepository = cr;
            OrderRepository = or;
            PassportRepository = pr;

            MainPage = new MainView();

        }
    }
}