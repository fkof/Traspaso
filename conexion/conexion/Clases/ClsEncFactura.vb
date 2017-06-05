<Serializable()> Public Class ClsEncFactura
    Private _IdAccess As Integer
    Private _Referencia As String
    Private _Consec As Integer
    Private _NoFac As String
    Private _FechaFac As Date
    Private _Incoterm As String
    Private _ValDlls As String
    Private _ValExtr As String
    Private _CveProv As String
    Private _EquDlls As Integer
    Private _MonFac As String
    Private _ObsCove As String
    Private _NoFac2 As String
    Private _Num_Rem As Integer
    Private _PES_BRUT As String
    Private _CAN_BULT As String
    Private _DAT_VEHI As String
    Private _CONTENEDOR As String



    Public Property CONTENEDOR() As String
        Get
            Return _CONTENEDOR
        End Get
        Set(ByVal value As String)
            _CONTENEDOR = value
        End Set
    End Property

    Public Property DAT_VEHI() As String
        Get
            Return _DAT_VEHI
        End Get
        Set(ByVal value As String)
            _DAT_VEHI = value
        End Set
    End Property

    Public Property CAN_BULT() As String
        Get
            Return _CAN_BULT
        End Get
        Set(ByVal value As String)
            _CAN_BULT = value
        End Set
    End Property

    Public Property PES_BRUT() As String
        Get
            Return _PES_BRUT
        End Get
        Set(ByVal value As String)
            _PES_BRUT = value
        End Set
    End Property
    Public Property Num_Rem() As Integer
        Get
            Return _Num_Rem
        End Get
        Set(ByVal value As Integer)
            _Num_Rem = value
        End Set
    End Property
    Public Property IdAccess() As Integer
        Get
            Return _IdAccess
        End Get
        Set(ByVal value As Integer)
            _IdAccess = value
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
    Public Property Consec() As Integer
        Get
            Return _Consec
        End Get
        Set(ByVal value As Integer)
            _Consec = value
        End Set
    End Property
    Public Property NoFac() As String
        Get
            Return _NoFac
        End Get
        Set(ByVal value As String)
            _NoFac = value
        End Set
    End Property
    Public Property FechaFac() As Date
        Get
            Return _FechaFac
        End Get
        Set(ByVal value As Date)
            _FechaFac = value
        End Set
    End Property
    Public Property Incoterm() As String
        Get
            Return _Incoterm
        End Get
        Set(ByVal value As String)
            _Incoterm = value
        End Set
    End Property
    Public Property ValDlls() As String
        Get
            Return _ValDlls
        End Get
        Set(ByVal value As String)
            _ValDlls = value
        End Set
    End Property
    Public Property ValExtr() As String
        Get
            Return _ValExtr
        End Get
        Set(ByVal value As String)
            _ValExtr = value
        End Set
    End Property
    Public Property CveProv() As String
        Get
            Return _CveProv
        End Get
        Set(ByVal value As String)
            _CveProv = value
        End Set
    End Property
    Public Property EquDlls() As Integer
        Get
            Return _EquDlls
        End Get
        Set(ByVal value As Integer)
            _EquDlls = value
        End Set
    End Property
    Public Property MonFac() As String
        Get
            Return _MonFac
        End Get
        Set(ByVal value As String)
            _MonFac = value
        End Set
    End Property
    Public Property ObsCove() As String
        Get
            Return _ObsCove
        End Get
        Set(ByVal value As String)
            _ObsCove = value
        End Set
    End Property
    Public Property NoFac2() As String
        Get
            Return _NoFac2
        End Get
        Set(ByVal value As String)
            _NoFac2 = value
        End Set
    End Property
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
    Function creafactura(ByVal objEnfact As ClsEncFactura) As Boolean
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
    Function creafacturarem(ByVal objEnfact As ClsEncFactura) As Boolean
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