<Serializable()> Public Class ClsFacturaPartidas
    Private _IdPacc As Integer
    Private _Referencia As String
    Private _consecutivoFactura As Integer
    Private _consecutivo As Integer
    Private _NoPart As String
    Private _PO As String
    Private _PV As String
    Private _Fraccion As String
    Private _Cas_TLCS As String
    Private _COM_TLC As String
    Private _Adval As Integer
    Private _Total As String
    Private _Moneda As String
    Private _PesoUni As String
    Private _CantFactur As String
    Private _UMC As String
    Private _CantTar As String
    Private _UMT As String
    Private _Descripcion As String
    Private _ValAgre As Integer
    Private _PrecioUnitario As String
    Private _PorcIVA As String
    Private _ValorComer As String
    Private _usuarioc As String
    Private _CantCove As String
    Private _UnidadCove As String
    Private _Serie As String
    Private _Marca As String
    Private _Modelo As String
    Private _VIN As String

    Public Property VIN() As String
        Get
            Return _VIN
        End Get
        Set(ByVal value As String)
            _VIN = value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal value As String)
            _Serie = value
        End Set
    End Property
    Public Property Marca() As String
        Get
            Return _Marca
        End Get
        Set(ByVal value As String)
            _Marca = value
        End Set
    End Property
    Public Property Modelo() As String
        Get
            Return _Modelo
        End Get
        Set(ByVal value As String)
            _Modelo = value
        End Set
    End Property

    Public Property IdPacc() As Integer
        Get
            Return _IdPacc
        End Get
        Set(ByVal value As Integer)
            _IdPacc = value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal value As String)
            _Referencia = value
        End Set
    End Property
    Public Property consecutivoFactura() As Integer
        Get
            Return _consecutivoFactura
        End Get
        Set(ByVal value As Integer)
            _consecutivoFactura = value
        End Set
    End Property
    Public Property consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
        End Set
    End Property
    Public Property NoPart() As String
        Get
            Return _NoPart
        End Get
        Set(ByVal value As String)
            _NoPart = value
        End Set
    End Property
    Public Property PO() As String
        Get
            Return _PO
        End Get
        Set(ByVal value As String)
            _PO = value
        End Set
    End Property
    Public Property PV() As String
        Get
            Return _PV
        End Get
        Set(ByVal value As String)
            _PV = value
        End Set
    End Property
    Public Property Fraccion() As String
        Get
            Return _Fraccion
        End Get
        Set(ByVal value As String)
            _Fraccion = value
        End Set
    End Property
    Public Property Cas_TLCS() As String
        Get
            Return _Cas_TLCS
        End Get
        Set(ByVal value As String)
            _Cas_TLCS = value
        End Set
    End Property
    Public Property COM_TLC() As String
        Get
            Return _COM_TLC
        End Get
        Set(ByVal value As String)
            _COM_TLC = value
        End Set
    End Property
    Public Property Adval() As Integer
        Get
            Return _Adval
        End Get
        Set(ByVal value As Integer)
            _Adval = value
        End Set
    End Property
    Public Property Total() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
        End Set
    End Property
    Public Property Modena() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property
    Public Property PesoUni() As String
        Get
            Return _PesoUni
        End Get
        Set(ByVal value As String)
            _PesoUni = value
        End Set
    End Property
    Public Property CantFactur() As String
        Get
            Return _CantFactur
        End Get
        Set(ByVal value As String)
            _CantFactur = value
        End Set
    End Property
    Public Property UMC() As String
        Get
            Return _UMC
        End Get
        Set(ByVal value As String)
            _UMC = value
        End Set
    End Property
    Public Property CantTar() As String
        Get
            Return _CantTar
        End Get
        Set(ByVal value As String)
            _CantTar = value
        End Set
    End Property
    Public Property UMT() As String
        Get
            Return _UMT
        End Get
        Set(ByVal value As String)
            _UMT = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property ValAgre() As Integer
        Get
            Return _ValAgre
        End Get
        Set(ByVal value As Integer)
            _ValAgre = value
        End Set
    End Property
    Public Property PrecioUnitario() As String
        Get
            Return _PrecioUnitario
        End Get
        Set(ByVal value As String)
            _PrecioUnitario = value
        End Set
    End Property
    Public Property PorcIVA() As String
        Get
            Return _PorcIVA
        End Get
        Set(ByVal value As String)
            _PorcIVA = value
        End Set
    End Property
    Public Property ValorComer() As String
        Get
            Return _ValorComer
        End Get
        Set(ByVal value As String)
            _ValorComer = value
        End Set
    End Property
    Public Property usuarioc() As String
        Get
            Return _usuarioc
        End Get
        Set(ByVal value As String)
            _usuarioc = value
        End Set
    End Property
    Public Property CantCove() As String
        Get
            Return _CantCove
        End Get
        Set(ByVal value As String)
            _CantCove = value
        End Set
    End Property
    Public Property UnidadCove() As String
        Get
            Return _UnidadCove
        End Get
        Set(ByVal value As String)
            _UnidadCove = value
        End Set
    End Property

    Function creapartida(ByVal objpart As ClsFacturaPartidas) As Boolean
        Dim objpro As New ClsProcesos
        Dim consulta As String = "INSERT INTO SAAIO_FACPAR (NUM_REFE , CONS_FACT , CONS_PART , NUM_PART , PAI_ORIG, PAI_VEND, FRACCION,CAS_TLCS,COM_TLC,ADVAL,MON_FACT,TIP_MONE,PES_UNIT,CAN_FACT,UNI_FACT,CAN_TARI,UNI_TARI,DES_MERC,VAL_AGRE,VAL_UNIT,PORC_IVA,CVE_VALO,CVE_VINC,CANT_COVE,UNI_COVE) " & _
                                    " VALUES ('" & objpart.Referencia & "'," & objpart.consecutivoFactura & "," & objpart.consecutivo & ",'" & objpart.NoPart & "','" & objpart.PO & "','" & objpart.PV & "','" & objpart.Fraccion & "','" & objpart.Cas_TLCS & "','" & objpart.COM_TLC & "'," & objpart.Adval & "," & objpart.Total & ",'" & objpart.Modena & "'," & objpart.PesoUni & "," & objpart.CantFactur & ",'" & objpart.UMC & "'," & objpart.CantTar & ",'" & objpart.UMT & "','" & objpart.Descripcion & "'," & objpart.ValAgre & "," & objpart.PrecioUnitario & "," & objpart.PorcIVA & ",'" & objpart._ValorComer & "','" & objpart.VIN & "'," & objpart.CantCove & ",'" & objpart.UnidadCove & "')"
        'AQUI VA LA VINCULACION
        If objpro.ejecutaQuery(consulta) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class