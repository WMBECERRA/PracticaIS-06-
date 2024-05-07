using Newtonsoft.Json;
using Practica_06_IS_Cliente02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Practica_06_IS_Cliente02.Controllers
{
    public class ProductosController : Controller
    {
        public Producto ObtenerProductoPorId(int id)
        {
            string url = $"http://localhost:50231/api/Productos/{id}";
            WebClient client = new WebClient();
            string productoJson = client.DownloadString(new Uri(url));

            Producto producto = JsonConvert.DeserializeObject<Producto>(productoJson);
            return producto;
        }
        public List<Producto> Deserializar()
        {
            string url = "http://localhost:50231/api/Productos";
            WebClient client = new WebClient();
            string getDatos = client.DownloadString(new Uri(url));

            List<Producto> listarProductos = JsonConvert.DeserializeObject<List<Producto>>(getDatos);
            return listarProductos;
        }
        private void Serializar(Producto producto)
        {
            string url = "http://localhost:50231/api/Productos";
            string verb = "POST";
            WebClient client = new WebClient();

            string jsonDatos = JsonConvert.SerializeObject(producto);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(jsonDatos);
            client.Headers.Add("content-type", "application/json");
            client.UploadData(url, verb, bytes);

        }
        // GET: Productos
        public ActionResult Index()
        {
            return View(Deserializar());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            var producto = ObtenerProductoPorId(id);
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                // TODO: Add insert logic here
                Serializar(producto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = ObtenerProductoPorId(id);
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto producto)
        {
            try
            {
                string url = $"http://localhost:50231/api/Productos/{id}";
                string verb = "PUT";
                WebClient client = new WebClient();

                string jsonDatos = JsonConvert.SerializeObject(producto);
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(jsonDatos);
                client.Headers.Add("content-type", "application/json");
                client.UploadData(url, verb, bytes);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = ObtenerProductoPorId(id);
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                string url = $"http://localhost:50231/api/Productos/{id}";
                string verb = "DELETE";
                WebClient client = new WebClient();
                client.UploadString(url, verb, "");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
