using MindAllot.Commands;
using MindAllot.Data;
using MindAllot.Views.Popups;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MindAllot.ViewModels
{
    /// <summary>
    /// <para>Logic and bindings for the <see cref="Views.MainWindow"/> class.</para>
    /// </summary>
    public class MainViewModel : ViewModel
    {
        private ObservableCollection<DailyTask> _dailyTasks;
        private ObservableCollection<Task> _todos;

        /// <summary>
        /// <para>Command to add a new idea to the <see cref="Ideas"/> collection.</para>
        /// </summary>
        public RelayCommand NewIdeaCommand { get; set; }

        /// <summary>
        /// <para>
        /// Observable collection of <see cref="DailyTask"/> that can be bound to. Triggers property
        /// changed events when the collection changes.
        /// </para>
        /// </summary>
        public ObservableCollection<DailyTask> Ideas
        {
            get => _dailyTasks;
            set
            {
                _dailyTasks = value;
                OnPropertyChanged("DailyTasks");
            }
        }

        /// <summary>
        /// <para>
        /// Observable collection of <see cref="Task"/> that can be bound to. Triggers property
        /// changed events when the collection changes.
        /// </para>
        /// </summary>
        public ObservableCollection<Task> Todos
        {
            get => _todos;
            set
            {
                _todos = value;
                OnPropertyChanged("Todos");
            }
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="MainViewModel"/> class.</para>
        /// </summary>
        public MainViewModel()
        {
            _dailyTasks = new ObservableCollection<DailyTask>();
            Ideas = new ObservableCollection<DailyTask>();

            NewIdeaCommand = new RelayCommand(o => { OpenNewIdeaDialog(); });
        }

        private void OpenNewIdeaDialog()
        {
            AddNewTaskDialog dialog = new AddNewTaskDialog();

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Ideas.Add(new DailyTask
                {
                    DailyState = Data.Enums.TaskState.Ongoing,
                    Title = "IDea" + DateTime.Now.ToUniversalTime().ToString(CultureInfo.InvariantCulture)
                });
            }
        }
    }
}
