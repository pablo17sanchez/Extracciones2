using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extraciones
{
    public partial class CAMBIAR_CONTRASEÑA : Form
    {
        public CAMBIAR_CONTRASEÑA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXTNEWPASSWORD.Text!=string.Empty)
                {
                    PRIVILEGIOS_DE_ACCESO cambiar = new PRIVILEGIOS_DE_ACCESO();
                cambiar.cambiar_contraseña(TXTUSUARIO.Text, TXTPASSWORD.Text, TXTNEWPASSWORD.Text); 
                }
                else
                {
                    MessageBox.Show("La contraseña debe tener al menos un caracter", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("ADADSADr", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            finally {

              
            
            }
            

        }

        private void TXTUSUARIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
