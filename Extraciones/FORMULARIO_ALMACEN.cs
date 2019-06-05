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
using Microsoft.VisualBasic;


using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;

namespace Extraciones
{
    public partial class FORMULARIO_ALMACEN : Form
    {
        DataTable table = new DataTable();
        string codigo;
        public string sub_codig=string.Empty;
        public FORMULARIO_ALMACEN()
        {
            InitializeComponent();
        }

        private void FORMULARIO_ALMACEN_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectionInfo myConnectionInfo = new ConnectionInfo();
                myConnectionInfo.ServerName = "SVR-SQL";
                myConnectionInfo.DatabaseName = "ALMACEN";
                myConnectionInfo.UserID = "SA";
                myConnectionInfo.Password = "$EXCC2013C";
                myConnectionInfo.Type = ConnectionInfoType.Query;
                myConnectionInfo.IntegratedSecurity = false;
                TableLogOnInfos mytableloginfos = new TableLogOnInfos();
                mytableloginfos = crystalReportViewer1.LogOnInfo;
                foreach (TableLogOnInfo myTableLogOnInfo in mytableloginfos)
                {
                    myTableLogOnInfo.ConnectionInfo = myConnectionInfo;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            DataTable datacombo = new DataTable();
            TRAERDATOS datos = new TRAERDATOS();
            // TODO: This line of code loads data into the 'ALMACENDataSet.EXTRACION_EQUIPO' table. You can move, or remove it, as needed.
            ///llenar combo begin 

            SqlDataAdapter llenar_combo = datos.llenarcombobodega();
            llenar_combo.Fill(datacombo);
            COMBOBODEGA.DataSource = datacombo;
            COMBOBODEGA.DisplayMember = "BODEGA";
            //llenar como finished
          //  TXTNUMKIT.Text = "0";
            TXTCONTADOR.Text = "0";
            TXTCANTIDAD.Text = "0";

            SqlDataAdapter data = datos.llenargrid();
            data.Fill(table);
            this.DataGrid.DataSource = table;
            //DataGridViewImageColumn img = new DataGridViewImageColumn();
            //Image image = Extraciones.Properties.Resources.delete;
            //img.Image = image;
            //DataGrid.Columns.Add(img);
            //img.HeaderText = "";
            //img.Name = "img";

            //DataGrid.Columns[3].Width = 18;



                    }

        private void BTNCLOSE_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void TXT_CODIGO_PIEZA_Leave(object sender, EventArgs e)
        {

        }

