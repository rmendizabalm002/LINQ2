using System;
using System.Collections.Generic;
using System.Linq;



namespace LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {

            ControlEmpresasEmpleados ce = new ControlEmpresasEmpleados();
            ce.getCEO();
            //ce.getEmpresaNombre();
            //ce.getInstitutoNombre();

        }
    }

    class ControlEmpresasEmpleados
    {
        public ControlEmpresasEmpleados()
        {

            listaEmpresas = new List<Empresa>();
            listaEmpleados = new List<Empleado>();
            listaInstitutos = new List<Instituto>();

            //LISTA EMPRESAS

            listaEmpresas.Add(new Empresa { Id = 1, Nombre = "Google" });
            listaEmpresas.Add(new Empresa { Id = 2, Nombre = "Informatica" });

            //LISTA EMPLEADOS

            listaEmpleados.Add(new Empleado { Id = 1, Nombre = "Oscar", Cargo = "CEO", EmpresaId = 1, InstitutoId = 0, Salario = 1500 });
            listaEmpleados.Add(new Empleado { Id = 2, Nombre = "Ruben", Cargo = "BAJO", EmpresaId = 0, InstitutoId = 0, Salario = 500 });
            listaEmpleados.Add(new Empleado { Id = 3, Nombre = "Pepe", Cargo = "CEO", EmpresaId = 0, InstitutoId = 1, Salario = 400 });
            listaEmpleados.Add(new Empleado { Id = 4, Nombre = "Edu", Cargo = "BAJO", EmpresaId = 1, InstitutoId = 1, Salario = 450 });

            //LISTA INSTITUTOS

            listaInstitutos.Add(new Instituto { Id = 1, Nombre = "IesValleCidacos", alumnosMatriculados = 70 });
            listaInstitutos.Add(new Instituto { Id = 2, Nombre = "IesAutol", alumnosMatriculados = 50 });

        }

        public void getCEO()
        {
            IEnumerable<Empleado> ceos =
                from empleado
                in listaEmpleados
                where empleado.Cargo == "CEO" && empleado.InstitutoId == 1 && empleado.EmpresaId == 0
                select empleado;

            foreach (var item in ceos)
            {
                item.getDatosEmpleado();
            }
        }

        public List<Empresa> listaEmpresas;
        public List<Empleado> listaEmpleados;
        public List<Instituto> listaInstitutos;
    }

    class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public void getDatosEmpresa()
        {
            Console.WriteLine(" Practicas en: {0}", Nombre);
        }
    }

    class Empleado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Cargo { get; set; }

        public double Salario { get; set; }


        //CLAVE FORANEA
        public int EmpresaId { get; set; }
        public int InstitutoId { get; set; }
        public void getDatosEmpleado()
        {
            Console.WriteLine(" Id: {0}, Empleado: {1}, Cargo: {2}, Salario: {3}"
                , Id, Nombre, Cargo, Salario);
        }
    }

    class Instituto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int alumnosMatriculados { get; set; }
        public void getDatosInstituto()
        {
            Console.WriteLine(" Nombre Instituto: {0}, Alumnos Matriculados: {1}", Nombre, alumnosMatriculados);
        }
    }
}