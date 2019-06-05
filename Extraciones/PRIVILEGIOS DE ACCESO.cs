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
   public class PRIVILEGIOS_DE_ACCESO
    {
        private string CONEXION_STRING = "Data Source=SVR-SQL;Initial Catalog=ALMACEN;User ID=sa;Password=$EXCC2013C";
     
        private bool comparestring(string string1, string string2)
 {  
            return String.Compare(string1, string2, true, System.Globalization.CultureInfo.InvariantCulture) == 0 ? true : false;  
      }  
       public SqlDataReader VALIDAR_LOGIN(string usuario,string password ) {
           string comadostring =  string.Format("SELECT  isnull([USUARIO],'')as [USUARIO] ,isnull([CLAVE],'') AS [CLAVE],isnull([PRIVILEGIO],'') AS [PRIVILEGIO]  FROM [ALMACEN].[dbo].[CSI.EXTRACION_LOGIN] where USUARIO='{0}' AND CLAVE ='{1}'",usuario,password);
            SqlConnection conn = new SqlConnection(CONEXION_STRING);
           conn.Open();
            SqlCommand comando = new SqlCommand(comadostring,conn);
            SqlDataReader dataread=comando.ExecuteReader();
   

        return dataread;
        
        }



       public void cambiar_contraseña(string usuario, string old_password,string new_password) {
           SqlConnection conn = new SqlConnection(CONEXION_STRING);
           conn.Open();
           string updatepassword = string.Format("UPDATE [dbo].[CSI.EXTRACION_LOGIN] SET [CLAVE] = '{2}'  WHERE USUARIO ='{0}' and [CLAVE]='{1}'",usuario,old_password,new_password);

           SqlCommand comando = new SqlCommand(updatepassword, conn);
           int numberOfRecords =  comando.ExecuteNonQuery();
           conn.Close();
           if (numberOfRecords == 0)
           {
               MessageBox.Show("Este nombre de usuario no existe o su contraseña es incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
           else { MessageBox.Show("La contraseña se cambio satifactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information); 
           }
       }

    }
}