        private void TXTCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TXTTECNICO_Leave(object sender, EventArgs e)
        {

        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TXTMODELOENTRADA_Leave(object sender, EventArgs e)
        {

        }

        private void TXTNOMBREEQUIPOENTRADA_Leave(object sender, EventArgs e)
        {

        }

        private void TXTNUMKIT_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TXTCONTADOR_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TXTMODELOEQUIPO_Leave(object sender, EventArgs e)
        {

        }

        private void TXTNUMEQUIPO_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (TXTCODIGO.Text != "")
            {

                DialogResult resultado = MessageBox.Show("DESEA INGRESAR ESTE EQUIPO DE ENTRADA", "ACTUALIZACION", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (resultado == System.Windows.Forms.DialogResult.Yes)
                {

                    if (TXTCODIGO.Text == "")
                    {
                        MessageBox.Show("Debe seleccionar una extracion", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        try
                        {
                            int cantidadvar = Convert.ToInt32(TXTCANTIDAD.Text);
                            UTILITY UPDATE = new UTILITY();
                            int contador = Convert.ToInt32(TXTCONTADOR.Text);
                            int codgo = Convert.ToInt32(TXTCODIGO.Text);
                            UPDATE.update(TXTNUMEQUIPO.Text, TXTMODELOEQUIPO.Text, TXTSERIEEQUIPO.Text, contador,"", TXTCODIGO.Text);
                            table.Clear();
                            TRAERDATOS datos = new TRAERDATOS();
                            SqlDataAdapter data = datos.llenargrid();
                            data.Fill(table);
                            this.DataGrid.DataSource = table;



                        }
                        catch (Exception EX)
                        {
                            MessageBox.Show("ERROR" + EX, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                     
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una extracion de la tabla");
                }
            }
           
        
        }

        private void BTNCLOSE_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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
                MessageBox.Show("VERIFIQUE QUE LA FECHA DE INICIO ES MENOR A LA DE FINAL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
           
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

        private void DataGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            TXTCONTADORENTRADA.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CONTADOR_E"].Value);
                   
          TXTNUMEQUIPO.Text=(string)DataGrid.CurrentRow.Cells["NO.EQUIPO_S"].Value;
          TXTMODELOEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["MODELO_EQUIPO_S"].Value;
          TXTSERIEEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["SERIE_EQUIPO_S"].Value;
          TXTCONTADOR.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CONTADOR_S"].Value);
            
            // int quantity = (int)DataGrid.CurrentRow.Cells["CANTIDAD"].Value;
         //   TXTCODIGO.Text = (string)DataGrid.CurrentRow.Cells["CODIGO EXTRACION"].Value;
            TXTMODELOEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["MODELO_EQUIPO_S"].Value;
            TXTSERIEEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["SERIE_EQUIPO_S"].Value;
            TXTCONTADOR.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CONTADOR_S"].Value);
            TXTNUMEQUIPO.Text = (string)DataGrid.CurrentRow.Cells["NO.EQUIPO_S"].Value;
            // COMBOBODEGA.Text = Convert.ToString(DataGrid.CurrentRow.Cells["BODEGA"].Value);
            COMBOCONDICION.Text = (string)DataGrid.CurrentRow.Cells["CONDICION_EXTRACION"].Value;

            TXTNOMBREEQUIPOENTRADA.Text = (string)DataGrid.CurrentRow.Cells["NO.EQUIPO_E"].Value;

            TXTMODELOENTRADA.Text = (string)DataGrid.CurrentRow.Cells["MODELO_EQUIPO_E"].Value;
            TXTSERIEENTRADA.Text = (string)DataGrid.CurrentRow.Cells["SERIE_EQUIPO_E"].Value;
          //  TXTCONTADOR.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CONTADOR_E"].Value);
            //NOKITENTRADA.Text = (string)DataGrid.CurrentRow.Cells["NUM. KIT_EQUIPO_E"].Value;
            TXTTECNICO.Text=(string)DataGrid.CurrentRow.Cells["TECNICO"].Value;
            DATATIMEPICO.Value = (DateTime)DataGrid.CurrentRow.Cells["FECHA_CREA"].Value;
     //       TXT_CODIGO_PIEZA.Text = (string)DataGrid.CurrentRow.Cells["CODIGO_DEPIEZA"].Value;
          //  TXTCANTIDAD.Text = Convert.ToString(DataGrid.CurrentRow.Cells["CANTIDAD"].Value);
           // TXTDESCRIPCION.Text = (string)DataGrid.CurrentRow.Cells["DESCRIPCION_PIEZA"].Value;
          //  COMBOBODEGA.Text = Convert.ToString(DataGrid.CurrentRow.Cells["BODEGA"].Value);

            TXTGERENTE.Text = (string)DataGrid.CurrentRow.Cells["GERENTE_DE_SERVICIO"].Value;
            TXTSERVICIO.Text = (string)DataGrid.CurrentRow.Cells["SERVICIO_AL_CLIENTE"].Value;

            TXTCOMENTARIO.Text=(string)DataGrid.CurrentRow.Cells["COMENTARIO"].Value;
            codigo = (string)DataGrid.CurrentRow.Cells["CODIGO EXTRACION"].Value;
            EXTRALABEL1.Text = codigo;
            int longitud = codigo.Length - 4;
            sub_codig = codigo.Substring(4, longitud);
            TXTCODIGO.Text = sub_codig;

        }

        private void TXTCANTIDAD_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            table.Clear();
            TRAERDATOS datos = new TRAERDATOS();
            SqlDataAdapter data = datos.llenargrid();
            data.Fill(table);
            this.DataGrid.DataSource = table;

        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CAMBIAR_CONTRASEÑA cambiar = new CAMBIAR_CONTRASEÑA();
            cambiar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           string value= Interaction.InputBox("Inserte el codigo de la extracion que desea buscar ", "SEARCH", string.Empty, -1 , -1);

           table.Clear();
           TRAERDATOS datos = new TRAERDATOS();
           SqlDataAdapter data = datos.busqueda(value, "CODIGO_EXTRACION");
           data.Fill(table);
           this.DataGrid.DataSource = table;
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //USUARIOS f = new USUARIOS();
   //  string hora=   f.prueba();

    // MessageBox.Show("Esto es una prueba " + hora,"");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            limpiar();

        }

        public void limpiar() {
            TXTNUMEROKITS.Text = "";
            EXTRALABEL1.Text = "EXT-";
            //TXTNUMKIT.Text="0";
            TXTCONTADOR.Text = "0";
            TXTSERIEEQUIPO.Text = "";
            //TXTMODELOEQUIPO.Text="";
            //TXTNUMEQUIPO.Text="";
            TXTCANTIDAD.Text = "0";
            TXTDESCRIPCION.Text = "";
            //TXTSERIENTRADA.Text="";
            //TXTMODELOENTRADA.Text="";
            //TXTNOMBREEQUIPOENTRADA.Text = "";

            TXTNUMEQUIPO.Text = "";
            TXTMODELOEQUIPO.Text = "";
            TXTSERIEEQUIPO.Text = "";
            //TXTCONTADOR
            TXTNOMBREEQUIPOENTRADA.Text = "";
            TXTMODELOENTRADA.Text = "";
            TXTSERIEENTRADA.Text = "";
            TXTCONTADORENTRADA.Text = "0";
            TXTCOMENTARIO.Text = "";
            COMBOCONDICION.Text = "";
            TXTTECNICO.Text = "";
           // COMBOCLIENTE.Text = "";
            DATATIMEPICO.Text = "";
            TXTGERENTE.Text = "";
            TXTSERVICIO.Text = "";
            TXT_CODIGO_PIEZA.Text = "";
            TXTCANTIDAD.Text = "";
            TXTCODIGO.Text = "";

            TXTDESCRIPCION.Text = "";
            COMBOBODEGA.Text = "";
        
        }

        private void TXTCONTADOR_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void ADDKIT_Click(object sender, EventArgs e)
        {
            if (TXTCODIGO.Text!="")
            {
                
            

            if (TXTNUMEROKITS.Text=="" )
            {
                MessageBox.Show("Debe colocar los numeros de kit","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                UTILITY UTIL = new UTILITY();
                int codigo = Convert.ToInt32(TXTCODIGO.Text);
                UTIL.ADDNUMER("", TXTNUMEROKITS.Text, codigo);

            }
            }
            else
            {
                MessageBox.Show("Selecciona una extracion ","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
         
        }
    }
}
