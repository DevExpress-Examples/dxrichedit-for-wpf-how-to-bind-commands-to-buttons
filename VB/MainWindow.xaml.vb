Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.RichEdit

Namespace RichEditBindCommandsToStandardControlsWpf
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class CustomRichEditUICommand
		Implements ICommand

'INSTANT VB NOTE: The field myCommand was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private Shared ReadOnly myCommand_Conflict As New CustomRichEditUICommand("MyCommand")
		Public Shared ReadOnly Property MyCommand() As CustomRichEditUICommand
			Get
				Return myCommand_Conflict
			End Get
		End Property
		Private ReadOnly commandName As String

		Public Sub New()
		End Sub

		Protected Friend Sub New(ByVal commandName As String)
			Me.commandName = commandName
		End Sub

		#Region "ICommand Members"

		Public Custom Event CanExecuteChanged As System.EventHandler
			AddHandler(ByVal value As System.EventHandler)
			End AddHandler
			RemoveHandler(ByVal value As System.EventHandler)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event

		Public Function CanExecute(ByVal parameter As Object) As Boolean
			Return True
		End Function

		Public Sub Execute(ByVal parameter As Object)
			If commandName <> "MyCommand" Then
				Throw New System.ApplicationException("Unknown command")
			End If

			MessageBox.Show("Custom command is executed" & vbCrLf & "RichEditControl.Text: " & DirectCast(parameter, RichEditControl).Text, "MyCommand")
		End Sub

		#End Region
	End Class
End Namespace
