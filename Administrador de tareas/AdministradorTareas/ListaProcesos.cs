using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministradorTareas
{
    class ListaProcesos
    {
        // Instancia.
        private List<Procesos> pro = new List<Procesos>();
        public String[] nombreProceso = new string[10];
        public String[] tipoProceso = new string[3];
        public String[] desc = new string[10];
        // Constructor.
        public ListaProcesos() { }

        // Métodos get y set.

        public List<Procesos> ProcesosLista
        {
            get { return pro; }
            set { pro = value; }
        }

        // Ingresar datos a la lista.
        public void InsertarLista(Procesos datos)
        {
            ProcesosLista.Add(datos);
        }

        // Mostrar la lista.
        public List<Procesos> MostrarLista()
        {
            return ProcesosLista;
        }

        // Buscar datos en la lista.
        public bool BuscarLista(int id)
        {
            bool find = false;
            foreach (var data in ProcesosLista)
            {
                if (data.PID == id)
                {
                    find = true;
                }
                else
                {
                    find = false;
                }
            }
            return find;
        }

        // Eliminar un dato de la lista.
        public void EliminarDatoLista(int id)
        {
            foreach (var data in ProcesosLista)
            {
                if (data.PID == id)
                {
                    ProcesosLista.Remove(data);
                    break;
                }
            }
        }

        // Reiniciar la lista.
        public void ReiniciarLista()
        {
            ProcesosLista.Clear();
        }

        // Muestra el total de procesos.
        public int Total()
        {
            return ProcesosLista.Count();
        }

        public int disco(int x)
        {
            if (ProcesosLista[x].Estado.Equals("Ejecutando"))
            {
                return ProcesosLista[x].Disco;
            }
            return 0;
        }

        public int cpu(int x)
        {
            if (ProcesosLista[x].Estado.Equals("Ejecutando"))
            {
                return ProcesosLista[x].CPU;
            }
            return 0;
        }

        public int ram(int x)
        {
            if (ProcesosLista[x].Estado.Equals("Ejecutando"))
            {
                return ProcesosLista[x].Memoria;
            }
            return 0;
        }

        public void tiempo(int indice)
        {
            int valor = ProcesosLista[indice].Tiempo;
            if (ProcesosLista[indice].Tiempo > 0)
            {
                valor--;
                ProcesosLista[indice].Tiempo = valor;
            }
            else
            {
                ProcesosLista[indice].Estado = "FInalizado";
            }
        }

        // Iniciar lista con datos.
        public void IniciaLista()
        {
            Random num = new Random();
            nombreProceso[0] = "explorer.exe";
            nombreProceso[1] = "System";
            nombreProceso[2] = "Spotify.exe";
            nombreProceso[3] = "avp.exe";
            nombreProceso[4] = "audiodg.exe";
            nombreProceso[5] = "SearchUI.exe";
            nombreProceso[6] = "SkypeApp.exe";
            nombreProceso[7] = "CCleaner64.exe";
            nombreProceso[8] = "AppleMobileDeviceService.exe";
            tipoProceso[0] = "Uribe";
            tipoProceso[1] = "Alfredo";
            tipoProceso[2] = "Miguel";
            desc[0] = "NT kernel & System";
            desc[1] = "Spotify";
            desc[2] = "Simbolo del sistema";
            desc[3] = "Navegador web";
            Procesos dt1 = new Procesos(nombreProceso[num.Next(0,9)], num.Next(0,1620), "Ejecutando", tipoProceso[num.Next(0,2)], num.Next(100, 180), num.Next(1, 300), num.Next(100, 500), desc[num.Next(0,3)], num.Next(15,90));
            ProcesosLista.Add(dt1);
        }
    }
}
