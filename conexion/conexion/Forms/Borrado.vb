Imports System.Windows.Forms

Public Class Borrado
    Dim objProc As New ClsProcesos
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger("Borrado.vb")
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click




        borrar(txtreferencia.Text)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub borrar(ByVal referencia)

        Dim CONSULTA As String = String.Format("delete  From CTRAO_EMBAR Where NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA)
        CONSULTA = String.Format("delete  From saaio_factur  Where NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA)
        CONSULTA = String.Format("delete  From SAAIO_FACPAR  Where NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA) '  SAAIO_COVESER()
        CONSULTA = String.Format("delete  From SAAIO_COVESER  Where NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA)
        CONSULTA = String.Format("delete  From SAAIO_PEDIME  Where NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA)
        CONSULTA = String.Format("delete  From SAAIO_INCREM  Where NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA) 'SAAIO_FACPAR
        CONSULTA = String.Format("delete  From SAAIO_idePAR  Where NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA) 'SAAIO_FACPAR
        CONSULTA = String.Format("DELETE FROM SAAIO_CONTEN WHERE NUM_REFE='{0}'", txtreferencia.Text)
        objProc.ejecutaQuery(CONSULTA) 'SAAIO_FACPAR
        MsgBox("BORRADO")


        log.Info("Referencia Borrada")

    End Sub
End Class
