using MindAllot.Data;
using MindAllot.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MindAllot.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            IdeaListBox.ItemsSource = DailyTasks;
            TodoListBox.ItemsSource = Todos;

            TimeZoneInfo americanTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo japaneseTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

            LocalTimeTextBlock.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            AmericanTimeTextBlock.Text = TimeZoneInfo.ConvertTime(DateTime.Now, americanTimeZoneInfo).ToString(CultureInfo.InvariantCulture);
            JapaneseTimeTextBlock.Text = TimeZoneInfo.ConvertTime(DateTime.Now, japaneseTimeZoneInfo).ToString(CultureInfo.InvariantCulture);
        }

        private readonly ObservableCollection<DailyTask> DailyTasks = new ObservableCollection<DailyTask>();
        private readonly ObservableCollection<Task> Todos = new ObservableCollection<Task>();

        private void NewIdeaButton_Click(object sender, RoutedEventArgs e)
        {
            DailyTasks.Add(new DailyTask { DailyState = Data.Enums.TaskState.Ongoing, Title = "IDea" + DateTime.Now.ToUniversalTime().ToString(CultureInfo.InvariantCulture) });
        }

        private void NewTodoButton_Click(object sender, RoutedEventArgs e)
        {
            Todos.Add(new Task { State = Data.Enums.TaskState.Completed, Description = "Todo " + DateTime.Now.ToUniversalTime().ToString(CultureInfo.InvariantCulture) });
        }

        private void IdeaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                DisplayTextBlock.Text = e.AddedItems[0].ToString();
            }
        }

        private void TodoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                DisplayTextBlock.Text = e.AddedItems[0].ToString();
            }
        }
    }
}
