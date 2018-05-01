using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library : System.Web.UI.Page
{
    public const int MaxNumOfCheckOut = 3;
    static List<Book> checkedOutBooks = new List<Book>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            List<Book> availableBooks = Book.AvailableBooks;

            lblDescription.Visible = false;
            lblConfirmation.Visible = false;

            //Add your code here
            if (this.IsPostBack == false)
            {
                for (int i = 0; i < availableBooks.Count; i++)
                {
                    drpBookSelection.Items.Add(new ListItem(availableBooks[i].Title, availableBooks[i].Id.ToString()));
                }
            }
        }
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        Book selectedBook = Book.GetBookById((drpBookSelection.SelectedValue));
        lblDescription.Visible = true;
        lblDescription.Text = selectedBook.Description;
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        if (checkedOutBooks.Count < MaxNumOfCheckOut)
        {
            Book thisBook = Book.GetBookById((drpBookSelection.SelectedValue));
            checkedOutBooks.Add(thisBook);
            Book.MakeBookUnavailable(thisBook.Id.ToString());
            int booksLeft = MaxNumOfCheckOut - checkedOutBooks.Count;
            lblDescription.Visible = false;
            lblConfirmation.Visible = true;
            lblConfirmation.Text = "You just checked out: " + thisBook.Title + "\nYou can check out " + booksLeft + " more book(s).";
            drpBookSelection.Items.Remove(drpBookSelection.SelectedItem);
            drpBookSelection.SelectedIndex = -1;
            Session["checkedOutBooks"] = checkedOutBooks;
        } else
        {
            lblConfirmation.Visible = true;
            lblConfirmation.Text = "You have checked out maximum number of books allowed.";
        }
    }
}