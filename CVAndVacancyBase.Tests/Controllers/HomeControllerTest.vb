Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CVAndVacancyBase

<TestClass()> Public Class HomeControllerTest
    <TestMethod()> Public Sub Index()
        'Упорядочение
        Dim controller As New HomeController()

        'Действие
        Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

        'Утверждение
        Assert.IsNotNull(result)
        Dim viewData As ViewDataDictionary = result.ViewData
        Assert.AreEqual("Home Page", viewData("Title"))
    End Sub
End Class
