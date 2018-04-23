Imports System.Windows

Namespace CustomEditingFieldsSelector
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            preview.DocumentSource = New XtraReport1()
        End Sub
    End Class
End Namespace
