<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="ResetPassword.aspx.cs" AutoEventWireup="true" Inherits="ResetPassword" %>



<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>





      

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


   <div class="row" style="margin:auto;text-align:center">
          <div class="col-lg-12 mb-12" style="margin:auto;text-align:center">
          <div class="card h-100">
            <h4 class="card-header"><asp:Literal runat="server" Text="<%$Resources:Resource, changepassword%>" /></h4>
            <div class="card-body">
              <p class="card-text"><asp:Literal runat="server" Text="<%$Resources:Resource, newpassword%>" /></p>
                                       <asp:TextBox runat="server" ID="txtPass"  CssClass="form-control" TextMode="Password"></asp:TextBox>
                      <asp:RegularExpressionValidator runat="server" Display="dynamic"
                            ControlToValidate="txtPass"
                            ErrorMessage="<%$Resources:Resource, passwordlenght%>"
                            ValidationExpression="[^\s]{4,12}" />
               <br/>
               <p class="card-text"><asp:Literal runat="server" Text="<%$Resources:Resource, repeatnewpassword%>" /></p>
                <asp:TextBox runat="server" ID="txtConfirmPass"  CssClass="form-control" TextMode="Password"></asp:TextBox>   
                  <asp:RegularExpressionValidator runat="server" Display="dynamic"
                            ControlToValidate="txtConfirmPass"
                            ErrorMessage="<%$Resources:Resource, passwordlenght%>"
                            ValidationExpression="[^\s]{4,12}" /> 
                            <asp:CompareValidator ID="CompareValidator1"
                            runat="server" ErrorMessage="<%$Resources:Resource, notequalpassword%>" ForeColor="red"
                            ControlToValidate="txtPass"
                            ControlToCompare="txtConfirmPass"></asp:CompareValidator>                             
            </div>
            <div class="card-footer">
            <asp:Button CssClass="btn btn-primarynira" ID="btn_resetpass" runat="server" Text="<%$Resources:Resource, savepassword%>"  OnClick="btnResetPass_Click"/>
            </div>
          </div>
        </div>
</div>
</asp:Content>
