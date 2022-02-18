﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            List<Item> items = _context.Items.ToList();

            return View("Index", items);
        }

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Item item = _context.Items.FirstOrDefault(x => x.Id == id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
//        public IActionResult Delete(int id)
//        {
//            Item item = _context.Items.FirstOrDefault(e => e.Id == id);
//            _context.Items.Remove(item);
//            _context.SaveChanges();
//            return RedirectToAction("Index");
//        }


    }

}
