Imports System.Text

<Serializable()> Public Class ClsPedimento
#Region "Propiedades"
    Private _Referencia As String
    Private _Importador As String
    Private _Toper As Integer
    Private _Adudesp As Integer
    Private _Patente As Integer
    Private _NoPedimento As String
    Private _AduEnt As Integer
    Private _FechaEntrada As Date
    Private _TipoCambio As String
    Private _Regimen As String
    Private _DestinoOrigen As String
    Private _Bultos As String
    Private _PesoBruto As String
    Private _NVehiculo As String
    Private _Tipo_cont As String
    Private _ValDll As String
    Private _ValCome As String
    Private _TotalIncre As String
    Private _ValorNormal As String
    Private _FecAjus As Integer
    Private _CvePedimento As String
    Private _EmbCve_Capt As String
    Private _EmbApe_Refe As Date
    Private _EmbSec_Desp As String

    Private _Valseguros As String
    Private _seguro As String
    Private _embalaje As String
    Private _fletes As String
    Private _otros As String

    Private _impseguro As String
    Private _impembalaje As String
    Private _impfletes As String
    Private _impotros As String
    Private _ListIdSalida As List(Of String)

    Public Property ListIdSalida As List(Of String)
        Get
            Return _ListIdSalida
        End Get
        Set(value As List(Of String))
            _ListIdSalida = value
        End Set
    End Property


    Public Property impSeguro As String
        Get
            Return _impseguro
        End Get
        Set(ByVal value As String)
            If _impseguro = value Then
                Return
            End If
            _impseguro = value
        End Set
    End Property
    Public Property impEmbalaje As String
        Get
            Return _impembalaje
        End Get
        Set(ByVal value As String)
            If _impembalaje = value Then
                Return
            End If
            _impembalaje = value
        End Set
    End Property
    Public Property impFletes As String
        Get
            Return _impfletes
        End Get
        Set(ByVal value As String)
            If _impfletes = value Then
                Return
            End If
            _impfletes = value
        End Set
    End Property
    Public Property impOtros As String
        Get
            Return _impotros
        End Get
        Set(ByVal value As String)
            If _impotros = value Then
                Return
            End If
            _impotros = value
        End Set
    End Property

    Public Property Valseguros As String
        Get
            Return _Valseguros
        End Get
        Set(ByVal value As String)
            If _Valseguros = value Then
                Return
            End If
            _Valseguros = value
        End Set
    End Property
    Public Property Seguro As String
        Get
            Return _seguro
        End Get
        Set(ByVal value As String)
            If _seguro = value Then
                Return
            End If
            _seguro = value
        End Set
    End Property
    Public Property Embalaje As String
        Get
            Return _embalaje
        End Get
        Set(ByVal value As String)
            If _embalaje = value Then
                Return
            End If
            _embalaje = value
        End Set
    End Property
    Public Property Fletes As String
        Get
            Return _fletes
        End Get
        Set(ByVal value As String)
            If _fletes = value Then
                Return
            End If
            _fletes = value
        End Set
    End Property
    Public Property Otros As String
        Get
            Return _otros
        End Get
        Set(ByVal value As String)
            If _otros = value Then
                Return
            End If
            _otros = value
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
    Public Property Importador() As String
        Get
            Return _Importador
        End Get
        Set(ByVal value As String)
            _Importador = value
        End Set
    End Property
    Public Property Toper() As Integer
        Get
            Return _Toper
        End Get
        Set(ByVal value As Integer)
            _Toper = value
        End Set
    End Property
    Public Property Adudesp() As Integer
        Get
            Return _Adudesp
        End Get
        Set(ByVal value As Integer)
            _Adudesp = value
        End Set
    End Property
    Public Property Patente() As Integer
        Get
            Return _Patente
        End Get
        Set(ByVal value As Integer)
            _Patente = value
        End Set
    End Property
    Public Property NoPedimento() As String
        Get
            Return _NoPedimento
        End Get
        Set(ByVal value As String)
            _NoPedimento = value
        End Set
    End Property
    Public Property AduEnt() As Integer
        Get
            Return _AduEnt
        End Get
        Set(ByVal value As Integer)
            _AduEnt = value
        End Set
    End Property
    Public Property FechaEntrada() As Date
        Get
            Return _FechaEntrada
        End Get
        Set(ByVal value As Date)
            _FechaEntrada = value
        End Set
    End Property
    Public Property TipoCambio() As String
        Get
            Return _TipoCambio
        End Get
        Set(ByVal value As String)
            _TipoCambio = value
        End Set
    End Property
    Public Property Regimen() As String
        Get
            Return _Regimen
        End Get
        Set(ByVal value As String)
            _Regimen = value
        End Set
    End Property
    Public Property DestinoOrigen() As String
        Get
            Return _DestinoOrigen
        End Get
        Set(ByVal value As String)
            _DestinoOrigen = value
        End Set
    End Property
    Public Property Bultos() As String
        Get
            Return _Bultos
        End Get
        Set(ByVal value As String)
            _Bultos = value
        End Set
    End Property
    Public Property PesoBruto() As String
        Get
            Return _PesoBruto
        End Get
        Set(ByVal value As String)
            _PesoBruto = value
        End Set
    End Property
    Public Property NVehiculo() As String
        Get
            Return _NVehiculo
        End Get
        Set(ByVal value As String)
            _NVehiculo = value
        End Set
    End Property
    Public Property Tipo_cont() As String
        Get
            Return _Tipo_cont
        End Get
        Set(ByVal value As String)
            _Tipo_cont = value
        End Set
    End Property
    Public Property ValDll() As String
        Get
            Return _ValDll
        End Get
        Set(ByVal value As String)
            _ValDll = value
        End Set
    End Property
    Public Property ValCome() As String
        Get
            Return _ValCome
        End Get
        Set(ByVal value As String)
            _ValCome = value
        End Set
    End Property
    Public Property TotalIncre() As String
        Get
            Return _TotalIncre
        End Get
        Set(ByVal value As String)
            _TotalIncre = value
        End Set
    End Property
    Public Property ValorNormal() As String
        Get
            Return _ValorNormal
        End Get
        Set(ByVal value As String)
            _ValorNormal = value
        End Set
    End Property
    Public Property FecAjus() As Integer
        Get
            Return _FecAjus
        End Get
        Set(ByVal value As Integer)
            _FecAjus = value
        End Set
    End Property
    Public Property CvePedimento() As String
        Get
            Return _CvePedimento
        End Get
        Set(ByVal value As String)
            _CvePedimento = value
        End Set
    End Property
    Public Property EmbCve_Capt() As String
        Get
            Return _EmbCve_Capt
        End Get
        Set(ByVal value As String)
            _EmbCve_Capt = value
        End Set
    End Property
    Public Property EmbApe_Refe() As Date
        Get
            Return _EmbApe_Refe
        End Get
        Set(ByVal value As Date)
            _EmbApe_Refe = value
        End Set
    End Property
    Public Property EmbSec_Desp() As String
        Get
            Return _EmbSec_Desp
        End Get
        Set(ByVal value As String)
            _EmbSec_Desp = value
        End Set
    End Property
