<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SequencesManager.Web._Default" Async="true"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div class="fieldContainer">
                <div>Sequence type</div>
                <asp:DropDownList runat="server" ID="SequenceTypeList">
                    <asp:ListItem Value="0" Text="Fibonacci Sequence"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Catalan Sequence"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Bell Sequence"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fieldContainer">
                <div>Sequence elements count</div>
                <asp:TextBox runat="server" ID="ElementsCountField"></asp:TextBox>
                
                <asp:CompareValidator ID="cmpmin" runat="server" 
                    ControlToValidate="ElementsCountField" Operator="GreaterThan"
                        Display="Dynamic" Type="Integer"
                        ValueToCompare="0" ErrorMessage="Elements count should be integer and greater than 0" Text="*"/>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Set sequence elements count, please." Text="*"
                    ControlToValidate="ElementsCountField"></asp:RequiredFieldValidator>
                <asp:ValidationSummary runat="server"/>
            </div>
            <div class="fieldContainer">
                <asp:Button runat="server" Text="Generate" OnClick="OnGenerate"/>
            </div>
            <asp:Label runat="server" ID="ErrorInfo"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="ResultsPanel">
        <ContentTemplate>
            <asp:GridView runat="server" ID="ResultsGrid" AutoGenerateColumns="false" CssClass="resultsGrid">
                <Columns>
                    <asp:BoundField DataField="RunNumber" HeaderText="Run Number"/>
                    <asp:BoundField DataField="SequenceLength" HeaderText="Sequence Length"/>
                    <asp:BoundField DataField="MaxElement" HeaderText="Max Element"/>
                    <asp:BoundField DataField="Average" HeaderText="Average Element"/>
                    <asp:BoundField DataField="SequenceType" HeaderText="Sequence Type"/>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
