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

    <div class="row mt-3">
        <div class="col-sm-6">
            <div class="card h-100 bg-light">
                <div class="card-header">
                    Ürün Görsel
                </div>
                <div class="card-body">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img runat="server" class="d-block w-100" id="img1" alt="First slide">
                    </div>
                    <div class="carousel-item">
                        <img runat="server" class="d-block w-100" id="img2" alt="Second slide">
                    </div>
                    <div class="carousel-item">
                        <img runat="server" class="d-block w-100" id="img3" alt="Second slide">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="card h-100">
                <div class="card-header">
                    Ürün Bilgileri
                </div>
                <div class="card-body">
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblProductCode" CssClass="informationColor" Text="Ürün Kodu :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblProductCodeValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblProductName" CssClass="informationColor" Text="Ürün Adı :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblProductNameValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblBody" CssClass="informationColor" Text="Gövde :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblBodyValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblReflector" CssClass="informationColor" Text="Reflektör :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblReflectorValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblSocket" CssClass="informationColor" Text="Duy :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblSocketValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblStain" CssClass="informationColor" Text="Boya :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblStainValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblConta" CssClass="informationColor" Text="Conta :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblContaValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblGlass" CssClass="informationColor" Text="Cam :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblGlassValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblWeight" CssClass="informationColor" Text="Ağırlık :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblWeightValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblSize" CssClass="informationColor" Text="Ebat :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblSizeValue"></asp:Label>
                        </div>
                    </div>
                    <div class="row marginBottomForDetailRow">
                        <div class="col-sm-4 font-weight-600">
                            <asp:Label runat="server" ID="lblDeep" CssClass="informationColor" Text="Derinlik :"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblDeepValue"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row my-2">
        <div class="col-sm-6" runat="server" id="pnlVideo">
            <div class="card h-100">
                <div class="card-header">
                    Ürün Video
                </div>
                <div class="card-body">
                    <video runat="server" id="myVideo" autoplay muted loop title="Uzun Mentilli Tarama Projektörü"
                        style="margin-bottom: 10px; width: 100%; max-width: 350px; height: auto; max-height: 370px;">
                    </video>
                </div>
            </div>
        </div>
        <div class="col-sm-6" runat="server">
            <div class="card h-100">
                <div class="card-header">
                    Özellikler ve Kullanım Alanları
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <img src="Icons/impect_resist.png" width="75" height="75" />
                        </div>
                        <div class="col">
                            <img src="Icons/resist_hight_warm.png" width="75" height="75" />
                        </div>
                        <div class="col">
                            <img src="Icons/resist_electricity.png" width="75" height="75" />
                        </div>
                        <div class="col">
                            <img src="Icons/resist_water.png" width="75" height="75" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <asp:DataList ID="dlDescriptions" runat="server">
                        <ItemTemplate>
                            <div class="bs-callout bs-callout-danger">
                                <p><%#Eval("description") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
