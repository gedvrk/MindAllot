using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            IdeaListBox.ItemsSource = ideaList;
            TodoListBox.ItemsSource = todoList;
        }

        public ObservableCollection<Tuple<bool, string>> ideaList = new ObservableCollection<Tuple<bool, string>>();
        public ObservableCollection<Tuple<bool, string>> todoList = new ObservableCollection<Tuple<bool, string>>();

        private void NewIdeaButton_Click(object sender, RoutedEventArgs e)
        {
            ideaList.Add(new Tuple<bool, string>(false, "Idea " + DateTime.Now.ToUniversalTime()));
        }

        private void NewTodoButton_Click(object sender, RoutedEventArgs e)
        {
            todoList.Add(new Tuple<bool, string>(false, "Todo " + DateTime.Now.ToUniversalTime()));
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
