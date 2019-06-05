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
    public class UTILITY
    {
       private string CONEXION_STRING = "Data Source=SVR-SQL;Initial Catalog=ALMACEN;User ID=sa;Password=$EXCC2013C";

        public SqlConnection retornarconexion()
        {

            SqlConnection con = new SqlConnection(CONEXION_STRING);


            return con;
        }


        public void insertar(string NO_EQUIPO_S, string MODELO_EQUIPO_S, string SERIE_EQUIPO_S, int CONTADOR_S, string NUM_KIT_EQUIPO_S ,string CONDICION_EXTRACION, string NO_EQUIPO_E, string MODELO_EQUIPO_E, string SERIE_EQUIPO_E, int CONTADOR_E, string NUM_KIT_EQUIPO_E, string TECNICO, string CLIENTE, string GERENTE_DE_SERVICIO, string SERVICIO_AL_CLIENTE, string COMENTARIO, string USUARIO_CREA, string FECHA_CREA,string USUARIO_ACTUALIZA,string FECHA_ACTUALIZA)
        {
SqlConnection conn= retornarconexion();
string fomrato = string.Format("INSERT INTO [CSI].[EXTRACION_EQUIPO_MAESTRO]([CONDICION_EXTRACION],[NO.EQUIPO_S],[MODELO_EQUIPO_S],[SERIE_EQUIPO_S],[CONTADOR_S] ,[NUM. KIT_EQUIPO_S],[NO.EQUIPO_E],[MODELO_EQUIPO_E],[SERIE_EQUIPO_E],[CONTADOR_E],[NUM. KIT_EQUIPO_E],[TECNICO],[CLIENTE],[GERENTE_DE_SERVICIO],[SERVICIO_AL_CLIENTE],[COMENTARIO],[USUARIO_CREA],[FECHA_CREA],[USUARIO_ACTUALIZA],[FECHA_ACTUALIZA]) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')", CONDICION_EXTRACION, NO_EQUIPO_S, MODELO_EQUIPO_S, SERIE_EQUIPO_S, CONTADOR_S,NUM_KIT_EQUIPO_S, NO_EQUIPO_E, MODELO_EQUIPO_E, SERIE_EQUIPO_E, CONTADOR_E, NUM_KIT_EQUIPO_E, TECNICO, CLIENTE, GERENTE_DE_SERVICIO, SERVICIO_AL_CLIENTE, COMENTARIO, USUARIO_CREA, FECHA_CREA, USUARIO_ACTUALIZA, FECHA_ACTUALIZA);

        conn.Open();
        SqlCommand comando = new SqlCommand(fomrato, conn);
        comando.ExecuteNonQuery();
        conn.Close();
	
        
        
        }

        public void borrar(string codigo) {


            SqlConnection conn = retornarconexion();
            string comandostring = string.Format("DELETE FROM [CSI].[EXTRACION_EQUIPO_MAESTRO]  WHERE [CODIGO EXTRACION]={0}", codigo);
            string commandostringdetalle = string.Format("DELETE FROM [CSI].[EXTRACION_EQUIPO_DETALLE]  WHERE [CODIGO EXTRACION]={0}",codigo);
            if (conn.State==ConnectionState.Open)
            {
                SqlCommand comando_para_detalle = new SqlCommand(commandostringdetalle, conn);
                comando_para_detalle.ExecuteNonQuery();
                SqlCommand comando = new SqlCommand(comandostring,conn);
                comando.ExecuteNonQuery();
                conn.Close();
              
            }
            else
            {
                conn.Open();
                SqlCommand comando_para_detalle = new SqlCommand(commandostringdetalle, conn);
                comando_para_detalle.ExecuteNonQuery();
                SqlCommand comando = new SqlCommand(comandostring, conn);
                comando.ExecuteNonQuery();
                conn.Close();

            }
        
        
        
        }

        public void update(string NO_EQUIPO_S, string MODELO_EQUIPO_S, string SERIE_EQUIPO_S, int CONTADOR_S, string NUM_KIT_EQUIPO_S, string CODIGO_EXTRACION )
        {

            SqlConnection conn = retornarconexion();
            conn.Open();
            string comandoinsertdetalle = string.Format("UPDATE [CSI].[EXTRACION_EQUIPO_MAESTRO] SET [NO.EQUIPO_S] ='{0}',[MODELO_EQUIPO_S] = '{1}',[SERIE_EQUIPO_S] = '{2}',[CONTADOR_S] = {3},[NUM. KIT_EQUIPO_S] = '{4}' WHERE [CODIGO EXTRACION]='{5}'",NO_EQUIPO_S,MODELO_EQUIPO_S,SERIE_EQUIPO_S,CONTADOR_S,NUM_KIT_EQUIPO_S,CODIGO_EXTRACION);

            SqlCommand comando = new SqlCommand(comandoinsertdetalle, conn);
            comando.ExecuteNonQuery();
            conn.Close();
           MessageBox.Show("Se agrego a la EXT-"+CODIGO_EXTRACION, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }


        public void insertar_detalle(string CODIGO_EXTRACION,string CODIGO_PIEZA, string DESCRIPCION_PIEZA, int CANTIDAD, string BODEGA,string NUMEROE, string NUMEROS)
        {



            SqlConnection conn = retornarconexion();
            conn.Open();
            string comandoinsertdetalle = string.Format("INSERT INTO [CSI].[EXTRACION_EQUIPO_DETALLE]([CODIGO EXTRACION],[CODIGO_DE_PIEZA],[DESCRIPCION_PIEZA] ,[CANTIDAD] ,[BODEGA],[NUM. KIT_EQUIPO_S],[NUM. KIT_EQUIPO_E])VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}')",CODIGO_EXTRACION,CODIGO_PIEZA,DESCRIPCION_PIEZA,CANTIDAD,BODEGA,NUMEROS,NUMEROE);

            SqlCommand comando = new SqlCommand(comandoinsertdetalle, conn);
            comando.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Se agrego la pieza en EXT-"+CODIGO_EXTRACION,"Informaticon",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        public void update_de_servicio(string CONDICION_EXTRACION, string NO_EQUIPO_E, string MODELO_EQUIPO_E, string SERIE_EQUIPO_E, int CONTADOR_E, string KIT_EQUIPO_E, string TECNICO, string CLIENTE, string GERENTE_DE_SERVICIO, string SERVICIO_AL_CLIENTE, string COMENTARIO, string USUARIO_CREA, string FECHA_CREA, string CODIGO_EXTRACION)
        {


            SqlConnection conn = retornarconexion();
            conn.Open();
            string comando_update = string.Format("UPDATE [CSI].[EXTRACION_EQUIPO_MAESTRO]SET [CONDICION_EXTRACION] = '{0}',[NO.EQUIPO_E] = '{1}',[MODELO_EQUIPO_E] = '{2}',[SERIE_EQUIPO_E] ='{3}',[CONTADOR_E] = {4},[NUM. KIT_EQUIPO_E] = '{5}',[TECNICO] = '{6}',[CLIENTE] = '{7}',[GERENTE_DE_SERVICIO] = '{8}',[SERVICIO_AL_CLIENTE] = '{9}',[COMENTARIO] = '{10}',[USUARIO_ACTUALIZA] = '{11}',[FECHA_ACTUALIZA] = '{12}' WHERE [CODIGO EXTRACION]='{13}'",
                CONDICION_EXTRACION,NO_EQUIPO_E,MODELO_EQUIPO_E,SERIE_EQUIPO_E,CONTADOR_E,KIT_EQUIPO_E,TECNICO,CLIENTE,GERENTE_DE_SERVICIO,SERVICIO_AL_CLIENTE,COMENTARIO,USUARIO_CREA,FECHA_CREA,CODIGO_EXTRACION);
            SqlCommand comando = new SqlCommand(comando_update, conn);
            comando.ExecuteNonQuery();
            conn.Close();
        
        }


        public void ADDNUMER(string NUME,string NUMS,int CODIGO) {


            SqlConnection conn = retornarconexion();
            conn.Open();
            string comandoinsertdetalle = string.Format("UPDATE [CSI].[EXTRACION_EQUIPO_DETALLE] SET [NUM. KIT_EQUIPO_S] = '{0}',[NUM. KIT_EQUIPO_E] = '{1}' WHERE [CODIGO EXTRACION]={2}",NUMS,NUME,CODIGO);
            SqlCommand comando = new SqlCommand(comandoinsertdetalle, conn);
            comando.ExecuteNonQuery();
            conn.Close();
            string codigo = Convert.ToString(CODIGO);
            MessageBox.Show("Se ingreso perfectamente en EXT-" + codigo,"INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
