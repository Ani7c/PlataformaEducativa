﻿using Ecosistemas_Marinos.Entidades;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private IAddUser AddUserUC;

        public UsuarioController(IAddUser addUserUC)
        {
            AddUserUC = addUserUC;
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }


        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {              
                this.AddUserUC.AddUser(usuario);
                ViewBag.msg = "Usuario agregado con éxito";
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = "Usuario ya existente" });
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}