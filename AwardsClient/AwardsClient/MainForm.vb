Imports System.Net
Imports System.Net.Sockets

Public Class MainForm
    Public Const HardCodedConnectionIP = "127.0.0.1"

    Private CurrentIPStage = 0 ' 0 = Not tried, 1 = Tried github ip, 2 = tried hardcoded, >3 = currently looping.
    Dim FirstChosen As Boolean = False
    Dim SecoundChosen As Boolean = False
    Dim Ready As Boolean = True
    Public ReadOnly Property ConnectionIP As String
        Get
            Dim ip = ""
            If CurrentIPStage = 0 Then ' use the /dev/ branch for now, for testing purposes - eventually change it back to /master/
                Dim url = "https://raw.githubusercontent.com/TheGrandCoding/awardsserver/dev/AwardsServer/ServerIP"
                Using wc = New WebClient()
                    ip = wc.DownloadString(url)
                End Using
            ElseIf CurrentIPStage = 1 Then
                ip = HardCodedConnectionIP
            Else
                ' We have tried the above, so now we need to loop through them all.
                Dim baseString = "10.249.67."
                ip = baseString + (CurrentIPStage - 1).ToString()
                If (CurrentIPStage - 2) > 255 Then
                    ip = "10.249.68." + (CurrentIPStage - (1 + 255)).ToString()
                End If
            End If
            CurrentIPStage += 1
            Return ip
        End Get
    End Property
    Public ConnectionPort As Integer = 56567
    Public Client As TcpClient
    Public Const MaximumStudentsDisplayInDropDown = 15
    Public Const LettersBeforeQuery = 3

    Public Students As New Dictionary(Of String, Student) ' account name

    Dim AllChache As New Dictionary(Of String, Student)

    Public Categories As New Dictionary(Of Integer, Category)

    Public CurrentCategory As Category

    Public NumberOfCategories = 0

    Public HasConnectedAtleastOnce = False

    Public Class Student
        Public AccountName As String
        Public FirstName As String
        Public LastName As String
        Public Tutor As String
        <Obsolete("Removed. See: TheGrandCoding/awardsprogram#15", True)>
        Public Sex As Char
        Public Sub New(accn As String, fn As String, ln As String, tt As String)
            AccountName = accn
            FirstName = fn
            LastName = ln
            Tutor = tt
        End Sub
        Public Overrides Function ToString() As String
            Return Me.ToString("FN LN (TT)")
        End Function
        Public Overloads Function ToString(format As String) As String
            format = format.Replace("AN", "{0}")
            format = format.Replace("FN", "{1}")
            format = format.Replace("LN", "{2}")
            format = format.Replace("TT", "{3}")
            If format.Contains("SX") Then
                format = format.Replace("SX", "[remove sex]")
            End If
            Return String.Format(format, AccountName, FirstName, LastName, Tutor)
        End Function

        Public Function ToQueryFormat() As String
            Return Me.ToString("AN-FN-LN-TT")
        End Function
    End Class
    Public PreviousClicked As Boolean = False
    Public Class Category
        Public ID As Integer = 0
        Public Prompt As String = ""
        Public FirstWinner As String = ""
        Public SecondWinner As String = ""

        Public ReadOnly Property FirstDisplay As String
            Get
                Dim val As Student = Nothing
                If MainForm.Students.TryGetValue(FirstWinner, val) Then
                    Return val.ToString()
                End If
                Return ""
            End Get
        End Property

        Public ReadOnly Property SecondDisplay As String
            Get
                Dim val As Student = Nothing
                If MainForm.Students.TryGetValue(SecondWinner, val) Then
                    Return val.ToString()
                End If
                Return ""
            End Get
        End Property
    End Class

    Public Event Messaged As EventHandler(Of String)

    Public Sub Log(message As String)
        DebugForm.Log("MainForm/ " + message)
    End Sub

    Private Disallowed As New List(Of Char) From {
    "`", "%"
    }

    Private Sub Send(message As String)
        Try
            For Each item In Disallowed
                message = message.Replace(item, "")
            Next
            message = $"%{message}`"
            Dim stream = Client.GetStream()
            Dim bytes = System.Text.Encoding.UTF8.GetBytes(message)
            stream.Write(bytes, 0, bytes.Length)
        Catch x As Exception
            Try
                System.IO.File.WriteAllText("Log.txt", x.ToString())
                MsgBox("Server has disconnected, the error has been logged")
            Catch
                MsgBox("Server has disconnected, error cannot be logged" + vbCrLf + x.ToString())
            End Try
            Me.Close()
        End Try
    End Sub

    Public recieveMessageThread As Threading.Thread


    Private Sub ClientConnected()
        ' for some reason, this also gets called when the client 
        ' hasnt disconnected, such as when it errors
        If Client.Connected Then
            HasConnectedAtleastOnce = True
            contactServerTimer.Stop()
            connThread.Abort()
            recieveMessageThread = New Threading.Thread(AddressOf ReceiveMessage)
            recieveMessageThread.Start()
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
            btnStart.Visible = True
            lblOpeningMessage.Text = "Hello, " + message + vbCrLf _
                + "For each of the award categories, chose two people that you want to win" + vbCrLf _
                + "Then, hit the Next button in the bottom right." + vbCrLf _
                + "If you need to go back, hit the 'Previous' button" + vbCrLf + vbCrLf _
                + "Once you reach the final category, the Next button will become 'Finish' and you will be prompted to confirm your vote."
            first_panel_load.Hide()
        ElseIf message = "UnknownUser" Then
            lblOpeningMessage.Text = "Errored" + vbCrLf + "Your account name is unknown." + vbCrLf + "Please contact someone."
            btnStart.Visible = False
            HasConnectedAtleastOnce = True
            first_panel_load.Hide()
        ElseIf message = "Accepted" Then
            lblOpeningMessage.Text = "The server has indicated that your vote was accepted" + vbCrLf + "Thanks for voting and have a nice day."
        ElseIf message = "Rejected" Then
            lblOpeningMessage.Text = "Uh oh!" + vbCrLf + "The server has indicated that your vote was rejected, though a reason was not given" + vbCrLf + vbCrLf + "You may have already voted, or attempted to vote for yourself.. it isn't clear"
        ElseIf message.StartsWith("Rejected") Then
            message = message.Substring("Rejected".Length + 1)
            If message = "Self" Then
                lblOpeningMessage.Text = "Your vote was rejected because you attempted to vote for yourself."
            ElseIf message = "Errored" Then
                lblOpeningMessage.Text = "Your vote was rejected because the server encountered an error - its probably happening to everyone."
            ElseIf message = "Duplicate" Then
                lblOpeningMessage.Text = "Your vote was rejected because you voted for the same person twice as your first/second winner in a single category"
            End If
        ElseIf message.StartsWith("REJECT:") Then
            first_panel_load.Hide()
            second_panel_prompt.Show()
            message = message.Replace("REJECT:", "")
            If message = "Voted" Then
                lblOpeningMessage.Text = "Refused!" + vbCrLf + vbCrLf + "The server closed the connection because you have already voted"
            End If
            HasConnectedAtleastOnce = True
            Client.Close()
            btnStart.Visible = False
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
        ElseIf message.StartsWith("Q_RES") Then
            message = message.Replace("Q_RES:", "")
            ' format is:
            ' AccountName-First-Last-Tutor
            ' with a # seperating
            Dim First = QueryIsSecond
            Dim splited = message.Split("#").Where(Function(x) String.IsNullOrWhiteSpace(x) = False)
            For Each value In splited
                Dim stuSplit = value.Split("-")
                Dim newSt = New Student(stuSplit(0), stuSplit(1), stuSplit(2), stuSplit(3))
                If Students.ContainsKey(newSt.AccountName) Then
                    Continue For
                Else
                    Students.Add(newSt.AccountName, newSt)
                End If
            Next
            lblQuerySecond.Hide()
            lblQueryFirst.Hide()
            txtQuerySecond.ReadOnly = False
            txtQueryFirst.ReadOnly = False
            'If First Then Took cout cause it caused the focus to move to next text box when i types 3 letters in first text box
            '    txtQueryFirst.Focus()
            'Else
            '    txtQuerySecond.Focus()
            'End If
            RefreshCategoryUI()
        ElseIf message.StartsWith("QUEUE:") Then
            message = message.Replace("QUEUE:", "")
            If message.EndsWith("11") Or message.EndsWith("12") Or message.EndsWith("13") Then
                message += "th"
            ElseIf message.EndsWith("1") Then
                message += "st"
            ElseIf message.EndsWith("2") Then
                message += "nd"
            ElseIf message.EndsWith("3") Then
                message += "rd"
            Else
                message += "th"
            End If
            first_panel_load.Hide()
            second_panel_prompt.Show()
            btnStart.Visible = False
            lblOpeningMessage.Text = "You are currently in a queue, since many people are trying to vote." + vbCrLf + vbCrLf + $"You are {message} in line."
        End If
    End Sub

    Private Sub ReceiveMessage()
        Try
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
        Catch ex As Exception
            Log(ex.ToString())
        End Try
    End Sub

    Private Sub AttemptConnection(Optional delay As Integer = 0)
        If delay > 15 Then
            Threading.Thread.Sleep(delay)
        End If
        Me.Invoke(Sub() contactServerTimer.Start())
        If Client IsNot Nothing Then
            If Client.Connected Then
                Return
            End If
        End If
        If HasConnectedAtleastOnce Then
            Return ' They have already recieved an error message
        End If
        Client = New TcpClient()
        Dim tempIP = ConnectionIP ' needs to only do it once, since we +1 each time we access this variable
        Log($"Starting connection to {tempIP}:{ConnectionPort}")
        Dim conn = Client.BeginConnect(tempIP, ConnectionPort, AddressOf ClientConnected, Nothing)
        Threading.Thread.Sleep(1000 * 10)
        If Client.Connected Then
            Return
        End If
        Try
            Client.EndConnect(conn)
        Catch ex As Exception
            Log(ex.ToString())
        End Try
        EndConnection("Connection timed out, either the server is overloaded or offline or setup incorrectly" + vbCrLf + "Restarting in 5 seconds")
    End Sub


    Private numberOfFailures = 0
    Private Sub EndConnection(message As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() EndConnection(message))
            Return
        End If
        numberOfFailures += 1
        contactServerTimer.Stop()
        lblFirstPanelDisplay.Text = message
        LoadedStartCon(5000)
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If DEBUG Then
        DebugForm.Show()
