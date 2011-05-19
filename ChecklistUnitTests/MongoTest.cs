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
            var query = Query.EQ("_id", "UnitTest");
            CheckList checklist = lists.FindOne(query);
            Assert.IsNotNull(checklist);
            Console.WriteLine(FnsUtility.XmlUtility.SerializeObject(checklist));
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
