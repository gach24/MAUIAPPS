using PropertyChanged;
using ProsperDaily.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSumary> Summary { get; set; }
        public ObservableCollection<Transaction> SpendingList { get; set; }

        public void GetTransactionsSummary()
        {
            var data = App.TransactionsRepo.GetItems();

            var result = new List<TransactionsSumary>();

            var groupedTransactions = data.GroupBy(t => t.OperationDate.Date); 

            foreach(var group in groupedTransactions)
            {
                result.Add(new TransactionsSumary
                    {
                        TransactionsDate = group.Key,
                        TransactionsTotal = group.Sum(t => t.IsIncome ? t.Amount : -t.Amount),
                        ShownDate = group.Key.ToString("MM/dd")
                    });
            }

            Summary = new ObservableCollection<TransactionsSumary>(
                result.OrderBy(s => s.TransactionsDate)
            );

            SpendingList = new ObservableCollection<Transaction>( 
                data.Where(t => t.IsIncome)
            );
        }
    }
}
