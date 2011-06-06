using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(new CheckListDataModel.CheckListItem());
        } 

        //
        // POST: /Checklist/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
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
        public ActionResult Delete(int id, FormCollection collection)
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
