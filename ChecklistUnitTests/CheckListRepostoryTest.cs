using CheckListDataModel;
using NUnit.Framework;
using System;
using FnsUtility;


namespace CheckListUnitTests
{
    [TestFixture]
    public class CheckListRepostoryTest
    {
        [Test]
        public void TestCreateSave()
        {
            var checklist = new CheckList 
                { 
                   Name = "UnittestList", 
                   Description = "This is a checklist on how to start the day." 
                };

            checklist.AddItem("Wake up", "This is the first task.");
            checklist.AddItem("Get out of bed", "This is another task.");
            checklist.AddItem("Drag a comb across your head", "This is the final task.");
            Console.WriteLine(XmlUtility.SerializeObject(checklist));
            var task = checklist.Items[2] as CheckList;
            NUnit.Framework.Assert.IsNotNull(task, "cast failed!");
            task.AddItem("Details", "When complete, sit back and relax.");
            Console.WriteLine(XmlUtility.SerializeObject(task));
            checklist.RemoveItem("Get out of bed");
            var xml = XmlUtility.SerializeObject(checklist);
            Console.WriteLine(XmlUtility.SerializeObject(checklist));
            var newlist = XmlUtility.DeserializeObject<CheckList>(xml);
            NUnit.Framework.Assert.IsNotNull(newlist);
            Console.WriteLine(XmlUtility.SerializeObject(checklist));
 
        }
    }
}
