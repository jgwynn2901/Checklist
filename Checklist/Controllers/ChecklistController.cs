using System.Web.Mvc;
using System.Linq;
using CheckList.Models;

namespace CheckList.Controllers
{
    public class ChecklistController : Controller
    {
        //
        // GET: /Checklist/

        public ActionResult Index()
        {
            return View(ChecklistRepository.Select());
        }

        public ActionResult Select(string name)
        {
            return View(ChecklistRepository.SelectByName(name));
        }
        //
        // GET: /Checklist/Create

        public ActionResult Create()
        {
            ViewBag.Item = false;
            return View(new CheckListDataModel.CheckListItem());
        }

       
        //
        // POST: /Checklist/Create

        [HttpPost]
        public ActionResult Create(CheckListDataModel.CheckListItem list)
        {
            try
            {
                if (string.IsNullOrEmpty(list.Parent))
                {
                    ChecklistRepository.Insert(list);
                }
                else
                {
                    ChecklistRepository.Update(list.Parent, list);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Checklist/Details/5

        public ActionResult Edit(string id, int? index)
        {
            if (index.HasValue)
            {
                var parent = ChecklistRepository.SelectByName(id);
                if (parent != null && parent.Items.Count > index)
                {
                    var item = parent.Items.Where(a => a.Ordinal == index).First();
                    item.Parent = parent.Name;
                    return View("Edit", item);
                }
            }
            return RedirectToAction("Index");
        }
        //
        // POST: /Checklist/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                var item = new CheckListDataModel.CheckListItem
                {
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Data = collection["Data"],
                    Parent = collection["Parent"]
                };
                // TODO: Add update logic here
                ChecklistRepository.Update(item.Parent, item);
                return View("Select", ChecklistRepository.SelectByName(item.Parent));
            }
            catch
            {
                return View();
            }
        }

        

        //
        // GET: /Checklist/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Checklist/Delete/5

        [HttpPost]
        public ActionResult Delete(string name)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
