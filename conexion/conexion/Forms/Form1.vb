Imports FirebirdSql.Data.FirebirdClient
Imports System.Data.SqlClient
Imports System.Text

<Assembly: log4net.Config.XmlConfigurator(Watch:=True)> 
Public Class Form1
    Dim objProc As New ClsProcesos
    Dim objEnFac As New FacturaDTO
    Dim objEnFac2 As New ClsEncFactura
    Dim objpartidas As New PartidasDTO
    Dim objpartidas2 As New ClsFacturaPartidas
    Dim objpedimento As New ClsPedimento
    Public id_salida As String
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger("Principal.vb")
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        objProc.conectarfb()
        objProc.conectaracc()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            log.Info("Inicio de proceso....    " + Now.ToString)
            InsertaEmbarque()

            MsgBox("Traspaso Completo", MsgBoxStyle.Information)
            log.Info("Fin de proceso....    " + Now.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)

            TextBox1.Text = TextBox1.Text + ex.Message + vbCrLf
        End Try

    End Sub
    Sub InsertaEmbarque()
        Try
            Dim CVE_IMPO As String
            Dim NOM_IMPO As String
            Dim DIR_IMPO As String
            Dim POB_IMPO As String
            Dim ZIP_IMPO As String
            Dim TAX_IMPO As String
            Dim PAI_IMPO As String
            Dim objpedimentoconsulta As String = String.Format("SELECT * FROM [Pedimentos 5001 Encabezado] where Pedimento = {0}", txtPedimento.Text.Trim)
            Dim dtpedimento As New DataTable
            Dim consultaemb As String
            Dim dt As New DataTable
            dtpedimento = objProc.llenaDataSet(objpedimentoconsulta, "ACC")
            'Dim consultaemb As String
            Dim dr As DataRow
            dr = dtpedimento.Rows(0)
            If dtpedimento.Rows.Count > 0 Then
                objpedimento = objpedimento.GetObjPedimento(dtpedimento)
                objpedimento.AduEnt = txtaduana.Text.Trim 'dr("AduanaINT")
                objpedimento.Adudesp = txtaduana.Text.Trim
                objpedimento.Patente = txtpatente.Text.Trim

                If objpedimento.Patente = 3778 Then
                    objpedimento.Importador = dr("Kalisch IDComprador")
                Else
                    objpedimento.Importador = dr("IDImportador/Exportador")
                End If


                Dim iconsultaemb As String = String.Format("SELECT * From CTRAO_EMBAR Where NUM_REFE='{0}'", objpedimento.Referencia)

                dt = objProc.llenaDataSet(iconsultaemb, "FB")
                If dt.Rows.Count > 0 Then
                    Throw New Exception("La Referencia ya existe en el casa")
                Else
                    Dim cadprove As String = String.Format("SELECT * From ctrac_client Where cve_imp='{0}'", objpedimento.Importador)
                    Dim dtpro As New DataTable
                    dtpro = objProc.llenaDataSet(cadprove, "FB")
                    If dtpro.Rows.Count > 0 Then
                        ' si es mayo a cero quiere decir que existe

                    Else
                        Dim consprove As String

                        'traigo los datos del importador
                        If txtpatente.Text.Trim() = 3778 Then
                            consprove = String.Format("SELECT * FROM [Pedimentos 1001 Companias] where Idsalida={0} and IDComprador={1};", objpedimento.ListIdSalida(0), objpedimento.Importador)
                        Else
                            consprove = String.Format("SELECT * FROM [Pedimentos 1001 Companias] where Idsalida={0} and Idcompania={1};", objpedimento.ListIdSalida(0), objpedimento.Importador)
                        End If


                        Dim dtinfo As New DataTable
                        dtinfo = objProc.llenaDataSet(consprove, "ACC")
                        For Each drinfo As DataRow In dtinfo.Rows
                            CVE_IMPO = objpedimento.Importador
                            NOM_IMPO = UCase(quitaacentos(drinfo("Nombre")))
                            Dim direccion As String = drinfo("Calle") + " " + IIf(IsDBNull(drinfo("No ext")), "", drinfo("No ext")) + IIf(IsDBNull(drinfo("Numero_Int")), "", drinfo("Numero_Int"))
                            direccion = quitaacentos(direccion)
                            DIR_IMPO = UCase(direccion)
                            POB_IMPO = UCase(drinfo("Ciudad"))
                            ZIP_IMPO = IIf(IsDBNull(drinfo("Zip code")), "", drinfo("Zip code"))
                            TAX_IMPO = IIf(IsDBNull(drinfo("Id fiscal")), "", quitaacentos(drinfo("Id fiscal")))
                            PAI_IMPO = IIf(IsDBNull(drinfo("Pais_abrev")), "", drinfo("Pais_abrev"))
                            Dim insIMP As String
                            insIMP = "INSERT INTO CTRAC_CLIENT (CVE_IMP , NOM_IMP , DIR_IMP , POB_IMP , CP_IMP, RFC_IMP,PAI_IMP,pag_elec,com_enom,des_orig,mod_facpar) " & _
                              " VALUES ('" & CVE_IMPO & "','" & NOM_IMPO & "','" & DIR_IMPO & "','" & POB_IMPO & "','" & ZIP_IMPO & "','" & TAX_IMPO & "','" & PAI_IMPO & "','S','VIII',9,'S')"

                            If (objProc.ejecutaQuery(insIMP)) Then
                            Else
                                Throw New Exception("Error Al Insertar El Importador")
                            End If
                        Next
                    End If

                    If objpedimento.creaembarque(objpedimento) = False Then
                        Throw New Exception("Error Al crear el embarque")

                    Else
                        inserta_Facturas(objpedimento)
                        ' objpedimento.InsertaEncabezadoPedimento(objpedimento)
                        objpedimento.insertaincrementables(objpedimento)
                    End If



                End If



            Else
                Throw New Exception("El pedimento no existe en las tablas del Access")
            End If

            log.Info("Creacion Validacion del embarque    " + Now.ToString)




        Catch ex As Exception

            log.Error(ex.Message)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Info("Borrado.....")


            Borrado.borrar(objpedimento.Referencia)

        End Try
    End Sub
    Sub validaembarque()
        Try
            Dim CVE_IMPO As String
            Dim NOM_IMPO As String
            Dim DIR_IMPO As String
            Dim POB_IMPO As String
            Dim ZIP_IMPO As String
            Dim TAX_IMPO As String
            Dim PAI_IMPO As String

            Dim consultaped As String

            Dim consultaemb As String = String.Format("SELECT * From CTRAO_EMBAR Where NUM_REFE='{0}'", txtPedimento.Text.Trim)
            Dim dt As New DataTable
            dt = objProc.llenaDataSet(consultaemb, "FB")
            If dt.Rows.Count > 0 Then
                MsgBox("La Referencia Ya Existe!!!", MsgBoxStyle.Critical, "Error")
            Else
                Dim dtp As New DataTable
                If txtpatente.Text.Trim() = 3778 Then
                    consultaped = String.Format("SELECT * FROM [Pedimentos 5001 Encabezado] where [Kalisch Referencia]='{0}'", txtPedimento.Text)
                Else
                    consultaped = String.Format("SELECT * FROM [Pedimentos 5001 Encabezado] where PatenteINT={0}", txtPedimento.Text)
                End If



                dtp = objProc.llenaDataSet(consultaped, "ACC")

                For Each dr As DataRow In dtp.Rows
                    objpedimento.Referencia = txtPedimento.Text.Trim

                    If txtpatente.Text.Trim() = 3778 Then
                        objpedimento.Importador = dr("Kalisch IDComprador")
                    Else
                        objpedimento.Importador = dr("IDImportador/Exportador")
                    End If

                    If dr("T OperINT") = "1" Then
                        objpedimento.Toper = 1
                    Else
                        objpedimento.Toper = 2
                    End If

                    objpedimento.Adudesp = txtaduana.Text.Trim
                    objpedimento.Patente = txtpatente.Text.Trim
                    objpedimento.NoPedimento = dr("Pedimento")
                    objpedimento.AduEnt = txtaduana.Text.Trim 'dr("AduanaINT")


                    objpedimento.FechaEntrada = IIf(IsDBNull(dr("Fecha Entrada")), Now, dr("Fecha Entrada"))

                    'objpedimento.TipoCambio = dr("")
                    objpedimento.Regimen = IIf(IsDBNull(dr("RegimenINT")), "", dr("RegimenINT"))
                    'objpedimento.DestinoOrigen     =
                    objpedimento.Bultos = IIf(IsDBNull(dr("Bultos")), "0", dr("Bultos")) 'dr("Bultos")
                    objpedimento.PesoBruto = IIf(IsDBNull(dr("Peso bruto")), "0.0", dr("Peso bruto")) ' dr("Peso bruto")
                    objpedimento.NVehiculo = IIf(IsDBNull(dr("NumVehiculo")), "", dr("NumVehiculo"))
                    objpedimento.Tipo_cont = IIf(IsDBNull(dr("Tipo_Contenedor")), "", dr("Tipo_Contenedor"))
                    'objpedimento.ValDll            =
                    'objpedimento.ValCome           =
                    'objpedimento.TotalIncre        =
                    '  objpedimento.ValorNormal       =
                    objpedimento.FecAjus = 1
                    objpedimento.CvePedimento = dr("Clave PedimentoINT")
                    objpedimento.EmbCve_Capt = "TRASPASO"
                    objpedimento.EmbApe_Refe = Now
                    objpedimento.EmbSec_Desp = 0
                    objpedimento.Seguro = dr("SegurosINT")
                    objpedimento.Fletes = dr("FletesINT")
                    objpedimento.Embalaje = dr("EmbalajesINT")
                    objpedimento.Otros = dr("Otros incremINT")
                    objpedimento.impSeguro = IIf(objpedimento.Seguro > 0, "S", "N")
                    objpedimento.impFletes = IIf(objpedimento.Fletes > 0, "S", "N")
                    objpedimento.impEmbalaje = IIf(objpedimento.Embalaje > 0, "S", "N")
                    objpedimento.impOtros = IIf(objpedimento.Otros > 0, "S", "N")

                    id_salida = dr("IdSalidaINT")
                Next

                ' valida el importador
                Dim cadprove As String = String.Format("SELECT * From ctrac_client Where cve_imp='{0}'", objpedimento.Importador)
                Dim dtpro As New DataTable
                dtpro = objProc.llenaDataSet(cadprove, "FB")
                If dtpro.Rows.Count > 0 Then
                    ' si es mayo a cero quiere decir que existe
                Else
                    Dim consprove As String
                    'traigo los datos del importador
                    If txtpatente.Text.Trim() = 3778 Then
                        consprove = String.Format("SELECT * FROM [Pedimentos 1001 Companias] where Idsalida={0} and IDComprador={1};", id_salida, objpedimento.Importador)
                    Else
                        consprove = String.Format("SELECT * FROM [Pedimentos 1001 Companias] where Idsalida={0} and Idcompania={1};", id_salida, objpedimento.Importador)
                    End If


                    Dim dtinfo As New DataTable
                    dtinfo = objProc.llenaDataSet(consprove, "ACC")
                    For Each drinfo As DataRow In dtinfo.Rows
                        CVE_IMPO = objpedimento.Importador
                        NOM_IMPO = UCase(quitaacentos(drinfo("Nombre")))
                        Dim direccion As String = drinfo("Calle") + " " + IIf(IsDBNull(drinfo("No ext")), "", drinfo("No ext")) + IIf(IsDBNull(drinfo("Numero_Int")), "", drinfo("Numero_Int"))
                        direccion = quitaacentos(direccion)
                        DIR_IMPO = UCase(direccion)
                        POB_IMPO = UCase(drinfo("Ciudad"))
                        ZIP_IMPO = IIf(IsDBNull(drinfo("Zip code")), "", drinfo("Zip code"))
                        TAX_IMPO = IIf(IsDBNull(drinfo("Id fiscal")), "", quitaacentos(drinfo("Id fiscal")))
                        PAI_IMPO = IIf(IsDBNull(drinfo("Pais_abrev")), "", drinfo("Pais_abrev"))
                        Dim insIMP As String
                        insIMP = "INSERT INTO CTRAC_CLIENT (CVE_IMP , NOM_IMP , DIR_IMP , POB_IMP , CP_IMP, RFC_IMP,PAI_IMP,pag_elec,com_enom,des_orig,mod_facpar) " & _
                          " VALUES ('" & CVE_IMPO & "','" & NOM_IMPO & "','" & DIR_IMPO & "','" & POB_IMPO & "','" & ZIP_IMPO & "','" & TAX_IMPO & "','" & PAI_IMPO & "','S','VIII',9,'S')"

                        If (objProc.ejecutaQuery(insIMP)) Then
                        Else
                            Throw New Exception("Error Al Insertar El Importador")
                        End If
                    Next
                End If
                If objpedimento.creaembarque(objpedimento) = False Then
                    Throw New Exception("Error Al crear el embarque")

                Else
                    inserta_Facturas(objpedimento)
                    ' objpedimento.InsertaEncabezadoPedimento(objpedimento)
                    objpedimento.insertaincrementables(objpedimento)
                End If


            End If
        Catch ex As Exception
            TextBox1.Text = TextBox1.Text + ex.Message + vbCrLf + ""
            Dim CONSULTA As String = String.Format("delete  From CTRAO_EMBAR Where NUM_REFE='{0}'", txtPedimento.Text)
            objProc.ejecutaQuery(CONSULTA)
            CONSULTA = String.Format("delete  From saaio_factur  Where NUM_REFE='{0}'", txtPedimento.Text)

            objProc.ejecutaQuery(CONSULTA)
            CONSULTA = String.Format("delete  From SAAIO_FACPAR  Where NUM_REFE='{0}'", txtPedimento.Text)
            objProc.ejecutaQuery(CONSULTA)
            Throw New Exception(ex.Message)
            log.Info("Error de validacion del embarque")
        End Try
    End Sub
    Sub inserta_Facturas(ByVal _objpedimento As ClsPedimento)

        Dim CVE_PRO As String
        Dim NOM_PRO As String
        Dim DIR_PRO As String
        Dim POB_PRO As String
        Dim ZIP_PRO As String
        Dim TAX_PRO As String
        Dim NOINT As String
        Dim NOEXT As String
        'Traes la informacion del encabezado
        Dim consecutivo As Integer = 1
        Dim condicion As String = ""
        For Each id_salida As String In _objpedimento.ListIdSalida
            If condicion = "" Then
                condicion = "where idSalida in(" + id_salida
            Else
                condicion = condicion + "," + id_salida
            End If

        Next

        condicion = condicion + ")"

        Dim consulta As New StringBuilder
        consulta.AppendLine("SELECT IDFactura,NumFacturaFac,FechaFacturaFac,Incoterm,")
        consulta.AppendLine("sum(Valortotalfactura) AS ValorFactura,Monedadefacturacion,[Kalisch IDVendedor],")
        consulta.AppendLine("[IDVendedor Proveedor],Numero,Numero_Int,Nombre_Provee,")
        consulta.AppendLine("Calle,Ciudad,Zip_code,Id_fiscal,Pais")
        consulta.AppendLine("From [Pedimentos 3001 Facturas encabezado] ")
        consulta.AppendLine(condicion)
        consulta.AppendLine("GROUP BY IDFactura,NumFacturaFac,FechaFacturaFac,Incoterm,Monedadefacturacion,[Kalisch IDVendedor],")
        consulta.AppendLine("[IDVendedor Proveedor],Numero,Numero_Int,Nombre_Provee,")
        consulta.AppendLine("Calle,Ciudad,Zip_code,Id_fiscal,Pais")

        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta.ToString(), "ACC")
        For Each dr As Data.DataRow In dt.Rows
            objEnFac.IdAccess = dr("IDFactura")
            objEnFac.NoFac = dr("NumFacturaFac")
            objEnFac.FechaFac = dr("FechaFacturaFac")
            objEnFac.Incoterm = dr("Incoterm")

            objEnFac.ValDlls = Convert.ToDecimal(dr("ValorFactura"))
            objEnFac.ValExtr = Convert.ToDecimal(dr("ValorFactura"))
            objEnFac.EquDlls = 1
            objEnFac.NoFac2 = dr("NumFacturaFac")
            objEnFac.MonFac = dr("Monedadefacturacion")
            If txtpatente.Text.Trim = 3778 Then
                objEnFac.CveProv = dr("Kalisch IDVendedor")
            Else
                objEnFac.CveProv = dr("IDVendedor Proveedor")
            End If

            objEnFac.Consec = consecutivo
            objEnFac.Referencia = _objpedimento.Referencia
            consecutivo = consecutivo + 1
            objEnFac.ObsCove = "SE DECLARAN DATOS CORRECTOS DE IMPORTADOR, PROVEEDOR, FACTURA Y MERCANCIA"
            'antes de validar la factura se valida el proveedor/DESTINATARIO

            Dim cadprove As String
            If objpedimento.Toper = 1 Then
                cadprove = String.Format("SELECT * From CTRAC_PROVED Where CVE_PRO='{0}'", objEnFac.CveProv)

            Else
                cadprove = String.Format("SELECT * From CTRAC_DESTIN Where CVE_PRO='{0}'", objEnFac.CveProv)
            End If

            Dim dtpro As New DataTable
            dtpro = objProc.llenaDataSet(cadprove, "FB")
            If dtpro.Rows.Count > 0 Then
                ' si es mayo a cero quiere decir que existe
            Else
                'traigo los datos del proveedor

                'modificacion 9-10-2014
                'NOM_COVE, MUN_COVE ES EL NOMBRE Y LA CIUDAD
                NOEXT = IIf(IsDBNull(dr("Numero")), "", dr("Numero"))
                NOINT = IIf(IsDBNull(dr("Numero_Int")), "", dr("Numero_Int"))
                CVE_PRO = objEnFac.CveProv
                NOM_PRO = LCase(quitaacentos(dr("Nombre_Provee")))
                Dim direccion As String = dr("Calle") + " " + IIf(IsDBNull(dr("Numero")), "", dr("Numero")) + " " + IIf(IsDBNull(dr("Numero_Int")), "", dr("Numero_Int"))
                direccion = quitaacentos(direccion)
                DIR_PRO = UCase(direccion)
                POB_PRO = UCase(dr("Ciudad"))
                ZIP_PRO = IIf(IsDBNull(dr("Zip_code")), "", dr("Zip_code"))
                TAX_PRO = IIf(IsDBNull(dr("Id_fiscal")), "", dr("Id_fiscal"))
                Dim inspro As String
                If objpedimento.Toper = 1 Then
                    inspro = String.Format("INSERT INTO CTRAC_PROVED (CVE_PRO , NOM_PRO , DIR_PRO , POB_PRO , ZIP_PRO, TAX_PRO,NOE_PRO,EFE_PRO,PAI_PRO,NOI_PRO,VIN_PRO)  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", CVE_PRO, NOM_PRO, DIR_PRO, POB_PRO, ZIP_PRO, TAX_PRO, NOEXT, dr("Entidad_Fed"), dr("Pais"), NOINT, "N")

                Else
                    inspro = String.Format("INSERT INTO CTRAC_DESTIN (CVE_PRO , NOM_PRO , DIR_PRO , POB_PRO , ZIP_PRO, TAX_PRO,NOE_PRO,EFE_PRO,PAI_PRO,NOI_PRO,VIN_PRO)  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", CVE_PRO, NOM_PRO, DIR_PRO, POB_PRO, ZIP_PRO, TAX_PRO, NOEXT, dr("Entidad_Fed"), dr("Pais"), NOINT, "N")
                End If


                If (objProc.ejecutaQuery(inspro)) Then
                Else
                    Throw New Exception("Error Al Insertar El Proveedor/Destinatario")
                End If


            End If

            If objEnFac2.validafactura(_objpedimento.Referencia, objEnFac.CveProv, objEnFac.NoFac) Then
                'insertar encabezado de factura
                log.Info("Insercion Factura con el ID: " + objEnFac.IdAccess.ToString)

                If objEnFac2.creafactura(objEnFac) Then
                    PartidasFactura(objEnFac.IdAccess, objEnFac.Consec, _objpedimento.Referencia, _objpedimento.ListIdSalida)
                Else
                    MsgBox("Error al insertar el Encabezado de la factura")
                End If
            End If
        Next

    End Sub
    'Sub inserta_Facturas()

    '    Dim CVE_PRO As String
    '    Dim NOM_PRO As String
    '    Dim DIR_PRO As String
    '    Dim POB_PRO As String
    '    Dim ZIP_PRO As String
    '    Dim TAX_PRO As String
    '    Dim NOINT As String
    '    Dim NOEXT As String
    '    'Traes la informacion del encabezado
    '    Dim consulta As String = String.Format("SELECT * FROM [Pedimentos 3001 Facturas encabezado] where idSalida={0} order by [IDVendedor Proveedor],NumFacturaFac asc", id_salida)
    '    Dim dt As New DataTable
    '    dt = objProc.llenaDataSet(consulta, "ACC")
    '    Dim consecutivo As Integer = 1
    '    For Each dr As Data.DataRow In dt.Rows
    '        objEnFac.IdAccess = dr("IDFactura")
    '        objEnFac.NoFac = dr("NumFacturaFac")
    '        objEnFac.FechaFac = dr("FechaFacturaFac")
    '        objEnFac.Incoterm = dr("Incoterm")
    '        objEnFac.ValDlls = System.Decimal.Round(dr("Valortotalfactura"), 2)
    '        objEnFac.ValExtr = System.Decimal.Round(dr("Valortotalfactura"), 2)
    '        objEnFac.EquDlls = 1
    '        objEnFac.NoFac2 = dr("NumFacturaFac")
    '        objEnFac.MonFac = dr("Monedadefacturacion")
    '        If txtpatente.Text.Trim = 3778 Then
    '            objEnFac.CveProv = dr("Kalisch IDVendedor")
    '        Else
    '            objEnFac.CveProv = dr("IDVendedor Proveedor")
    '        End If

    '        objEnFac.Consec = consecutivo
    '        objEnFac.Referencia = txtPedimento.Text
    '        consecutivo = consecutivo + 1
    '        objEnFac.ObsCove = "SE DECLARAN DATOS CORRECTOS DE IMPORTADOR, PROVEEDOR, FACTURA Y MERCANCIA"
    '        'antes de validar la factura se valida el proveedor/DESTINATARIO

    '        Dim cadprove As String
    '        If objpedimento.Toper = 1 Then
    '            cadprove = String.Format("SELECT * From CTRAC_PROVED Where CVE_PRO='{0}'", objEnFac.CveProv)

    '        Else
    '            cadprove = String.Format("SELECT * From CTRAC_DESTIN Where CVE_PRO='{0}'", objEnFac.CveProv)
    '        End If

    '        Dim dtpro As New DataTable
    '        dtpro = objProc.llenaDataSet(cadprove, "FB")
    '        If dtpro.Rows.Count > 0 Then
    '            ' si es mayo a cero quiere decir que existe
    '        Else
    '            'traigo los datos del proveedor

    '            'modificacion 9-10-2014
    '            'NOM_COVE, MUN_COVE ES EL NOMBRE Y LA CIUDAD
    '            NOEXT = IIf(IsDBNull(dr("Numero")), "", dr("Numero"))
    '            NOINT = IIf(IsDBNull(dr("Numero_Int")), "", dr("Numero_Int"))
    '            CVE_PRO = objEnFac.CveProv
    '            NOM_PRO = LCase(quitaacentos(dr("Nombre_Provee")))
    '            Dim direccion As String = dr("Calle") + " " + IIf(IsDBNull(dr("Numero")), "", dr("Numero")) + " " + IIf(IsDBNull(dr("Numero_Int")), "", dr("Numero_Int"))
    '            direccion = quitaacentos(direccion)
    '            DIR_PRO = UCase(direccion)
    '            POB_PRO = UCase(dr("Ciudad"))
    '            ZIP_PRO = IIf(IsDBNull(dr("Zip_code")), "", dr("Zip_code"))
    '            TAX_PRO = IIf(IsDBNull(dr("Id_fiscal")), "", dr("Id_fiscal"))
    '            Dim inspro As String
    '            If objpedimento.Toper = 1 Then
    '                inspro = String.Format("INSERT INTO CTRAC_PROVED (CVE_PRO , NOM_PRO , DIR_PRO , POB_PRO , ZIP_PRO, TAX_PRO,NOE_PRO,EFE_PRO,PAI_PRO,NOI_PRO,VIN_PRO)  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", CVE_PRO, NOM_PRO, DIR_PRO, POB_PRO, ZIP_PRO, TAX_PRO, NOEXT, dr("Entidad_Fed"), dr("Pais"), NOINT, "N")

    '            Else
    '                inspro = String.Format("INSERT INTO CTRAC_DESTIN (CVE_PRO , NOM_PRO , DIR_PRO , POB_PRO , ZIP_PRO, TAX_PRO,NOE_PRO,EFE_PRO,PAI_PRO,NOI_PRO,VIN_PRO)  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", CVE_PRO, NOM_PRO, DIR_PRO, POB_PRO, ZIP_PRO, TAX_PRO, NOEXT, dr("Entidad_Fed"), dr("Pais"), NOINT, "N")
    '            End If


    '            If (objProc.ejecutaQuery(inspro)) Then
    '            Else
    '                Throw New Exception("Error Al Insertar El Proveedor/Destinatario")
    '            End If


    '        End If

    '        If objEnFac.validafactura(txtPedimento.Text, objEnFac.CveProv, objEnFac.NoFac) Then
    '            'insertar encabezado de factura
    '            If objEnFac.creafactura(objEnFac) Then
    '                'PartidasFactura(objEnFac.IdAccess, objEnFac.Consec)
    '            Else
    '                MsgBox("Error al insertar el Encabezado de la factura")
    '            End If
    '        End If
    '    Next

    'End Sub
    Sub PartidasFactura(ByVal idfactura As String, ByVal consecutivo As Integer, ByVal referencia As String, ByVal id_salidas As List(Of String))
        'Consulta de las partidas de access
        Try

            Dim condicion As String = ""
            For Each id_salida As String In id_salidas
                If condicion = "" Then
                    condicion = "where idSalida in(" + id_salida
                Else
                    condicion = condicion + "," + id_salida
                End If

            Next
            condicion = condicion + ")"
            Dim consparti As New StringBuilder
            consparti.AppendLine("SELECT Idfacturapartidas, Numero_Partida, NumeroParteFac, Origenpartida, Fraccion_Arancelaria, ApliacaTLC, ")
            consparti.AppendLine("sum(Valor_Total_Partida) AS Total_Partida, Moneda_Facturacion, sum(PesoPartidaKgsFac) AS PesoPartida, ")
            consparti.AppendLine("sum(CantEnSalidas) AS cantidadsalidas, UMFac, UM_Tarifa, Descripcion_Parte,MetodoValoracionFac,")
            consparti.AppendLine("marca,modelo,serie")
            consparti.AppendLine("FROM [Pedimentos 3002 Partidas de facturas]")
            consparti.AppendLine(condicion)
            consparti.AppendLine("AND IDFactura=" + idfactura)
            consparti.AppendLine("GROUP BY Idfacturapartidas, Numero_Partida, NumeroParteFac, Origenpartida, Fraccion_Arancelaria, ")
            consparti.AppendLine("ApliacaTLC, Moneda_Facturacion, UMFac, UM_Tarifa, Descripcion_Parte,MetodoValoracionFac,")
            consparti.AppendLine("Marca,Modelo,Serie")
            consparti.AppendLine("ORDER BY Idfacturapartidas;")

            Dim dtparti As New DataTable
            Dim consecpartida As Integer = 1
            dtparti = objProc.llenaDataSet(consparti.ToString(), "ACC")
            For Each drparti As DataRow In dtparti.Rows
                objpartidas.IdPacc = drparti("Idfacturapartidas")
                objpartidas.Referencia = referencia
                objpartidas.consecutivoFactura = consecutivo
                objpartidas.consecutivo = drparti("Numero_Partida")
                objpartidas.NoPart = drparti("NumeroParteFac")
                objpartidas.PO = drparti("Origenpartida")
                objpartidas.PV = regresaPV(idfactura)
                Dim frac As String = drparti("Fraccion_Arancelaria")
                objpartidas.Fraccion = frac.Replace(".", "")
                If drparti("ApliacaTLC") Then
                    objpartidas.Cas_TLCS = "TL"
                    objpartidas.COM_TLC = objpartidas.PO
                Else
                    objpartidas.Cas_TLCS = " "
                    objpartidas.COM_TLC = " "
                End If
                If objpedimento.Toper = 1 Then
                    objpartidas.VIN = vinculacion(idfactura)
                Else
                    objpartidas.VIN = 0
                End If

                objpartidas.Adval = 0
                objpartidas.Total = IIf(IsDBNull(drparti("Total_Partida")), "0", drparti("Total_Partida"))
                objpartidas.Modena = drparti("Moneda_Facturacion")
                objpartidas.PesoUni = IIf(IsDBNull(drparti("PesoPartida")), "0", drparti("PesoPartida"))
                objpartidas.CantFactur = drparti("cantidadsalidas")

                objpartidas.UMC = drparti("UMFac")
                objpartidas.UMT = drparti("UM_Tarifa")
                If objpartidas.UMC = objpartidas.UMT Then
                    objpartidas.CantTar = drparti("cantidadsalidas")
                Else
                    If objpartidas.UMT = "1" Then
                        objpartidas.CantTar = IIf(IsDBNull(drparti("PesoPartida")), 0, drparti("PesoPartida"))
                    Else
                        objpartidas.CantTar = "0"
                    End If
                End If



                objpartidas.Descripcion = quitaacentos(drparti("Descripcion_Parte"))
                objpartidas.ValAgre = 0
                objpartidas.PrecioUnitario = "0"
                If objpedimento.Toper = 1 Then
                    objpartidas.PorcIVA = "16"
                Else
                    objpartidas.PorcIVA = "0"

                End If

                Dim consultaval As String = String.Format("select ClaveVoloracion from [Pedimentos-Metodos de valoracion] where IDMetValoracion ={0}", drparti("MetodoValoracionFac"))
                Dim dtvalorcomer As New DataTable
                dtvalorcomer = objProc.llenaDataSet(consultaval, "ACC")
                For Each drvalcomer As DataRow In dtvalorcomer.Rows
                    If objpedimento.Toper = 1 Then
                        objpartidas.ValorComer = drvalcomer("ClaveVoloracion") ' Valor comercial
                    Else
                        objpartidas.ValorComer = 0
                    End If


                Next

                objpartidas.usuarioc = "1"
                objpartidas.CantCove = drparti("cantidadsalidas")
                objpartidas.UnidadCove = drparti("UMFac")
                objpartidas.Marca = IIf(IsDBNull(drparti("Marca")), "", drparti("Marca"))
                objpartidas.Modelo = IIf(IsDBNull(drparti("Modelo")), "", drparti("Modelo")) ' drparti("Modelo")
                objpartidas.Serie = IIf(IsDBNull(drparti("Serie")), "", drparti("Serie")) ' drparti("Serie")
                log.Info("se inserta partida " + objpartidas.IdPacc.ToString)
                If objpartidas2.creapartida(objpartidas) Then
                    log.Info("se inserta series #Partida: " + objpartidas.IdPacc.ToString)
                    creaseries(objpartidas.Marca, objpartidas.Modelo, objpartidas.Serie, objpartidas.consecutivoFactura, objpartidas.consecutivo, objpartidas.NoPart, referencia)
                    log.Info("se inserta indentifcadores #Partida:  " + objpartidas.IdPacc.ToString)
                    insidepar(objEnFac.IdAccess, objpartidas.IdPacc, objpartidas.consecutivoFactura, objpartidas.consecutivo, referencia, "")
                    'cambio la estructura necesito que se mande el id de la factura por que no se de que factura es el identificador o se pone en todas las facturas?
                    'ahi que onda
                Else

                End If
                consecpartida = consecpartida + 1

            Next

        Catch ex As Exception
            log.Info("Error al insertar las partidas")
            log.Error(quitarSaltosLinea(ex.Message, ""))
            log.Fatal(quitarSaltosLinea(ex.StackTrace, ""))
        End Try
    End Sub
    Sub InsertaEncabezadoPedimento(ByVal objpedimento As ClsPedimento)

    End Sub
    ''' <summary>
    ''' CREA REGISTROS DE SERIES EN CASA
    ''' </summary>
    ''' <param name="consecfatur">COSECUTIVO DE LA FACTURA</param>
    ''' <param name="consparte">CONSECUTIVO DE PARTIDA</param>
    ''' <param name="num_par">NUMERO DE PARTE QUE SE LE ASIGNARA MARCA MODELO NOSERIE</param>
    ''' <remarks></remarks>
    Sub creaseries(ByVal marca As String, ByVal modelo As String, ByVal series As String, ByVal consecfatur As String, ByVal consparte As String, ByVal num_par As String, ByVal referencia As String)
        'Dim consulta As String = String.Format("SELECT MarcaFac,ModeloFac,SeriesPartidaFac From [Pedimentos 3003 Partidas Marca Modelo Serie] PMMS INNER JOIN [Pedimentos 3002 Partidas de facturas] PF on PMMS.Idfacturapartidas=PF.Idfacturapartidas where PF.Idfacturapartidas ={0}", consparte)
        'Dim dt As New DataTable
        'dt = objProc.llenaDataSet(consulta, "ACC")
        Dim id As Integer = 1

        Dim existecoma As Integer = InStr(",", series)
        If existecoma = 0 Then
            Dim serie As String() = series.Split(New Char() {","c})

            ' Use For Each loop over words and display them

            For Each valor In serie
                Dim instseries As String = String.Format("INSERT INTO SAAIO_COVESER (NUM_REFE , CONS_FACT , CONS_PART , CONS_SERI, NUM_PART  ,MAR_MERC, SUB_MODE,NUM_SERI)  VALUES ('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}')", referencia, consecfatur, consparte, id, num_par, marca, modelo, valor)
                objProc.ejecutaQuery(instseries)
                id = id + 1
            Next
        Else
            Dim instseries As String = String.Format("INSERT INTO SAAIO_COVESER (NUM_REFE , CONS_FACT , CONS_PART , CONS_SERI, NUM_PART  ,MAR_MERC, SUB_MODE,NUM_SERI)  VALUES ('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}')", referencia, consecfatur, consparte, id, num_par, marca, modelo, series)
            objProc.ejecutaQuery(instseries)
            id = id + 1
        End If



    End Sub
    ''' <summary>
    ''' Inserta la partida en las tablas del CASA
    ''' </summary>
    ''' <param name="consecfatur">Consecutivo de Factura</param>
    ''' <param name="consparte">No de parte de la partida</param>
    ''' <remarks></remarks>
    Sub insidepar(ByVal IDFACTURA As String, ByVal idpartida As String, ByVal consecfatur As String, ByVal consparte As String, ByVal referencia As String, ByVal id_salida As String)
        Dim consulta As String = String.Format("SELECT * FROM [Pedimentos 6003 Identificadores Partidas o fracciones] where Partida={0} and IdFactura={1}", idpartida, IDFACTURA)
        'Dim consulta As String = String.Format("SELECT * FROM [Pedimentos 6003 Identificadores Partidas o fracciones] where Partida={0} and IdFactura={1} AND Id_Salida={2}", idpartida, IDFACTURA, id_salida)
        Dim dt As New DataTable
        Dim ma As String, id As Integer
        ma = regresaMA(IDFACTURA, idpartida)
        If ma = 0 Then
            id = 1
        Else
            Dim insideparma As String = String.Format("INSERT INTO SAAIO_IDEPAR (NUM_REFE , CONS_FACT,CONS_PART , NUM_IDE , CVE_PERM, NUM_PERM,NUM_PERM2,NUM_PERM3) VALUES ('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}')", referencia, consecfatur, consparte, 1, "MA", "", "", "")
            objProc.ejecutaQuery(insideparma)
            id = 2
        End If

        dt = objProc.llenaDataSet(consulta, "ACC")

        For Each dr As DataRow In dt.Rows
            Dim insidepar As String = String.Format("INSERT INTO SAAIO_IDEPAR (NUM_REFE , CONS_FACT,CONS_PART , NUM_IDE , CVE_PERM, NUM_PERM,NUM_PERM2,NUM_PERM3) VALUES ('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}')", referencia, consecfatur, consparte, id, dr("Id_Identificador"), dr("Complemento_1"), dr("Complemento_2"), dr("Complemento_3"))
            If dr("Id_Identificador") <> "00" Then
                objProc.ejecutaQuery(insidepar)
            End If

            id = id + 1

        Next
        'Dim insidepar = String.Format("INSERT INTO SAAIO_IDEPAR (NUM_REFE , CONS_FACT,CONS_PART , NUM_IDE , CVE_PERM, NUM_PERM,NUM_PERM2,NUM_PERM3)  VALUES ('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}')", txtreferencia.Text, consecfatur, consparte, id, dr("Identiticador"), dr("Complemento1"), dr("Complemento2"), dr("Complemento3"))
        'objProc.ejecutaQuery(insidepar)
    End Sub
#Region "Extras"
    Function quitaacentos(ByVal texto As String)
        texto = Replace(texto, "á", "a", 1, Len(texto), 1)
        texto = Replace(texto, "é", "e", 1, Len(texto), 1)
        texto = Replace(texto, "í", "i", 1, Len(texto), 1)
        texto = Replace(texto, "ó", "o", 1, Len(texto), 1)
        texto = Replace(texto, "ú", "u", 1, Len(texto), 1)
        texto = Replace(texto, "ñ", "n", 1, Len(texto), 1)
        texto = Replace(texto, "ç", "c", 1, Len(texto), 1)

        texto = Replace(texto, "Á", "A", 1, Len(texto), 1)
        texto = Replace(texto, "É", "E", 1, Len(texto), 1)
        texto = Replace(texto, "Í", "I", 1, Len(texto), 1)
        texto = Replace(texto, "Ó", "O", 1, Len(texto), 1)
        texto = Replace(texto, "Ú", "U", 1, Len(texto), 1)
        texto = Replace(texto, "Ñ", "N", 1, Len(texto), 1)
        texto = Replace(texto, "Ç", "C", 1, Len(texto), 1)
        texto = Replace(texto, "-", "", 1, Len(texto), 1)
        texto = Replace(texto, "_", "", 1, Len(texto), 1)
        Return texto
    End Function
    Function regresaincoterm(ByVal idincoterm As String) As String
        Dim consulta As String = "select Clave from Incoterms where IDIncoterm=" + idincoterm
        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta, "ACC")
        For Each dr As DataRow In dt.Rows
            Return dr(0)
        Next
        Return ""
    End Function
    Function Traemoneda(ByVal idmoneda As String) As String
        Dim consulta As String = "select ClaveMoneda from Monedas where IDMoneda=" + idmoneda
        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta, "ACC")
        For Each dr As DataRow In dt.Rows
            Return dr(0)
        Next
        Return ""
    End Function
    Function regresapais(ByVal idpais As String) As String
        Dim consulta As String = "Select ClavePais from Paises where IDpais=" + idpais
        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta, "ACC")
        For Each dr As DataRow In dt.Rows
            Return dr(0)
        Next
        Return ""
    End Function
    Function regresaPV(ByVal idfactura As String) As String
        Dim consulta As String = "Select pais from [Pedimentos 3001 Facturas encabezado] where IDFactura=" + idfactura
        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta, "ACC")
        For Each dr As DataRow In dt.Rows
            Return dr(0)
        Next
        Return ""
    End Function
    Function regresaMA(ByVal idfactura As String, ByVal idpartida As String) As String
        Dim consulta As String = "Select MA_Datos from [Pedimentos 3002 Partidas de facturas] where IDFactura=" + idfactura + " and Idfacturapartidas = " + idpartida
        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta, "ACC")
        For Each dr As DataRow In dt.Rows
            Return IIf(dr(0), 1, 0)
        Next
        Return 0
    End Function
    Function vinculacion(ByVal idfactura As String) As String
        Dim consulta As String = "Select VinculacionCasa from [Pedimentos 3001 Facturas encabezado] where IDFactura=" + idfactura
        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consulta, "ACC")
        For Each dr As DataRow In dt.Rows
            Return IIf(dr(0).ToString() = "True", "1", 0)
        Next
        Return 0
    End Function
    Private Function quitarSaltosLinea(ByVal texto As String,
                caracterReemplazar As String) As String
        quitarSaltosLinea = Replace(Replace(texto, Chr(10),
                caracterReemplazar), Chr(13), caracterReemplazar)
    End Function
#End Region

    Private Sub txtreferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPedimento.TextChanged

    End Sub

    Private Sub UntilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UntilToolStripMenuItem.Click
        loginUntil.Show()
    End Sub

    Private Sub BorrarTraspasoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BorrarTraspasoToolStripMenuItem.Click
        Borrado.Show()

    End Sub

    Private Sub ConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigToolStripMenuItem.Click
        Config.Show()

    End Sub

    Private Sub RemesasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RemesasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemesasToolStripMenuItem.Click
        Remesas.Show()
    End Sub

    Private Sub LogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogToolStripMenuItem.Click
        conexion.Log.Show()
    End Sub

    Private Sub CuadroDeLiquidacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuadroDeLiquidacionToolStripMenuItem.Click
        CuadroDeLiquidaion.Show()
    End Sub
End Class
