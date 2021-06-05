using System.Resources;
using System.Windows;
using System.Windows.Threading;

namespace MindAllot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            ResourceManager resourceManager = new ResourceManager(typeof(MindAllotStrings));
            string errorTitle = resourceManager.GetString("GlobalErrorWindowTitle");
            string errorMessage = resourceManager.GetString("GlobalErrorWindowMessage");

            _ = MessageBox.Show(errorMessage + " : " + e.Exception.Message,
                errorTitle,
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            Current.Shutdown();
        }
    }
}
