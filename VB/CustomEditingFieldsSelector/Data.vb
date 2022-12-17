Imports System.Collections.Generic

Namespace CustomEditingFieldsSelector

    Public Class CustomData

        Public Property Items As ItemList

        Public Sub New()
            Items = New ItemList()
        End Sub
    End Class

    Public Class ItemList
        Inherits List(Of Item)

        Public Sub New()
            For i As Integer = 0 To 3 - 1
                Add(New Item() With {.Int32Property = i, .DateTimeProperty = Date.Now.AddDays(-i), .EnumProperty = CType(i, CustomEnum)})
            Next
        End Sub
    End Class

    Public Class Item

        Public Property Int32Property As Integer

        Public Property DateTimeProperty As Date

        Public Property EnumProperty As CustomEnum
    End Class

    Public Enum CustomEnum
        Value1 = 0
        Value2 = 1
        Value3 = 2
    End Enum
End Namespace
