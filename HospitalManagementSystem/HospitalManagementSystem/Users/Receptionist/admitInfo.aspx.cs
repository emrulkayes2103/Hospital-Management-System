using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementSystem.Users.Receptionist
{
    public partial class admitInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                getRandomSerialNumber();
            
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
            if (!IsPostBack)
            {
                
                getTime();
            }
        }
        protected void sendNametoMasterpage(string email)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select Name from Receptionist where Email=@email";
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

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string serialNumber = fromSerial.Text;
                string date = txtDate.Text;
                string patientName = txtPatientName.Text;
                string year = dobYear.Text;
                string month =dobMonth.Text;
                string day = dobDay.Text;
                string age = txtAge.Text;
                string sex = gender.SelectedValue.ToString();
                string bGroup = ddlList.SelectedValue.ToString();
                string phone = txtPhone.Text;
                string emergencyNumber = txtEmergencyNum.Text;
                string fatherName = txtFatherNane.Text;
                string motheName = txtMotherName.Text;
                string religion = txtReligion.Text;
                string nationality = txtNationality.Text;
                string passportNumber = txtPassportNum.Text;
                string occupation = txtOccupation.Text;

                string houseNo = txtHouseNo.Text;
                string village = txtVillageOrRoadno.Text;
                string postoffice = txtPostOffice.Text;
                string postalCode = txtPostCode.Text;
                string thana = txtThana.Text;
                string district = txtDistrict.Text;
                string country = txtCountry.Text;
                string email = txtEmail.Text;

                if (patientName != string.Empty && year != string.Empty && month != string.Empty && day != string.Empty  && age != string.Empty && sex != string.Empty && bGroup != string.Empty && phone != string.Empty && fatherName != string.Empty && motheName != string.Empty && religion != string.Empty && nationality != string.Empty && occupation != string.Empty && district != string.Empty && country != string.Empty)
                {
                     int chckValue;
                     if (int.TryParse(age, out chckValue) && int.TryParse(year, out chckValue) && int.TryParse(month, out chckValue) && int.TryParse(day, out chckValue))
                     {
                         if ((Convert.ToInt32(age) >= 1 && (Convert.ToInt32(year) >= 1901 && Convert.ToInt32(year) <= 2020) && Convert.ToInt32(month) >= 1 && Convert.ToInt32(month) <= 12 && Convert.ToInt32(day) >= 1 && Convert.ToInt32(day) <= 31))
                         {
                             if (Convert.ToInt32(year) >= DateTime.Now.Year)
                             {
                                 errorMsg.Text = "Enter correct Year";
                                 errorMsg.ForeColor = System.Drawing.Color.Red;
                               
                             }
                             else
                             {
                                 if (emergencyNumber == "" || passportNumber == "" || houseNo == "" || village == "" || postoffice == "" || postalCode == "" || thana == "")
                                 {
                                     string Dob = year + "-" + month + "-" + day;
                                     emergencyNumber = "--";
                                     passportNumber = "--";
                                     houseNo = "";
                                     village = "";
                                     postoffice = "";
                                     postalCode = "--";
                                     thana = "";
                                     email = "--";
                                     string address = houseNo + "," + village + "," + postoffice + "," + thana + "," + district + "," + country;
                                     insertAdmitedPatientData(serialNumber, date, patientName, Dob, age, sex, bGroup, phone, emergencyNumber, fatherName, motheName, religion, nationality, passportNumber, occupation, address, postalCode, email);
                                     emptyForm();
                                     ClientScript.RegisterStartupScript(Page.GetType(), "",
                                         "<script language='javascript'>alert('Successfully Registered')</script>");
                                 }
                                 else
                                 {
                                     string Dob = year + "-" + month + "-" + day;
                                     string address = houseNo + "," + village + "," + postoffice + "," + thana + "," + district + "," + country;
                                     insertAdmitedPatientData(serialNumber, date, patientName, Dob, age, sex, bGroup, phone, emergencyNumber, fatherName, motheName, religion, nationality, passportNumber, occupation, address, postalCode, email);
                                     emptyForm();
                                     ClientScript.RegisterStartupScript(Page.GetType(), "",
                                        "<script language='javascript'>alert('Successfully Registered')</script>");
                                
                                 }
                             }
                         }
                         else
                         {
                             if (Convert.ToInt32(age) < 1)
                             {
                                 errorMsg.Text = "Enter correct Age";
                                 errorMsg.ForeColor = System.Drawing.Color.Red;
                                
                             }
                             if (Convert.ToInt32(month) < 1 || Convert.ToInt32(month) > 12)
                             {
                                 errorMsg.Text = "Enter correct Month";
                                 errorMsg.ForeColor = System.Drawing.Color.Red;
                                
                             }
                             if (Convert.ToInt32(day) < 1 || Convert.ToInt32(day) > 31)
                             {
                                 errorMsg.Text = "Enter correct Date";
                                 errorMsg.ForeColor = System.Drawing.Color.Red;
                                 
                             }
                         }
                     }
                     else
                     {
                         errorMsg.Text = "Enter correct format of Age or Date of Birth";
                         errorMsg.ForeColor = System.Drawing.Color.Red;
                     }
                }
                else
                {
                    errorMsg.Text = "Enter all Information Please";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void insertAdmitedPatientData(string serialNo, string date, string patientName , string dateOfBirth,string age,string gender,string bloodGroup,string phone, string emeerGencyNumber, string fname,string mname,string religion,string nationality,string passportNumber,string occuption,string address,string postalCode,string Email)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "insert into AdmitedPatient values(@serialNumber,@date,@patientName,@dateofBirth,@age,@gender,@bloodGroup,@phone,@emergencyNumber,@fname,@mname,@religion,@nationality,@passportNum,@occupation,@address,@postalCode,@email,@paid)";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        string paidAmmount = "NO";
                        cmd.Parameters.AddWithValue("@serialNumber", serialNo);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@patientName", patientName);
                        cmd.Parameters.AddWithValue("@dateofBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@bloodGroup", bloodGroup);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@emergencyNumber", emeerGencyNumber);
                        cmd.Parameters.AddWithValue("@fname", fname);
                        cmd.Parameters.AddWithValue("@mname", mname);
                        cmd.Parameters.AddWithValue("@religion", religion);
                        cmd.Parameters.AddWithValue("@nationality", nationality);
                        cmd.Parameters.AddWithValue("@passportNum", passportNumber);
                        cmd.Parameters.AddWithValue("@occupation", occuption);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@postalCode", postalCode);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@paid", paidAmmount);
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
        protected void getRandomSerialNumber()
        {
            string number = DateTime.Now.ToString("yyMMddhhmmtss");
            fromSerial.Text = number;

        }
        protected void getTime()
        {
            txtDate.Text = DateTime.Now.ToShortDateString();
        }
        protected void emptyForm()
        {
            txtPatientName.Text = "";
            dobDay.Text = "";
            dobMonth.Text = "";
            dobYear.Text = "";
            txtAge.Text = "";
            gender.ClearSelection();
            ddlList.ClearSelection();
            txtPhone.Text = "";
            txtEmergencyNum.Text = "";
            txtFatherNane.Text = "";
            txtMotherName.Text = "";
            txtReligion.Text = "";
            txtNationality.Text = "";
            txtPassportNum.Text = "";
            txtOccupation.Text = "";
            txtHouseNo.Text = "";
            txtVillageOrRoadno.Text = "";
            txtPostOffice.Text = "";
            txtPostCode.Text = "";
            txtThana.Text = "";
            txtDistrict.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";

        }
    }
}