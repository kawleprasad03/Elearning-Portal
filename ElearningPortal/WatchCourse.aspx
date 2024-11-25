<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="WatchCourse.aspx.cs" Inherits="ElearningPortal.WatchCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container {
            display: flex;
            align-items: flex-start;
            margin-top: 20px;
        }

        .sidebarfortopic {
            height: 650px;
            width: 18%;
            border: 2px solid black;
            overflow-y: auto;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
        }

        .grid-container {
            flex-grow: 1;
        }

        .content-player-container {
            display: flex;
            flex-direction: column;
            width: 100%;
            margin-left: 20px;
        }

        .player {
            height: 350px;
            width: 100%;
            max-width: 1000px;
            padding: 20px;
            border: 2px solid black;
            overflow: hidden;
            margin-bottom: 25px;
        }

        /* Tabs Styling */
        .tabs {
            display: flex;
            justify-content: center;
            background-color: #003a8c;
            padding: 10px 0;
        }

        .tab-button {
            padding: 10px 20px;
            color: #ffffff;
            font-weight: bold;
            border: none;
            background-color: transparent;
            cursor: pointer;
            border-radius: 5px;
            transition: background-color 0.3s ease, color 0.3s ease;
        }

            .tab-button.active {
                background-color: #ffffff;
                color: #003a8c;
                box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);
            }

            .tab-button:hover {
                background-color: #ffffff;
                color: #003a8c;
            }

        .tab-content {
            display: none;
            width: 100%;
            max-width: 1000px;
            margin-top: 20px;
            padding: 20px;
            border: 2px solid black;
            overflow-y: auto;
        }

        .active-tab {
            display: block;
        }
    </style>
    <script type="text/javascript">
<%--    function showContent(contentType) {
        // Hide all content sections initially
        document.querySelectorAll('.tab-content').forEach((el) => el.classList.remove('active-tab'));

        // Show selected content section
        var selectedContent = document.getElementById(contentType + 'Content');
        if (selectedContent) {
            selectedContent.classList.add('active-tab');
        }

        // Remove 'active' class from all buttons and set it on the clicked button
        document.querySelectorAll('.tab-button').forEach((btn) => btn.classList.remove('active'));
        document.querySelector(`[onclick="showContent('${contentType}'); return false;"]`).classList.add('active');

        // Store the current tab in sessionStorage to persist state
        sessionStorage.setItem('activeTab', contentType);

        // Trigger the server-side event if contentType is MCQ
        if (contentType === 'MCQ') {
            document.getElementById('<%= btnMCQTab.ClientID %>').click(); // Triggers btnMCQTab's Click event
        }
        document.addEventListener('DOMContentLoaded', function () {
            const activeTab = sessionStorage.getItem('activeTab') || 'Video'; // Default to Video if no tab is set
            showContent(activeTab);
        });

        // Handle partial postback to keep the selected tab active
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            const activeTab = sessionStorage.getItem('activeTab') || 'Video'; // Default to Video if no tab is set
            showContent(activeTab);
        });

    }

    // Ensure the last active tab is shown on page load
    document.addEventListener('DOMContentLoaded', function () {
        const activeTab = sessionStorage.getItem('activeTab') || 'Video'; // Default to Video if no tab is set
        showContent(activeTab);
    });--%>

   <%-- function showContent(tabId) {
        document.getElementById("MCQContent").style.display = tabId === 'MCQ' ? 'block' : 'none';
        document.getElementById("AssignmentContent").style.display = tabId === 'Assignment' ? 'block' : 'none';

          if (tabId === 'MCQ') {
              document.getElementById("MCQContent").style.display = 'block';
              if (document.getElementById('<%= rptQuestions.ClientID %>').innerHTML.trim() === "") {
                  document.getElementById('<%= btnMCQTab.ClientID %>').click(); // Trigger server-side MCQ load
              }
          } else if (tabId === 'Assignment') {
              document.getElementById("AssignmentContent").style.display = 'block';
              if (document.getElementById('<%= ltrAssignment.ClientID %>').innerHTML.trim() === "") {
                  // Only load Assignment content from server if it's not already loaded
                  __doPostBack('<%= btnAssignmentTab.ClientID %>', '');

               }
          }
          document.getElementById('<%= HiddenActiveTab.ClientID %>').value = tabId;
        }

        window.onload = function () {
            var activeTab = document.getElementById('<%= HiddenActiveTab.ClientID %>').value || 'MCQ';
            showContent(activeTab);
        };--%>

   <%-- function showContent(tabId) {
        // Hide all tab contents initially
        document.getElementById("MCQContent").style.display = 'none';
        document.getElementById("AssignmentContent").style.display = 'none';
        document.getElementById("ReviewContent").style.display = 'none';

        // Show the selected tab content
        document.getElementById(tabId + "Content").style.display = 'block';

        // Trigger server-side load for specific tabs
        if (tabId === 'MCQ') {
            document.getElementById("MCQContent").style.display = 'block';
            document.getElementById('<%= btnMCQTab.ClientID %>').click(); // Trigger server-side MCQ load
        } else if (tabId === 'Assignment') {
            document.getElementById("AssignmentContent").style.display = 'block';
            document.getElementById('<%= btnAssignmentTab.ClientID %>').click(); // Trigger server-side assignment load
        }
    }--%>



