using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDbTodoApp.UI;

namespace MongoDbTodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("TodoAppDb");
            var todos = db.GetCollection<Todo>("Todos");

            Action loop = null;
            loop = () =>
            {
                var selectedOption = Selector.From(Commands.MainMenu(todos), "Main menu, select a number form menu above: ");
                if (selectedOption.Text == "Exit")
                {
                    selectedOption.Action();
                    return;
                }
                selectedOption.Action();
                loop();
            };

            loop();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
