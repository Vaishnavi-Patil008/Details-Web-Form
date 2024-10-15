using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-KD5M1AOT\MSSQLSERVER01;Initial Catalog=web1;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                btDel.Enabled = false;
                FillGridView();
            }
        }

        protected void btClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            hfCustID.Value = "";
            txtName.Text = txtmobile.Text = txtadress.Text = "";
            lblsuccessmsg.Text = lblerrormsg.Text = "";
            btSave.Text = "Save";
            btDel.Enabled = false;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("detailsCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@CustID", (hfCustID.Value == "" ? 0 : Convert.ToInt32(hfCustID.Value)));
            sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Mobile", txtmobile.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Adress", txtadress.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string CustID = hfCustID.Value;
            clear();
            if (CustID == "")

                lblsuccessmsg.Text = "Saved Succesfully";
            else
                lblsuccessmsg.Text = "Updated Succesfully";

            FillGridView();

        }
        void FillGridView()
        {
            if(sqlCon.State==ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("detailsviewall", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon.Close();
            gvdetails.DataSource = dtbl;
            gvdetails.DataBind();
        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int CustID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("detailsviewbyid", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@CustID", CustID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon.Close();
            hfCustID.Value = CustID.ToString();
            txtName.Text = dtbl.Rows[0]["Name"].ToString();
            txtmobile.Text = dtbl.Rows[0]["Mobile"].ToString();
            txtadress.Text = dtbl.Rows[0]["Adress"].ToString();
            btSave.Text = "Update";
            btDel.Enabled = true;
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("detaildeletebyid", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@CustID",Convert.ToInt32(hfCustID.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            clear();
            FillGridView();
            lblsuccessmsg.Text = "Deleted Successfully";

        }
    } 
}
