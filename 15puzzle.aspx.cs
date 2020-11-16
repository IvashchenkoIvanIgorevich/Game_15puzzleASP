using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;

using LogicDLL;

namespace _20201108_15puzzleASP
{
    public partial class _15puzzle : System.Web.UI.Page
    {
        private int countMoves;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Request.Cookies["countMove"] != null 
                && Request.Cookies["countMove"].Value != "")
            {
                lblMoves.Text = Request.Cookies["countMove"].Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GameField _field = new GameField();

            if (!IsPostBack)    // вызов метода POST, форма отправила свои данные на сервер
            {
                if (Session["field"] == null)
                {
                    Initialisation newInit = new Initialisation();
                    _field = newInit.InitGame();
                }
                else
                {
                    _field = (GameField)Session["field"];
                }
            }
            else
            {
                _field = (GameField)Session["field"];
            }

            if (_field.IsWinTheGame())
            {
                string url = string.Format("~/Winner.aspx?time={0}&move={1}", lblTime.Text, Request.Cookies["countMove"].Value);    // lblMoves.Text не сработало

                Session.Clear();
                DeleteCookies();

                Request.Cookies["countMove"].Value = "0";
                Response.Redirect(url);
            }

            PrintField(_field);
        }

        private void PrintField(GameField _field)
        {
            List<Button> listOfBtn = new List<Button>(Common.SIZE_GAMEFIELD);

            for (int row = 0; row < Common.LENGTH_ROW_COL; row++)
            {
                for (int col = 0; col < Common.LENGTH_ROW_COL; col++)
                {
                    Position newPos = new Position(row, col);
                    Button newBtn = new Button();
                    newBtn.ID = _field[newPos].Name;
                    newBtn.Text = _field[newPos].Text;
                    newBtn.Font.Size = 20;
                    newBtn.Font.Bold = true;

                    if (_field[newPos].Visible == false)
                    {
                        newBtn.OnClientClick = "return false";
                        newBtn.CssClass = "btn-ghost";
                    }
                    else
                    {
                        newBtn.Visible = _field[newPos].Visible;
                        newBtn.CssClass = "btn btn-primary";
                    }

                    newBtn.BorderColor = Color.Black;
                    newBtn.Click += ClickBtn;

                    listOfBtn.Add(newBtn);
                }
            }

            List<Panel> listOfPanel = new List<Panel>(Common.LENGTH_ROW_COL);
            listOfPanel.Add(Panel_1);
            listOfPanel.Add(Panel_2);
            listOfPanel.Add(Panel_3);
            listOfPanel.Add(Panel_4);

            int lengthRowCol = Common.LENGTH_ROW_COL;
            int temp = 0;

            for (int numPanel = 0; numPanel < listOfPanel.Count; numPanel++)
            {
                for (int numBtn = temp; numBtn < lengthRowCol; numBtn++)
                {
                    listOfPanel[numPanel].Controls.Add(listOfBtn[numBtn]);
                    temp = numBtn + 1;
                }

                lengthRowCol += Common.LENGTH_ROW_COL;
            }

            Button btnReset = new Button();
            btnReset.ID = "btnReset";
            btnReset.Text = "Reset";
            btnReset.Font.Size = 20;
            btnReset.Font.Bold = true;
            btnReset.CssClass = "classReset";
            btnReset.Click += ClickRestart;

            Panel_5.Controls.Add(btnReset);

            Session["field"] = _field;
        }

        private void ClickBtn(object sender, EventArgs eventArg)
        {
            GameField _field = new GameField();
            _field = (GameField)Session["field"];

            Button clickedBtn;

            if (sender is Button)
            {
                clickedBtn = (Button)sender;

                bool find = _field.IsFindObject(clickedBtn.Text, _field);

                if (find)
                {
                    HttpCookie countMove = new HttpCookie("countMove");

                    if (Request.Cookies["countMove"] == null)    // первый вызов в Cookies ничего нет
                    {
                        countMove.Value = (++countMoves).ToString();
                    }
                    else
                    {
                        if (Request.Cookies["countMove"].Value == "")
                        {
                            countMove.Value = (++countMoves).ToString();
                        }
                        else
                        {
                            countMoves = int.Parse(Request.Cookies["countMove"].Value);    // забираем то что есть в Cookies и увеличиваем на 1
                            countMove.Value = (++countMoves).ToString();
                        }
                    }

                    Response.AppendCookie(countMove);    // пишем в Cookies
                }
            }

            Session["field"] = _field;

            Response.Redirect("~/15puzzle.aspx");
        }

        private void ClickRestart(object sender, EventArgs eventArg) 
        {
            Session.Clear();
            DeleteCookies();

            Response.Redirect("~/15puzzle.aspx");
        }

        private void DeleteCookies()
        {
            if (Request.Cookies["countMove"] != null)    // delete cookies on client side
            {
                HttpCookie countMove = new HttpCookie("countMove");
                countMove.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(countMove);
            }
        }
    }
}