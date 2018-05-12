Imports System
Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Text
Imports System.Web.Http
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CVAndVacancyBase

<TestClass()> Public Class ValuesControllerTest
    <TestMethod()> Public Sub GetValues()
        'Упорядочение
        Dim controller As New ValuesController()

        'Действие
        Dim result As IEnumerable(Of String) = controller.GetValues()

        'Утверждение
        Assert.IsNotNull(result)
        Assert.AreEqual(2, result.Count())
        Assert.AreEqual("value1", result.ElementAt(0))
        Assert.AreEqual("value2", result.ElementAt(1))
    End Sub

    <TestMethod()> Public Sub GetValueById()
        'Упорядочение
        Dim controller As New ValuesController()

        'Действие
        Dim result As String = controller.GetValue(5)

        'Утверждение
        Assert.AreEqual("value", result)
    End Sub

    <TestMethod()> Public Sub PostValue()
        'Упорядочение
        Dim controller As New ValuesController()

        'Действие
        controller.PostValue("value")

        'Утверждение
    End Sub

    <TestMethod()> Public Sub PutValue()
        'Упорядочение
        Dim controller As New ValuesController()

        'Действие
        controller.PutValue(5, "value")

        'Утверждение
    End Sub

    <TestMethod()> Public Sub DeleteValue()
        'Упорядочение
        Dim controller As New ValuesController()

        'Действие
        controller.DeleteValue(5)

        'Утверждение
    End Sub
End Class
