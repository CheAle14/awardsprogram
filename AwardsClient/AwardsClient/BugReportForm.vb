Imports System
Imports System.Reflection
Imports System.ComponentModel
Public Class BugReportForm
    Public Report As BugReport
    Public FirstSize As New Size(270, 89)
    Public FullSize As New Size(270, 257)
    Public SecondStartLocation As New Point(11, 113)
    Private Sub BugReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Report = New BugReport("", BugReportType.NotSubmitted, "")
        cboType.Items.Clear()
        For Each item As BugReportType In System.Enum.GetValues(BugReportType.NotSubmitted.GetType())
            If item = BugReportType.NotSubmitted Then
                Continue For
            End If
            cboType.Items.Add(DirectCast(item, Integer).ToString() + ": " + GetEnumDescription(item))
        Next
        Me.Size = FirstSize
        txtPrimary.Text = ""
        txtSecondary.Text = ""
        cboType.SelectedIndex = -1
    End Sub
    Public Shared Function GetEnumDescription(e As [Enum]) As String
        Dim t As Type = e.GetType()
        Dim attr = CType(t.
                        GetField([Enum].GetName(t, e)).
                        GetCustomAttribute(GetType(DescriptionAttribute)),
                        DescriptionAttribute)
        If attr IsNot Nothing Then
            Return attr.Description
        Else
            Return e.ToString
        End If
    End Function

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        Me.Size = FullSize
        Dim text = cboType.SelectedItem.ToString()
        Dim firstBit = text.Substring(0, text.IndexOf(":"))
        Dim enumm As BugReportType
        If System.Enum.TryParse(Of BugReportType)(firstBit, enumm) Then
            Me.Size = FullSize
            txtPrimary.Show()
            lblSecondary.Show()
            txtSecondary.Location = SecondStartLocation

            If enumm = BugReportType.User Then
                lblPrimary.Text = "Enter the affected student's name and tutor"
            ElseIf enumm = BugReportType.Category Then
                lblPrimary.Text = "Enter the affected category"
            ElseIf enumm = BugReportType.Other Then
                lblPrimary.Text = "Provide as much information as you can"
                txtPrimary.Hide()
                lblSecondary.Hide()
                txtSecondary.Location = txtPrimary.Location
            End If
            Report.ConcernType = enumm
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Report.Submitted = True
        Report.PrimaryConcern = txtPrimary.Text
        Report.AdditionalData = txtSecondary.Text
        Me.Close()
    End Sub
End Class
Public Class BugReport
    Public PrimaryConcern As String
    Public ConcernType As BugReportType
    Public AdditionalData As String
    Public Submitted = False
    Public Sub New(primary As String, type As BugReportType, additional As String)
        PrimaryConcern = primary
        ConcernType = type
        AdditionalData = additional
    End Sub
End Class
Public Enum BugReportType
    NotSubmitted = 0
    <Description("General issue ('other')")>
    Other
    <Description("A student is missing, or otherwise incorrect")>
    User
    <Description("A category is incorrect")>
    Category
End Enum
