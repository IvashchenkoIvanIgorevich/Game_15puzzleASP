using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _20201108_15puzzleASP
{
    public partial class Winner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //imgWin.ImageUrl = "~/img/you_win.jpg";
            
            imgWin.ImageUrl = "https://image.freepik.com/free-vector/you-win-lettering-pop-art-text-banner_185004-60.jpg";

            try
            {
                //string resTime = Request.QueryString.Get("time");
                string resMove = Request.QueryString.Get("move");

                //lblResTime.Text = resTime;
                lblResMove.Text = resMove;
            }
            catch (Exception)
            {
                lblResMove.CssClass = "alert alert-danger";
                lblResTime.CssClass = "alert alert-danger";

                lblResMove.Text = "Wrong argumets!!!";
                lblResTime.Text = "Wrong argumets!!!";
            }
        }

        protected void restart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/15puzzle.aspx");
        }
    }
}