<%--      function showContent(tabId) {
            // Hide all tab contents
            document.getElementById("MCQContent").style.display = 'none';
            document.getElementById("AssignmentContent").style.display = 'none';

            // Show the selected tab content
            if (tabId === 'MCQ') {
                document.getElementById("MCQContent").style.display = 'block';
                if (document.getElementById('<%= rptQuestions.ClientID %>').innerHTML.trim() === "") {
            // Only load MCQ content from server if it's not already loaded
                  document.getElementById('<%= btnMCQTab.ClientID %>').click();
                    
        }
    } else if (tabId === 'Assignment') {
        document.getElementById("AssignmentContent").style.display = 'block';
        if (document.getElementById('<%= ltrAssignment.ClientID %>').innerHTML.trim() === "") {
            // Only load Assignment content from server if it's not already loaded
            __doPostBack('<%= btnAssignmentTab.ClientID %>', '');
            document.getElementById('<%= btnAssignmentTab.ClientID %>').click();
        }
    }

    // Update the hidden field with the active tab state
    document.getElementById('<%= HiddenActiveTab.ClientID %>').value = tabId;
}

// On page load, show the previously selected tab
window.onload = function () {
            var activeTab = document.getElementById('<%= HiddenActiveTab.ClientID %>').value || 'MCQ';
            showContent(activeTab);
        };--%>


     <%--   function showContent(tabId) {
            document.getElementById("MCQContent").style.display = tabId === 'MCQ' ? 'block' : 'none';
            document.getElementById("AssignmentContent").style.display = tabId === 'Assignment' ? 'block' : 'none';

            if (tabId === 'MCQ') {
                if (document.getElementById('<%= rptQuestions.ClientID %>').innerHTML.trim() === "") {
            document.getElementById('<%= btnMCQTab.ClientID %>').click(); // Trigger server-side MCQ load
        }
    } else if (tabId === 'Assignment') {
        if (document.getElementById('<%= ltrAssignment.ClientID %>').innerHTML.trim() === "") {
            __doPostBack('<%= btnAssignmentTab.ClientID %>', ''); // Trigger server-side assignment load
        }
    }
    document.getElementById('<%= HiddenActiveTab.ClientID %>').value = tabId;
        }--%>



    </script>

    <%--<div class="container">
    <!-- sidebarfortopic with GridView for SubCourses -->
    <div class="sidebarfortopic">
        <div class="grid-container">
            <asp:GridView ID="gridPlaylists" runat="server" OnRowCommand="gridPlaylists_RowCommand" AutoGenerateColumns="False" CssClass="table thead-dark table-hover table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="Sub Courses">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPlay" runat="server" CommandName="Play" CommandArgument='<%# Eval("subCourseName") %>'>
                                <asp:Image ID="imgThumbnail" runat="server" Width="100px" Height="75px" ImageUrl='<%# ResolveUrl(Eval("image").ToString()) %>' />
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="subCourseName" HeaderText="Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <!-- Player and Tabbed Content Section -->
    <div class="content-player-container">
        <!-- Video Player -->
        <div class="player">
            <asp:Literal ID="ltrYouTubePlayer" runat="server" />
        </div>

        <!-- Tabs below the video player -->
        <div class="tabs">
            <button type="button" class="tab-button" onclick="showContent('MCQ'); return false;">MCQ</button>
            <button type="button" class="tab-button" onclick="showContent('Assignment'); return false;">Assignment</button>
            <button type="button" class="tab-button" onclick="showContent('Review'); return false;">Review</button>
            <asp:Button ID="btnMCQTab" runat="server" Style="display: none;" OnClick="btnMCQTab_Click" />
        </div>

        <!-- Tab Content with UpdatePanel -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="MCQContent" class="tab-content">
                    <h3>MCQ Section</h3>
                    <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDataBound">
                        <ItemTemplate>
                            <div style="margin-bottom: 20px;">
                                <strong>Q<%# Container.ItemIndex + 1 %>. <%# Eval("question") %></strong><br />
                                <asp:RadioButtonList ID="rblOptions" runat="server" RepeatDirection="Vertical" />
                                <asp:Label ID="lblAnswer" runat="server" ForeColor="Green" Visible="false"></asp:Label>
                                <asp:Button ID="btnCheckAnswer" runat="server" Text="Check Answer" CommandName="CheckAnswer" CommandArgument='<%# Eval("answer") %>' OnClick="btnCheckAnswer_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnMCQTab" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <div id="AssignmentContent" class="tab-content">
            <h3>Assignment Section</h3>
            <p>Content for Assignments will appear here.</p>
        </div>

        <div id="ReviewContent" class="tab-content">
            <h3>Review Section</h3>
            <p>Content for Reviews will appear here.</p>
        </div>
    </div>
