using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
namespace Extraciones
{
    public partial class Form1_1 : Form
    {
        DataTable table = new DataTable();
        public Form1_1()
        {
            InitializeComponent();
        }

        public void limpiar() {

            EXTRALABEL.Text = "EXT-";
        //TXTNUMKIT.Text="0";
TXTCONTADOR.Text="0";
TXTSERIEEQUIPO.Text="";
//TXTMODELOEQUIPO.Text="";
//TXTNUMEQUIPO.Text="";
TXTCANTIDAD.Text="0";
TXTDESCRIPCION.Text="";
//TXTSERIENTRADA.Text="";
//TXTMODELOENTRADA.Text="";
//TXTNOMBREEQUIPOENTRADA.Text = "";

            TXTNUMEQUIPO.Text="";
TXTMODELOEQUIPO.Text="";
TXTSERIEEQUIPO.Text="";
//TXTCONTADOR
TXTNOMBREEQUIPOENTRADA.Text="";
TXTMODELOENTRADA.Text="";
TXTSERIENTRADA.Text="";
TXTCONTADOR_ENTRADA.Text="0";
TXTCOMENTARIO.Text="";
COMBOCONDICION.Text="";
TXTTECNICO.Text="";
COMBOCLIENTE.Text="";
DATATIMEPICO.Text="";
TXTGERENTESERVICIO.Text="";
TXTSERVICIO.Text="";
TXT_CODIGO_PIEZA.Text="";
TXTCANTIDAD.Text="";
TXTCODIGOEXTRA.Text="";

TXTDESCRIPCION.Text="";
COMBOBODEGA.Text = "";

        
        
        }
        private void Form1_Resize(object sender, EventArgs e)
        {   
            //tamano de tab control
            tabmain.Size = new Size(this.Width, this.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // rpt1.DataSourceConnections.Item(0).SetLogon("admin", "admin");

            try
                
            {
                Extracciones_CSI rpt = new Extracciones_CSI();
                ConnectionInfo myConnectionInfo = new ConnectionInfo();
                myConnectionInfo.ServerName = "SVR-SQL";
                myConnectionInfo.DatabaseName = "ALMACEN";
                myConnectionInfo.UserID = "SA";
                myConnectionInfo.Password = "$EXCC2013C";
                myConnectionInfo.Type = ConnectionInfoType.Query;
                myConnectionInfo.IntegratedSecurity = false;
                TableLogOnInfos mytableloginfos = new TableLogOnInfos();
                TableLogOnInfos mytableloginfos2 = new TableLogOnInfos();
                mytableloginfos = crystalReportViewer1.LogOnInfo;
                mytableloginfos2 =  CRYSTAL.LogOnInfo;
                foreach (TableLogOnInfo myTableLogOnInfo in mytableloginfos)
                {
                    myTableLogOnInfo.ConnectionInfo = myConnectionInfo;
                }
                foreach (TableLogOnInfo myTableLogOnInfo in mytableloginfos2)
                {
                    myTableLogOnInfo.ConnectionInfo = myConnectionInfo;
                }
                rpt.SetParameterValue(0, 52);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:"+ ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
              
            }


          


            DataTable datacombo = new DataTable();
            DataTable datacombcliente = new DataTable();
            TRAERDATOS datos = new TRAERDATOS();
            // TODO: This line of code loads data into the 'ALMACENDataSet.EXTRACION_EQUIPO' table. You can move, or remove it, as needed.
           ///llenar combo begin 

            SqlDataAdapter llenar_combo = datos.llenarcombobodega();
            SqlDataAdapter llenarcomobocliente = datos.llenarcliente();
            llenar_combo.Fill(datacombo);
            llenarcomobocliente.Fill(datacombcliente);

            //COMOBO CLIENTE
            COMBOCLIENTE.DataSource = datacombcliente;
            COMBOCLIENTE.DisplayMember = "NOMBRE";

            ///COMO BODEGA
           COMBOBODEGA.DataSource = datacombo;
           COMBOBODEGA.DisplayMember = "BODEGA";
            //COMBOBODEGA.DisplayMember = "NOMBRE";
            //llenar como finished
            //TXTNUMKIT.Text = "0";
            TXTCONTADOR.Text = "0";
            TXTCANTIDAD.Text = "0";
          
            SqlDataAdapter data = datos.llenargrid();
            data.Fill(table);
            this.DataGrid.DataSource = table;
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image image = Extraciones.Properties.Resources.delete;
            img.Image = image;
            DataGrid.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";

            DataGrid.Columns[3].Width = 18;

            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

         


        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            if (TXTCOMENTARIO.Enabled == false)
            {
                DialogResult YESNOOT = MessageBox.Show("Desea seguir agregando extracciones", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (YESNOOT == System.Windows.Forms.DialogResult.Yes)
                {
                    TXTMODELOENTRADA.Enabled =  true;
                    TXTNOMBREEQUIPOENTRADA.Enabled = true;
                    TXTSERIENTRADA.Enabled = true;
                    TXTCONTADOR_ENTRADA.Enabled = true;
                    //TXTNOKITENTRADA.Enabled = true;
                   // TXTMODELOEQUIPO.Enabled = true;
                    TXTCOMENTARIO.Enabled = true;
                    COMBOCONDICION.Enabled = true;
                    TXTTECNICO.Enabled = true;
                    COMBOCLIENTE.Enabled = true;
                    DATATIMEPICO.Enabled = true;
                    TXTGERENTESERVICIO.Enabled = true;
                    TXTSERVICIO.Enabled = true;
                    TXT_CODIGO_PIEZA.Enabled = false;
                    TXTCANTIDAD.Enabled = false;
                    TXTDESCRIPCION.Enabled = false;
                    COMBOBODEGA.Enabled = false;
                    TXTMODELOEQUIPO.Enabled = false;
                 /*   TXTNUMEROKITE.Enabled = false;
                    TXTNUMEROKITE.Enabled = true;
                    TXTNUMEROKITS.Enabled = true;*/
                }
                MessageBox.Show("PUEDE SEGUIR AGREGANDO ESTRACCONES","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {



                if (TXTTECNICO.Text == "" || TXTNOMBREEQUIPOENTRADA.Text == "" || TXTMODELOENTRADA.Text == "" || TXTNOMBREEQUIPOENTRADA.Text == "" || TXTMODELOENTRADA.Text == "")
                {
                    MessageBox.Show("DEBE INGRESAR LOS CAMPOS OBLIGATORIOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {


                    DialogResult resultado = MessageBox.Show("Desea guardar esta informacion", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        UTILITY utilidad = new UTILITY();
                        DateTime fecha = (DateTime)DATATIMEPICO.Value;
                        string STRING_FECHA = fecha.ToString("MM/dd/yyyy HH:mm:ss");
                      //  int txtnumerkit = Convert.ToInt32(TXTNUMKIT.Text);
                        int contador = Convert.ToInt32(TXTCONTADOR_ENTRADA.Text);
                        int cantidad = Convert.ToInt32(TXTCANTIDAD.Text);
                        int contador_entrada = Convert.ToInt32(TXTCONTADOR_ENTRADA.Text);
                        string USUARIOLABEL = label23.Text;
                        //CONDICION_EXTRACION, NO_EQUIPO_S, MODELO_EQUIPO_S, SERIE_EQUIPO_S, CONTADOR_S,NUM_KIT_EQUIPO_S, NO_EQUIPO_E, MODELO_EQUIPO_E, SERIE_EQUIPO_E, CONTADOR_E, NUM_KIT_EQUIPO_E, TECNICO, CLIENTE, GERENTE_DE_SERVICIO, SERVICIO_AL_CLIENTE, COMENTARIO, USUARIO_CREA, FECHA_CREA, USUARIO_ACTUALIZA, FECHA_ACTUALIZA);
                        utilidad.insertar("", "", "", 0, "", COMBOCONDICION.Text, TXTNOMBREEQUIPOENTRADA.Text, TXTMODELOENTRADA.Text, TXTSERIENTRADA.Text, contador, "", TXTTECNICO.Text, COMBOCLIENTE.Text, TXTGERENTESERVICIO.Text, TXTSERVICIO.Text, TXTCOMENTARIO.Text, USUARIOLABEL, STRING_FECHA, USUARIOLABEL, STRING_FECHA);


                    }

                    table.Clear();
                    TRAERDATOS datos = new TRAERDATOS();
                    SqlDataAdapter data = datos.llenargrid();
                    data.Fill(table);
                    this.DataGrid.DataSource = table;

                    //DataGrid.ColumnCount = 3;
                    //DataGrid.Columns[0].Name = "Articulo";
                    //DataGrid.Columns[1].Name = "Descripcion";
                    //DataGrid.Columns[2].Name = "Cantidad";


                    //string[] row = new string[] { ArticuloText.Text, DescripcionText.Text, CantidadText.Text };
                    //DataGrid.Rows.Add(row);



                }
            }
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string CODIGO;

                if (e.ColumnIndex == 21)// created column index (delete button)
                {

                    string sub_valor = (string) DataGrid.CurrentRow.Cells["CODIGO EXTRACION"].Value;
                    int longitud = sub_valor.Length-4;

                    string valor = sub_valor.Substring(4, longitud);
                    if (EXTRALABEL.Text=="ADMIN")
                    {
                        UTILITY util = new UTILITY();
                        util.borrar(valor);
                    }
                    
                    DataGrid.Rows.Remove(DataGrid.Rows[e.RowIndex]);
                }
                COMBOCONDICION.Text = (string)DataGrid.CurrentRow.Cells["CONDICION_EXTRACION"].Value;
            //    COMBOCONDICION.Text = (string)DataGrid.CurrentRow.Cells["CONDICION_EXTRACION"].Value;
                TXTNUMEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["NO.EQUIPO_S"].Value;
                TXTMODELOEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["MODELO_EQUIPO_S"].Value;
                TXTSERIEEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["SERIE_EQUIPO_S"].Value;
                TXTCONTADOR.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CONTADOR_S"].Value);

                // int quantity = (int)DataGrid.CurrentRow.Cells["CANTIDAD"].Value;
                //   TXTCODIGO.Text = (string)DataGrid.CurrentRow.Cells["CODIGO EXTRACION"].Value;
                TXTMODELOEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["MODELO_EQUIPO_S"].Value;
                TXTSERIEEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["SERIE_EQUIPO_S"].Value;
                //TXTCONTADOR.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CONTADOR_S"].Value);
                TXTNUMEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["NO.EQUIPO_S"].Value;
   
                TXTNOMBREEQUIPOENTRADA.Text = (string)DataGrid.CurrentRow.Cells["NO.EQUIPO_E"].Value;
                TXTCOMENTARIO.Text = (string)DataGrid.CurrentRow.Cells["COMENTARIO"].Value;

                TXTMODELOENTRADA.Text = (string)DataGrid.CurrentRow.Cells["MODELO_EQUIPO_E"].Value;
                TXTSERIENTRADA.Text = (string)DataGrid.CurrentRow.Cells["SERIE_EQUIPO_E"].Value;
                TXTCONTADOR_ENTRADA.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CONTADOR_E"].Value);
               // TXTNOKITENTRADA.Text = (string)DataGrid.CurrentRow.Cells["NUM. KIT_EQUIPO_E"].Value;
                TXTTECNICO.Text = (string)DataGrid.CurrentRow.Cells["TECNICO"].Value;
                DATATIMEPICO.Value = (DateTime)DataGrid.CurrentRow.Cells["FECHA_CREA"].Value;
                //       TXT_CODIGO_PIEZA.Text = (string)DataGrid.CurrentRow.Cells["CODIGO_DEPIEZA"].Value;
                //  TXTCANTIDAD.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CANTIDAD"].Value);
                // TXTDESCRIPCION.Text = (string)DataGrid.CurrentRow.Cells["DESCRIPCION_PIEZA"].Value;
                //  COMBOBODEGA.Text = Convert.ToString(DataGrid.CurrentRow.Cells["BODEGA"].Value);
                TXTCOMENTARIO.Text = (string)DataGrid.CurrentRow.Cells["COMENTARIO"].Value;
                TXTGERENTESERVICIO.Text = (string)DataGrid.CurrentRow.Cells["GERENTE_DE_SERVICIO"].Value;
                TXTSERVICIO.Text = (string)DataGrid.CurrentRow.Cells["SERVICIO_AL_CLIENTE"].Value;
                CODIGO = (string)DataGrid.CurrentRow.Cells["CODIGO EXTRACION"].Value;
                EXTRALABEL.Text = CODIGO;
                if (CODIGO != "")
                {
                    int LONG = CODIGO.Length - 4;
                    string sub_codig = CODIGO.Substring(4, LONG);
                    TXTCODIGOEXTRA.Text = sub_codig;
                }
                else {
                    MessageBox.Show("Error al seleccionar el codigo (Por favor contacte con el administrador del sistema)", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }
            catch (Exception)
            {

                MessageBox.Show("NO DEBE DARLE CLICK AL TITULO DE LA TABLA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
        }

        private void TXTCONTADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TXTNUMKIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TXTCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TXTNUMEQUIPO_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXTNUMEQUIPO.Text) || TXTNUMEQUIPO.Text=="")
            {
                EQUIPOFAIL.Clear();
                EQUIPOFAIL.Icon = Extraciones.Properties.Resources.mal; ;

                EQUIPOFAIL.SetError(TXTNUMEQUIPO, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                EQUIPOFAIL.Clear();
                EQUIPOFAIL.Icon = Extraciones.Properties.Resources._1422667798_17871;
                EQUIPOFAIL.SetError(TXTNUMEQUIPO, "OK");
            }
        }

        private void TXTTECNICO_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXTTECNICO.Text))
            {
                errorProvider2.Clear();
                errorProvider2.Icon = Extraciones.Properties.Resources.mal; ;
                errorProvider2.SetError(TXTTECNICO, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                errorProvider2.Clear();
                errorProvider2.Icon = Extraciones.Properties.Resources._1422667798_17871;
                errorProvider2.SetError(TXTTECNICO, "OK");
            }
        }

        private void TXTMODELOEQUIPO_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TXTMODELOEQUIPO.Text))
            {
                ERRORMODELO.Clear();
                ERRORMODELO.Icon = Extraciones.Properties.Resources.mal; ;
                ERRORMODELO.SetError(TXTMODELOEQUIPO, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                ERRORMODELO.Clear();
                ERRORMODELO.Icon = Extraciones.Properties.Resources._1422667798_17871;
                ERRORMODELO.SetError(TXTMODELOEQUIPO, "OK");
            }
        }

        private void TXT_CODIGO_PIEZA_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_CODIGO_PIEZA.Text))
            {
                errorProvider1.Clear();
                errorProvider1.Icon = Extraciones.Properties.Resources.mal; ;
                errorProvider1.SetError(TXT_CODIGO_PIEZA, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                errorProvider1.Clear();
                errorProvider1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                errorProvider1.SetError(TXT_CODIGO_PIEZA, "OK");
            }

        }

