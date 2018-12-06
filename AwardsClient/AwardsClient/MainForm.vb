Imports System.Net
Imports System.Net.Sockets

Public Class MainForm
    Public ConnectionIP As String = "10.249.67.121"
    Public ConnectionPort As Integer = 56567
    Public Client As TcpClient
    Public Const MaximumStudentsDisplayInDropDown = 15
    Public Const LettersBeforeQuery = 3

    Public Students As New Dictionary(Of String, Student) ' account name

    Dim MaleCache As New Dictionary(Of String, Student)
    Dim FemaleCache As New Dictionary(Of String, Student)

    Public Categories As New Dictionary(Of Integer, Category)

    Public CurrentCategory As Category

    Public NumberOfCategories = 0

    Public HasConnectedAtleastOnce = False

    Public Class Student
        Public AccountName As String
        Public FirstName As String
        Public LastName As String
        Public Tutor As String
        Public Sex As Char
        Public Sub New(accn As String, fn As String, ln As String, tt As String, sx As Char)
            AccountName = accn
            FirstName = fn
            LastName = ln
            Tutor = tt
            Sex = sx
        End Sub
        Public Overrides Function ToString() As String
            Return Me.ToString("FN LN (TT)")
        End Function
        Public Overloads Function ToString(format As String) As String
            format = format.Replace("AN", "{0}")
            format = format.Replace("FN", "{1}")
            format = format.Replace("LN", "{2}")
            format = format.Replace("TT", "{3}")
            format = format.Replace("SX", "{4}")
            Return String.Format(format, AccountName, FirstName, LastName, Tutor, Sex)
        End Function

        Public Function ToQueryFormat() As String
            Return Me.ToString("AN-FN-LN-TT-SX")
        End Function
    End Class
    Public PreviousClicked As Boolean = False
    Public Class Category
        Public ID As Integer = 0
        Public Prompt As String = ""
        Public MaleWinner As String = ""
        Public FemaleWinner As String = ""

        Public ReadOnly Property MaleDisplay As String
            Get
                Dim val As Student = Nothing
                If MainForm.Students.TryGetValue(MaleWinner, val) Then
                    Return val.ToString()
                End If
                Return ""
            End Get
        End Property

        Public ReadOnly Property FemaleDisplay As String
            Get
                Dim val As Student = Nothing
                If MainForm.Students.TryGetValue(FemaleWinner, val) Then
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
                + "For each of the award categories, select the Male and Female winner" + vbCrLf _
                + "Then, hit the Next button in the bottom left." + vbCrLf _
                + "If you need to go back, hit the 'Previous' button" + vbCrLf + vbCrLf _
                + "Once you reach the final category, the Next button will become 'Finish' and you will be prompted to confirm your vote."
            first_panel_load.Hide()
        ElseIf message = "UnknownUser" Then
            lblOpeningMessage.Text = "Errored" + vbCrLf + "Your account name is unknown." + vbCrLf + "Please contact someone."
            btnStart.Visible = False
            HasConnectedAtleastOnce = True
            first_panel_load.Hide()
        ElseIf message = "Accepted" Then
            lblOpeningMessage.Text = "Thanks for your vote!" + vbCrLf + "The server has indicated that your vote was accepted, you can leave now."
        ElseIf message = "Rejected" Then
            lblOpeningMessage.Text = "Uh oh!" + vbCrLf + "The server has indicated that your vote was rejected, though a reason was not given" + vbCrLf + vbCrLf + "You may have already voted, or attempted to vote for yourself.. it isn't clear"
        ElseIf message.StartsWith("Rejected") Then
            message = message.Substring("Rejected".Length + 1)
            If message = "Self" Then
                lblOpeningMessage.Text = "Your vote was rejected because you attempted to vote for yourself."
            ElseIf message = "Errored" Then
                lblOpeningMessage.Text = "Your vote was rejected because the server encountered an error - its probably happening to everyone."
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
            Dim male = QueryIsMale
            Dim splited = message.Split("#").Where(Function(x) String.IsNullOrWhiteSpace(x) = False)
            For Each value In splited
                Dim stuSplit = value.Split("-")
                Dim newSt = New Student(stuSplit(0), stuSplit(1), stuSplit(2), stuSplit(3), If(QueryIsMale, "M", "F"))
                If Students.ContainsKey(newSt.AccountName) Then
                    Continue For
                Else
                    Students.Add(newSt.AccountName, newSt)
                End If
            Next
            lblQueryFemale.Hide()
            lblQueryMale.Hide()
            txtQueryFemale.ReadOnly = False
            txtQueryMale.ReadOnly = False
            If male Then
                txtQueryMale.Focus()
            Else
                txtQueryFemale.Focus()
            End If
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

            txtQueryFemale.Text = If(CurrentCategory.FemaleDisplay = "", txtQueryFemale.Text, CurrentCategory.FemaleDisplay)
            txtQueryMale.Text = If(CurrentCategory.MaleDisplay = "", txtQueryMale.Text, CurrentCategory.MaleDisplay)

            If txtQueryMale.Text.Length >= LettersBeforeQuery OrElse txtQueryFemale.Text.Length >= LettersBeforeQuery Then
                ' show a "drop down" in the form of buttons..

                Dim maleAutocomplete As New Dictionary(Of String, String) ' display item for each
                Dim femaleAutocomplete As New Dictionary(Of String, String)
                Dim accsAlreadyDone As New List(Of String) ' so we dont add two identical
                Dim count = 0
                For Each stud As Student In Students.Values
                    If count > MaximumStudentsDisplayInDropDown Then
                        Exit For
                    End If
                    If accsAlreadyDone.Contains(stud.AccountName) Then
                        Continue For
                    End If
                    If stud.Sex = "M" AndAlso txtQueryMale.Text.Length >= LettersBeforeQuery Then
                        Dim done As Boolean = False
                        If stud.ToString().StartsWith(txtQueryMale.Text) Then
                            done = True
                        ElseIf stud.ToString().ToLower().StartsWith(txtQueryMale.Text.ToLower()) Then
                            done = True
                        ElseIf stud.ToString().ToLower().Contains(txtQueryMale.Text.ToLower()) Then
                            done = True
                        End If
                        If done Then
                            count += 1
                            maleAutocomplete.Add(stud.AccountName, stud.ToString())
                            accsAlreadyDone.Add(stud.AccountName)
                        End If
                    ElseIf stud.Sex = "F" AndAlso txtQueryFemale.Text.Length >= LettersBeforeQuery Then
                        Dim done As Boolean = False
                        If stud.ToString().StartsWith(txtQueryFemale.Text) Then
                            done = True
                        ElseIf stud.ToString().ToLower().StartsWith(txtQueryFemale.Text.ToLower()) Then
                            done = True
                        ElseIf stud.ToString().ToLower().Contains(txtQueryFemale.Text.ToLower()) Then
                            done = True
                        End If
                        If done Then
                            count += 1
                            femaleAutocomplete.Add(stud.AccountName, stud.ToString())
                            accsAlreadyDone.Add(stud.AccountName)
                        End If
                    End If
                Next

                ' not selected, so we display..
                SetFemaleDropDown(femaleAutocomplete)
                SetMaleDropDown(maleAutocomplete)
            End If
        End If
    End Sub

    Private Sub SetFemaleDropDown(names As Dictionary(Of String, String))
        For Each vv In femaleButtons
            vv.Hide()
        Next
        For i As Integer = 0 To Maximum(names.Count - 1, MaximumStudentsDisplayInDropDown)
            Dim accName = names.Keys(i)
            Dim display = names(accName)
            Dim button As Button = Nothing
            Try
                button = femaleButtons(i)
                button.Show()
            Catch ex As Exception
                button = New Button()
                femaleDisplayPanel.Controls.Add(button)
                button.Name = "female-" + i.ToString()
                Dim newX = 0
                Dim newY = -button.Height
                For yy As Integer = 0 To i
                    newY += button.Height + 1
                Next
                button.Location = New Point(newX, newY)
                button.Width = txtQueryFemale.Width - 15
                femaleButtons.Insert(i, button)
                AddHandler button.Click, AddressOf UserSelectedWinner
            End Try
            button.Text = display
            button.Tag = accName
            If button.Tag.ToString().ToLower() = Environment.UserName.ToLower() Then
                button.Enabled = False
                button.Text += " (you)"
            Else
                button.Enabled = True ' otherwise it remains disabled
            End If
        Next
    End Sub

    Private Sub SetMaleDropDown(names As Dictionary(Of String, String))
        For Each vv In maleButtons
            vv.Hide()
        Next
        For i As Integer = 0 To Maximum(names.Count - 1, MaximumStudentsDisplayInDropDown)
            Dim accName = names.Keys(i)
            Dim display = names(accName)
            Dim button As Button = Nothing
            Try
                button = maleButtons(i)
                button.Show()
            Catch ex As Exception
                button = New Button()
                maleDisplayPanel.Controls.Add(button)
                button.Name = "male-" + i.ToString()
                Dim newX = 0
                Dim newY = -button.Height
                For yy As Integer = 0 To i
                    newY += button.Height + 1
                Next
                button.Location = New Point(newX, newY)
                button.Width = txtQueryMale.Width - 15
                maleButtons.Insert(i, button)
                AddHandler button.Click, AddressOf UserSelectedWinner
            End Try
            button.Text = display
            button.Tag = accName
            If button.Tag = Environment.UserName Then
                button.Enabled = False
                button.Text += " (you)"
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

    Private femaleButtons As New List(Of Button)
    Private maleButtons As New List(Of Button)

    Private Sub UserSelectedWinner(sender As Object, e As EventArgs)
        Dim btnClicked = DirectCast(sender, Button)
        Dim sex = btnClicked.Name.Split("-")(0)
        Dim accName = DirectCast(btnClicked.Tag, String)
        lastQuery = "ssssssssssssssssssssssssssssssss" ' so it doesnt query again
        If sex = "female" Then
            CurrentCategory.FemaleWinner = accName
            txtQueryFemale.Text = CurrentCategory.FemaleDisplay
            femaleDisplayPanel.Hide()
        Else
            CurrentCategory.MaleWinner = accName
            txtQueryMale.Text = CurrentCategory.MaleDisplay
            maleDisplayPanel.Hide()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        PreviousClicked = False
        If CurrentCategory.ID + 1 > NumberOfCategories Then
            ' end.. me..
            second_panel_prompt.Visible = True
            btnStart.Text = ".."
            btnStart.Visible = False
            lblOpeningMessage.Text = "Your submission is currently being looked at, please wait.."
            DataGridView1.Rows.Clear()
            For Each category In Categories
                Dim row() As String = {category.Value.Prompt, category.Value.MaleDisplay, category.Value.FemaleDisplay}
                DataGridView1.Rows.Add(row)
            Next
            finalPromptPanel.Location = New Point(0, 0)
            Dim pSize = New Size(Me.Width, Me.Height - 25)
            finalPromptPanel.Size = pSize
            finalPromptPanel.Dock = DockStyle.Fill
            finalPromptPanel.BringToFront()
            finalPromptPanel.Visible = True
            If Me.InvokeRequired Then
                Me.Invoke(Sub()
                              Dim response = InputBox("Please type a category you think should be added" + vbCrLf + "Or some other category-related change.", "Category Altrication", "TYPE HERE")
                              Send("QUES:" + response)
                          End Sub)
            Else
                Dim response = InputBox("Please type a category you think should be added" + vbCrLf + "Or some other category-related change.", "Category Altrication", "TYPE HERE")
                Send("QUES:" + response)
            End If
        Else
            If CurrentCategory.MaleWinner = "" Then
                If MsgBox("Warning: you have not selected a male winner (you need to search then click their button)" + vbCrLf + vbCrLf + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Missing Name") = vbNo Then
                    Return
                End If
            Else
                If Not MaleCache.ContainsKey(CurrentCategory.MaleWinner) Then
                    MaleCache.Add(CurrentCategory.MaleWinner, Students(CurrentCategory.MaleWinner))
                End If
            End If
            If CurrentCategory.FemaleWinner = "" Then
                If MsgBox("Warning: you have not selected a female winner (you need to search then click their button)" + vbCrLf + vbCrLf + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Missing Name") = vbNo Then
                    Return
                End If
            Else
                If Not FemaleCache.ContainsKey(CurrentCategory.FemaleWinner) Then
                    FemaleCache.Add(CurrentCategory.FemaleWinner, Students(CurrentCategory.FemaleWinner))
                End If
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
            txtQueryFemale.Text = ""
            txtQueryMale.Text = ""
            RefreshCategoryUI()
            btnNext.Text = If(nextCat.ID = NumberOfCategories, "Finish", "Next")


            ' Show cache of males/females.

            Dim males As New Dictionary(Of String, String) 'name: display
            For Each st In MaleCache
                males.Add(st.Key, st.Value.ToString("FN LN (TT)"))
            Next

            Dim females As New Dictionary(Of String, String) 'name: display
            For Each st In FemaleCache
                females.Add(st.Key, st.Value.ToString("FN LN (TT)"))
            Next
            If males.Count > 0 Then
                maleDisplayPanel.Show()
                SetMaleDropDown(males)
            End If
            If females.Count > 0 Then
                femaleDisplayPanel.Show()
                SetFemaleDropDown(females)
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
            txtQueryFemale.Text = ""
            txtQueryMale.Text = ""
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

    Private Sub DisableDueToQuery(isMale As Boolean)
        txtQueryFemale.ReadOnly = True
        txtQueryMale.ReadOnly = True
        lblQueryFemale.Visible = Not isMale
        lblQueryMale.Visible = isMale
        maleDisplayPanel.Visible = isMale
        femaleDisplayPanel.Visible = Not isMale
    End Sub

    ''' <summary>
    ''' Returns true if the query is for a male student
    ''' 
    ''' Note: this will return even if there is no query, but it will return False.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property QueryIsMale As Boolean
        Get
            Return lblQueryMale.Visible
        End Get
    End Property

    Private lastQuery As String = ""

    Private Sub txtQueryMale_TextChanged(sender As Object, e As EventArgs) Handles txtQueryMale.TextChanged
        If txtQueryMale.Text.Length >= LettersBeforeQuery AndAlso txtQueryMale.Text.Contains(")") = False Then
            ' query it.
            If txtQueryMale.Text.StartsWith(lastQuery) Then
                If txtQueryMale.TextLength < lastQuery.Length + 2 Then
                    Return ' must enter a few more characters prior.
                End If
            End If
            CurrentCategory.MaleWinner = ""
            DisableDueToQuery(True)
            Send("QUERY:M:" + txtQueryMale.Text)
            lastQuery = txtQueryMale.Text
        End If
    End Sub

    Private Sub txtQueryFemale_TextChanged(sender As Object, e As EventArgs) Handles txtQueryFemale.TextChanged
        If txtQueryFemale.Text.Length >= LettersBeforeQuery AndAlso txtQueryFemale.Text.Contains(")") = False Then
            ' query it.
            If txtQueryFemale.Text.StartsWith(lastQuery) Then
                If txtQueryFemale.TextLength < lastQuery.Length + 2 Then
                    Return ' must enter a few more characters prior.
                End If
            End If
            CurrentCategory.FemaleWinner = ""
            DisableDueToQuery(False)
            Send("QUERY:F:" + txtQueryFemale.Text)
            lastQuery = txtQueryFemale.Text
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
            msg += category.Value.MaleWinner + ";" + category.Value.FemaleWinner + "#"
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


End Class
