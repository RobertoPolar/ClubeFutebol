using CRUD.Business;
using CRUD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Clube
{
    public partial class Adicionar : System.Web.UI.Page
    {
        AtletaService service = new AtletaService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdicionarAtleta(object sender, EventArgs e)
        {
            Atleta atleta = new Atleta()
            {
                NomeCompleto = txtNomeCompleto.Text,
                Apelido = txtApelido.Text,
                DataNascimento = Convert.ToDateTime(dtDataNascimento.Text),
                Altura = Convert.ToDecimal(txtAltura.Text),
                Peso = Convert.ToDecimal(txtPeso.Text),
                Posicao = txtPosicao.Text,
                NroCamisa = Convert.ToInt32(txtNroCamisa.Text)
            };

            bool result = service.Criar(atleta);

            if (result)
                Response.Redirect("~/Default.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);
        }
    }
}