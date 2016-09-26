using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTodoApp.UI
{
    public class Selector
    {
        public static T From<T>(IEnumerable<T> source, string message)
        {
            if (!source.Any())
            {
                Console.WriteLine("No items");
                return default(T);
            }

            Console.Clear();
            var items = source.ToArray();
            for(int idx = 0; idx < items.Length; idx++)
            {
                Console.WriteLine($"{idx + 1} => {items[idx].ToString()}");
            }

            Console.Write($"{message}");
            var index = int.Parse(Console.ReadLine());
            return items[index - 1];
        }
    }
}
