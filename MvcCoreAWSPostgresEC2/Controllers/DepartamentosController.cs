using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSPostgresEC2.Models;
using MvcCoreAWSPostgresEC2.Repositories;

namespace MvcCoreAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamento repo;
        public DepartamentosController(RepositoryDepartamento repo)
        {
            this.repo = repo;
        }
      
        public async Task<ActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }
        public async Task<ActionResult> Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamento(id);
            return View(dept);
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}
