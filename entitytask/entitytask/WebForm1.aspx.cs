﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entitytask
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        task1Entities db= new task1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var x = from s in db.Cities select s;
                DropDownList1.DataSource = x.ToList();
                DropDownList1.DataTextField = "City1";
                DropDownList1.DataValueField = "CityId";
                DropDownList1.DataBind();


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                CustomerName = TextBox1.Text,
                Age = Convert.ToInt32(TextBox2.Text),
                CityId = Convert.ToInt32(DropDownList1.SelectedValue),
                Phone = Convert.ToInt32(TextBox4.Text),
                Email = TextBox5.Text,
                Photo = "img/"+FileUpload1.FileName,


            };
            db.Customers.Add(customer);
            db.SaveChanges();
            FileUpload1.SaveAs(System.IO.Path.Combine(Server.MapPath("img"), FileUpload1.FileName));
            Response.Redirect("admin.aspx");
        }
    }
}