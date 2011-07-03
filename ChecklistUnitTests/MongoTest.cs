using CheckListDataModel;
using MongoDB.Driver;
using NUnit.Framework;
using System;
using MongoDB.Driver.Builders;

namespace CheckListUnitTests
{
    [TestFixture]
    public class MongoTest
    {
        [Test]
        public void TestServer()
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase test = server.GetDatabase("test");
            Assert.IsNotNull(test);
        }

        [Test]
        public void TestCreate()
        {
            var checklist = new CheckList
            {
                Name = "A Day In The Life",
                Description = "This is a checklist on how to start the day."
            };

            checklist.AddItem("Wake up", "This is the first task.");
            checklist.AddItem("Get out of bed", "This is another task.");
            checklist.AddItem("Drag a comb across your head", "This is the final task.");

            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            Assert.IsNotNull(checklistDb);
            MongoCollection<CheckList> lists = checklistDb.GetCollection<CheckList>("lists");
            Assert.IsNotNull(lists);
             lists.Insert(checklist);
        }

        [Test]
        public void TestQuery()
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            Assert.IsNotNull(checklistDb);
            MongoCollection<CheckList> lists = checklistDb.GetCollection<CheckList>("lists");
            Assert.IsNotNull(lists);
            var query = Query.EQ("_id", "A Day In The Life");
            CheckList checklist = lists.FindOne(query);
            Assert.IsNotNull(checklist);
            Console.WriteLine(FnsUtility.XmlUtility.SerializeObject(checklist));
        }

        [Test]
        public void TestUpdate()
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            Assert.IsNotNull(checklistDb);
            MongoCollection<CheckList> lists = checklistDb.GetCollection<CheckList>("lists");
            Assert.IsNotNull(lists);
            var query = Query.EQ("_id", "A Day In The Life");
            CheckList checklist = lists.FindOne(query);

            var item = checklist.Items.Find(a => a.Name == "Wake up");
            Assert.IsNotNull(item);
            Console.WriteLine("{0},{1},{2},{3}", item.Name, item.Description, item.Ordinal, item.Data);
            item.Data = string.Format("{{\"_id\": \"{0}\"}};", item.Name);
            Console.WriteLine("{0},{1},{2},{3}", item.Name, item.Description, item.Ordinal, item.Data);
            var update = MongoDB.Driver.Builders.Update.Replace(checklist);
            var result = lists.Update(query, update, UpdateFlags.None, SafeMode.True);
            Console.WriteLine(result);
        }

        [Test]
        public void TestFindAll()
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            MongoCollection<CheckListDataModel.CheckList> lists = checklistDb.GetCollection<CheckListDataModel.CheckList>("lists");
            foreach (CheckListDataModel.CheckList list in lists.FindAllAs<CheckListDataModel.CheckList>())
                Console.WriteLine(list.Name);

        }
    }
}
