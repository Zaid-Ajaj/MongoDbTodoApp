using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTodoApp.UI
{
    public class Command
    {
        public string Text { get; set; }
        public Action Action { get; set; }
        public override string ToString() => Text;
    }

    public class Command<T>
    {
        public string Text { get; set; }
        public Action<T> Action { get; set; }
        public override string ToString() => Text;
    }
}
 