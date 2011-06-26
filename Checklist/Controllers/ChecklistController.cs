using System.Web.Mvc;
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

        //
        // GET: /Checklist/Details/5

        public ActionResult Details(string name, int? index )
        {
            if(index.HasValue)
                return View(ChecklistRepository.SelectByName(name).Items[index??0]);
            return RedirectToAction("Index");
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

        public ActionResult CreateItem(string id)
        {
            ViewBag.Item = !string.IsNullOrEmpty(id);
            ViewBag.Parent = id;
            return View("Create", new CheckListDataModel.CheckListItem());
        }

        //
        // POST: /Checklist/Create

        [HttpPost]
        public ActionResult Create(CheckListDataModel.CheckListItem list)
        {
            try
            {
                if(string.IsNullOrEmpty(ViewBag.Parent))
                {
                    ChecklistRepository.Insert(list);
                }
                else
                {
                    ChecklistRepository.Update(ViewBag.Parent, list);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateItem(string id, CheckListDataModel.CheckListItem list)
        {
            try
            {
                // TODO: Add insert logic here
                ChecklistRepository.Update(id, list);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Checklist/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Checklist/Edit/5

        [HttpPost]
        public ActionResult Details(string name, CheckListDataModel.CheckListItem item)
        {
            try
            {
                // TODO: Add update logic here
                ChecklistRepository.Update(name, item);
                return RedirectToAction("Index");
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
