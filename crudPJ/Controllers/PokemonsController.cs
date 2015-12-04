﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudPJ.DAL;
using crudPJ.Models;

namespace crudPJ.Controllers
{
    public class PokemonsController : Controller
    {
        private PokemonContext db = new PokemonContext();

        // GET: Pokemons
        public ActionResult Index()
        {
            return View(db.Pokemon.ToList());
        }

        // GET: Pokemons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemon.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // GET: Pokemons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Nickname")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Pokemon.Add(pokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pokemon);
        }

        // GET: Pokemons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemon.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Nickname")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokemon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        // GET: Pokemons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemon.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokemon pokemon = db.Pokemon.Find(id);
            db.Pokemon.Remove(pokemon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
