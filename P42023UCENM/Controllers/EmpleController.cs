using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using P42023UCENM.Models;
using System.Threading.Tasks;

namespace P42023UCENM.Controllers
{
    class EmpleController
    {
        readonly SQLiteAsyncConnection _connection;
        //Constructor de clase
        public EmpleController(string DBPath)
        {
            _connection = new SQLiteAsyncConnection(DBPath);
            _connection.CreateTableAsync<Models.Empleado>(); 
        }

        // Create / Update
        public Task<int> SaveEmple(Models.Empleado empleado) 
        {
            if (empleado.id !=0) 
                return _connection.UpdateAsync(empleado);
            else
                return _connection.InsertAsync(empleado);   

        }

        // Read
        public Task<Models.Empleado> GetEmpleado(int pid) 
        {
            return _connection.Table<Models.Empleado>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        // Read para toda la lista de empleados
        public Task<List<Models.Empleado>> GetListEmple() 
        {
            return _connection.Table<Models.Empleado>().ToListAsync();
        }

        // Eliminar la informacion
        public Task<int> DeleteEmple(Models.Empleado empleado)
        {
            return _connection.DeleteAsync(empleado);
        }
    }
}