#End If
        Me.Size = New Size(652, 405)
        Me.MinimumSize = New Size(652, 405)
        Me.MaximumSize = New Size(652, 405)
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
        LoadedStartCon()

        MsgBox("If you have any suggestions or bugs please report them to us" + vbCrLf + "Also if you have any suggestions for categories please tell us and we can consider")
    End Sub
    Private connThread As Threading.Thread
    Private Sub LoadedStartCon(Optional delay As Integer = 0)
        If numberOfFailures > 2 Then
            lblFirstPanelDisplay.Text = "Having issues contacting server.. Retrying in 5 seconds.."
        Else
            lblFirstPanelDisplay.Text = "Contacting server"
        End If
        If connThread IsNot Nothing Then
            Try
                connThread.Abort()
            Catch ex As Exception
            End Try
        End If
        connThread = New Threading.Thread(New Threading.ParameterizedThreadStart(Sub() AttemptConnection(delay)))
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
            FirstChosen = Not CurrentCategory.FirstDisplay = ""
            SecoundChosen = Not CurrentCategory.SecondDisplay = ""
            txtQuerySecond.Text = If(CurrentCategory.SecondDisplay = "", txtQuerySecond.Text, CurrentCategory.SecondDisplay)
            txtQueryFirst.Text = If(CurrentCategory.FirstDisplay = "", txtQueryFirst.Text, CurrentCategory.FirstDisplay)
            Ready = True
            If txtQueryFirst.Text.Length >= LettersBeforeQuery OrElse txtQuerySecond.Text.Length >= LettersBeforeQuery Then
                ' show a "drop down" in the form of buttons..

                Dim FirstAutocomplete As New Dictionary(Of String, String) ' display item for each
                Dim SecondAutocomplete As New Dictionary(Of String, String)
                Dim accsAlreadyDone As New List(Of String) ' so we dont add two identical
                Dim count = 0
                For Each stud As Student In Students.Values
                    If count > MaximumStudentsDisplayInDropDown Then
                        Exit For
                    End If
                    If accsAlreadyDone.Contains(stud.AccountName) Then
                        Continue For
                    End If
                    If txtQueryFirst.Text.Length >= LettersBeforeQuery AndAlso txtQueryFirst.Text.EndsWith(")") = False Then
                        Dim done As Boolean = False
                        If stud.ToString().StartsWith(txtQueryFirst.Text) Then
                            done = True
                        ElseIf stud.ToString().ToLower().StartsWith(txtQueryFirst.Text.ToLower()) Then
                            done = True
                        ElseIf stud.ToString().ToLower().Contains(txtQueryFirst.Text.ToLower()) Then
                            done = True
                        End If
                        If done Then
                            count += 1
                            FirstAutocomplete.Add(stud.AccountName, stud.ToString())
                            accsAlreadyDone.Add(stud.AccountName)
                        End If
                    ElseIf txtQuerySecond.Text.Length >= LettersBeforeQuery AndAlso txtQuerySecond.Text.EndsWith(")") = False Then
                        Dim done As Boolean = False
                        If stud.ToString().StartsWith(txtQuerySecond.Text) Then
                            done = True
                        ElseIf stud.ToString().ToLower().StartsWith(txtQuerySecond.Text.ToLower()) Then
                            done = True
                        ElseIf stud.ToString().ToLower().Contains(txtQuerySecond.Text.ToLower()) Then
                            done = True
                        End If
                        If done Then
                            count += 1
                            SecondAutocomplete.Add(stud.AccountName, stud.ToString())
                            accsAlreadyDone.Add(stud.AccountName)
                        End If
                    End If
                Next

                ' not selected, so we display..
                SetSecondDropDown(SecondAutocomplete)
                SetFirstDropDown(FirstAutocomplete)
            End If
        End If
    End Sub

    Private Sub SetSecondDropDown(names As Dictionary(Of String, String))
        For Each vv In SecondButtons
            vv.Hide()
        Next
        For i As Integer = 0 To Maximum(names.Count - 1, MaximumStudentsDisplayInDropDown)
            Dim accName = names.Keys(i)
            Dim display = names(accName)
            Dim button As Button = Nothing
            Try
                button = SecondButtons(i)
                button.Show()
            Catch ex As Exception
                button = New Button()
                SecondDisplayPanel.Controls.Add(button)
                button.Name = "Second-" + i.ToString()
                Dim newX = 0
                Dim newY = -button.Height
                For yy As Integer = 0 To i
                    newY += button.Height + 1
                Next
                button.Location = New Point(newX, newY)
                button.Width = 224
                SecondButtons.Insert(i, button)
                AddHandler button.Click, AddressOf UserSelectedWinner
            End Try
            button.Text = display
            button.Tag = accName
            If button.Tag.ToString().ToLower() = Environment.UserName.ToLower() Then
                button.Enabled = False
                button.Text += " (You)"
            Else
                button.Enabled = True ' otherwise it remains disabled
            End If
        Next
    End Sub

    Private Sub SetFirstDropDown(names As Dictionary(Of String, String))
        For Each vv In FirstButtons
            vv.Hide()
        Next
        For i As Integer = 0 To Maximum(names.Count - 1, MaximumStudentsDisplayInDropDown)
            Dim accName = names.Keys(i)
            Dim display = names(accName)
            Dim button As Button = Nothing
            Try
                button = FirstButtons(i)
                button.Show()
            Catch ex As Exception
                button = New Button()
                FirstDisplayPanel.Controls.Add(button)
                button.Name = "First-" + i.ToString()
                Dim newX = 0
                Dim newY = -button.Height
                For yy As Integer = 0 To i
                    newY += button.Height + 1
                Next
                button.Location = New Point(newX, newY)
                button.Width = 224
                FirstButtons.Insert(i, button)
                AddHandler button.Click, AddressOf UserSelectedWinner
            End Try
            button.Text = display
            button.Tag = accName
            If button.Tag.ToString().ToLower() = Environment.UserName.ToString().ToLower() Then
                button.Enabled = False
                button.Text += " (You)"
            Else
                button.Enabled = True
            End If
        Next
    End Sub

    Private Function Maximum(possibleAnyNumber As Integer, maximumAllowed As Integer) As Integer
        If possibleAnyNumber > maximumAllowed Then
            Return maximumAllowed
        End If
        Return possibleAnyNumber
    End Function

    Private SecondButtons As New List(Of Button)
    Private FirstButtons As New List(Of Button)

    Private Sub UserSelectedWinner(sender As Object, e As EventArgs)

        Dim btnClicked = DirectCast(sender, Button)
        Dim sex = btnClicked.Name.Split("-")(0)
        Dim accName = DirectCast(btnClicked.Tag, String)
        lastQuery = "ssssssssssssssssssssssssssssssss" ' so it doesnt query again
        If sex = "Second" Then
            SecoundChosen = False
            CurrentCategory.SecondWinner = accName
            txtQuerySecond.Text = CurrentCategory.SecondDisplay
            SecondDisplayPanel.Hide()
            SecoundChosen = True
        Else
            FirstChosen = False
            CurrentCategory.FirstWinner = accName
            txtQueryFirst.Text = CurrentCategory.FirstDisplay
            FirstDisplayPanel.Hide()
            FirstChosen = True
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        PreviousClicked = False
        FirstChosen = False
        SecoundChosen = False
        If CurrentCategory.ID + 1 > NumberOfCategories Then
            If CurrentCategory.FirstWinner = "" Then
                If MsgBox("Warning: you have not selected a First Choice (you need to search then click their button)" + vbCrLf + vbCrLf + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Missing Name") = vbNo Then
                    Return
                End If
            Else
                If Not AllChache.ContainsKey(CurrentCategory.FirstWinner) Then
                    AllChache.Add(CurrentCategory.FirstWinner, Students(CurrentCategory.FirstWinner))
                End If
            End If
            If CurrentCategory.SecondWinner = "" Then
                If MsgBox("Warning: you have not selected a Second Choice (you need to search then click their button)" + vbCrLf + vbCrLf + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Missing Name") = vbNo Then
                    Return
                End If
            Else
                If Not AllChache.ContainsKey(CurrentCategory.SecondWinner) Then
                    AllChache.Add(CurrentCategory.SecondWinner, Students(CurrentCategory.SecondWinner))
                End If
            End If
            If CurrentCategory.FirstWinner = CurrentCategory.SecondWinner And Not String.IsNullOrWhiteSpace(CurrentCategory.FirstWinner) Then
                MsgBox("You have nominated the same person twice - this is forbidden" + vbCrLf + "Please select two different people as your two winners", MsgBoxStyle.Critical, "Error - duplicate")
                Return
            End If
            second_panel_prompt.Visible = True
            btnStart.Text = ".."
            btnStart.Visible = False
            lblOpeningMessage.Text = "Your submission is currently being looked at, please wait.."
            DataGridView1.Rows.Clear()
            For Each category In Categories
                Dim row() As String = {category.Value.Prompt, category.Value.FirstDisplay, category.Value.SecondDisplay}
                DataGridView1.Rows.Add(row)
            Next
            finalPromptPanel.Location = New Point(0, 0)
            Dim pSize = New Size(Me.Width, Me.Height - 25)
            finalPromptPanel.Size = pSize
            finalPromptPanel.Dock = DockStyle.Fill
            finalPromptPanel.BringToFront()
            finalPromptPanel.Visible = True
            Me.Invoke(Sub()
                          Dim response = InputBox("Please type a category you think should be added" + vbCrLf + "Or some other category-related change.", "Category Altrication", "TYPE HERE")
                          If Not (String.IsNullOrWhiteSpace(response) Or response = "TYPE HERE") Then
                              Send("QUES:" + response)
                          End If
                      End Sub)
        Else
            If CurrentCategory.FirstWinner = "" Then
                If MsgBox("Warning: you have not selected a First Choice (you need to search then click their button)" + vbCrLf + vbCrLf + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Missing Name") = vbNo Then
                    Return
                End If
            Else
                If Not AllChache.ContainsKey(CurrentCategory.FirstWinner) Then
                    AllChache.Add(CurrentCategory.FirstWinner, Students(CurrentCategory.FirstWinner))
                End If
            End If
            If CurrentCategory.SecondWinner = "" Then
                If MsgBox("Warning: you have not selected a Second Choice (you need to search then click their button)" + vbCrLf + vbCrLf + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Missing Name") = vbNo Then
                    Return
                End If
            Else
                If Not AllChache.ContainsKey(CurrentCategory.SecondWinner) Then
                    AllChache.Add(CurrentCategory.SecondWinner, Students(CurrentCategory.SecondWinner))
                End If
            End If
            If CurrentCategory.FirstWinner = CurrentCategory.SecondWinner And Not String.IsNullOrWhiteSpace(CurrentCategory.FirstWinner) Then
                MsgBox("You have nominated the same person twice - this is forbidden" + vbCrLf + "Please select two different people as your two winners", MsgBoxStyle.Critical, "Error - duplicate")
                Return
            End If
            Dim nextCat = New Category() With {.ID = CurrentCategory.ID + 1}
            If Categories.ContainsKey(nextCat.ID) Then
                nextCat = If(Categories(nextCat.ID), CurrentCategory) ' this should prevent an error, but it might bug it in other ways?
            End If
            If (nextCat.ID + 1) > Categories.Count AndAlso (nextCat.ID + 1) <= NumberOfCategories Then
                Send("GET_CATE:" + (nextCat.ID + 1).ToString()) ' gets category after this.
                ' but only gets it if needed
            End If
            CurrentCategory = nextCat
            Ready = False
            txtQuerySecond.Text = ""
            txtQueryFirst.Text = ""
            RefreshCategoryUI()
            btnNext.Text = If(nextCat.ID = NumberOfCategories, "Finish", "Next")


            ' Show cache of Firsts/Seconds.

            Dim Firsts As New Dictionary(Of String, String) 'name: display
            For Each st In AllChache
                Firsts.Add(st.Key, st.Value.ToString("FN LN (TT)"))
            Next

            Dim Seconds As New Dictionary(Of String, String) 'name: display
            For Each st In AllChache
                Seconds.Add(st.Key, st.Value.ToString("FN LN (TT)"))
            Next
            If Firsts.Count > 0 Then
                FirstDisplayPanel.Show()
                SetFirstDropDown(Firsts)
            End If
            If Seconds.Count > 0 Then
                SecondDisplayPanel.Show()
                SetSecondDropDown(Seconds)
            End If
        End If
        btnPrevious.Visible = CurrentCategory.ID > 1
    End Sub
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If CurrentCategory.ID = 1 Then
            ' this shouldnt even be possible since the button should be hidden
        Else
            PreviousClicked = True
            Dim nextCat = Categories(CurrentCategory.ID - 1)
            CurrentCategory = nextCat
            Ready = False
            txtQuerySecond.Text = ""
            txtQueryFirst.Text = ""
            RefreshCategoryUI()
            btnNext.Text = If(nextCat.ID = NumberOfCategories, "Finish", "Next")
        End If
        btnPrevious.Visible = CurrentCategory.ID > 1
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Send("GET_CATE:1")
        second_panel_prompt.BringToFront()
        ' gets first category.
        ' in the recieve of the response, it also handles the hiding/showing of things.
        ' so we just need to send the message here.
    End Sub

    Private Sub DisableDueToQuery(isFirst As Boolean)
        txtQuerySecond.ReadOnly = True
        txtQueryFirst.ReadOnly = True
        FirstDisplayPanel.Visible = isFirst
        SecondDisplayPanel.Visible = Not isFirst
    End Sub

    ''' <summary>
    ''' Returns true if the query is for a First student
    ''' 
    ''' Note: this will return even if there is no query, but it will return False.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property QueryIsSecond As Boolean
        Get
            Return lblQueryFirst.Visible
        End Get
    End Property

    Private lastQuery As String = ""

    Private Sub txtQueryFirst_TextChanged(sender As Object, e As EventArgs) Handles txtQueryFirst.TextChanged
        If FirstChosen = True And Ready = True Then
            If txtQueryFirst.Text.ToLower() <> CurrentCategory.FirstDisplay.ToLower() Then
                CurrentCategory.FirstWinner = ""
                FirstChosen = False
            End If
        End If
        If txtQueryFirst.Text.Length >= LettersBeforeQuery AndAlso txtQueryFirst.Text.Contains(")") = False Then
            ' query it.
            If txtQueryFirst.Text.StartsWith(lastQuery) Then
                If txtQueryFirst.TextLength < lastQuery.Length + 2 Then
                    Return ' must enter a few more characters prior.
                End If
            End If
            CurrentCategory.FirstWinner = ""
            DisableDueToQuery(True)
            Send("QUERY:" + txtQueryFirst.Text)
            lastQuery = txtQueryFirst.Text
        End If
    End Sub

    Private Sub txtQuerySecond_TextChanged(sender As Object, e As EventArgs) Handles txtQuerySecond.TextChanged
        If SecoundChosen = True And Ready = True Then
            If txtQuerySecond.Text.ToLower() <> CurrentCategory.SecondDisplay.ToLower() Then
                CurrentCategory.SecondWinner = ""
                SecoundChosen = False
            End If
        End If
        If txtQuerySecond.Text.Length >= LettersBeforeQuery AndAlso txtQuerySecond.Text.Contains(")") = False Then
            ' query it.
            If txtQuerySecond.Text.StartsWith(lastQuery) Then
                If txtQuerySecond.TextLength < lastQuery.Length + 2 Then
                    Return ' must enter a few more characters prior.
                End If
            End If
            CurrentCategory.SecondWinner = ""
            DisableDueToQuery(False)
            Send("QUERY:" + txtQuerySecond.Text)
            lastQuery = txtQuerySecond.Text
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            recieveMessageThread.Abort()
        Catch ex As Exception
        End Try
        Try
            Client.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        Dim msg = "SUBMIT:"
        For Each category In Categories
            msg += category.Value.FirstWinner + ";" + category.Value.SecondWinner + "#"
        Next
        Send(msg)
        finalPromptPanel.Hide()
    End Sub
    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click

        finalPromptPanel.Visible = False
        second_panel_prompt.Visible = False
    End Sub

    Private Sub cmdConfirm_Resize(sender As Object, e As EventArgs) Handles cmdConfirm.Resize
        Try
            cmdConfirm.Font = New Font(cmdConfirm.Font.FontFamily, cmdConfirm.Height / 7.5)
            cmdBack.Font = New Font(cmdConfirm.Font.FontFamily, cmdBack.Height / 5)
        Catch
        End Try
    End Sub

    Private Sub lblFirstPanelDisplay_Click(sender As Object, e As EventArgs) Handles lblFirstPanelDisplay.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
