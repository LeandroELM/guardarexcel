using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using objExcel = Microsoft.Office.Interop.Excel;

namespace guardarexcel
{
    public partial class Form1 : Form
    {
        string ruta=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            objExcel.Application objAplicacion = new objExcel.Application();
            Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

            objAplicacion.Visible = false;

           

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                objHoja.Cells[1, columna.Index + 1] = columna.HeaderText;
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    objHoja.Cells[fila.Index + 2, columna.Index + 1] = fila.Cells[columna.Index].Value;
                }
            }

            objLibro.SaveAs(ruta + "\\MiprimerExcel.xlsx");
            objLibro.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string name, apell, cedu;

            name=txtnombre.Text;
            apell=txtapellido.Text;
            cedu=txtcedula.Text;

            string[]datos=new string[5];
            datos[0]=name;
            datos[1]=apell;
            datos[2]=cedu;

            dataGridView1.Rows.Add(datos);  
        }
    }
}
