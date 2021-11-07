using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Datos;
using System.Data;

namespace WebTransportes
{
    public partial class WebFormAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarCombo(ddlMarca);
            llenarCombo(ddlTarerPorMarca);
            mostrarAutos();
        }

        protected void btnGuardad_Click(object sender, EventArgs e)
        {
            string marca = ddlMarca.SelectedItem.Value.ToString();
            Auto auto = new Auto()
            {
                Marca = marca,
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text)
            };

            int filasAfectadas = AdmAuto.Insertar(auto);
            if (filasAfectadas > 0)
            {
                mostrarAutos();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Id = Convert.ToInt32(txtId.Text),
                Marca = ddlMarca.SelectedValue.ToString(),
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text)

            };

            int filasAfectadas = AdmAuto.Modificar(auto);

            if (filasAfectadas > 0)
            {
                mostrarAutos();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            int filasAfectadas = AdmAuto.Eliminar(id);
            if (filasAfectadas > 0)
            {
                mostrarAutos();
            }
        }

        protected void ddlTarerPorMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = ddlTarerPorMarca.SelectedValue.ToString();

            if (marca == "[TODAS]")
            {
                mostrarAutos();
            }
            else
            {
                gridAuto.DataSource = AdmAuto.Listar(marca);
                gridAuto.DataBind();
            }
        }

        private void llenarCombo(DropDownList dropDownList)
        {
            DataTable Marca = AdmAuto.ListarMarcas();

            DataRow fila = Marca.NewRow();
            fila["Marca"] = "[TODAS]";
            Marca.Rows.InsertAt(fila, 0);

            dropDownList.DataSource = Marca;
            dropDownList.DataValueField = Marca.Columns["Marca"].ToString();
            dropDownList.DataTextField = Marca.Columns["Marca"].ToString();
            dropDownList.DataBind();
        }
        private void mostrarAutos()
        {
            gridAuto.DataSource = AdmAuto.Listar();
            gridAuto.DataBind();
        }
    }
}