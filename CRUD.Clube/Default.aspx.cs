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
    public partial class _Default : Page
    {
        AtletaService service = new AtletaService();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListarAtletas();
        }

        private void ListarAtletas()
        {
            List<Atleta> atletas = service.Listar();

            gvAtleta.DataSource = atletas;
            gvAtleta.DataBind();
        }

        private void LimparGridAtleta()
        {
            gvAtleta.DataSource = null;
            gvAtleta.DataBind();
        }

        protected void PesquisarAtletas(object sender, EventArgs e)
        {
            List<Atleta> atletas = service.Listar();

            
            string apelido = txtApelido.Text;
            string classificacaoImc = ddlClassificacaoIMC.Text;

            if (!string.IsNullOrEmpty(txtNroCamisa.Text))
            {
                int nroCamisa = Convert.ToInt16(txtNroCamisa.Text);
                atletas = atletas.Where(x => x.NroCamisa == nroCamisa).ToList();
            }

            if (!string.IsNullOrEmpty(apelido))
                atletas = atletas.Where(x => x.Apelido == apelido).ToList();

            if(classificacaoImc != "0")
                atletas = atletas.Where(x => x.ClassificacaoImc == classificacaoImc).ToList();

            LimparGridAtleta();

            gvAtleta.DataSource = atletas;
            gvAtleta.DataBind();
        }

        protected void NovoAtleta(object sender, EventArgs e)
        {
            Response.Redirect("~/Adicionar.aspx");
        }
        protected void EditarAtleta(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            Response.Redirect($"~/Editar.aspx?id={id}");
        }

        protected void EliminarAtleta(object sender, EventArgs args)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            bool result = service.Eliminar(Convert.ToInt32(id));

            if (result)
                ListarAtletas();
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);
        }

        protected void gvAtleta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for(int i = 0; i < gvAtleta.Rows.Count; i++)
            {
                decimal imc = Convert.ToDecimal(gvAtleta.Rows[i].Cells[8].Text);

                if (imc > 25m)
                    gvAtleta.Rows[i].BackColor = Color.PaleVioletRed;
            }
        }
    }
}