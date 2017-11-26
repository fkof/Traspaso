<Serializable()> Public Class FacturaDTO
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
End Class
