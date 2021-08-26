﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_category category)

        {

            WebAppDbContext db = new WebAppDbContext();
            db.tbl_category.Add(category);
            db.SaveChanges();

            return View();
        }
        public ActionResult list()

        {

            WebAppDbContext db = new WebAppDbContext();
            var list = db.tbl_category.ToList();
            

            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            WebAppDbContext db = new WebAppDbContext();
            var category = db.tbl_category.Find(id);

            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(tbl_category category)
        {
            WebAppDbContext db = new WebAppDbContext();
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}