using act_02_03_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoDatos ma = new MantenimientoDatos();
            return View(ma.RecuperarTodos());
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoDatos ma = new MantenimientoDatos();
            Datos art = new Datos
            {
                Correo = collection["correo"],
                NombreUsuario = collection["nombreUsuario"],
                Clave = collection["clave"],
                RepetirClave = collection["repetirClave"],
                Apellido = collection["apellido"],
                Nombre = collection["nombre"],
                PaisOrigen = collection["paisOrigen"],
                Provincia = collection["provincia"],
                CodigoPostal = collection["codigoPostal"],
                Sexo = collection["sexo"],
                FechaNacimiento = collection["fechaNacimiento"],
                Comentarios = collection["comentarios"],
                AceptoTerminos = collection["aceptoTerminos"]

            };
            ma.Alta(art);
            return RedirectToAction("Index");
        }

        // GET: Home/Details/5
        public ActionResult Details(string id)
        {
            MantenimientoDatos ma = new MantenimientoDatos();
            Datos art = ma.Recuperar(id);
            return View(art);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string id)
        {
            MantenimientoDatos ma = new MantenimientoDatos();
            Datos art = ma.Recuperar(id);
            return View(art);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            MantenimientoDatos ma = new MantenimientoDatos();
            Datos art = new Datos
            {
                Correo = collection["correo"].ToString(),
                NombreUsuario = id,
                Clave = collection["clave"].ToString(),
                RepetirClave = collection["repetirClave"].ToString(),
                Apellido = collection["apellido"].ToString(),
                Nombre = collection["nombre"].ToString(),
                PaisOrigen = collection["paisOrigen"].ToString(),
                Provincia = collection["provincia"].ToString(),
                CodigoPostal = collection["codigoPostal"].ToString(),
                Sexo = collection["sexo"].ToString(),
                FechaNacimiento = collection["fechaNacimiento"].ToString(),
                Comentarios = collection["comentarios"].ToString(),
                AceptoTerminos = collection["aceptoTerminos"].ToString()
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(string id)
        {
            MantenimientoDatos ma = new MantenimientoDatos();
            Datos art = ma.Recuperar(id);
            return View(art);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            MantenimientoDatos ma = new MantenimientoDatos();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }

    }
}
