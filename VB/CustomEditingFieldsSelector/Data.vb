Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace CustomEditingFieldsSelector
    Public Class CustomData
        Public Property Items() As ItemList
        Public Sub New()
            Items = New ItemList()
        End Sub
    End Class
    Public Class ItemList
        Inherits List(Of Item)

        Public Sub New()
            For i As Integer = 0 To 2
                Add(New Item() With { _
                    .Int32Property = i, _
                    .DateTimeProperty = Date.Now.AddDays(-i), _
                    .EnumProperty = CType(i, CustomEnum) _
                })
            Next i
        End Sub
    End Class

    Public Class Item
        Public Property Int32Property() As Integer
        Public Property DateTimeProperty() As Date
        Public Property EnumProperty() As CustomEnum
    End Class

    Public Enum CustomEnum
        Value1 = 0
        Value2 = 1
        Value3 = 2
    End Enum
End Namespace
