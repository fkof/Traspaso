Public Class CuadroLiquidacionDTO

    'Private _ValAsegurado As String
    'Private _Bultos As Integer
    'Private _NumVehiculo As String
    'Private _TipoVehiculo As Integer
    'Private _FechaPago As String
    'Private _Rectificado As Boolean
    'Private _NoPediRectificado As String
    'Private _Rectificador As Boolean
    'Private _PedimentoOriginal As String

    'Private _Seguros As Decimal
    'Private _Embalajes As Decimal

    'Private _Fletes As Decimal
    'Private _Regimen As String
    'Private _PesoBruto As Decimal
    'Private _Consolidado As Boolean

    Private _ValorDolaresAduanaPed As Decimal
    Private _ValorDolaresComercialPed As Decimal
    Private _ValorAduanaPesoPed As Decimal
    Private _ValorComercialPesosPed As Decimal
    Private _Regalias As Decimal
    Private _Otros As Decimal
    Private _DTA As Decimal
    Private _FPDTA As Decimal
    Private _IGIOIGE As Decimal
    Private _FPIGIOIGE As Decimal
    Private _IVA As Decimal
    Private _FPIVA As Decimal
    Private _CC As Decimal
    Private _FPCC As Decimal
    Private _IEPS As Decimal
    Private _FPIEPS As Decimal
    Private _PREVALIDACION As Decimal
    Private _FPPREVALIDACION As Decimal
    Private _Embalaje As Decimal
    Private _Seguro As Decimal
    Private _Fletes As Decimal
    Private _PesoBruto As Decimal

    Public Property ValorDolaresAduanaPed As Decimal
        Get
            Return _ValorDolaresAduanaPed
        End Get
        Set(value As Decimal)
            _ValorDolaresAduanaPed = value
        End Set
    End Property

    Public Property ValorDolaresComercialPed As Decimal
        Get
            Return _ValorDolaresComercialPed
        End Get
        Set(value As Decimal)
            _ValorDolaresComercialPed = value
        End Set
    End Property

    Public Property ValorAduanaPesoPed As Decimal
        Get
            Return _ValorAduanaPesoPed
        End Get
        Set(value As Decimal)
            _ValorAduanaPesoPed = value
        End Set
    End Property

    Public Property ValorComercialPesosPed As Decimal
        Get
            Return _ValorComercialPesosPed
        End Get
        Set(value As Decimal)
            _ValorComercialPesosPed = value
        End Set
    End Property

    Public Property Regalias As Decimal
        Get
            Return _Regalias
        End Get
        Set(value As Decimal)
            _Regalias = value
        End Set
    End Property

    Public Property Otros As Decimal
        Get
            Return _Otros
        End Get
        Set(value As Decimal)
            _Otros = value
        End Set
    End Property

    Public Property DTA As Decimal
        Get
            Return _DTA
        End Get
        Set(value As Decimal)
            _DTA = value
        End Set
    End Property

    Public Property FPDTA As Decimal
        Get
            Return _FPDTA
        End Get
        Set(value As Decimal)
            _FPDTA = value
        End Set
    End Property

    Public Property IGIOIGE As Decimal
        Get
            Return _IGIOIGE
        End Get
        Set(value As Decimal)
            _IGIOIGE = value
        End Set
    End Property

    Public Property FPIGIOIGE As Decimal
        Get
            Return _FPIGIOIGE
        End Get
        Set(value As Decimal)
            _FPIGIOIGE = value
        End Set
    End Property

    Public Property IVA As Decimal
        Get
            Return _IVA
        End Get
        Set(value As Decimal)
            _IVA = value
        End Set
    End Property

    Public Property FPIVA As Decimal
        Get
            Return _FPIVA
        End Get
        Set(value As Decimal)
            _FPIVA = value
        End Set
    End Property

    Public Property CC As Decimal
        Get
            Return _CC
        End Get
        Set(value As Decimal)
            _CC = value
        End Set
    End Property

    Public Property FPCC As Decimal
        Get
            Return _FPCC
        End Get
        Set(value As Decimal)
            _FPCC = value
        End Set
    End Property

    Public Property IEPS As Decimal
        Get
            Return _IEPS
        End Get
        Set(value As Decimal)
            _IEPS = value
        End Set
    End Property

    Public Property FPIEPS As Decimal
        Get
            Return _FPIEPS
        End Get
        Set(value As Decimal)
            _FPIEPS = value
        End Set
    End Property

    Public Property PREVALIDACION As Decimal
        Get
            Return _PREVALIDACION
        End Get
        Set(value As Decimal)
            _PREVALIDACION = value
        End Set
    End Property

    Public Property FPPREVALIDACION As Decimal
        Get
            Return _FPPREVALIDACION
        End Get
        Set(value As Decimal)
            _FPPREVALIDACION = value
        End Set
    End Property

    Public Property PesoBruto As Decimal
        Get
            Return _PesoBruto
        End Get
        Set(value As Decimal)
            _PesoBruto = value
        End Set
    End Property

    Public Property Embalaje As Decimal
        Get
            Return _Embalaje
        End Get
        Set(value As Decimal)
            _Embalaje = value
        End Set
    End Property

    Public Property Seguro As Decimal
        Get
            Return _Seguro
        End Get
        Set(value As Decimal)
            _Seguro = value
        End Set
    End Property

    Public Property Fletes As Decimal
        Get
            Return _Fletes
        End Get
        Set(value As Decimal)
            _Fletes = value
        End Set
    End Property
End Class
