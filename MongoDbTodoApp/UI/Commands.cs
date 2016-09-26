using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbTodoApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTodoApp.UI
{
    public class Commands
    {
        public static IEnumerable<Command<Todo>> TodoOptions(IMongoCollection<Todo> todos)
        {
            return new Command<Todo>[]
            {
                new Command<Todo>
                {
                    Text = "Delete",
                    Action = todo =>
                    {
                        todos.RemoveTodo(todo.Id);
                        Console.WriteLine("Deleted!");
                    }
                },
                new Command<Todo>
                {
                    Text = "Edit",
                    Action = todo =>
                    {
                        // New data
                        var isDone = Selector.From(new[] { true, false }, "Is it done yet? ");
                        Console.Write("New Text: ");
                        var text = Console.ReadLine();
                        todos.UpdateTodo(todo.Id, text, isDone);
                        Console.WriteLine("Updated!");
                    }
                },

            };
        }

        public static IEnumerable<Command> MainMenu(IMongoCollection<Todo> todos)
        {
            return new Command[]
            {
                new Command
                {
                    Text = "View All Todos",
                    Action = () =>
                    {
                        var allTodos = todos.GetAll();
                        // Select one Todo from console
                        var todo = Selector.From(allTodos, "Select a Todo from list above: ");
                        // Get options on what to do with todo :)
                        var todoOptions = TodoOptions(todos);
                        var todoCommand = Selector.From(todoOptions, "Then? ");
                        todoCommand.Action(todo);
                    }
                },
                new Command
                {
                    Text = "Add New Todo",
                    Action = () =>
                    {
                        Console.Write("New todo: ");
                        var text = Console.ReadLine();
                        todos.AddTodo(text);
                        Console.WriteLine("Inserted");
                    }
                },
                new Command
                {
                    Text = "Exit",
                    Action = () =>
                    {
                        Console.WriteLine("Bye bye");
                    }
                }
            };
        }

    }
}
