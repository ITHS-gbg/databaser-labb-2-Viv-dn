using System.Configuration;
using System.Data;
using System.Windows;
using Db_First;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppContextManager.Initialize(new BooksContext());
        }


        protected override void OnExit(ExitEventArgs e)
        {
            AppContextManager.Context?.Dispose();
        }
    }

}
