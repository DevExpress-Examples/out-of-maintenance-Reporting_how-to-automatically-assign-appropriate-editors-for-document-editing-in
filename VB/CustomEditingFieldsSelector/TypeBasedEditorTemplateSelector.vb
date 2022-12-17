Imports DevExpress.Xpf.Printing
Imports DevExpress.XtraPrinting
Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Markup

Namespace CustomEditingFieldsSelector

    Public Class TypeBasedEditorTemplateSelector
        Inherits EditingFieldTemplateSelector

        Public Property Int32Template As DataTemplate

        Public Property DateTimeTemplate As DataTemplate

        Public Property EnumTemplate As DataTemplate

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim field = TryCast(item, EditingField)
            If field.EditValue IsNot Nothing AndAlso TypeOf field.EditValue Is [Enum] Then
                Return EnumTemplate
            ElseIf TypeOf field.EditValue Is Date Then
                Return DateTimeTemplate
            ElseIf TypeOf field.EditValue Is Integer Then
                Return Int32Template
            End If

            Return MyBase.SelectTemplate(item, container)
        End Function
    End Class

    Public Class EnumValueToEnumSourceConverter
        Inherits MarkupExtension
        Implements IValueConverter

        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function

        Private Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            If Not(TypeOf value Is [Enum]) Then Throw New InvalidOperationException()
            Return [Enum].GetValues(value.GetType())
        End Function

        Private Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotSupportedException()
        End Function
    End Class
End Namespace
