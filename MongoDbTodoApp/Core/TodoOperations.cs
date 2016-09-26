using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTodoApp.Core
{
    public static class TodoOperations
    {
        public static IList<Todo> GetAll(this IMongoCollection<Todo> todos)
        {
            // practically the same as todos.find({});
            var allTodoDocs =  todos.Find(new BsonDocument());
            return allTodoDocs.ToList();
        }

        public static void AddTodo(this IMongoCollection<Todo> todos, string todoText)
        {
            // Self explainatory?
            todos.InsertOne(new Todo
            {
                Text = todoText,
                Done = false,
                DateAdded = DateTime.Now
            });
        }

        public static DeleteResult RemoveTodo(this IMongoCollection<Todo> todos, ObjectId id)
        {
            // Find by Id
            var filter = Builders<Todo>.Filter.Eq(x => x.Id, id);
            // then delete it
            return todos.DeleteOne(filter);
        }

        public static UpdateResult UpdateTodo(this IMongoCollection<Todo> todos, ObjectId idOldTodo, string newText, bool isDone)
        {
            // What document to update? find by Id
            var filter = Builders<Todo>.Filter.Eq(x => x.Id, idOldTodo);
            // what fields to update and with which values?
            var update = Builders<Todo>.Update
                                       .Set(x => x.Text, newText)
                                       .Set(x => x.Done, isDone);
            // Perform update operation
            return todos.UpdateOne(filter, update);
        }
    }
}
