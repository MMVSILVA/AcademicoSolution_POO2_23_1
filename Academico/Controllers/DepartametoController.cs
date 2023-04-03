using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class DepartamentoController : Controller
    {
        private static List<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento()
            {
                Id= 1,
                Nome = "Recursos Humanos",
                Sala = 201
            },
            new Departamento()
            {
                Id= 2,
                Nome = "TI",
                Sala = 202
            },
             new Departamento()
            {
                Id= 3,
                Nome = "Operação",
                Sala = 203
            }
        };
        public IActionResult Index()
        {
            return View(departamentos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            departamento.Id = departamentos.Select(i => i.Id).Max() + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            return View(departamentos.Where(i => i.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.Id == departamento.Id).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            return View(departamentos.Where(i => i.Id == id).First());
        }
        public IActionResult Delete(long id)
        {
            return View(departamentos.Where(i => i.Id == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Instituicao departamento)
        {
            departamentos.Remove(departamentos.Where((i) => i.Id == departamento.Id).First());
            return RedirectToAction("Index");
        }



    }
}