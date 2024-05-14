using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostgresEC2.Data;
using MvcCoreAWSPostgresEC2.Models;

namespace MvcCoreAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamento
    {
        private DepartamentosContext context;
        public RepositoryDepartamento(DepartamentosContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();

        }
        public async Task<Departamento> FindDepartamento (int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == id);
        }
        public async Task InsertDepartamentoAsync (int id, string nombre, string localidad)
        {
            Departamento dep = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            this.context.Departamentos.Add(dep);
            await this.context.SaveChangesAsync();
        }
    }
}
