using CRUD.Business;
using CRUD.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Clube
{
    public partial class Editar : System.Web.UI.Page
    {
        AtletaService service = new AtletaService();
        private static int idAtleta = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    idAtleta = Convert.ToInt32(Request.QueryString["id"]);
                    if(idAtleta > 0)
                    {
                        Atleta atleta = service.ObterPorId(idAtleta);

                        txtNomeCompleto.Text = atleta.NomeCompleto;
                        txtApelido.Text = atleta.Apelido;
                        dtDataNascimento.Text = atleta.DataNascimento.ToString("yyyy-MM-dd");
                        txtAltura.Text = atleta.Altura.ToString();
                        txtPeso.Text = atleta.Peso.ToString();
                        txtPosicao.Text = atleta.Posicao.ToString();
                        txtNroCamisa.Text = atleta.NroCamisa.ToString();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void EditarAtleta(object sender, EventArgs e)
        {
            Atleta atleta = new Atleta()
            {
                IdAtleta = idAtleta,
                NomeCompleto = txtNomeCompleto.Text,
                Apelido = txtApelido.Text,
                DataNascimento = Convert.ToDateTime(dtDataNascimento.Text),
                Altura = Convert.ToDecimal(txtAltura.Text),
                Peso = Convert.ToDecimal(txtPeso.Text),
                Posicao = txtPosicao.Text,
                NroCamisa = Convert.ToInt32(txtNroCamisa.Text)
            };

            bool result = service.Editar(atleta);

            if (result)
                Response.Redirect("~/Default.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);

        }
    }
}