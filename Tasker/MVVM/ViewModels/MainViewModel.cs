using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        #region PUBLIC PROPERTIES
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Models.Task> Tasks { get; set; }
        #endregion

        #region CONSTRUCTORS
        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += (sender, e) =>
            {
                UpdateData();
            };
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
               {
                    new Category
                    {
                         Id = 1,
                         CategoryName = ".NET MAUI Course",
                         Color = "#CF14DF"
                    },
                    new Category
                    {
                         Id = 2,
                         CategoryName = "Tutorials",
                         Color = "#df6f14"
                    },
                    new Category
                    {
                         Id = 3,
                         CategoryName = "Shopping",
                         Color = "#14df80"
                    }
               };
            Tasks = new ObservableCollection<Models.Task>
               {
                    new Models.Task
                    {
                         TaskName = "Upload exercise files",
                         Completed = false,
                         CategoryId = 1
                    },
                    new Models.Task
                    {
                         TaskName = "Plan next course",
                         Completed = false,
                         CategoryId = 1
                    },
                    new Models.Task
                    {
                         TaskName = "Upload new ASP.NET video on YouTube",
                         Completed = false,
                         CategoryId = 2
                    },
                    new Models.Task
                    {
                         TaskName = "Fix Settings.cs class of the project",
                         Completed = false,
                         CategoryId = 2
                    },
                    new Models.Task
                    {
                         TaskName = "Update github repository",
                         Completed = true,
                         CategoryId = 2
                    },
                    new Models.Task
                    {
                         TaskName = "Buy eggs",
                         Completed = false,
                         CategoryId = 3
                    },
                    new Models.Task
                    {
                         TaskName = "Go for the pepperoni pizza",
                         Completed = false,
                         CategoryId = 3
                    },
               };
            UpdateData();
        }

        #endregion

        #region PUBLIC METHODS

        public void UpdateData()
        {
            foreach (var category in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == category.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed
                                select t;

                var notCompleted = from t in tasks
                                   where !t.Completed
                                   select t;

                category.PendingTask = notCompleted.Count();
                category.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var task in Tasks)
            {
                var color = (from c in Categories
                             where c.Id == task.CategoryId
                             select c.Color).FirstOrDefault();
                task.TaskColor = color;
            }
        }

        #endregion
    }
}
