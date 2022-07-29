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
    public partial class frmTipoDocumentoeEdit : Form
    {
        private int? Id;
        public frmTipoDocumentoeEdit(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 1 : 0;
            string nombre = txtnombre.Text;
            var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
            if (this.Id == null)
            {
                adaptador.Add(nombre, (byte)estado);
            }
            else
            {
                adaptador.Edit(nombre, (byte)estado, (int)this.Id);
            }
            this.Close();
        }

        private void frmTipoDocumentoeEdit_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataById((int)this.Id);
                var fila = (DataSet1.TipoDocumentoRow)tabla.Rows[0];
                txtnombre.Text = fila.Nombre;
                chkEstado.Checked = fila.Estado == 1 ? true : false;
            }
            else
            {
                this.Text = "Nuevo";
            }
        }
    }
}
