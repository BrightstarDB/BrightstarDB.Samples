using System;
using System.IO;
using Todo;
using Xamarin.Forms;

[assembly: Dependency(typeof(BrightstarConnectionStringProvider_Android))]
namespace Todo
{
    public class BrightstarConnectionStringProvider_Android : IBrightstarConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var brightstarPath = Path.Combine(documentsPath, "brightstar");
            var connectionString = string.Format("type=embedded;storesDirectory={0};storeName=todo", brightstarPath);
            return connectionString;
        }
    }
}