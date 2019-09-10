using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministradorTareas
{
    class Validar
    {
        // Validar TextBox para ingresar sólo números.
        public void SoloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar)) // Va a capturar si es número o no.
                {
                    e.Handled = false; // Permitir que escriba números.
                }
                else if (Char.IsControl(e.KeyChar)) // Para borrar.
                {
                    e.Handled = false; // Permitir que borre.
                }
                else
                {
                    e.Handled = true; // No se escribe si no es un núnero.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de validación: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SoloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar)) // Va a capturar si es letra o no.
                {
                    e.Handled = false; // Permita que escriba letras.
                }
                else if (Char.IsControl(e.KeyChar)) // Para borrar.
                {
                    e.Handled = false; // Permitir que borre.
                }
                else if (Char.IsSeparator(e.KeyChar)) // IsSeparator es para validar espacios.
                {
                    e.Handled = false; // Permitir espacios.
                }
                else
                {
                    e.Handled = true; // No se escribe si no es letra.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de validación: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
