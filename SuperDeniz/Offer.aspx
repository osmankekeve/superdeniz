﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Offer.aspx.cs" Inherits="SuperDeniz.Offer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        $(document).ready(function () {
            $('#myTable').DataTable();
        });
    </script>
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
    <div class="panel-body">
        <div id="dataTables-example_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
            <div class="row">
                <div class="col-sm-6">
                    <div class="dataTables_length" id="dataTables-example_length">
                        <label>Show
                            <select name="dataTables-example_length" aria-controls="dataTables-example" class="form-control input-sm">
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                            </select>
                            entries</label></div>
                </div>
                <div class="col-sm-6">
                    <div id="dataTables-example_filter" class="dataTables_filter">
                        <label>Search:<input class="form-control input-sm" placeholder="" aria-controls="dataTables-example" type="search"></label></div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <table class="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" id="dataTables-example" role="grid" aria-describedby="dataTables-example_info" style="width: 100%;" width="100%">
                        <thead>
                            <tr role="row">
                                <th class="sorting_asc" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 176px;" aria-label="Rendering engine: activate to sort column descending" aria-sort="ascending">Rendering engine</th>
                                <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 204px;" aria-label="Browser: activate to sort column ascending">Browser</th>
                                <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 185px;" aria-label="Platform(s): activate to sort column ascending">Platform(s)</th>
                                <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 151px;" aria-label="Engine version: activate to sort column ascending">Engine version</th>
                                <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 109px;" aria-label="CSS grade: activate to sort column ascending">CSS grade</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="gradeA odd" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Firefox 1.0</td>
                                <td>Win 98+ / OSX.2+</td>
                                <td class="center">1.7</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA even" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Firefox 1.5</td>
                                <td>Win 98+ / OSX.2+</td>
                                <td class="center">1.8</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA odd" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Firefox 2.0</td>
                                <td>Win 98+ / OSX.2+</td>
                                <td class="center">1.8</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA even" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Firefox 3.0</td>
                                <td>Win 2k+ / OSX.3+</td>
                                <td class="center">1.9</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA odd" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Camino 1.0</td>
                                <td>OSX.2+</td>
                                <td class="center">1.8</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA even" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Camino 1.5</td>
                                <td>OSX.3+</td>
                                <td class="center">1.8</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA odd" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Netscape 7.2</td>
                                <td>Win 95+ / Mac OS 8.6-9.2</td>
                                <td class="center">1.7</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA even" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Netscape Browser 8</td>
                                <td>Win 98SE+</td>
                                <td class="center">1.7</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA odd" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Netscape Navigator 9</td>
                                <td>Win 98+ / OSX.2+</td>
                                <td class="center">1.8</td>
                                <td class="center">A</td>
                            </tr>
                            <tr class="gradeA even" role="row">
                                <td class="sorting_1">Gecko</td>
                                <td>Mozilla 1.0</td>
                                <td>Win 95+ / OSX.1+</td>
                                <td class="center">1</td>
                                <td class="center">A</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="dataTables_info" id="dataTables-example_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div>
                </div>
                <div class="col-sm-6">
                    <div class="dataTables_paginate paging_simple_numbers" id="dataTables-example_paginate">
                        <ul class="pagination">
                            <li class="paginate_button previous disabled" aria-controls="dataTables-example" tabindex="0" id="dataTables-example_previous"><a href="#">Previous</a></li>
                            <li class="paginate_button active" aria-controls="dataTables-example" tabindex="0"><a href="#">1</a></li>
                            <li class="paginate_button " aria-controls="dataTables-example" tabindex="0"><a href="#">2</a></li>
                            <li class="paginate_button " aria-controls="dataTables-example" tabindex="0"><a href="#">3</a></li>
                            <li class="paginate_button " aria-controls="dataTables-example" tabindex="0"><a href="#">4</a></li>
                            <li class="paginate_button " aria-controls="dataTables-example" tabindex="0"><a href="#">5</a></li>
                            <li class="paginate_button " aria-controls="dataTables-example" tabindex="0"><a href="#">6</a></li>
                            <li class="paginate_button next" aria-controls="dataTables-example" tabindex="0" id="dataTables-example_next"><a href="#">Next</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.table-responsive -->
        <div class="well">
            <h4>DataTables Usage Information</h4>
            <p>DataTables is a very flexible, advanced tables plugin for jQuery. In SB Admin, we are using a specialized version of DataTables built for Bootstrap 3. We have also customized the table headings to use Font Awesome icons in place of images. For complete documentation on DataTables, visit their website at <a target="_blank" href="https://datatables.net/">https://datatables.net/</a>.</p>
            <a class="btn btn-default btn-lg btn-block" target="_blank" href="https://datatables.net/">View DataTables Documentation</a>
        </div>
    </div>
</asp:Content>
