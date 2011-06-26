using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckListDataModel;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CheckList.Models
{
    public class ChecklistRepository
    {
        public static IEnumerable<CheckListDataModel.CheckList> Select()
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            MongoCollection<CheckListDataModel.CheckList> lists = checklistDb.GetCollection<CheckListDataModel.CheckList>("lists");
            foreach (CheckListDataModel.CheckList list in lists.FindAllAs<CheckListDataModel.CheckList>())
                yield return list;
        }

        public static bool Insert (CheckListDataModel.CheckList list)
        {
            MongoServer server = MongoServer.Create(); // connect to localhost
            MongoDatabase checklistDb = server.GetDatabase("checklists");
            MongoCollection<CheckListDataModel.CheckList> lists = checklistDb.GetCollection<CheckListDataModel.CheckList>("lists");
            lists.Insert(list);
            return true;
        }

        public static CheckListDataModel.CheckList SelectByName(string name)
        {
            var server = MongoServer.Create(); // connect to localhost
            var checklistDb = server.GetDatabase("checklists");
            var lists = checklistDb.GetCollection<CheckListDataModel.CheckList>("lists");
            var query = Query.EQ("_id", name);
            var checklist = lists.FindOne(query);
            return checklist;
        }

        public static bool Update(string name, CheckListDataModel.CheckListItem list)
        {
            var server = MongoServer.Create(); // connect to localhost
            var checklistDb = server.GetDatabase("checklists");
            var lists = checklistDb.GetCollection<CheckListDataModel.CheckList>("lists");
            var query = Query.EQ("_id", name);

            var update = MongoDB.Driver.Builders.Update.AddToSetWrapped("Items", list);
            var result = lists.Update(query, update, UpdateFlags.Multi, SafeMode.True);

            return true;
        }

        public static bool Delete(string name)
        {
            return true;
        }


    }
}