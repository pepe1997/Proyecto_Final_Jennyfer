using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entPermisos;

namespace SistemaProduccion_Hielos_Norte.Interfaces
{
    public partial class frmInicio : Form
    {
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string FechaHora { get; set; }
        public string Clave { get; set; }
        public  Permisos oPermisos { get; set; }
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }
        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        private void btnProducto_Click(object sender, EventArgs e)
        {
            using (var Iform = new frmOpcProductos())
            {

                Iform.BackColor = Color.Teal;
                var result = Iform.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Form FormularioVista = Iform.FormularioVista;
                    this.Hide();
                    FormularioVista.Show();
                    FormularioVista.FormClosing += Frm_Closing;
                }
            }
        }
       
    }
}
