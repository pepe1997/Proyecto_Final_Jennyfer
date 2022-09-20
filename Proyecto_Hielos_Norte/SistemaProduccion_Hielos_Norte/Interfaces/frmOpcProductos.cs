using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaProduccion_Hielos_Norte.Interfaces;

namespace SistemaProduccion_Hielos_Norte
{
    public partial class frmOpcProductos : Form
    {
        public Form FormularioVista { get; set; }
        public frmOpcProductos()
        {
            InitializeComponent();
        }

        private void frmOpcProductos_Load(object sender, EventArgs e)
        {

        }
       

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            FormularioVista = new FrmRegistrarProductos();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
