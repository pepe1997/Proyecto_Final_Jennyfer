
namespace SistemaProduccion_Hielos_Norte
{
    partial class frmOpcProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegistrarProducto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegistrarProducto
            // 
            this.btnRegistrarProducto.Location = new System.Drawing.Point(154, 90);
            this.btnRegistrarProducto.Name = "btnRegistrarProducto";
            this.btnRegistrarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrarProducto.TabIndex = 0;
            this.btnRegistrarProducto.Text = "Registar";
            this.btnRegistrarProducto.UseVisualStyleBackColor = true;
            this.btnRegistrarProducto.Click += new System.EventHandler(this.btnRegistrarProducto_Click);
            // 
            // frmOpcProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistrarProducto);
            this.Name = "frmOpcProductos";
            this.Text = "frmOpcProductos";
            this.Load += new System.EventHandler(this.frmOpcProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarProducto;
    }
}