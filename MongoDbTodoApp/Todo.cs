using MongoDB.Bson;
using System;


namespace MongoDbTodoApp
{
    public class Todo
    {
        public ObjectId Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public DateTime DateAdded { get; set; }
        public override string ToString() => $"Text: {Text} - Done? {Done}";
    }
}
