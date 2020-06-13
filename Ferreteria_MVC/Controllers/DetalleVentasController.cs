﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ferreteria_MVC.Models;

namespace Ferreteria_MVC.Controllers
{
    public class DetalleVentasController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: DetalleVentas
        public ActionResult Index()
        {
            var detalleVenta = db.DetalleVenta.Include(d => d.Factura).Include(d => d.Producto).Include(d => d.Ventas);
            return View(detalleVenta.ToList());
        }

        // GET: DetalleVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Create
        public ActionResult Create()
        {
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura");
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "Descripcion");
            return View();
        }

        // POST: DetalleVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleV,IdFactura,IdVenta,IdProducto,Cantidad,SubTOTAL,Descuento,Iva,Total")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.DetalleVenta.Add(detalleVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", detalleVenta.IdFactura);
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", detalleVenta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "Descripcion", detalleVenta.IdVenta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", detalleVenta.IdFactura);
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", detalleVenta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "Descripcion", detalleVenta.IdVenta);
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleV,IdFactura,IdVenta,IdProducto,Cantidad,SubTOTAL,Descuento,Iva,Total")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", detalleVenta.IdFactura);
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", detalleVenta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "Descripcion", detalleVenta.IdVenta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            db.DetalleVenta.Remove(detalleVenta);
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
