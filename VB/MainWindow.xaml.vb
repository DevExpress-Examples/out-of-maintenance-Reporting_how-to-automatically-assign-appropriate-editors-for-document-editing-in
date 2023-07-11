Imports System.Windows

Namespace CustomEditingFieldsSelector

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.preview.DocumentSource = New XtraReport1()
        End Sub
    End Class
End Namespace
