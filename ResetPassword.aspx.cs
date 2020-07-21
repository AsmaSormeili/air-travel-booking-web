using com.nirasoftware;
using NRSWeb.Business.Logic;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Logger.logEvent("Entered To Reset Password Page.", this, Logger.NORAML);


        UserSession us = UserSession.GetUserSession(this);

        if (!IsPostBack)
        {
    

            if (us.Browser == "InternetExplorer" && (us.Browser != null))
            {

                Message.showError(Message.findMessage(Message.BROWSERERROR),Page);
                return;

            }
        }

        if (us.Origin == null && us.UserID == null)
        {
            //UserSession.LogoutUser(this);
            //Logger.logEvent("Time Out User.", this, Logger.NORAML);
            //Message.redirectMessage("~/Order.aspx", Message.TIMEOUT, "warning");


            //return;
        }






        //UserSession us = UserSession.GetUserSession(this);
        //var master = Master as SiteMaster;
        //bool Signed = master.IsLogged();
        //if (!Signed)
        //{
        //    us.NextPage = "~/ResetPassword.aspx";
        //    us.Phase = "ResetPasword";
        //    UserSession.SaveUserSession(this, us);
        //    Response.Redirect("~/ورود");
        //}
    }

    protected void btnResetPass_Click(object sender, EventArgs e)
    {
        if (com.nirasoftware.Validators.generalValidation(txtConfirmPass.Text) &&
          com.nirasoftware.Validators.generalValidation(txtPass.Text))
        {

            try
            {
                UserSession us = UserSession.GetUserSession(this);

                String ForgottenPassRandom = Request.QueryString["RND"];
                String UserID = Request.QueryString["USERID"];

                tbUser user = tbUser.findWhereCondition(x => x.UserID.Equals(UserID) && x.ExtraInfo.Contains(ForgottenPassRandom)).FirstOrDefault();

           
         
                 if (user == null)
                {

                    Logger.logEvent("Activation Link Not Valid.User Object is NULL", this, Logger.NORAML);

                    Message.showError(Message.findMessage(Message.INVALIDACTIVATIONLINK),Page);

                    return;
                }

                // else if (DateTime.Now > DateTime.ParseExact(user.ExpireDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture))
                //{
                //    Logger.logEvent("Expire Link In ResetPassword. UserID: " + user.UserID, this, Logger.NORAML);

                //   Message.showError(Message.findMessage(Message.EXPIRETIMEREGLINK),Page);

                //    Response.Redirect("فراموشی__رمز__عبور");

                //    user.History = user.History + "ExpireLink In ResetPass";

                //    return;

                //} 

               
                else if (txtPass.Text != txtConfirmPass.Text)
                {
                    Message.showError(Message.findMessage(Message.NOTEQUAlPASS),Page);

                    Logger.logEvent("Not Equal Password.", this, Logger.NORAML);

                    return;



                }
                else if (!com.nirasoftware.Validators.validatePassWord(txtConfirmPass.Text))
                {


                    Logger.logEvent("NIncorrect Password.", this, Logger.NORAML);

                    Message.showError(Message.findMessage(Message.INCORPASS),Page);


                    return;

                }
                else if (user.Passwd == txtConfirmPass.Text)
                {
                    Message.showError(Message.findMessage(Message.OLDNEWPASS),Page);
                    return;
                }

                

                else
                {
                    user.Passwd = txtPass.Text;

                    try
                    {
                        String s = "Password Chenged.";
                        user.addHistory(s);
                        user.store();
                        Logger.logEvent("Reset Password Was Successfullty.", this, Logger.NORAML);

                    }
                    catch (Exception ex)
                    {
                        Logger.logEvent("Unhandler Error Occurred. " + ex.Message, this, Logger.NORAML);
                    }
                    us.UserID = UserID;

                    Message.redirectMessage("~/Order.aspx", Message.SUCCESSCHANGEPASS, "warning");


                   // Response.Redirect("~/Order.aspx");

                    UserSession.SaveUserSession(this, us);

                }




            }
            catch (Exception ex)
            {
               // WebMessage.showError(Message.findMessage(Message.UNHANDLERERROR));
                Logger.logEvent("Unhandler Error Occured! ex: " +ex.Message, Logger.NORAML);
                return;

            }


        }
        else
        {
            Message.showError(Message.findMessage(Message.FORBIDDENINPUT),Page);
            Logger.logEvent("Forbidden Input Entered !", Logger.NORAML);
            return;
        }
    }
}