#End Region

    Function creaembarque(ByVal objpedimento As ClsPedimento) As Boolean
        Dim objfb As New ClsProcesos
        Dim consulta As String = String.Format("INSERT INTO CTRAO_EMBAR (NUM_REFE , IMP_EXPO , ADU_DESP , PAT_AGEN , CVE_PEDI, ADU_ENTR, FEC_ENTR,CVE_CAPT,CVE_IMPO,APE_REFE,SEC_DESP,IMP_FLET,IMP_SEGU,IMP_EMBA,IMP_OTRO,INC_FLET,INC_SEGU,INC_EMBA,INC_OTRO,MON_GUIA,MAR_NUME,PES_BRUT,CAN_BULT,tip_bult,des_orig)  " &
                                               "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}',33,9)",
                                               objpedimento.Referencia, objpedimento.Toper, objpedimento.Adudesp, objpedimento.Patente, objpedimento.CvePedimento, objpedimento.AduEnt, String.Format("{0:MM/dd/yyyy}", objpedimento.FechaEntrada), objpedimento.EmbCve_Capt, objpedimento.Importador, String.Format("{0:MM/dd/yyyy}", objpedimento.EmbApe_Refe), objpedimento.EmbSec_Desp,
                                               objpedimento.Fletes, objpedimento.Seguro, objpedimento.Embalaje, objpedimento.Otros, objpedimento.impFletes, objpedimento.impSeguro, objpedimento.impEmbalaje, objpedimento.impOtros, "USD", "S/M S/N", objpedimento.PesoBruto, objpedimento.Bultos)
        '  objfb.crealog(consulta)
        If objfb.ejecutaQuery(consulta) Then
            consulta = String.Format("INSERT INTO SAAIO_CONTEN (NUM_REFE,NUM_CONT,CVE_CONT) VALUES('{0}','{1}',{2})", objpedimento.Referencia, objpedimento.NVehiculo, objpedimento.Tipo_cont)
            ' objfb.crealog(consulta)
            Return objfb.ejecutaQuery(consulta)

        Else
            Return False
        End If
    End Function
    Function InsertaEncabezadoPedimento(ByVal objpedimento As ClsPedimento) As Boolean
        Dim objfb As New ClsProcesos
        Dim consulta As String = String.Format("INSERT INTO SAAIO_PEDIME(Num_refe,cve_impo,imp_expo,Adu_Desp,Pat_agen,Num_pedi,Adu_entr,Fec_Entr,cve_pedi,reg_adua,pes_brut, mar_nume) " &
       "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22},'{23}')", objpedimento.Referencia, objpedimento.Importador, objpedimento.Toper, objpedimento.Adudesp, objpedimento.Patente, objpedimento.NoPedimento, objpedimento.AduEnt, String.Format("{0:MM/dd/yyyy}", objpedimento.FechaEntrada), objpedimento.CvePedimento, objpedimento.Regimen, objpedimento.PesoBruto, "S/M S/N")
        If objfb.ejecutaQuery(consulta) Then
            Return True
        Else
            Return False
        End If
    End Function
    Function insertaincrementables(ByVal objpedimento As ClsPedimento) As Boolean
        Dim objfb As New ClsProcesos
        Try


            Dim consulta As String
            If objpedimento.Fletes > 0 Then
                consulta = String.Format("insert into saaio_increm values('{0}','{1}','{2}','USD')", objpedimento.Referencia, "1", objpedimento.Fletes)
                objfb.ejecutaQuery(consulta)
            End If

            If objpedimento.Seguro > 0 Then
                consulta = String.Format("insert into saaio_increm values('{0}','{1}','{2}','USD')", objpedimento.Referencia, "2", objpedimento.Seguro)
                objfb.ejecutaQuery(consulta)
            End If

            If objpedimento.Embalaje > 0 Then
                consulta = String.Format("insert into saaio_increm values('{0}','{1}','{2}','USD')", objpedimento.Referencia, "3", objpedimento.Embalaje)
                objfb.ejecutaQuery(consulta)
            End If

            If objpedimento.Otros > 0 Then
                consulta = String.Format("insert into saaio_increm values('{0}','{1}','{2}','USD')", objpedimento.Referencia, "6", objpedimento.Otros)
                objfb.ejecutaQuery(consulta)
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("No se pasaron los Incremetables")
        End Try
    End Function
    Function GetObjPedimento(ByVal dt As DataTable) As ClsPedimento
        Dim objpedimento As New ClsPedimento
        Dim dr As DataRow
        dr = dt.Rows(0)
        Dim listaid As New List(Of String)
        Dim bultos As Decimal = 0.0
        Dim peso_bruto As Decimal = 0.0
        Dim seguro, fletes, embalaje, _otros As Integer
        seguro = 0
        fletes = 0
        embalaje = 0
        _otros = 0


        For Each dtrow As DataRow In dt.Rows
            listaid.Add(dtrow("IdSalidaINT"))

            bultos = bultos + IIf(IsDBNull(dr("Bultos")), 0, dr("Bultos"))
            peso_bruto = peso_bruto + IIf(IsDBNull(dr("Peso bruto")), 0, dr("Peso bruto"))
            seguro = seguro + dr("SegurosINT")
            fletes = fletes + dr("FletesINT")
            embalaje = embalaje + dr("EmbalajesINT")
            _otros = _otros + dr("Otros incremINT")

        Next
        ' el indice debe ser variable.


        objpedimento.ListIdSalida = listaid ' .Add(dt.Rows(0).Item("IdSalidaINT"))

        objpedimento.Referencia = dr("Kalisch Referencia")



        If dr("T OperINT") = "1" Then
            objpedimento.Toper = 1
        Else
            objpedimento.Toper = 2
        End If


        objpedimento.NoPedimento = dr("Pedimento")



        objpedimento.FechaEntrada = IIf(IsDBNull(dr("Fecha Entrada")), Now, dr("Fecha Entrada"))

        objpedimento.Regimen = IIf(IsDBNull(dr("RegimenINT")), "", dr("RegimenINT"))

        objpedimento.Bultos = bultos 'IIf(IsDBNull(dr("Bultos")), "0", dr("Bultos"))
        objpedimento.PesoBruto = peso_bruto 'IIf(IsDBNull(dr("Peso bruto")), "0.0", dr("Peso bruto"))
        objpedimento.NVehiculo = IIf(IsDBNull(dr("NumVehiculo")), "", dr("NumVehiculo"))
        objpedimento.Tipo_cont = IIf(IsDBNull(dr("Tipo_Contenedor")), "", dr("Tipo_Contenedor"))

        objpedimento.FecAjus = 1
        objpedimento.CvePedimento = dr("Clave PedimentoINT")
        objpedimento.EmbCve_Capt = "TRASPASO"
        objpedimento.EmbApe_Refe = Now
        objpedimento.EmbSec_Desp = 0
        objpedimento.Seguro = seguro 'dr("SegurosINT")
        objpedimento.Fletes = fletes 'dr("FletesINT")
        objpedimento.Embalaje = embalaje 'dr("EmbalajesINT")
        objpedimento.Otros = _otros 'dr("Otros incremINT")
        objpedimento.impSeguro = IIf(objpedimento.Seguro > 0, "S", "N")
        objpedimento.impFletes = IIf(objpedimento.Fletes > 0, "S", "N")
        objpedimento.impEmbalaje = IIf(objpedimento.Embalaje > 0, "S", "N")
        objpedimento.impOtros = IIf(objpedimento.Otros > 0, "S", "N")



        Return objpedimento
    End Function
    Function getCuadroLiquidacion(ByVal params As Object) As DataTable
        Dim objclspedimento As New ClsPedimento
        Dim objProc As New ClsProcesos


        Dim Consulta_valsegdll As New StringBuilder

        Consulta_valsegdll.AppendLine("SELECT SUM(IMP_INCR) FROM SAAIO_INCREM ")
        Consulta_valsegdll.AppendLine(String.Format("WHERE CVE_INCR IN (4,6) AND NUM_REFE = '{0}'", params.Referencia))



        Dim consulta As New StringBuilder
        consulta.AppendLine("SELECT TOT_IMPU AS SUMA ,CVE_IMPU")
        consulta.AppendLine("FROM SAAIO_CONTPED")
        consulta.AppendLine(String.Format("WHERE NUM_REFE='{0}'", params.Referencia))
        consulta.AppendLine("UNION")
        consulta.AppendLine("SELECT SUM(TOT_IMPU) AS SUMA,CVE_IMPU")
        consulta.AppendLine("FROM SAAIO_CONTFRA ")
        consulta.AppendLine(String.Format("WHERE NUM_REFE='{0}'", params.Referencia))
        consulta.AppendLine("GROUP BY CVE_IMPU")

        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta.ToString(), "FB")
        ' MessageBox.Show("alerta" + params.Parametro1)
        ' MessageBox.Show("alertaw" + params.Parametro2)
        Return dt
    End Function

End Class