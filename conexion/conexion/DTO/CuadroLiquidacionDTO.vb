Public Class CuadroLiquidacionDTO

    Private _ValAsegurado As String
    Private _Regalias As String
    Private _Bultos As Integer
    Private _NumVehiculo As String
    Private _TipoVehiculo As Integer
    Private _FechaPago As String
    Private _Rectificado As Boolean
    Private _NoPediRectificado As String
    Private _Rectificador As Boolean
    Private _PedimentoOriginal As String
    Private _DTA As Decimal
    Private _IGIOIGE As Decimal
    Private _IVA As Decimal
    Private _CC As Decimal
    Private _IEPS As Decimal
    Private _Seguros As Decimal
    Private _Embalajes As Decimal
    Private _Otros As Decimal
    Private _Fletes As Decimal
    Private _Regimen As String
    Private _PesoBruto As Decimal
    Private _Consolidado As Boolean

    Public Property valAsegurado As String
        Get
            Return _ValAsegurado
        End Get
        Set(ByVal value As String)
            If _ValAsegurado = value Then
                Return
            End If
            _ValAsegurado = value
        End Set
    End Property

    Public Property Regalias As String
        Get
            Return _Regalias
        End Get
        Set(value As String)
            _Regalias = value
        End Set
    End Property

    Public Property Bultos As Integer
        Get
            Return _Bultos
        End Get
        Set(value As Integer)
            _Bultos = value
        End Set
    End Property

    Public Property NumVehiculo As String
        Get
            Return _NumVehiculo
        End Get
        Set(value As String)
            _NumVehiculo = value
        End Set
    End Property

    Public Property TipoVehiculo As Integer
        Get
            Return _TipoVehiculo
        End Get
        Set(value As Integer)
            _TipoVehiculo = value
        End Set
    End Property

    Public Property FechaPago As String
        Get
            Return _FechaPago
        End Get
        Set(value As String)
            _FechaPago = value
        End Set
    End Property

    Public Property Rectificado As Boolean
        Get
            Return _Rectificado
        End Get
        Set(value As Boolean)
            _Rectificado = value
        End Set
    End Property

    Public Property NoPediRectificado As String
        Get
            Return _NoPediRectificado
        End Get
        Set(value As String)
            _NoPediRectificado = value
        End Set
    End Property

    Public Property Rectificador As Boolean
        Get
            Return _Rectificador
        End Get
        Set(value As Boolean)
            _Rectificador = value
        End Set
    End Property

    Public Property PedimentoOriginal As String
        Get
            Return _PedimentoOriginal
        End Get
        Set(value As String)
            _PedimentoOriginal = value
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

    Public Property IGIOIGE As Decimal
        Get
            Return _IGIOIGE
        End Get
        Set(value As Decimal)
            _IGIOIGE = value
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

    Public Property CC As Decimal
        Get
            Return _CC
        End Get
        Set(value As Decimal)
            _CC = value
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

    Public Property Embalajes As Decimal
        Get
            Return _Embalajes
        End Get
        Set(value As Decimal)
            _Embalajes = value
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

    Public Property Fletes As Decimal
        Get
            Return _Fletes
        End Get
        Set(value As Decimal)
            _Fletes = value
        End Set
    End Property

    Public Property Regimen As String
        Get
            Return _Regimen
        End Get
        Set(value As String)
            _Regimen = value
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

    Public Property Consolidado As Boolean
        Get
            Return _Consolidado
        End Get
        Set(value As Boolean)
            _Consolidado = value
        End Set
    End Property
End Class