        private void Busqueda_Extracion_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter DATA = new SqlDataAdapter();
                DataTable datatable = new DataTable();
                TRAERDATOS datos = new TRAERDATOS();
                string textobusqueda = TXTBUSQUEDA.Text;
                DateTime DESDE = desde.Value;
                DateTime HASTA = hasta.Value;
                string STRINGDESDE = DESDE.ToString("MM/dd/yyyy 00:00:23");
                string STRINGHASTA = HASTA.ToString("MM/dd/yyyy 23:00:23");
                int LONGITUD = textobusqueda.Length - 4;
                //1/19/2015 15:34:42
                if (CRITERIOCOMBO.Text == "FECHA")
                {
                    datatable.Clear();
                    DATA = datos.busquedafecha(STRINGDESDE, STRINGHASTA);
                }

                else if (CRITERIOCOMBO.Text == "CODIGO_EXTRACION")
                {
                    string busqueda = textobusqueda.Substring(4, LONGITUD);
                    datatable.Clear();
                    DATA = datos.busqueda(busqueda, CRITERIOCOMBO.Text);
                }
                else
                {
                    datatable.Clear();
                    DATA = datos.busqueda(TXTBUSQUEDA.Text, CRITERIOCOMBO.Text);
                }

                DATA.Fill(datatable);
                this.DBGRID.DataSource = datatable;
            }
            catch (Exception)
            {
                MessageBox.Show("VERIFIQUE QUE LA FECHA DE INICIO ES MENOR A LA DE FINAL","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }
           


            
          
           
           
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void CRITERIOCOMBO_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CRITERIOCOMBO.Text == "FECHA")
            {
                TXTBUSQUEDA.Visible = false;
                label16.Visible = false;
                desde.Visible = true;
                hasta.Visible = true;
                LBDESDE.Visible = true;
                LBHASTA.Visible = true;
            }
            else if (CRITERIOCOMBO.Text == "CODIGO_EXTRACION")
            {

                TXTBUSQUEDA.Visible = true;
                label16.Visible = true;
                desde.Visible = false;
                hasta.Visible = false;
                LBDESDE.Visible = false;
                LBHASTA.Visible = false;
                TXTBUSQUEDA.Text = "EXT-";


            }

            else
            {
                TXTBUSQUEDA.Visible = true;
                label16.Visible = true;
                desde.Visible = false;
                hasta.Visible = false;
                LBDESDE.Visible = false;
                LBHASTA.Visible = false;
                TXTBUSQUEDA.Text = "";

            }
                
            }

        private void TXTNOMBREEQUIPOENTRADA_Leave(object sender, EventArgs e)
        {
         
            if (string.IsNullOrEmpty(TXTNOMBREEQUIPOENTRADA.Text))
            {
                ENTRADA1.Clear();
                ENTRADA1.Icon = Extraciones.Properties.Resources.mal; ;
                ENTRADA1.SetError(TXTNOMBREEQUIPOENTRADA, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                ENTRADA1.Clear();
                ENTRADA1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                ENTRADA1.SetError(TXTNOMBREEQUIPOENTRADA, "OK");
            }

        }

        private void TXTMODELOENTRADA_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXTMODELOENTRADA.Text))
            {
                 ENTRADA2.Clear();
                 ENTRADA2.Icon = Extraciones.Properties.Resources.mal; ;
                 ENTRADA2.SetError(TXTMODELOENTRADA, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                ENTRADA2.Clear();
                ENTRADA2.Icon = Extraciones.Properties.Resources._1422667798_17871;
                ENTRADA2.SetError(TXTMODELOENTRADA, "OK");
            }
        }

        private void BTNCLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CAMBIAR_CONTRASEÑA CONTRASEÑA = new CAMBIAR_CONTRASEÑA();
            CONTRASEÑA.Show();
        }

        private void Nueva_Extracion_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TXTNOMBREEQUIPOENTRADA_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TXTCONTADOR_ENTRADA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void TXTSERVICIOCLIENTE_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void BTNAGREGARPIEZA_Click(object sender, EventArgs e)
        {
            if (TXTCOMENTARIO.Enabled == true)
            {


                DialogResult yesno = MessageBox.Show("Desea agregar una pieza?", "INFORMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (yesno == System.Windows.Forms.DialogResult.Yes)
                {
                    TXTMODELOENTRADA.Enabled = false;
                    TXTNUMEQUIPO.Enabled = false;
                    TXTMODELOEQUIPO.Enabled = false;
                    TXTCONTADOR.Enabled = false;
                  //  TXTNUMKIT.Enabled = false;
                    COMBOCONDICION.Enabled = false;
                    TXTNOMBREEQUIPOENTRADA.Enabled = false;
                    TXTSERIENTRADA.Enabled = false;
                    TXTCONTADOR_ENTRADA.Enabled = false;
                  //  TXTNOKITENTRADA.Enabled = false;
                    TXTMODELOEQUIPO.Enabled = false;
                    TXTCOMENTARIO.Enabled = false;

                    TXTTECNICO.Enabled = false;
                    COMBOCLIENTE.Enabled = false;
                    DATATIMEPICO.Enabled = false;
                    TXTGERENTESERVICIO.Enabled = false;
                    TXTSERVICIO.Enabled = false;
                    TXT_CODIGO_PIEZA.Enabled = true;
                    TXTCANTIDAD.Enabled = true;
                    TXTDESCRIPCION.Enabled = true;
                    COMBOBODEGA.Enabled = true;
                   // TXTNUMEROKITE.Enabled = true;
                    //TXTNUMEROKITS.Enabled = true;
                }
            }
            else
            {

                if (TXTCODIGOEXTRA.Text == "")
                {

                    MessageBox.Show("Debe seleccionar una extracion para proseguir agregando piezas", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    int cantidad = Convert.ToInt32(TXTCANTIDAD.Text);

                    UTILITY UTILIDAD = new UTILITY();
                    UTILIDAD.insertar_detalle(TXTCODIGOEXTRA.Text, TXT_CODIGO_PIEZA.Text, TXTDESCRIPCION.Text, cantidad, COMBOBODEGA.Text,"","");
                    TXT_CODIGO_PIEZA.Text="";
                    TXTCANTIDAD.Text="0";
                    TXTDESCRIPCION.Text="";
                    COMBOBODEGA.Text = "";

                }




            }





               
           

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LBHASTA_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

         
            if (TXTCODIGOEXTRA.Text!="")
            {
                try
                {

                    DateTime fecha = DateTime.Now;
                    string STRING_FECHA = fecha.ToString("MM/dd/yyyy HH:mm:ss");
                    int CONTADOR = Convert.ToInt32(TXTCONTADOR_ENTRADA.Text);
                    UTILITY UTL = new UTILITY();
                    UTL.update_de_servicio(COMBOCONDICION.Text, TXTNOMBREEQUIPOENTRADA.Text, TXTMODELOENTRADA.Text, TXTSERIEEQUIPO.Text, CONTADOR, "", TXTTECNICO.Text, COMBOCLIENTE.Text, TXTGERENTESERVICIO.Text, TXTSERVICIOCLIENTE.Text, TXTCOMENTARIO.Text, label23.Text, STRING_FECHA, TXTCODIGOEXTRA.Text);
                    table.Clear();
                    TRAERDATOS datos = new TRAERDATOS();
                    SqlDataAdapter data = datos.llenargrid();
                    data.Fill(table);
                    this.DataGrid.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally {

                    MessageBox.Show("Se completo la actualizacion", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }
                 
            }
            else
            {
                MessageBox.Show("Debe seleccionar una extraccion", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        }



     
    }

