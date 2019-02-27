Imports AwardsClient.MainForm
Public Class AdminForm
    ReadOnly Property Auth As MainForm.Authentication
        Get
            Return MainForm.CurrentAuth
        End Get
    End Property

    Public CurrentQueue As New List(Of MainForm.Student)
    Public CurrentVoters As New List(Of MainForm.Student)
    Public ReadOnly Property CurrentAdmins As List(Of MainForm.Student)
        Get
            Dim ss As New List(Of Student)
            ss.AddRange(CurrentQueue.Where(Function(x) x.Auth.GetValueOrDefault(Authentication.Student) > Authentication.Student))
            ss.AddRange(CurrentVoters.Where(Function(x) x.Auth.GetValueOrDefault(Authentication.Student) > Authentication.Student))
            Return ss
        End Get
    End Property


    Private Sub AddChatToTextBox(message As AdminMessage)
        rtbAdminChat.SelectionColor = If(message.FromAuth = MainForm.Authentication.Sysop, Color.LightPink, Color.Red)
        rtbAdminChat.SelectionFont = New Font(rtbAdminChat.SelectionFont, FontStyle.Bold)
        rtbAdminChat.AppendText($"{message.From}: {message.Content}" + vbCrLf)
    End Sub

    Public Sub HandleAuthMessages(message As String)
        If Auth = MainForm.Authentication.Sysadmin Then
            ' Requires sys admin
        End If
        If Auth >= MainForm.Authentication.Sysop Then
            ' Requires sys admin OR sys op
            If message.StartsWith("CHAT:") Then
                AddChatToTextBox(AdminMessage.Parse(message))
            ElseIf message.StartsWith("AQU:") Then
                message = message.Replace("AQU:", "")
                Dim splited = message.Split("#").Where(Function(x) Not String.IsNullOrWhiteSpace(x))
                CurrentQueue.Clear()
                For Each msg As String In splited
                    Dim stuSplit = msg.Split(":")
                    Dim newSt = New Student(stuSplit(0), stuSplit(1), stuSplit(2), stuSplit(3), Integer.Parse(stuSplit(4)), stuSplit(5))
                    CurrentQueue.Add(newSt)
                Next
            ElseIf message.StartsWith("AVT:") Then
                message = message.Replace("AVT:", "")
                Dim splited = message.Split("#").Where(Function(x) Not String.IsNullOrWhiteSpace(x))
                CurrentVoters.Clear()
                For Each msg As String In splited
                    Dim stuSplit = msg.Split(":")
                    Dim newSt = New Student(stuSplit(0), stuSplit(1), stuSplit(2), stuSplit(3), DirectCast(Integer.Parse(stuSplit(4)), Authentication), stuSplit(5))
                    CurrentVoters.Add(newSt)
                Next
            ElseIf message.StartsWith("MANRD:") Then
                message = message.Replace("MANRD:", "")
                Dim splited = message.Split("#").Where(Function(x) Not String.IsNullOrWhiteSpace(x))
                Dim count = 1
                dgvManualVotes.Rows.Clear()
                For Each msg As String In splited
                    Dim row As New List(Of String)
                    Dim catString = count.ToString("00")
                    Dim category As Category = Nothing
                    If MainForm.Categories.TryGetValue(count, category) Then
                        catString += ": " + category.Prompt
                    End If
                    row.Add(catString)
                    Dim catSplit = msg.Split(";")
                    For Each student In catSplit
                        Dim stuSplit = msg.Split(":")
                        Dim newSt = New Student(stuSplit(0), stuSplit(1), stuSplit(2), stuSplit(3), DirectCast(Integer.Parse(stuSplit(4)), Authentication), stuSplit(5))
                        If MainForm.AllKnownStudents.ContainsKey(stuSplit(0)) Then
                        Else
                            MainForm.Students.Add(newSt.AccountName, newSt)
                        End If
                        row.Add(newSt.ToString("FN LN TT"))
                    Next
                    count += 1
                    dgvManualVotes.Rows.Add(row.ToArray())
                Next
            End If
            ReloadUI()
        End If
    End Sub

    Private Sub SendAChat()
        If Not String.IsNullOrWhiteSpace(txtChat.Text) Then
            MainForm.Send($"/CHAT:{txtChat.Text.Replace("%", "")}")
        End If
    End Sub

    Private Sub ReloadUI()
        Select Case Auth
            Case MainForm.Authentication.Sysadmin
                Me.Text = "Sysadmin Form"
            Case MainForm.Authentication.Sysop
                Me.Text = "Sysop Form"
            Case Else
                Me.Hide()
        End Select

        dgvQueue.Rows.Clear()
        For Each std As Student In CurrentQueue
            Dim row() As String = {std.PositionInQueue, std.AccountName, std.IP, "Kick"}
            dgvQueue.Rows.Add(row)
        Next

        dgvVoters.Rows.Clear()
        For Each std As Student In CurrentVoters
            Dim row() As String = {std.IP, std.AccountName, "Kick"}
            dgvVoters.Rows.Add(row)
        Next

        boxSysops.Items.Clear()
        For Each adm As Student In CurrentAdmins
            Dim str = $"{adm.Auth}: {adm.AccountName}"
            boxSysops.Items.Add(str)
        Next
    End Sub

    Private Sub RefreshQueue()
        MainForm.Send("/QUEUE")
    End Sub

    Private Sub RefreshVoters()
        MainForm.Send("/VOTERS")
    End Sub

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshQueue()
        RefreshVoters()
    End Sub

    Private Sub btnRefreshQueue_Click(sender As Object, e As EventArgs) Handles btnRefreshQueue.Click
        RefreshQueue()
    End Sub

    Private Sub btnRefreshVoters_Click(sender As Object, e As EventArgs) Handles btnRefreshVoters.Click
        RefreshVoters()
    End Sub

    Private Sub btnSendChat_Click(sender As Object, e As EventArgs) Handles btnSendChat.Click
        If txtChat.Focused Then
            SendAChat()
            txtChat.Text = ""
        End If
    End Sub

    Private Sub AdminForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ReloadUI()
    End Sub

    Private Sub KickStudent(stud As Student)
        Dim reason = InputBox("Provide a reason to kick " + stud.ToString(), "Kick Reason")
        If Not String.IsNullOrWhiteSpace(reason) Then
            MainForm.Send("/KICK:" + stud.AccountName + ":" + reason)
        End If
    End Sub

    Private Sub dgvQueue_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQueue.CellContentClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
            Return
        End If
        If e.ColumnIndex = 3 Then
            Dim row = dgvQueue.Rows.Item(e.RowIndex)
            Dim name = row.Cells.Item(1).Value
            Dim student = MainForm.AllKnownStudents.Item(name)
            KickStudent(student)
        End If
    End Sub

    Private Sub dgvVoters_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVoters.CellContentClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
            Return
        End If
        If e.ColumnIndex = 2 Then
            Dim row = dgvVoters.Rows.Item(e.RowIndex)
            Dim name = row.Cells.Item(1).Value
            Dim student = MainForm.AllKnownStudents.Item(name)
            KickStudent(student)
        End If
    End Sub

    Private Sub btnSubmitManualVote_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnPerformManualVote_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtNameOfManualVote_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnReadyManualVote_Click(sender As Object, e As EventArgs) Handles btnReadyManualVote.Click
        If Not String.IsNullOrWhiteSpace(txtNameOfManualVote.Text) Then
            MainForm.Send("/MANR:" + txtNameOfManualVote.Text)
        End If
    End Sub
End Class

Public Class AdminMessage
    Public From As String
    Public FromAuth As MainForm.Authentication
    Public Content As String

    Public Function ToSend() As String
        Return $"/CHAT:{From}^{DirectCast(FromAuth, Integer)}^{Content}"
    End Function

    Public Shared Function Parse(message As String) As AdminMessage
        If message.StartsWith("/") Then
            message = message.Substring(1)
        End If
        If message.StartsWith("CHAT:") Then
            message = message.Substring(5)
        End If
        Dim split = message.Split("^").ToList()
        Dim from = split(0)
        Dim auth = DirectCast(Integer.Parse(split(1)), MainForm.Authentication)
        split.RemoveRange(0, 2)
        Dim content = String.Join("", split)
        Return New AdminMessage() With {
            .From = from,
            .Content = content,
            .FromAuth = auth}
    End Function
End Class