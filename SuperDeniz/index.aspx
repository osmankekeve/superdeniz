<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SuperDeniz.index" %>

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
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="rptUrunler_ItemCommand" OnItemDataBound="rptUrunler_ItemDataBound">
        <ItemTemplate>
            <div class="col-sm-4">
                <div class="card h-100">
                    <img class="img-thumbnail card-img-top border-none" src='<%#Eval("imageUrl") %>' width="800" height="500" title='<%#Eval("productName") %>'>
                    <div class="card-body">
                        <h4 class="card-title"><%#Eval("productCode") %></h4>
                        <p class="card-text"><%#Eval("productName") %></p>
                        <div class="thumbnail">
                            <div class="ratings">
                                <div class="form-group-sm">
                                    <a href='<%#Eval("productID", "ProductDetail.aspx?pid={0}") %>' class="btn btn-warning">Detayı Göster</a>
                                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-info pull-right" CommandName="btnAddBasket" CommandArgument='<%#Eval("productID") %>' Text="Sepete Ekle" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>





                <div class="panel panel-red">
                    <div class="panel-heading">
                        <%#Eval("productCode") %>
                    </div>
                    <div class="panel-body">
                        <div class="thumbnail">
                            <img src='<%#Eval("imageUrl") %>' width="800" height="500" title='<%#Eval("productName") %>'>
                            <div class="caption">
                                <p><%#Eval("productName") %></p>
                            </div>
                            <div class="ratings">
                                <div class="form-group-sm">
                                    <a href='<%#Eval("productID", "ProductDetail.aspx?pid={0}") %>' class="btn btn-warning">Detayı Göster</a>
                                    <asp:Button runat="server" ID="btnAddBasket" CssClass="btn btn-info pull-right" CommandName="btnAddBasket" CommandArgument='<%#Eval("productID") %>' Text="Sepete Ekle" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <%#Eval("view") %> Görüntülenme
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Repeater ID="rptUrunler" runat="server" OnItemCommand="rptUrunler_ItemCommand" OnItemDataBound="rptUrunler_ItemDataBound">
        <ItemTemplate>
            <div class="col-sm-4">
                <div class="panel panel-red">
                    <div class="panel-heading">
                        <%#Eval("productCode") %>
                    </div>
                    <div class="panel-body">
                        <div class="thumbnail">
                            <img src='<%#Eval("imageUrl") %>' width="800" height="500" title='<%#Eval("productName") %>'>
                            <div class="caption">
                                <p><%#Eval("productName") %></p>
                            </div>
                            <div class="ratings">
                                <div class="form-group-sm">
                                    <a href='<%#Eval("productID", "ProductDetail.aspx?pid={0}") %>' class="btn btn-warning">Detayı Göster</a>
                                    <asp:Button runat="server" ID="btnAddBasket" CssClass="btn btn-info pull-right" CommandName="btnAddBasket" CommandArgument='<%#Eval("productID") %>' Text="Sepete Ekle" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <%#Eval("view") %> Görüntülenme
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
