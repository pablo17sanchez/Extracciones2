using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace Extraciones
{
    class TRAERDATOS
    {
        private string CONEXION_STRING = "Data Source=SVR-SQL;Initial Catalog=ALMACEN;User ID=sa;Password=$EXCC2013C";
        private string comandostring = "SELECT'EXT-'+ CONVERT(VARCHAR(20),[CODIGO EXTRACION]) AS [CODIGO EXTRACION],[NO.EQUIPO_S],[MODELO_EQUIPO_S],[SERIE_EQUIPO_S],[CONTADOR_S],[NUM. KIT_EQUIPO_S],[CONDICION_EXTRACION],[NO.EQUIPO_E],[MODELO_EQUIPO_E],[SERIE_EQUIPO_E],[CONTADOR_E],[NUM. KIT_EQUIPO_E],[TECNICO] ,[CLIENTE],[GERENTE_DE_SERVICIO],[SERVICIO_AL_CLIENTE],[COMENTARIO],[USUARIO_CREA],[FECHA_CREA],[USUARIO_ACTUALIZA],[FECHA_ACTUALIZA] FROM [ALMACEN].[CSI].[EXTRACION_EQUIPO_MAESTRO]";
        public SqlConnection retornarconexion()
        {

            SqlConnection con = new SqlConnection(CONEXION_STRING);
      

            return con;
        }


       



        public SqlDataAdapter llenargrid() {

            SqlConnection conn = retornarconexion();

           
              
                conn.Open();
                SqlCommand comando = new SqlCommand(comandostring, conn);
                
                conn.Close();
           

            SqlDataAdapter data = new SqlDataAdapter(comando);
            return data;

 }

        public SqlDataAdapter busquedafecha(string desde, string hasta) {

            SqlDataAdapter data = new SqlDataAdapter();

            SqlConnection conn = retornarconexion();

            string select = string.Format("SELECT'EXT-'+ CONVERT(VARCHAR(20),[CODIGO EXTRACION]) AS [CODIGO EXTRACION],[NO.EQUIPO_S],[MODELO_EQUIPO_S],[SERIE_EQUIPO_S],[CONTADOR_S],[NUM. KIT_EQUIPO_S],[CONDICION_EXTRACION],[NO.EQUIPO_E],[MODELO_EQUIPO_E],[SERIE_EQUIPO_E],[CONTADOR_E],[NUM. KIT_EQUIPO_E],[TECNICO] ,[CLIENTE],[GERENTE_DE_SERVICIO],[SERVICIO_AL_CLIENTE],[COMENTARIO],[USUARIO_CREA],[FECHA_CREA],[USUARIO_ACTUALIZA],[FECHA_ACTUALIZA] FROM [ALMACEN].[CSI].[EXTRACION_EQUIPO_MAESTRO] where  FECHA_CREA >='{0}' and FECHA_CREA <= '{1}'", desde, hasta);
            conn.Open();
            SqlCommand comando = new SqlCommand(select, conn);

            conn.Close();
            data = new SqlDataAdapter(comando);
            return data;
        }
        public SqlDataAdapter busqueda(string texto,string criterio )
        {
            SqlDataAdapter data = new SqlDataAdapter();
           
            SqlConnection conn = retornarconexion();


            if (criterio=="CODIGO_EXTRACION")
            {
                string selectporcodigo = string.Format("SELECT'EXT-'+ CONVERT(VARCHAR(20),[CODIGO EXTRACION]) AS [CODIGO EXTRACION],[NO.EQUIPO_S],[MODELO_EQUIPO_S],[SERIE_EQUIPO_S],[CONTADOR_S],[NUM. KIT_EQUIPO_S],[CONDICION_EXTRACION],[NO.EQUIPO_E],[MODELO_EQUIPO_E],[SERIE_EQUIPO_E],[CONTADOR_E],[NUM. KIT_EQUIPO_E],[TECNICO] ,[CLIENTE],[GERENTE_DE_SERVICIO],[SERVICIO_AL_CLIENTE],[COMENTARIO],[USUARIO_CREA],[FECHA_CREA],[USUARIO_ACTUALIZA],[FECHA_ACTUALIZA] FROM [ALMACEN].[CSI].[EXTRACION_EQUIPO_MAESTRO] where [CODIGO EXTRACION] = '{0}'", texto);
           
             conn.Open();
             SqlCommand comando = new SqlCommand(selectporcodigo, conn);

            conn.Close();


           data = new SqlDataAdapter(comando);

            
            
            }

                  if (criterio=="NUMERO_EQUIPO")
            {
                string selectpornumero = string.Format("SELECT'EXT-'+ CONVERT(VARCHAR(20),[CODIGO EXTRACION]) AS [CODIGO EXTRACION],[NO.EQUIPO_S],[MODELO_EQUIPO_S],[SERIE_EQUIPO_S],[CONTADOR_S],[NUM. KIT_EQUIPO_S],[CONDICION_EXTRACION],[NO.EQUIPO_E],[MODELO_EQUIPO_E],[SERIE_EQUIPO_E],[CONTADOR_E],[NUM. KIT_EQUIPO_E],[TECNICO] ,[CLIENTE],[GERENTE_DE_SERVICIO],[SERVICIO_AL_CLIENTE],[COMENTARIO],[USUARIO_CREA],[FECHA_CREA],[USUARIO_ACTUALIZA],[FECHA_ACTUALIZA] FROM [ALMACEN].[CSI].[EXTRACION_EQUIPO_MAESTRO] where [NO.EQUIPO_E] = '{0}'", texto);
           
             conn.Open();
             SqlCommand comando = new SqlCommand(selectpornumero, conn);

            conn.Close();


        data = new SqlDataAdapter(comando);

            
            
            }
                      if (criterio=="TECNICO")
            {
                string selectportecnico = string.Format("SELECT'EXT-'+ CONVERT(VARCHAR(20),[CODIGO EXTRACION]) AS [CODIGO EXTRACION],[NO.EQUIPO_S],[MODELO_EQUIPO_S],[SERIE_EQUIPO_S],[CONTADOR_S],[NUM. KIT_EQUIPO_S],[CONDICION_EXTRACION],[NO.EQUIPO_E],[MODELO_EQUIPO_E],[SERIE_EQUIPO_E],[CONTADOR_E],[NUM. KIT_EQUIPO_E],[TECNICO] ,[CLIENTE],[GERENTE_DE_SERVICIO],[SERVICIO_AL_CLIENTE],[COMENTARIO],[USUARIO_CREA],[FECHA_CREA],[USUARIO_ACTUALIZA],[FECHA_ACTUALIZA] FROM [ALMACEN].[CSI].[EXTRACION_EQUIPO_MAESTRO] where TECNICO = '{0}'", texto);
           
             conn.Open();
             SqlCommand comando = new SqlCommand(selectportecnico, conn);

            conn.Close();


        data = new SqlDataAdapter(comando);

            
            
            }
           
            return data;
        }



        public SqlDataAdapter llenarcombobodega(){
            SqlConnection conn = retornarconexion();
            //SqlDataReader dataread = new SqlDataReader();
            string seletbodegas = "SELECT  [BODEGA] FROM [EXACTUS].[CSI].[BODEGA]";
            conn.Open();
                SqlDataAdapter comando = new SqlDataAdapter(seletbodegas,conn);

             
                conn.Close();
                
            
         
           
            return comando;
        
        
        }


        public SqlDataAdapter llenarcliente()
        {
            SqlConnection conn = retornarconexion();
            //SqlDataReader dataread = new SqlDataReader();
            string seletbodegas = "SELECT [NOMBRE] FROM [EXACTUS].[CSI].[CLIENTE]";
            conn.Open();
            SqlDataAdapter comando = new SqlDataAdapter(seletbodegas, conn);


            conn.Close();




            return comando;


        }


    

    }
}
