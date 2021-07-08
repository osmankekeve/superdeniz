<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailModule.ascx.cs" Inherits="SuperDeniz.Modules.ProductDetailModule" %>

<asp:Panel runat="server" ID="pnlMain" CssClass="contanierPanelFixed" Width="500px">
    <div class="panel panel-red">
        <div class="panel-heading">
            <p>Ürün Detayı</p>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div class="col-sm-12">
                    <div class="col-sm-4" style="font-weight: bold">
                        <asp:Label runat="server" ID="Label21" CssClass="informationColor" Text="Derinlik :"></asp:Label>
                    </div>
                    <div class="col-sm-8">
                       
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <p>Footer</p>
        </div>
    </div>
</asp:Panel>
