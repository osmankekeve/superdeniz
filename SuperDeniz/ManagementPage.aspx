<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManagementPage.aspx.cs" Inherits="SuperDeniz.ManagementPage" %>

<%@ Register Src="~/Modules/OfferModule.ascx" TagPrefix="uc1" TagName="OfferModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <asp:Panel runat="server" ID="pnlProduct">
        <div class="col-sm-6">
            <div class="panel panel-red">
                <div class="panel-heading" style="margin-bottom: 10px">
                    <h3 class="panel-title">Karışık Ürünler</h3>
                </div>
                <div class="list-group" style="max-height: 600px; overflow: auto">
                    <asp:DataList ID="dlProducts" runat="server" OnItemCommand="dlProducts_ItemCommand">
                        <ItemTemplate>
                            <div class="row" style="border-bottom: solid thin #d9534f; padding-top: 5px; padding-bottom: 5px; margin-left: 0px !important; margin-right: 0px !important">
                                <div class="col-sm-2">
                                    <asp:Button runat="server" ID="btnEditProduct" CssClass="btn btn-success btn-sm" CommandName="btnEditProduct" CommandArgument='<%#Eval("productID") %>' Text="Düzenle" />
                                </div>
                                <div class="col-sm-4">
                                    <img src='<%#Eval("imageUrl") %>' width="100" height="63" title='<%#Eval("productName") %>'>
                                </div>
                                <div class="col-sm-6">
                                    <p><%#Eval("productName") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <h4 class="panel-title">Ürün Detay</h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label1" CssClass="control-label informationColor" Text="Ürün Kodu :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtProductCode" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label3" CssClass="informationColor" Text="Ürün Adı :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label5" CssClass="informationColor" Text="Gövde :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtBody" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label7" CssClass="informationColor" Text="Reflektör :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtReflector" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label9" CssClass="informationColor" Text="Duy :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtSocket" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label11" CssClass="informationColor" Text="Boya :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtStain" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label13" CssClass="informationColor" Text="Conta :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtGasket" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label15" CssClass="informationColor" Text="Cam :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtGlass" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label17" CssClass="informationColor" Text="Ağarlık :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtWeight" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label19" CssClass="informationColor" Text="Ebat :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtSize" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-4" style="font-weight: bold">
                                    <asp:Label runat="server" ID="Label21" CssClass="informationColor" Text="Derinlik :"></asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtDeep" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 well well-sm">
                            <div class="pull-right">
                                <p>
                                    <asp:Button runat="server" ID="btnSaveProduct" CssClass="btn btn-success" Text="Kaydet" OnClick="btnSaveProduct_Click" />
                                    <asp:Button runat="server" ID="btnShowDetail" CssClass="btn btn-success" Text="Detay" OnClick="btnShowDetail_Click" />
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlSearch" runat="server">
        <div class="col-sm-12">
            <div class="panel panel-red">
                <div class="panel-heading">
                    ARAMA SONUÇLARI
                </div>
            </div>
        </div>
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
    </asp:Panel>
    <asp:Panel ID="pnlVisitor" runat="server">
        <div class="panel panel-red">
            <div class="panel-heading">
                Ziyaretçi - Gün Raporu
            </div>
        </div>
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Ziyaret Tarihi</th>
                        <th>Ziyaretçi Sayısı</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptVisitor" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%#Eval("rowNumber") %></th>
                                <td><%#Eval("visitingDate") %></td>
                                <td><%#Eval("visitorCount") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlProductView" runat="server">
        <div class="panel panel-red">
            <div class="panel-heading">
                Ürün Görüntülenme Raporu
            </div>
        </div>
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Ürün Kodu</th>
                        <th>Ürün Adı</th>
                        <th>Görüntülenme Sayısı</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptProductView" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%#Eval("rowNumber") %></th>
                                <td><%#Eval("productCode") %></td>
                                <td><%#Eval("productName") %></td>
                                <td><%#Eval("viewCount") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
