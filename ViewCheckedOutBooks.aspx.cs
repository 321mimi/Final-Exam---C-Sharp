using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCheckedOutBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["checkedOutBooks"] != null)
        {
            List<Book> checkedOutBooks = (List<Book>)Session["checkedOutBooks"];
            lblNumCheckouts.Text = checkedOutBooks.Count.ToString();
            for (int i = 0; i < checkedOutBooks.Count; i++)
            {
                lstCheckedOutBooks.Items.Add(checkedOutBooks[i].Title);
            }
        } else
        {
            lblNumCheckouts.Text = "0";

        }
    }

}