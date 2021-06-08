using MindAllot.ViewModels;
using System;
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

            TimeZoneInfo americanTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo japaneseTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

            LocalTimeTextBlock.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            AmericanTimeTextBlock.Text = TimeZoneInfo.ConvertTime(DateTime.Now, americanTimeZoneInfo).ToString(CultureInfo.InvariantCulture);
            JapaneseTimeTextBlock.Text = TimeZoneInfo.ConvertTime(DateTime.Now, japaneseTimeZoneInfo).ToString(CultureInfo.InvariantCulture);
        }

        private void NewTodoButton_Click(object sender, RoutedEventArgs e)
        {
            //Todos.Add(new Task { State = Data.Enums.TaskState.Completed, Description = "Todo " + DateTime.Now.ToUniversalTime().ToString(CultureInfo.InvariantCulture) });
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
