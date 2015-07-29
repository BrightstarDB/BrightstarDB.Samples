using System;
using System.IO;
using Todo.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(BrightstarConnectionStringProvider_iOS))]
namespace Todo.iOS
{
    class BrightstarConnectionStringProvider_iOS : IBrightstarConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var brightstarPath = Path.Combine(libraryPath, "brightstar");
            var connectionString = string.Format("type=embedded;storesDirectory={0};storeName=todo", brightstarPath);
            return connectionString;
        }
    }
}