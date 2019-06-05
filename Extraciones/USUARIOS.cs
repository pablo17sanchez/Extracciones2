using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Extraciones
{
    public partial class USUARIOS : Form
    {
        private string CONEXION_STRING = "Data Source=SVR-SQL;Initial Catalog=ALMACEN;User ID=sa;Password=$EXCC2013C";
        
         public string privilegi = string.Empty;
       
      
        public USUARIOS()
        {
            InitializeComponent();
        }

        private void TXTUSUARIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            PRIVILEGIOS_DE_ACCESO acceso = new PRIVILEGIOS_DE_ACCESO();
             SqlDataReader datard = acceso.VALIDAR_LOGIN(TXTUSUARIO.Text,TXTCONTRASEÑA.Text);
           
            bool validar = false;
            

            while (datard.Read())
            {
                if (this.comparestring(datard["USUARIO"].ToString(), TXTUSUARIO.Text) &&
                         this.comparestring(datard["CLAVE"].ToString(), TXTCONTRASEÑA.Text)
                    //   && this.comparestring(datard["PRIVILEGIO"].ToString(), roll)
                    )
                {

                    this.privilegi = datard["PRIVILEGIO"].ToString();
                    string prue = datard["USUARIO"].ToString();
                   
                    validar = true;
                   
                }
                else
                {

                    MessageBox.Show("Error");

                }
            }
            if (validar == true)
            {

                if (privilegi=="1")
                {
                   Form1_1 formulario = new Form1_1();
                    
                formulario.Show();
              
                string prueba = TXTUSUARIO.Text;
                formulario.label23.Text = prueba;

                Hide();
                    
                }
                else if(privilegi=="2")
                {
                    FORMULARIO_ALMACEN formulario = new FORMULARIO_ALMACEN();

                    formulario.Show();
                    string prueba = TXTUSUARIO.Text;
                    formulario.USUARIO.Text = prueba;
                    Hide();
                }







            }
            else
            {
               
                MessageBox.Show("LOGIN FAIL ","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);

                TXTCONTRASEÑA.Text = "";
            }

            
        }
     

        private bool comparestring(string string1, string string2)
        {
            return String.Compare(string1, string2, true, System.Globalization.CultureInfo.InvariantCulture) == 0 ? true : false;
        }

 
   
        
    }
}
