using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA1_CARRASCO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            // Creamos la instancia del Adaptador
            var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
            // Obtenemos el objeto DataTable
            var tabla = adaptador.GetData();
            // Asignamos el origen de datos al control (DataGridView)
            dgvtipodocumento.DataSource = tabla;
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            var frm = new frmTipoDocumentoeEdit();
            frm.ShowDialog();
            cargarDatos();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new frmTipoDocumentoeEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un Id válido", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int getId()
        {
            try
            {
                // ¿Qué queremos procesar?
                DataGridViewRow filaActual = dgvtipodocumento.CurrentRow;
                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvtipodocumento.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                // ¿Qué hacer en caso de error?
                return 0;
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistemas",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    // ELIMINAR EL REGISTRO
                    var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
                    adaptador.Remove(id);

                    MessageBox.Show("Registro Eliminado", "Sistemas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Id válido", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
