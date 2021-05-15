using MindAllot.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MindAllot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            IdeaListBox.ItemsSource = dailyTasks;
            TodoListBox.ItemsSource = todos;

            var americanTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var japaneseTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

            LocalTimeTextBlock.Text = DateTime.Now.ToString();
            AmericanTimeTextBlock.Text = TimeZoneInfo.ConvertTime(DateTime.Now, americanTimeZoneInfo).ToString();
            JapaneseTimeTextBlock.Text = TimeZoneInfo.ConvertTime(DateTime.Now, japaneseTimeZoneInfo).ToString();
        }

        public ObservableCollection<DailyTask> dailyTasks = new ObservableCollection<DailyTask>();
        public ObservableCollection<Data.Task> todos = new ObservableCollection<Data.Task>();

        private void NewIdeaButton_Click(object sender, RoutedEventArgs e)
        {
            dailyTasks.Add(new DailyTask { DailyState = Data.Enums.TaskState.Ongoing, Title = "IDea" + DateTime.Now.ToUniversalTime() });
        }

        private void NewTodoButton_Click(object sender, RoutedEventArgs e)
        {
            todos.Add(new Data.Task { State = Data.Enums.TaskState.Completed, Description = "Todo " + DateTime.Now.ToUniversalTime() });
        }

        private void IdeaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                DisplayTextBlock.Text = e.AddedItems[0].ToString();
        }

        private void TodoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                DisplayTextBlock.Text = e.AddedItems[0].ToString();
        }
    }
}
