using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using DbModel = CheckListDataModel;

namespace CheckList.Models
{
    public class ChecklistRepository
    {
        public static IEnumerable<DbModel.CheckList> Select()
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            MongoCollection<DbModel.CheckList> lists = checklistDb.GetCollection<DbModel.CheckList>("lists");
            foreach (DbModel.CheckList list in lists.FindAllAs<DbModel.CheckList>())
                yield return list;
        }

        public static bool Insert (DbModel.CheckList list)
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            MongoCollection<DbModel.CheckList> lists = checklistDb.GetCollection<DbModel.CheckList>("lists");
            lists.Insert(list);
            return true;
        }

        public static DbModel.CheckList SelectByName(string name)
        {
            var server = MongoServer.Create(); // connect to localhost
            var checklistDb = server.GetDatabase("checklists");
            var lists = checklistDb.GetCollection<DbModel.CheckList>("lists");
            var query = Query.EQ("_id", name);
            var checklist = lists.FindOne(query);
            return checklist;
        }

        public static bool Update(string name, DbModel.CheckListItem list)
        {
            var server = MongoServer.Create(); // connect to localhost
            var checklistDb = server.GetDatabase("checklists");
            var lists = checklistDb.GetCollection<DbModel.CheckList>("lists");
            var query = Query.EQ("_id", name);
            DbModel.CheckList checklist = lists.FindOne(query);
            checklist.UpdateItem(list);
            var update = MongoDB.Driver.Builders.Update.Replace(checklist);
            var result = lists.Update(query, update, UpdateFlags.None, SafeMode.True);

            return result.Ok;
        }

        public static bool Delete(string name)
        {
            return true;
        }


    }
}