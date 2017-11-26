Public Class ClsFacturaPartidas
    Function creapartida(ByVal objpart As PartidasDTO) As Boolean
        Dim objpro As New ClsProcesos
        Dim consulta As String = "INSERT INTO SAAIO_FACPAR (NUM_REFE , CONS_FACT , CONS_PART , NUM_PART , PAI_ORIG, PAI_VEND, FRACCION,CAS_TLCS,COM_TLC,ADVAL,MON_FACT,TIP_MONE,PES_UNIT,CAN_FACT,UNI_FACT,CAN_TARI,UNI_TARI,DES_MERC,VAL_AGRE,VAL_UNIT,PORC_IVA,CVE_VALO,CVE_VINC,CANT_COVE,UNI_COVE) " &
                                    " VALUES ('" & objpart.Referencia & "'," & objpart.consecutivoFactura & "," & objpart.consecutivo & ",'" & objpart.NoPart & "','" & objpart.PO & "','" & objpart.PV & "','" & objpart.Fraccion & "','" & objpart.Cas_TLCS & "','" & objpart.COM_TLC & "'," & objpart.Adval & "," & objpart.Total & ",'" & objpart.Modena & "'," & objpart.PesoUni & "," & objpart.CantFactur & ",'" & objpart.UMC & "'," & objpart.CantTar & ",'" & objpart.UMT & "','" & objpart.Descripcion & "'," & objpart.ValAgre & "," & objpart.PrecioUnitario & "," & objpart.PorcIVA & ",'" & objpart.ValorComer & "','" & objpart.VIN & "'," & objpart.CantCove & ",'" & objpart.UnidadCove & "')"
        'AQUI VA LA VINCULACION
        If objpro.ejecutaQuery(consulta) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class