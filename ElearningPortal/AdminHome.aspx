<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ElearningPortal.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
    <h1>Welcome to E-Learning</h1>
    <div class="card-container">
            <div class="card text-white bg-primary mb-3">
                <div class="card-header">Number of Users</div>
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </h5>
                    <p class="card-text">Total registered users.</p>
                </div>
            </div>
            <div class="card text-white bg-success mb-3">
                <div class="card-header">Number of Courses</div>
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </h5>
                    <p class="card-text">Total courses added.</p>
                </div>
            </div>
            <div class="card text-white bg-info mb-3">
                <div class="card-header">Number of Sales</div>
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </h5>
                    <p class="card-text">Total sales made.</p>
                </div>
            </div>
        </div>
        <canvas id="myLineChart" width="400" height="400"></canvas>
        
    </div>
       <%--<script>
           var ctxLine = document.getElementById('myLineChart').getContext('2d');
           var myLineChart = new Chart(ctxLine, {
               type: 'line',
               data: {
                   labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                   datasets: [
                       {
                           label: 'Users',
                           data: [120, 130, 150, 145, 160, 170, 180, 190, 200, 210, 220, 230],
                           borderColor: 'rgba(54, 162, 235, 1)',
                           backgroundColor: 'rgba(54, 162, 235, 0.2)',
                           fill: true,
                           tension: 0.1
                       },
                       {
                           label: 'Courses',
                           data: [30, 35, 40, 42, 43, 44, 45, 45, 45, 46, 46, 47],
                           borderColor: 'rgba(75, 192, 192, 1)',
                           backgroundColor: 'rgba(75, 192, 192, 0.2)',
                           fill: true,
                           tension: 0.1
                       },
                       {
                           label: 'Sales',
                           data: [100, 110, 120, 115, 125, 130, 135, 140, 145, 150, 155, 160],
                           borderColor: 'rgba(255, 206, 86, 1)',
                           backgroundColor: 'rgba(255, 206, 86, 0.2)',
                           fill: true,
                           tension: 0.1
                       }
                   ]
               },
               options: {
                   responsive: true,
                   plugins: {
                       legend: { position: 'top' },
                       tooltip: {
                           callbacks: {
                               label: function (tooltipItem) {
                                   return tooltipItem.label + ': ' + tooltipItem.raw;
                               }
                           }
                       }
                   },
                   scales: {
                       y: { beginAtZero: true }
                   }
               }
           });
       </script>--%>


    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var ctxLine = document.getElementById('myLineChart').getContext('2d');
            var myLineChart = new Chart(ctxLine, {
                type: 'line',
                data: {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    datasets: [
                        {
                            label: 'Sales',
                            data: monthlySalesData, // Use the JSON data output from the server
                            borderColor: 'rgba(255, 206, 86, 1)',
                            backgroundColor: 'rgba(255, 206, 86, 0.2)',
                            fill: true,
                            tension: 0.1
                        }
                    ]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: { position: 'top' },
                        tooltip: {
                            callbacks: {
                                label: function (tooltipItem) {
                                    return tooltipItem.label + ': ₹ ' + tooltipItem.raw;
                                }
                            }
                        }
                    },
                    scales: {
                        y: { beginAtZero: true }
                    }
                }
            });
        });
    </script>

</asp:Content>

