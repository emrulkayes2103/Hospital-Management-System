using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace HospitalManagementSystem.Users.Accountent
{
    public partial class addPayement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            try
            {
                if (Session["Username"] != null)
                {
                    string name = Session["Username"].ToString();
                    sendNametoMasterpage(name);
                }
                else
                {
                    Response.Redirect("~/userlogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void sendNametoMasterpage(string email)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select Name from Accountant where Email=@email";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@email", email);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string username = (string)dr["Name"];
                            Master.lblforUserName.Text = username;
                        }
                        else
                        {
                            Master.lblforUserName.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string date = lblDate.Text;
                int payAbleAmmount = Convert.ToInt32(txtPaybleAmmount.Text);
                int paidAmmount = Convert.ToInt32(txtPaidammount.Text);
                string serial = txtSerial.Text;
                if (date != string.Empty && serial != string.Empty && payAbleAmmount != null && paidAmmount != null)
                {
                    if (paidAmmount < payAbleAmmount)
                    {
                        if (chkSerial(serial) == true)
                        {
                            if (chkPaymentIsAlraedyInserted(serial) == false)
                            {
                                getData(serial, payAbleAmmount, paidAmmount, date);
                                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language='javascript'>alert('Successfully Saved')</script>");
                                txtPaidammount.Text = "";
                                txtPaybleAmmount.Text = "";
                                txtSerial.Text = "";
                                errorMsg.Text = "";
                            }
                            else if (chkPaymentIsAlraedyInserted(serial) == true)
                            {
                                getDataForUpdate(serial, paidAmmount, date);
                                
                            }
                            else
                            {
                                errorMsg.Text = "Can Not saved Data";
                                errorMsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            errorMsg.Text = "Invalid serial No";
                            errorMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        errorMsg.Text = "Enter Correct Ammount to paid";
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
               
                else
                {
                    errorMsg.Text = "Enter all Information";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                errorMsg.Text = "Enter all correct Information";
                errorMsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        protected bool chkPaymentIsAlraedyInserted(string serial)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select seialNo from Payment where seialNo=@serial";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@serial", serial);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                return false;
            }
        }
        protected bool chkSerial(string serial)
       {
           try
           {
               string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
               using (SqlConnection con = new SqlConnection(CS))
               {
                   string command = "select serialNo from AdmitedPatient where serialNo=@serial";
                   using (SqlCommand cmd = new SqlCommand(command, con))
                   {
                       cmd.Parameters.AddWithValue("@serial", serial);
                       con.Open();
                       SqlDataReader dr = cmd.ExecuteReader();
                       if (dr.HasRows)
                       {
                           return true;
                       }
                       else
                       {
                           return false;
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               Response.Write(ex);
               return false;
           }
        }
       
        protected void getData(string serial, int payableAmmount, int paidAmmount, string date)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select PatientName,fathersName,mothername,phone from AdmitedPatient where serialNo=@serial";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@serial", serial);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            string patientName = (string)dr["PatientName"];
                            string ptientFatherName = (string)dr["fathersName"];
                            string patientMotherName = (string)dr["mothername"];
                            string patientPhone = (string)dr["phone"];
                            insertPaymentData(serial, payableAmmount, paidAmmount, date, patientName, ptientFatherName, patientMotherName, patientPhone);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void insertPaymentData(string serial, int payableAmmount, int paidAmmount,string date,string name,string fName,string mName,string phone)
        {
            try
            {
                
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string comand = "insert into Payment values(@serialno,@name,@fathersName,@motherName,@phone,@paybaleAmmount,@paidAmmount,@due,@date)";
                   
                    int due = (Convert.ToInt32(payableAmmount) -Convert.ToInt32(paidAmmount));
                    using (SqlCommand cmd = new SqlCommand(comand, con))
                    {
                        cmd.Parameters.AddWithValue("@serialno", serial);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@fathersName", fName);
                        cmd.Parameters.AddWithValue("@motherName", mName);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@paybaleAmmount", payableAmmount);
                        cmd.Parameters.AddWithValue("@paidAmmount", paidAmmount);
                        cmd.Parameters.AddWithValue("@due", due);
                        cmd.Parameters.AddWithValue("@date", date);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        protected void getDataForUpdate(string serial,int PaidAmmount,string date)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select PayableAmmount,PaidAmmount from Payment where seialNo=@serial";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@serial", serial);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int PayableAmmount = (int)dr["PayableAmmount"];
                            int preViousPaidAmmount = (int)dr["PaidAmmount"];
                            int total = preViousPaidAmmount + PaidAmmount;
                            if (total > PayableAmmount)
                            {
                                int alreadyAddedAmmount = PayableAmmount - preViousPaidAmmount;
                                errorMsg.Text = "Ammount alrady addred "+alreadyAddedAmmount+" and total Payable ammount is "+PayableAmmount;
                            
                            }
                            else
                            {
                                updateData(serial, PayableAmmount, PaidAmmount, preViousPaidAmmount, date);
                                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language='javascript'>alert('Successfully Updated')</script>");
                                txtPaidammount.Text = "";
                                txtPaybleAmmount.Text = "";
                                txtSerial.Text = "";
                                errorMsg.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void updateData(string serial, int payableAmmount, int paidAmmount,int prePaidAmmount, string date)
        {
            try
            {

                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string comand = "update Payment set PaidAmmount=@paidAmmount,Due=@due,Date=@date where seialNo=@serialno";
                    int totalPaidAmmountToday = (paidAmmount + prePaidAmmount);
                    int due = (Convert.ToInt32(payableAmmount) - Convert.ToInt32(totalPaidAmmountToday));
                    using (SqlCommand cmd = new SqlCommand(comand, con))
                    {
                        cmd.Parameters.AddWithValue("@serialno", serial);
                        cmd.Parameters.AddWithValue("@paidAmmount", totalPaidAmmountToday);
                        cmd.Parameters.AddWithValue("@due", due);
                        cmd.Parameters.AddWithValue("@date", date);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}