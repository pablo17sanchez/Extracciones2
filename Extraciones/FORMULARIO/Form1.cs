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
        
        
        TXTNUMKIT_1.Text="0";
TXTCONTADOR_1.Text="0";
TXTSERIEEQUIPO_1.Text="";
TXTMODELOEQUIPO_1.Text="";
TXTNUMEQUIPO_1.Text="";
TXTCANTIDAD_1.Text="0";
TXTDESCRIPCION_1.Text="";
TXTSERIE3_1.Text="";
TXTMODELOENTRADA_1.Text="";
TXTNOMBREEQUIPOENTRADA_1.Text = "";
        
        
        }
        private void Form1_Resize(object sender, EventArgs e)
        {   
            //tamano de tab control
            tabmain_1.Size = new Size(this.Width, this.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            DataTable datacombo = new DataTable();
            TRAERDATOS datos = new TRAERDATOS();
            // TODO: This line of code loads data into the 'ALMACENDataSet.EXTRACION_EQUIPO' table. You can move, or remove it, as needed.
           ///llenar combo begin 

            SqlDataAdapter llenar_combo = datos.llenarcombobodega();
            llenar_combo.Fill(datacombo);
            COMBOBODEGA_1.DataSource = datacombo;
            COMBOBODEGA_1.DisplayMember = "BODEGA";
            //llenar como finished
            TXTNUMKIT_1.Text = "0";
            TXTCONTADOR_1.Text = "0";
            TXTCANTIDAD_1.Text = "0";
          
            SqlDataAdapter data = datos.llenargrid();
            data.Fill(table);
            this.DataGrid_1.DataSource = table;
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image image = Extraciones.Properties.Resources.delete;
            img.Image = image;
            DataGrid_1.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";

            DataGrid_1.Columns[3].Width = 18;

            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

         


        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            



            if ( TXTNUMEQUIPO_1.Text==""|| TXTMODELOEQUIPO_1.Text==""||TXTTECNICO_1.Text=="" || TXT_CODIGO_PIEZA_1.Text==""|| TXTNOMBREEQUIPOENTRADA_1.Text==""||TXTMODELOENTRADA_1.Text=="")
            {
                MessageBox.Show("DEBE INGRESAR LOS CAMPOS OBLIGATORIOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            
         DialogResult resultado =  MessageBox.Show("Desea guardar esta informacion", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
         if (resultado==System.Windows.Forms.DialogResult.Yes)
         {
             UTILITY utilidad = new UTILITY();
             DateTime fecha = (DateTime)DATATIMEPICO_1.Value;
             int txtnumerkit = Convert.ToInt32(TXTNUMKIT_1.Text);
             int contador = Convert.ToInt32(TXTCONTADOR_1.Text);
             int cantidad = Convert.ToInt32(TXTCANTIDAD_1.Text);

             utilidad.insertar(TXTNUMEQUIPO_1.Text, TXTMODELOEQUIPO_1.Text, TXTSERIEEQUIPO_1.Text, contador, txtnumerkit, COMBOCONDICION_1.Text, TXTNOMBREEQUIPOENTRADA_1.Text, TXTMODELOENTRADA_1.Text, TXTSERIE3_1.Text, TXTTECNICO_1.Text, fecha, TXT_CODIGO_PIEZA_1.Text, TXTDESCRIPCION_1.Text, cantidad);
          
    
         }

         table.Clear();
            TRAERDATOS datos = new TRAERDATOS();
            SqlDataAdapter data = datos.llenargrid();
            data.Fill(table);
            this.DataGrid_1.DataSource = table;
            
            //DataGrid.ColumnCount = 3;
            //DataGrid.Columns[0].Name = "Articulo";
            //DataGrid.Columns[1].Name = "Descripcion";
            //DataGrid.Columns[2].Name = "Cantidad";


            //string[] row = new string[] { ArticuloText.Text, DescripcionText.Text, CantidadText.Text };
            //DataGrid.Rows.Add(row);



            }
           
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                

                if (e.ColumnIndex == 14)// created column index (delete button)
                {
                    int valor = (int)DataGrid_1.CurrentRow.Cells["CODIGO EXTRACION"].Value;

                    UTILITY util = new UTILITY();
                    util.borrar(valor);
                    DataGrid_1.Rows.Remove(DataGrid_1.Rows[e.RowIndex]);
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
            if (string.IsNullOrEmpty(TXTNUMEQUIPO_1.Text) || TXTNUMEQUIPO_1.Text=="")
            {
                EQUIPOFAIL1_1.Clear();
                EQUIPOFAIL1_1.Icon = Extraciones.Properties.Resources.mal; ;

                EQUIPOFAIL1_1.SetError(TXTNUMEQUIPO_1, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                EQUIPOFAIL1_1.Clear();
                EQUIPOFAIL1_1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                EQUIPOFAIL1_1.SetError(TXTNUMEQUIPO_1, "OK");
            }
        }

        private void TXTTECNICO_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXTTECNICO_1.Text))
            {
                errorProvider2_1.Clear();
                errorProvider2_1.Icon = Extraciones.Properties.Resources.mal; ;
                errorProvider2_1.SetError(TXTTECNICO_1, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                errorProvider2_1.Clear();
                errorProvider2_1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                errorProvider2_1.SetError(TXTTECNICO_1, "OK");
            }
        }

        private void TXTMODELOEQUIPO_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TXTMODELOEQUIPO_1.Text))
            {
                ERRORMODELO1_1.Clear();
                ERRORMODELO1_1.Icon = Extraciones.Properties.Resources.mal; ;
                ERRORMODELO1_1.SetError(TXTMODELOEQUIPO_1, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                ERRORMODELO1_1.Clear();
                ERRORMODELO1_1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                ERRORMODELO1_1.SetError(TXTMODELOEQUIPO_1, "OK");
            }
        }

        private void TXT_CODIGO_PIEZA_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_CODIGO_PIEZA_1.Text))
            {
                errorProvider1_1.Clear();
                errorProvider1_1.Icon = Extraciones.Properties.Resources.mal; ;
                errorProvider1_1.SetError(TXT_CODIGO_PIEZA_1, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                errorProvider1_1.Clear();
                errorProvider1_1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                errorProvider1_1.SetError(TXT_CODIGO_PIEZA_1, "OK");
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
                if (CRITERIOCOMBO_1.Text == "FECHA")
                {
                    datatable.Clear();
                    DATA = datos.busquedafecha(desde_1.Value, hasta_1.Value);
                }
                else
                {
                    datatable.Clear();
                    DATA = datos.busqueda(TXTBUSQUEDA_1.Text, CRITERIOCOMBO_1.Text);
                }

                DATA.Fill(datatable);
                this.DBGRID_1.DataSource = datatable;
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
                 if (CRITERIOCOMBO_1.Text=="FECHA")
            {
                TXTBUSQUEDA_1.Visible = false;
                label16_1.Visible = false;
                desde_1.Visible = true;
                hasta_1.Visible = true;
                LBDESDE_1.Visible = true;
                LBHASTA_1.Visible = true;
            }
            else
            {
                 TXTBUSQUEDA_1.Visible = true;
                label16_1.Visible = true;
                desde_1.Visible = false;
                hasta_1.Visible = false;
                LBDESDE_1.Visible =  false;
                LBHASTA_1.Visible = false;
            }
                
            }

        private void TXTNOMBREEQUIPOENTRADA_Leave(object sender, EventArgs e)
        {
         
            if (string.IsNullOrEmpty(TXTNOMBREEQUIPOENTRADA_1.Text))
            {
                ENTRADA1_1.Clear();
                ENTRADA1_1.Icon = Extraciones.Properties.Resources.mal; ;
                ENTRADA1_1.SetError(TXTNOMBREEQUIPOENTRADA_1, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                ENTRADA1_1.Clear();
                ENTRADA1_1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                ENTRADA1_1.SetError(TXTNOMBREEQUIPOENTRADA_1, "OK");
            }

        }

        private void TXTMODELOENTRADA_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXTMODELOENTRADA_1.Text))
            {
                 ENTRADA2_1.Clear();
                 ENTRADA2_1.Icon = Extraciones.Properties.Resources.mal; ;
                 ENTRADA2_1.SetError(TXTMODELOENTRADA_1, "EL CAMPO NO PUEDE QUEDAR VACIO");
            }
            else
            {
                ENTRADA2_1.Clear();
                ENTRADA2_1.Icon = Extraciones.Properties.Resources._1422667798_17871;
                ENTRADA2_1.SetError(TXTMODELOENTRADA_1, "OK");
            }
        }

        private void BTNCLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        }



     
    }

