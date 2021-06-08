using MindAllot.ViewModels;
using System.Windows;

namespace MindAllot.Views.Popups
{
    /// <summary>
    /// Interaction logic for AddNewTaskDialog.xaml
    /// </summary>
    public partial class AddNewTaskDialog : Window
    {
        public AddNewTaskDialog()
        {
            DataContext = new DialogViewModel();

            InitializeComponent();
        }
    }
}