</div>--%>

    <div class="container">
        <!-- sidebarfortopic with GridView for Topics (from uploadVideo table) -->
        <div class="sidebarfortopic">
            <div class="grid-container">
                <asp:GridView ID="gridTopics" runat="server" OnRowCommand="gridTopics_RowCommand" AutoGenerateColumns="False" CssClass="table thead-dark table-hover table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="Topics">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkTopic" runat="server" Text='<%# Eval("topicName") %>' CommandName="PlayTopic" CommandArgument='<%# Eval("topicUrl") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Player and Tabbed Content Section -->
        <div class="content-player-container">
            <!-- Video Player -->
            <div class="player">
                <asp:Literal ID="ltrYouTubePlayer" runat="server" />
            </div>


            <%--  <asp:HiddenField ID="HiddenActiveTab" runat="server" Value='<%# Session["ActiveTab"] ?? "MCQ" %>' />

        <!-- Tabs below the video player -->
        <div class="tabs">
            <button type="button" class="tab-button" onclick="showContent('MCQ'); return false;">MCQ</button>
            <button type="button" class="tab-button" onclick="showContent('Assignment'); return false;">Assignment</button>
            <asp:Button ID="btnMCQTab" runat="server" Style="display: none;" OnClick="btnMCQTab_Click" />
            <asp:Button ID="btnAssignmentTab" runat="server" Style="display: none;" OnClick="btnAssignmentTab_Click" />
        </div>

         <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <!-- Tab Content with UpdatePanel -->
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- MCQ Content -->
                <div id="MCQContent" class="tab-content">
                    <h3>MCQ Section</h3>
                    <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDataBound">
                        <ItemTemplate>
                            <div style="margin-bottom: 20px;">
                                <strong>Q<%# Container.ItemIndex + 1 %>. <%# Eval("question") %></strong><br />
                                <asp:RadioButtonList ID="rblOptions" runat="server" RepeatDirection="Vertical" />
                                <asp:Label ID="lblAnswer" runat="server" ForeColor="Green" Visible="false"></asp:Label>
                                <asp:Button ID="btnCheckAnswer" runat="server" Text="Check Answer" CommandName="CheckAnswer" CommandArgument='<%# Eval("answer") %>' OnClick="btnCheckAnswer_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnMCQTab" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <!-- Assignment Content -->
        <div id="AssignmentContent" class="tab-content">
            <h3>Assignment Section</h3>
            <asp:Literal ID="ltrAssignment" runat="server" />
        </div>--%>

            <asp:HiddenField ID="HiddenActiveTab" runat="server" Value='<%# Session["ActiveTab"] ?? "MCQ" %>' />

            <!-- Tabs below the video player -->
            <div class="tabs">
                <asp:Button ID="Button1" class="tab-button" runat="server" Text="MCQ" OnClick="Button1_Click" />
                <asp:Button ID="Button2" class="tab-button" runat="server" Text="Assignment" OnClick="Button2_Click" />
                <asp:Button ID="Button3" class="tab-button" runat="server" Text="Review" OnClick="Button3_Click" />
                <%--<button type="button" class="tab-button" onclick="showContent('MCQ'); return true;">MCQ</button>
                <button type="button" class="tab-button" onclick="showContent('Assignment'); return false;">Assignment</button>
                <asp:Button ID="btnMCQTab" runat="server" Style="display: none;" OnClick="btnMCQTab_Click" />
                <asp:Button ID="btnAssignmentTab" runat="server" Style="display: none;" OnClick="btnAssignmentTab_Click" />--%>
            </div>

         <%--   <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <!-- Tab Content with UpdatePanel -->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <!-- MCQ Content -->
                    <div id="MCQContent" class="tab-content" style="display: none;">
                        <h3>MCQ Section</h3>
                        <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDataBound">
                            <ItemTemplate>
                                <div style="margin-bottom: 20px;">
                                    <strong>Q<%# Container.ItemIndex + 1 %>. <%# Eval("question") %></strong><br />
                                    <asp:RadioButtonList ID="rblOptions" runat="server" RepeatDirection="Vertical" />
                                    <asp:Label ID="lblAnswer" runat="server" ForeColor="Green" Visible="false"></asp:Label>
                                    <asp:Button ID="btnCheckAnswer" runat="server" Text="Check Answer" CommandName="CheckAnswer" CommandArgument='<%# Eval("answer") %>' OnClick="btnCheckAnswer_Click" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnMCQTab" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>

            <!-- Assignment Content -->
            <div id="AssignmentContent" class="tab-content" style="display: none;">
                <h3>Assignment Section</h3>
                <asp:Literal ID="ltrAssignment" runat="server" />
            </div>--%>

            
        </div>
    </div>

</asp:Content>
