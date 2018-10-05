Imports System.Net
Imports System.Net.Sockets

Public Class MainForm
    Public ConnectionIP As String = "127.0.0.1"
    Public ConnectionPort As Integer = 56567
    Public Client As TcpClient

    Public Students As New Dictionary(Of String, String) ' account name: display text

    Public Categories As New Dictionary(Of Integer, Category)

    Public CurrentCategory As Category

    Public NumberOfCategories = 0

    Public Class Category
        Public ID As Integer = 0
        Public Prompt As String = ""
        Public MaleWinner As String = ""
        Public FemaleWinner As String = ""

        Public ReadOnly Property MaleDisplay As String
            Get
                Dim val = ""
                If MainForm.Students.TryGetValue(MaleWinner, val) Then
                    Return val
                End If
                Return ""
            End Get
        End Property

        Public ReadOnly Property FemaleDisplay As String
            Get
                Dim val = ""
                If MainForm.Students.TryGetValue(FemaleWinner, val) Then
                    Return val
                End If
                Return ""
            End Get
        End Property
    End Class

    Public Event Messaged As EventHandler(Of String)

    Public Sub Log(message As String)
        DebugForm.Log("MainForm/ " + message)
    End Sub

    Private Sub Send(message As String)
        message = $"%{message}`"
        Dim stream = Client.GetStream()
        Dim bytes = System.Text.Encoding.UTF8.GetBytes(message)
        stream.Write(bytes, 0, bytes.Length)
    End Sub

    Private Sub ClientConnected()
        If Client.Connected Then
            Dim recThread = New Threading.Thread(AddressOf ReceiveMessage)
            recThread.Start()
            AddHandler Me.Messaged, AddressOf MessageRecievedHandler
            EndConnection("Connected, waiting for server to confirm be ready..")
            Send(Environment.UserName)
        End If
    End Sub

    Private Sub MessageRecievedHandler(sender As Object, message As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() MessageRecievedHandler(sender, message))
            Return
        End If

        DebugForm.Log("Server/ " + message)

        If message.StartsWith("Ready:") Then
            message = message.Replace("Ready:", "")
            lblOpeningMessage.Text = "Hello, " + message + vbCrLf _
                + "For each of the award categories, select the Male and Female winner" + vbCrLf _
                + "Then, hit the Next button in the bottom left." + vbCrLf _
                + "If you need to go back, hit the 'Previous' button" + vbCrLf + vbCrLf _
                + "Once you reach the final category, the Next button will become 'Finish' and you will be prompted to confirm your vote."
            first_panel_load.Hide()
        ElseIf message.StartsWith("CTS:") Then
            message = message.Replace("CTS:", "")
            Dim int As Integer = 0
            If Integer.TryParse(message, int) Then
                NumberOfCategories = int
            End If
        ElseIf message.StartsWith("Cat:") Then
            message = message.Replace("Cat:", "")
            Dim firstColon = message.IndexOf(":")
            Dim _id = message.Substring(0, firstColon)
            Dim id As Integer
            If Integer.TryParse(_id, id) Then
                message = message.Replace(_id + ":", "")
                Dim newC = New Category()
                newC.ID = id
                newC.Prompt = message
                If Categories.ContainsKey(id) Then
                    Categories(id) = newC
                Else
                    Categories.Add(id, newC)
                End If
                If id = 1 Then
                    CurrentCategory = newC
                    RefreshCategoryUI()
                    second_panel_prompt.Hide()
                End If
                ' we also want to grab the next one, since we may as well
                If id = CurrentCategory.ID Then
                    Send("GET_CATE:" + (id + 1).ToString()) ' the server may not respond if it exceeds the number of catags
                End If
            End If
        ElseIf message.StartsWith("NumCat") Then
            message = message.Replace("NumCat:", "")
            If Integer.TryParse(message, NumberOfCategories) Then
            End If
        End If
    End Sub

    Private Sub ReceiveMessage()
        While Client IsNot Nothing AndAlso Client.Connected
            Dim stream = Client.GetStream()
            Dim bytes(Client.ReceiveBufferSize) As Byte
            stream.Read(bytes, 0, Client.ReceiveBufferSize)
            Dim msg = System.Text.Encoding.UTF8.GetString(bytes).Replace(vbNullChar, String.Empty)
            For Each message As String In msg.Split("%")
                If String.IsNullOrWhiteSpace(message) Then
                    Continue For
                End If
                RaiseEvent Messaged(Me, message.Substring(0, message.LastIndexOf("`")))
            Next
        End While
    End Sub

    Private Sub AttemptConnection()
        Client = New TcpClient()
        Log($"Starting connection to {ConnectionIP}:{ConnectionPort}")
        Dim conn = Client.BeginConnect(ConnectionIP, ConnectionPort, AddressOf ClientConnected, Nothing)
        Threading.Thread.Sleep(1000 * 10)
        If Client.Connected Then
            Return
        End If
        Try
            Client.EndConnect(conn)
        Catch ex As Exception
            Log(ex.ToString())
        End Try
        EndConnection("Connection timed out, either the server is overloaded or offline or setup incorrectly")
    End Sub

    Private Sub EndConnection(message As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() EndConnection(message))
            Return
        End If

        contactServerTimer.Stop()
        lblFirstPanelDisplay.Text = message
    End Sub


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DebugForm.Show()
        first_panel_load.Location = New Point(0, 0)
        Dim pSize = New Size(Me.Width, Me.Height - 25)
        first_panel_load.Size = pSize
        first_panel_load.Dock = DockStyle.Fill


        second_panel_prompt.Location = New Point(0, 0)
        second_panel_prompt.Size = pSize
        second_panel_prompt.Dock = DockStyle.Fill

        second_panel_prompt.BringToFront()
        first_panel_load.BringToFront()

        Log("Loaded")
        lblFirstPanelDisplay.Text = "Contacting server"
        contactServerTimer.Start()
        Dim connThread As New Threading.Thread(AddressOf AttemptConnection)
        connThread.Name = "Connectiong Thread"
        connThread.Start()
        Log("Started conn thread")
    End Sub

    Private contactCount = 0
    Private Sub contactServerTimer_Tick(sender As Object, e As EventArgs) Handles contactServerTimer.Tick
        If Client Is Nothing OrElse Client.Connected = False Then
            contactCount += 1
            If contactCount = 1 Then
                lblFirstPanelDisplay.Text = "Contacting server ."
            ElseIf contactCount = 2 Then
                lblFirstPanelDisplay.Text = "Contacting server . ."
            ElseIf contactCount = 3 Then
                lblFirstPanelDisplay.Text = "Contacting server . ."
            ElseIf contactCount = 4 Then
                lblFirstPanelDisplay.Text = "Contacting server . . ."
            ElseIf contactCount = 5 Then
                lblFirstPanelDisplay.Text = "Contacting server . ."
            ElseIf contactCount = 6 Then
                lblFirstPanelDisplay.Text = "Contacting server ."
            Else
                lblFirstPanelDisplay.Text = "Contacting server"
                contactCount = 0
            End If
        Else
            lblFirstPanelDisplay.Text = "Connected."
        End If
    End Sub

    Private Sub RefreshCategoryUI()
        If CurrentCategory Is Nothing Then
            Try
                CurrentCategory = Categories(0)
            Catch ex As Exception
            End Try
        End If
        If CurrentCategory IsNot Nothing Then
            lblPrompt.Text = CurrentCategory.Prompt
            lblNumRemain.Text = $"{CurrentCategory.ID}/{NumberOfCategories}"
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If CurrentCategory.ID + 1 > NumberOfCategories Then
            ' end..
        Else
            Dim nextCat = Categories(CurrentCategory.ID + 1)
            If (nextCat.ID + 1) > Categories.Count Then
                Send("GET_CATE:" + (nextCat.ID + 1).ToString()) ' gets category after this.
                ' but only gets it if needed
            End If
            CurrentCategory = nextCat
            RefreshCategoryUI()
            btnNext.Text = If(nextCat.ID = NumberOfCategories, "Finish", "Next")
        End If
        btnPrevious.Visible = CurrentCategory.ID > 1
    End Sub
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If CurrentCategory.ID = 1 Then
            ' this shouldnt even be possible since the button should be hidden
        Else
            Dim nextCat = Categories(CurrentCategory.ID - 1)
            CurrentCategory = nextCat
            RefreshCategoryUI()
            btnNext.Text = If(nextCat.ID = NumberOfCategories, "Finish", "Next")
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Send("GET_CATE:1") ' gets first category.
        ' in the recieve of the response, it also handles the hiding/showing of things.
        ' so we just need to send the message here.
    End Sub

End Class
