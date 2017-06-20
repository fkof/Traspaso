Public Class CuadroDeLiquidaion
    Dim objPedimento As New ClsPedimento


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim parameters As New paramsseahr
        parameters.Referencia = txtReferencia.Text
        parameters.Parametro2 = txtReferencia.Text
        dgvCuadro.DataSource = objPedimento.getCuadroLiquidacion(parameters)
    End Sub

    Private Sub CuadroDeLiquidaion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
<Serializable()> Public Class paramsseahr
    Private _Referencia As String


    Public Property Referencia As String
        Get
            Return _Referencia
        End Get
        Set(ByVal value As String)
            If _Referencia = value Then
                Return
            End If
            _Referencia = value
        End Set
    End Property

    Public Property Parametro2 As String
End Class