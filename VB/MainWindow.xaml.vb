Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.RichEdit

Namespace RichEditBindCommandsToStandardControlsWpf

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class CustomRichEditUICommand
        Implements ICommand

        Private Shared ReadOnly myCommandField As CustomRichEditUICommand = New CustomRichEditUICommand("MyCommand")

        Public Shared ReadOnly Property MyCommand As CustomRichEditUICommand
            Get
                Return myCommandField
            End Get
        End Property

        Private ReadOnly commandName As String

        Public Sub New()
        End Sub

        Protected Friend Sub New(ByVal commandName As String)
            Me.commandName = commandName
        End Sub

'#Region "ICommand Members"
        Public Custom Event CanExecuteChanged As System.EventHandler Implements ICommand.CanExecuteChanged
            AddHandler(ByVal value As System.EventHandler)
            End AddHandler

            RemoveHandler(ByVal value As System.EventHandler)
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            End RaiseEvent
        End Event

        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
            If Not Equals(commandName, "MyCommand") Then Throw New System.ApplicationException("Unknown command")
            Call MessageBox.Show("Custom command is executed" & Microsoft.VisualBasic.Constants.vbCrLf & "RichEditControl.Text: " & CType(parameter, RichEditControl).Text, "MyCommand")
        End Sub
'#End Region
    End Class
End Namespace
