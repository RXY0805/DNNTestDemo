<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="TAC.Modules.HelloWorld.View" %>
<asp:Repeater ID="rptItemList" runat="server" OnItemDataBound="rptItemListOnItemDataBound" OnItemCommand="rptItemListOnItemCommand">
   <HeaderTemplate>
        <ul class="tm_tl">
            <li>view page</li>
            </ul>
    </HeaderTemplate>
   
    <ItemTemplate>

            <h3>
                <asp:Label ID="lblitemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"HelloText").ToString() %>' />
            </h3>
            <asp:Panel ID="pnlAdmin" runat="server" Visible="true">
                <asp:HyperLink ID="lnkEdit" runat="server"  Text="Edit" Visible="true" Enabled="true" />
                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" Visible="false" Enabled="false" CommandName="Delete" />
            </asp:Panel>
       
    </ItemTemplate>
   
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
