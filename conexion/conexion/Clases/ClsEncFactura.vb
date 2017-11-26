Public Class ClsEncFactura
    ''' <summary>
    ''' Valida la factua que no se encuentre en el casa
    ''' </summary>
    ''' <param name="Referencia">Referencia del casa</param>
    ''' <param name="proveedor">Clave del proveedor del casa</param>
    ''' <param name="NoFactura">Numero de factura</param>
    ''' <returns>si regresa un true es que NO existe la factura</returns>
    ''' <remarks></remarks>
    Function validafactura(ByVal Referencia As String, ByVal proveedor As String, ByVal NoFactura As String) As Boolean
        Dim objfb As New ClsProcesos
        Dim consulta As String = String.Format("select * from saaio_factur where num_refe='{0}' and cve_prov='{1}' and num_fact='{2}'", Referencia, proveedor, NoFactura)
        Dim dt As New DataTable
        dt = objfb.llenaDataSet(consulta, "FB")
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Crea El Registro del Encabezado de La Factura
    ''' </summary>
    ''' <param name="objEnfac">Encabezado de la Factura (objeto)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function creafactura(ByVal objEnfact As FacturaDTO) As Boolean
        Dim objfb As New ClsProcesos
        Dim consulta As String = String.Format("INSERT INTO SAAIO_FACTUR (NUM_REFE , CONS_FACT , NUM_FACT , FEC_FACT , ICO_FACT, VAL_DLLS, VAL_EXTR,CVE_PROV,EQU_DLLS,MON_FACT,NUM_FACT2,OBS_COVE )  VALUES ('{0}',{1},'{2}','{3}','{4}',{5},{6},'{7}',{8},'{9}','{10}','{11}')", objEnfact.Referencia, objEnfact.Consec, objEnfact.NoFac, String.Format("{0:yyyy/MM/dd}", objEnfact.FechaFac), objEnfact.Incoterm, objEnfact.ValDlls, objEnfact.ValExtr, objEnfact.CveProv, objEnfact.EquDlls, objEnfact.MonFac, objEnfact.NoFac2, objEnfact.ObsCove)
        If objfb.ejecutaQuery(consulta) Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Crea factura de remesas
    ''' </summary>
    ''' <param name="objEnfact"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function creafacturarem(ByVal objEnfact As FacturaDTO) As Boolean
        Dim objfb As New ClsProcesos
        Dim consulta As String = String.Format("INSERT INTO SAAIO_FACTUR (NUM_REFE , CONS_FACT , NUM_FACT , FEC_FACT , ICO_FACT, VAL_DLLS, VAL_EXTR,CVE_PROV,EQU_DLLS,MON_FACT,NUM_FACT2,OBS_COVE, NUM_REM, PES_BRUT,CAN_BULT,DAT_VEHI,NUM_CONT) VALUES ('{0}',{1},'{2}','{3}','{4}',{5},{6},'{7}',{8},'{9}','{10}','{11}',{12},{13},{14},'{15}','{16}')", objEnfact.Referencia, objEnfact.Consec, objEnfact.NoFac,
                                               String.Format("{0:yyyy/MM/dd}", objEnfact.FechaFac), objEnfact.Incoterm, objEnfact.ValDlls, objEnfact.ValExtr, objEnfact.CveProv, objEnfact.EquDlls, objEnfact.MonFac, objEnfact.NoFac2, objEnfact.ObsCove, objEnfact.Num_Rem, objEnfact.PES_BRUT, objEnfact.CAN_BULT, objEnfact.DAT_VEHI, objEnfact.CONTENEDOR)
        If objfb.ejecutaQuery(consulta) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class