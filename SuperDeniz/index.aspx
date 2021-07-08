<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SuperDeniz.index" %>
<%@ Register Src="~/Modules/BannerModule.ascx" TagPrefix="uc1" TagName="BannerModule" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .panel-body {
            padding: 0px;
        }

        .thumbnail {
            margin-bottom: 0px;
            border: 0;
        }
    </style>
</asp:Content>

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
    <div class="card mt-1" runat="server" id="pnlInfo">
        <div class="card-body bg-success text-white">
            <img src="Images/info.png" width="50" />
            YENİLENDİK!!! Sizlere daha iyi hizmet verebilmek için sitemizi yeniliyoruz.!!
        </div>
    </div>
    <div class="row mb-2">
        <asp:Repeater ID="rptUrunler" runat="server">
            <ItemTemplate>
                <div class="col-sm-3 mt-2">
                    <div class="card h-100" style="border: 1px solid rgba(0,0,0,.2) !important">
                        <div class="card-body">
                            <a href='<%#Eval("productID", "ProductDetail.aspx?pid={0}") %>'>
                                <img class="img-thumbnail border-none mb-3" src='<%#Eval("imageUrl") %>' width="800" height="500" title="Detay Görüntüle">
                            </a>
                            <h5 class="card-title"><%#Eval("productCode") %></h5>
                            <p class="card-text product-name"><%#Eval("productName") %></p>
                        </div>
                        <div class="card-footer">
                            <p class="card-text text-danger"><%#Eval("view") %> Görüntülenme</p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
