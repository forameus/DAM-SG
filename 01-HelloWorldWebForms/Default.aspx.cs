using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bien.Visible = false;
        Mal.Visible = false;        
    }

    protected void ClickNombre(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(texto.Text))
        {
            LabelError.Text = "No escribió usted su nombre no más.";
            testo.Text = "";
            Label1.Text = "";
            
        }
        else{
            testo.Text = "Hola, " + texto.Text + ". ¿Qué tal el día?";
            Bien.Visible = true;
            Mal.Visible = true;
            Label1.Text = "";
            LabelError.Text = "";
        }
    }

    protected void Bien_Click(object sender, EventArgs e)
    {
        Label1.Text = "Me alegro. :D";
    }

    protected void Mal_Click(object sender, EventArgs e)
    {
        Label1.Text = "Me alegro. :D";
    }

    protected void Decir_Dia(object sender, EventArgs e)
    {
        
    }
}