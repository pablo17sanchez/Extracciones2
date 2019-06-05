using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Extraciones
{
    class CONEXION
    {

        private SqlConnection conn;
        private string connctionstring ="Data Source=SVR-SQL;Initial Catalog=Extraciones;User ID=sa;Password=$EXCC2013C"; 
        public SqlConnection DELVOERCONEXION() {
            try
            {
                    conn = new SqlConnection();


            conn.ConnectionString = connctionstring;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar con la base de datos: "+e.ToString(),"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
                
            }
       
           return conn;
        
        
        }



        public void insertar( ) {

            //string comandostring = string.Format("",);
            SqlConnection conn = DELVOERCONEXION();


            if (conn.State==System.Data.ConnectionState.Open)
            {
                //SqlCommand comando = new SqlCommand(comandostring,conn);


                //comando.ExecuteNonQuery();
                //conn.Close();

            }
            else
            {
              
            }
        
        
        }

    }
}
