Imports System.ComponentModel

Public Class DebugForm
    Public syncContext As WindowsFormsSynchronizationContext
    Private obj As Object = New Object()
    Private Shared _log As String = ""
    Private Sub UpdateStatus(ByVal State As Object)
        _log += $"{DateTime.Now.ToString("hh:mm:ss.fff")}: " + CType(State, String) + vbCrLf
    End Sub
    Public Sub Log(message As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() Log(message))
            Return
        End If
        SyncLock obj
            _log += $"{DateTime.Now.ToString("hh:mm:ss.fff")}: " + CType(message, String) + vbCrLf
        End SyncLock

        'syncContext = AsyncOperationManager.SynchronizationContext()
        'syncContext.Post(New Threading.SendOrPostCallback(AddressOf UpdateStatus), message)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SyncLock obj
            RichTextBox1.Text = _log
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
        End SyncLock
    End Sub

    Private Sub DebugForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If DEBUG Then
#Else
        Me.Close()
#End If
    End Sub
End Class