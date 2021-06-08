using MindAllot.Commands;
using MindAllot.Data;
using MindAllot.Views.Popups;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MindAllot.ViewModels
{
    public class MainViewModel : ViewModel
    {
        //private readonly ObservableCollection<DailyTask> DailyTasks = new ObservableCollection<DailyTask>();
        //private readonly ObservableCollection<Task> Todos = new ObservableCollection<Task>();

        private ObservableCollection<DailyTask> _dailyTasks;

        public ObservableCollection<DailyTask> DailyTasks
        {
            get => _dailyTasks;
            set
            {
                _dailyTasks = value;
                OnPropertyChanged("DailyTasks");
            }
        }

        private ObservableCollection<Task> _todos;

        public ObservableCollection<Task> Todos
        {
            get => _todos;
            set
            {
                _todos = value;
                OnPropertyChanged("Todos");
            }
        }

        public RelayCommand NewIdeaCommand { get; set; }

        public MainViewModel()
        {
            _dailyTasks = new ObservableCollection<DailyTask>();
            DailyTasks = new ObservableCollection<DailyTask>();

            NewIdeaCommand = new RelayCommand(o => { OpenNewIdeaDialog(); });
        }

        private void OpenNewIdeaDialog()
        {
            AddNewTaskDialog dialog = new AddNewTaskDialog();

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                DailyTasks.Add(new DailyTask
                {
                    DailyState = Data.Enums.TaskState.Ongoing,
                    Title = "IDea" + DateTime.Now.ToUniversalTime().ToString(CultureInfo.InvariantCulture)
                });
            }
        }
    }
}
