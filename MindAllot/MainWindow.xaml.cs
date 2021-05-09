using System;
using System.Collections.Generic;
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
        }

        private void NewIdeaButton_Click(object sender, RoutedEventArgs e)
        {
            IdeaListBox.Items.Add("Idea " + DateTime.Now.ToUniversalTime());
        }

        private void NewTodoButton_Click(object sender, RoutedEventArgs e)
        {
            TodoListBox.Items.Add("Todo " + DateTime.Now.ToUniversalTime());
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
