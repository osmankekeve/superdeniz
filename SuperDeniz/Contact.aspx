<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SuperDeniz.Contact" %>
<%@ Register Src="~/Modules/BannerModule.ascx" TagPrefix="uc1" TagName="BannerModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlErrorInformation">
        <div class="alert alert-danger">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>Dikkat!</strong>
            <asp:Label runat="server" ID="lblErrorInformation"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlSuccessInformation">
        <div class="alert alert-success">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>Tebrikler!</strong>
            <asp:Label runat="server" ID="lblSuccessInformation"></asp:Label>
        </div>
    </asp:Panel>
    <div class="mt-2">
        <uc1:BannerModule runat="server" ID="BannerModule" />
    </div>
    <div class="row mt-1">
        <div class="col-sm-6">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d752.2486977529284!2d28.96522000000001!3d41.04724300000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab7458ffcf501%3A0x52e4eb130a37fe6!2zU2Vsw6d1ayBTay4gTm86MiwgUGl5YWxlcGHFn2EsIDM0NDQwIEJleW_En2x1L8Swc3RhbmJ1bCwgVMO8cmtpeWU!5e0!3m2!1str!2s!4v1442134922874" width="560" height="450" frameborder="0" style="border: 0"></iframe>
        </div>
        <div class="col-sm-6">

            <div class="card">
                <div class="card-header">
                    İletişim Bilgileri
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label>Adres : </label>
                        <asp:Label runat="server" ID="lblAddressValue"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Telefon : </label>
                        <asp:Label runat="server" ID="lblPhone1Value"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Fax : </label>
                        <asp:Label runat="server" ID="lblFaxValue"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Mail Adres : </label>
                        <asp:Label runat="server" ID="lblMailAddressValue"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>WhatsApp İletişim : </label>
                        <asp:Label runat="server" ID="lblWhatsUppNumberValue"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Telegram İletişim : </label>
                        <asp:Label runat="server" ID="lblTelegramNumberValue"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
