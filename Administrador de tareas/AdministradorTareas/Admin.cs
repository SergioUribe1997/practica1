using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AdministradorTareas
{
    public partial class Admin : Form
    {
        // Instancia de la lista de procesos.
        ListaProcesos lp = new ListaProcesos();
        Validar v = new Validar();
        int memoriaRAM = 4096;
        int memoriaRAMutilizada = 0;
        int cpu = 2000;
        int cpuUtilizado = 0;
        int disco = 5000;
        int discoUtilizado = 0;

        // Constructor.
        public Admin()
        {
            InitializeComponent();
        }

        // Form.
        private void Admin_Load(object sender, EventArgs e)
        {
            // Inicializar lista.
            lp.IniciaLista();

            // Se actualiza las tablas y el total de procesos.
            ActualizarDatos();

            // Cargar datos a los ComboBox.
            this.cbUsuario.Items.Add("Alfredo");
            this.cbUsuario.Items.Add("Miguel");
            this.cbUsuario.Items.Add("Sergio");
            this.cbUsuario.Items.Add("SYSTEM");
            this.cbUsuario.Items.Add("SERVICIO LOCAL");

            // Mensajes de ayuda.
            this.ttMensajeAyuda.ToolTipTitle = "Complete los campos";
            this.ttMensajeAyuda.ToolTipIcon = ToolTipIcon.Info;
            this.ttMensajeAyuda.SetToolTip(this.txtNombre, "Ingrese letras: A, B, C...");
            this.ttMensajeAyuda.SetToolTip(this.txtPidId, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtCpu, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtMemoria, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtDisco, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.cbUsuario, "Elija un usuario para el proceso.");
            this.ttMensajeAyuda.SetToolTip(this.txtDescripcion, "Ingrese letras: A, B, C...");
            this.ttMensajeAyuda.SetToolTip(this.txtTiempo, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtPID, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtPID2, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtCPUTope, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtMemoriaTope, "Ingrese números: 1, 2, 3, 4, 5...");
            this.ttMensajeAyuda.SetToolTip(this.txtDiscoTope, "Ingrese números: 1, 2, 3, 4, 5...");

            // Texbox de la vista Equipo desactivados.
            this.txtCPUTope.Enabled = false;
            this.txtMemoriaTope.Enabled = false;
            this.txtDiscoTope.Enabled = false;

            // Gráfica y tablas.
            cGrafica1.Titles.Add("Rendimiento");
            tTiempo.Start();
            timer1.Start();
        }

        // Se actualiza las tablas y el total de procesos.
        public void ActualizarDatos()
        {
            // Mostrar lista en la vista Nuevo proceso.
            dgvProIngresado.DataSource = null;
            dgvProIngresado.DataSource = lp.MostrarLista();
            // Mostrar lista en la vista Procesos.
            dgvProcesos.DataSource = null;
            dgvProcesos.DataSource = lp.MostrarLista();
            // Total de procesos.
            lblTotal.Text = "Total de procesos: " + lp.Total();
        }

        // Limpiar todos los Textbox y ComboBox.
        public void LimpiarTxt()
        {
            this.txtNombre.Clear();
            this.txtPidId.Clear();
            this.txtCpu.Clear();
            this.txtMemoria.Clear();
            this.txtDisco.Clear();
            this.cbUsuario.SelectedIndex = -1;
            this.txtDescripcion.Clear();
            this.txtPID.Clear();
            this.txtPID2.Clear();
            this.txtTiempo.Clear();
        }

        // Activar o desactivar Texbox de la vista Equipo.
        public void ActivarDesactivar()
        {
            if (ckbActivar.Checked)
            {
                this.txtCPUTope.Enabled = true;
                this.txtMemoriaTope.Enabled = true;
                this.txtDiscoTope.Enabled = true;
            }
            else
            {
                this.txtCPUTope.Enabled = false;
                this.txtMemoriaTope.Enabled = false;
                this.txtDiscoTope.Enabled = false;
            }
        }

        // Validar TextBox.
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void txtPidId_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtCpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtMemoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtDisco_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void txtPID_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtPID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtPID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtCPUTope_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtMemoriaTope_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtDiscoTope_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        // Botón de Ingresar.
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Trim().Length == 0 || this.txtPidId.Text.Trim().Length == 0 || !(this.cbUsuario.SelectedIndex > -1) || 
                this.txtCpu.Text.Trim().Length == 0 || this.txtMemoria.Text.Trim().Length == 0 || this.txtDisco.Text.Trim().Length == 0 || 
                this.txtDescripcion.Text.Trim().Length == 0 || this.txtTiempo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Rellene todos los campos por favor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Procesos dt = new Procesos(this.txtNombre.Text, Int32.Parse(this.txtPidId.Text), "Ejecutando", 
                    this.cbUsuario.Text, Int32.Parse(this.txtCpu.Text), Int32.Parse(this.txtMemoria.Text), 
                    Int32.Parse(this.txtDisco.Text), this.txtDescripcion.Text, Int32.Parse(this.txtTiempo.Text));
                // Validar la busqueda.
                if(!(lp.BuscarLista(Int32.Parse(this.txtPidId.Text))))
                {
                    lp.InsertarLista(dt);
                    ActualizarDatos();
                    LimpiarTxt();
                    MessageBox.Show("Proceso almacenado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo alamacenar (PID ya existe).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Botón de Eliminar.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.txtPID2.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha agregado un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lp.EliminarDatoLista(Int32.Parse(txtPID2.Text));
                ActualizarDatos();
                LimpiarTxt();
                MessageBox.Show("Proceso eliminado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Botón de Finalizar.
        private void btnFinalizarProceso_Click(object sender, EventArgs e)
        {
            if (this.txtPID.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha agregado un valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lp.EliminarDatoLista(Int32.Parse(txtPID.Text));
                ActualizarDatos();
                LimpiarTxt();
                MessageBox.Show("Proceso finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Activar o desactivar los TextBox de la vista Equipo.
        private void ckbActivar_CheckedChanged(object sender, EventArgs e)
        {
            ActivarDesactivar();
        }

        // Opción Información.
        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Este sistema esta creado por Alción Computer.\nPrograma: Administrador de tareas.\nVersión: 1.0";
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Opción Ayuda.
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si necesita ayuda con la aplicación contacte con el Administrador.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        // Opción Actualizar.
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Se actualiza las tablas y el total de procesos.

            lp.IniciaLista();
            ActualizarDatos();
            MessageBox.Show("Procesos actualizados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Opción Salir.
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Quiere salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void tiempo()
        {
            memoriaRAMutilizada = 0;
            discoUtilizado = 0;
            cpuUtilizado = 0;
            for(int x = 0; x < lp.Total(); x++)
            {
                lp.tiempo(x);
                memoriaRAMutilizada = memoriaRAMutilizada + lp.ram(x);
                discoUtilizado = discoUtilizado + lp.disco(x);
                cpuUtilizado = cpuUtilizado + lp.cpu(x);
            }
            label1.Text = "RAM:" + memoriaRAMutilizada;
        }

        // Gráficas y tablas.
        private void tTiempo_Tick(object sender, EventArgs e)
        {
            if (memoriaRAM > memoriaRAMutilizada)
            {
                lp.IniciaLista();
            }
            ActualizarDatos();
        }

        private void DgvProIngresado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VistaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DgvProIngresado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvProIngresado.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value.Equals("Ejecutando"))
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
            if (this.dgvProIngresado.Columns[e.ColumnIndex].Name == "Tiempo")
            {
                if (Convert.ToInt32(e.Value) > 0)
                {
                    e.CellStyle.BackColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void DgvProcesos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvProcesos.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value.Equals("Ejecutando"))
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else{
                    e.CellStyle.BackColor = Color.Red;
                }
            }
            if(this.dgvProcesos.Columns[e.ColumnIndex].Name == "Tiempo")
            {
                if (Convert.ToInt32(e.Value) > 0)
                {
                    e.CellStyle.BackColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            tiempo();
            ActualizarDatos();
            label4.Text = "RAM: " + memoriaRAMutilizada + "\n" + ((100*memoriaRAMutilizada)/memoriaRAM + "% en uso") ;
            label5.Text = "CPU: " + cpuUtilizado + "\n" + ((100 * cpuUtilizado) / cpu + "% en uso");
            label6.Text = "Disco: " + discoUtilizado + "\n" + ((100 * discoUtilizado) / disco + "% en uso");
            cGrafica1.Series[0].Points.AddXY("", cpuUtilizado);
            cGrafica1.Series[1].Points.AddXY("", memoriaRAMutilizada);
            cGrafica1.Series[2].Points.AddXY("", discoUtilizado);

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void DgvProcesos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
