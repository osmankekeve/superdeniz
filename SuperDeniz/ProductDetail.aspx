<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="SuperDeniz.ProductDetail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .marginBottomForDetailRow {
            margin-bottom: 5px;
        }

        .alert {
            padding: 10px 0 0 0 !important;
            margin-bottom: 20px;
            border: 1px solid transparent;
            border-radius: 4px;
        }

        .bs-callout-danger {
            border-left-color: #d9534f !important;
        }

        video::-webkit-media-controls-volume-slider {
            display: none !important;
        }

        video::-webkit-media-controls-mute-button {
            display: none !important;
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
    <div class="row" style="margin-bottom: 10px">
        <div class="col-sm-10">
            <div class="row thumbnail">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img runat="server" id="img1" class="col-sm-11">
                        </div>

                        <div class="item">
                            <img runat="server" id="img2" class="col-sm-11">
                        </div>

                        <div class="item">
                            <img runat="server" id="img3" class="col-sm-11">
                        </div>
                    </div>
                    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
        <div class="col-sm-1">
            <img src="Icons/impect_resist.png" width="75" height="75" />
            <img src="Icons/resist_hight_warm.png" width="75" height="75" />
            <img src="Icons/resist_electricity.png" width="75" height="75" />
            <img src="Icons/resist_water.png" width="75" height="75" />
            <asp:Button runat="server" ID="btnDownloadImage" OnClick="btnDownloadImage_Click" Text="Resim İndir" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <h4 class="panel-title">Ürün Bilgileri
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblProductCode" CssClass="informationColor" Text="Ürün Kodu :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblProductCodeValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblProductName" CssClass="informationColor" Text="Ürün Adı :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblProductNameValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblBody" CssClass="informationColor" Text="Gövde :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblBodyValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblReflector" CssClass="informationColor" Text="Reflektör :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblReflectorValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblSocket" CssClass="informationColor" Text="Duy :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblSocketValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblStain" CssClass="informationColor" Text="Boya :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblStainValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblConta" CssClass="informationColor" Text="Conta :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblContaValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblGlass" CssClass="informationColor" Text="Cam :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblGlassValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblWeight" CssClass="informationColor" Text="Ağarlık :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblWeightValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblSize" CssClass="informationColor" Text="Ebat :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblSizeValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4" style="font-weight: bold">
                            <asp:Label runat="server" ID="lblDeep" CssClass="informationColor" Text="Derinlik :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblDeepValue"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6" runat="server" id="pnlVideo">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <h4 class="panel-title">Ürün Video
                    </h4>
                </div>
                <div class="panel-body">
                    <video runat="server" id="myVideo" autoplay muted loop title="Uzun Mentilli Tarama Projektörü" 
                        style="
                        margin-bottom: 10px;
                        width:100%;
                        max-width:350px;
                        height: auto;
                        max-height:370px;">
                    </video>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="alert alert-danger" role="alert">
                <h4 class="text-center">Özellikler ve Kullanım Alanları</h4>
            </div>
            <asp:DataList ID="dlDescriptions" runat="server">
                <ItemTemplate>
                    <div class="bs-callout bs-callout-danger">
                        <p><%#Eval("description") %></p>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
