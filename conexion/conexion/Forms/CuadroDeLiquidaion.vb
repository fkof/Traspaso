Public Class CuadroDeLiquidaion
    Dim objPedimento As New ClsPedimento


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim algo As New paramsseahr
        algo.Parametro1 = "sa"
        algo.Parametro2 = "sas"
        objPedimento.getCuadroLiquidacion(algo)
    End Sub
End Class
Public Class paramsseahr
    Public Property Parametro1 As String
        Get
            Return Parametro1
        End Get
        Set(value As String)

        End Set
    End Property

    Public Property Parametro2 As String
End Class