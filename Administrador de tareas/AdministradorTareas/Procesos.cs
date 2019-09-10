using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministradorTareas
{
    class Procesos
    {
        // Atributos.
        private string nombre;
        private int pid;
        private string estado;
        private string nombreUsuario;
        private int cpu;
        private int memoria;
        private int disco;
        private string descripcion;
        private int tiempo;

        // Contructores;
        public Procesos() { }

        public Procesos(string nombre, int pid, string estado, string nombreUsuario, int cpu, int memoria, int disco, string descripcion, int tiempo)
        {
            this.nombre = nombre;
            this.pid = pid;
            this.estado = estado;
            this.nombreUsuario = nombreUsuario;
            this.cpu = cpu;
            this.memoria = memoria;
            this.disco = disco;
            this.descripcion = descripcion;
            this.tiempo = tiempo;
        }

        // Métodos get y set.
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int PID
        {
            get { return pid; }
            set { pid = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Usuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public int CPU
        {
            get { return cpu; }
            set { cpu = value; }
        }

        public int Memoria
        {
            get { return memoria; }
            set { memoria = value; }
        }

        public int Disco
        {
            get { return disco; }
            set { disco = value; }
        }

        public string Descripción
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
    }
}
