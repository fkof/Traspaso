
Public Class Remesas
    Dim objProc As New ClsProcesos
    Dim objEnFac As New ClsEncFactura
    Dim objpartidas As New ClsFacturaPartidas
    Dim objpedimento As New ClsPedimento
    Dim id_salida As String
    Dim ini As log4net.Config.XmlConfigurator

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger("conexion.Remesas.vb")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pbwait.Visible = True

        Try

            For Each dtrow As DataGridViewRow In dgvRemesas.Rows
                Dim idselected = Convert.ToBoolean(dtrow.Cells(0).Value)

            Next

            ' Return
            Dim CONSEG As String
            Dim rem_num As Integer = 1
            Dim consultaemb As String = String.Format("SELECT * From SAAIO_PEDIME Where NUM_REFE='{0}' and PAT_AGEN = {1} and ADU_DESP = {2}", txtpedimento.Text.Trim, txtpatente.Text.Trim, txtaduana.Text.Trim)
            Dim dt As New DataTable
            Dim consecutivo As Integer
            dt = objProc.llenaDataSet(consultaemb, "FB")
            If dt.Rows.Count > 0 Then
                CONSEG = String.Format("SELECT MAX(CONS_FACT) AS FAC,MAX(NUM_REM) AS REM FROM SAAIO_FACTUR WHERE NUM_REFE  ='{0}'", txtpedimento.Text.Trim)
                dt = objProc.llenaDataSet(CONSEG, "FB")
                For Each CROWS As DataRow In dt.Rows
                    If CROWS(0).ToString > 0 Then
                        consecutivo = CROWS(0).ToString
                        consecutivo = consecutivo + 1
                    Else
                        consecutivo = 1
                    End If
                    If CROWS(1).ToString > 0 Then
                        rem_num = CROWS(1).ToString
                        rem_num = rem_num + 1

                    Else
                        rem_num = 1
                    End If


                Next

                For Each dtrow As DataGridViewRow In dgvRemesas.Rows
                    Dim idselected = Convert.ToBoolean(dtrow.Cells(0).Value)
                    If idselected Then


                        objEnFac.PES_BRUT = dtrow.Cells(26).Value 'rows("Peso bruto").ToString()
                        objEnFac.CAN_BULT = dtrow.Cells(22).Value 'rows("Bultos").ToString()
                        objEnFac.DAT_VEHI = dtrow.Cells(23).Value ' rows("NumVehiculo")
                        objEnFac.ObsCove = txtobscove.Text.Trim '"Remesa de prueba traspaso"
                        objEnFac.CONTENEDOR = dtrow.Cells(24).Value


                        Dim CVE_PRO As String
                        Dim NOM_PRO As String
                        Dim DIR_PRO As String
                        Dim POB_PRO As String
                        Dim ZIP_PRO As String
                        Dim TAX_PRO As String
                        Dim NOINT As String
                        Dim NOEXT As String
                        id_salida = dtrow.Cells(2).Value
                        'Traes la informacion del encabezado
                        Dim consulta As String = String.Format("SELECT * FROM [Pedimentos 3001 Facturas encabezado] where idSalida={0} order by [IDVendedor Proveedor],NumFacturaFac asc", id_salida) 'rows("idsalidaint"))
                        dt = New DataTable
                        dt = objProc.llenaDataSet(consulta, "ACC")

                        For Each dr As Data.DataRow In dt.Rows
                            objEnFac.IdAccess = dr("IDFactura")
                            objEnFac.NoFac = dr("NumFacturaFac")
                            objEnFac.FechaFac = dr("FechaFacturaFac")
                            objEnFac.Incoterm = dr("Incoterm")
                            objEnFac.ValDlls = System.Decimal.Round(dr("Valortotalfactura"), 2)
                            objEnFac.ValExtr = System.Decimal.Round(dr("Valortotalfactura"), 2)
                            objEnFac.EquDlls = 1
                            objEnFac.NoFac2 = dr("NumFacturaFac")
                            objEnFac.MonFac = dr("Monedadefacturacion")
                            If txtpatente.Text.Trim = 3778 Then
                                objEnFac.CveProv = dr("Kalisch IDVendedor")
                            Else
                                objEnFac.CveProv = dr("IDVendedor Proveedor")
                            End If

                            objEnFac.Consec = consecutivo
                            objEnFac.Referencia = txtpedimento.Text.Trim
                            objEnFac.Num_Rem = rem_num

                            consecutivo = consecutivo + 1
                            ' objEnFac.ObsCove = "SE DECLARAN DATOS CORRECTOS DE IMPORTADOR, PROVEEDOR, FACTURA Y MERCANCIA"
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
                                NOM_PRO = LCase(Form1.quitaacentos(dr("Nombre_Provee")))
                                Dim direccion As String = String.Format("{0} {1} {2}", dr("Calle"), IIf(IsDBNull(dr("Numero")), "", dr("Numero")), IIf(IsDBNull(dr("Numero_Int")), "", dr("Numero_Int")))
                                direccion = Form1.quitaacentos(direccion)
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

                            ' If objEnFac.validafactura(txtpedimento.Text, objEnFac.CveProv, objEnFac.NoFac) Then
                            'insertar encabezado de factura
                            If objEnFac.creafacturarem(objEnFac) Then
                                PartidasFactura(objEnFac.IdAccess, objEnFac.Consec)

                                objEnFac.PES_BRUT = 0
                                objEnFac.CAN_BULT = 0
                                objEnFac.DAT_VEHI = ""
                                objEnFac.ObsCove = ""
                                objEnFac.CONTENEDOR = 0

                            Else
                                MsgBox("Error al insertar el Encabezado de la factura")
                            End If
                            '   End If
                        Next
                        rem_num = rem_num + 1
                    End If
                Next

                MsgBox("Traspaso Exitoso!!")
                pbwait.Visible = False
            Else
                pbwait.Visible = False
            End If

        Catch ex As Exception
            pbwait.Visible = False
            log.Info("Error en try de remesas")
            conexion.Log.Show()
        End Try
    End Sub
    Sub PartidasFactura(ByVal idfactura As String, ByVal consecutivo As Integer)
        'Consulta de las partidas de access
        Try

     
        Dim consparti As String = String.Format("SELECT * FROM [Pedimentos 3002 Partidas de facturas] WHERE IDFactura={0} and IdSalida={1}", idfactura, id_salida)
        Dim dtparti As New DataTable
        Dim consecpartida As Integer = 1
        dtparti = objProc.llenaDataSet(consparti, "ACC")
        For Each drparti As DataRow In dtparti.Rows
            objpartidas.IdPacc = drparti("Idfacturapartidas")
            objpartidas.Referencia = txtpedimento.Text
            objpartidas.consecutivoFactura = consecutivo
            objpartidas.consecutivo = drparti("Numero_Partida")
            objpartidas.NoPart = drparti("NumeroParteFac")
            objpartidas.PO = drparti("Origenpartida")
            objpartidas.PV = Form1.regresaPV(idfactura)
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
                objpartidas.VIN = Form1.vinculacion(idfactura)
            Else
                objpartidas.VIN = 0
            End If

            objpartidas.Adval = 0
            objpartidas.Total = IIf(IsDBNull(drparti("Valor_Total_Partida")), "0", drparti("Valor_Total_Partida"))
            objpartidas.Modena = drparti("Moneda_Facturacion")
            objpartidas.PesoUni = IIf(IsDBNull(drparti("PesoPartidaKgsFac")), "0", drparti("PesoPartidaKgsFac"))
            objpartidas.CantFactur = drparti("CantEnSalidas")

            objpartidas.UMC = drparti("UMFac")
            objpartidas.UMT = drparti("UM_Tarifa")
            If objpartidas.UMC = objpartidas.UMT Then
                objpartidas.CantTar = drparti("CantEnSalidas")
            Else
                If objpartidas.UMT = "1" Then
                    objpartidas.CantTar = IIf(IsDBNull(drparti("PesoPartidaKgsFac")), 0, drparti("PesoPartidaKgsFac"))
                Else
                    objpartidas.CantTar = "0"
                End If
            End If



            objpartidas.Descripcion = Form1.quitaacentos(drparti("Descripcion_Parte"))
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
            objpartidas.CantCove = drparti("CantEnSalidas")
            objpartidas.UnidadCove = drparti("UMFac")
            objpartidas.Marca = IIf(IsDBNull(drparti("Marca")), "", drparti("Marca"))
            objpartidas.Modelo = IIf(IsDBNull(drparti("Modelo")), "", drparti("Modelo")) ' drparti("Modelo")
            objpartidas.Serie = IIf(IsDBNull(drparti("Serie")), "", drparti("Serie")) ' drparti("Serie")
            If objpartidas.creapartida(objpartidas) Then
                '    creaseries(objpartidas.Marca, objpartidas.Modelo, objpartidas.Serie, objpartidas.consecutivoFactura, objpartidas.consecutivo, objpartidas.NoPart)
                '   insidepar(objEnFac.IdAccess, objpartidas.IdPacc, objpartidas.consecutivoFactura, objpartidas.consecutivo)
                'cambio la estructura necesito que se mande el id de la factura por que no se de que factura es el identificador o se pone en todas las facturas?
                'ahi que onda
            Else

            End If
            consecpartida = consecpartida + 1

        Next
        Catch ex As Exception
            log.Info("Error en Try de partidas")
        End Try
        hiloSegundoPlano.CancelAsync()
        pbwait.Visible = False
    End Sub

    Private Sub Remesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        log4net.Config.XmlConfigurator.Configure()

        'Dim TextFieldParser1 As New Microsoft.VisualBasic.FileIO.TextFieldParser("log.log")
        'Dim dtr As New DataTable
        'dtr.Columns.Add("Hora")
        'dtr.Columns.Add("Tipo")
        'dtr.Columns.Add("Objeto")
        'dtr.Columns.Add("Mensaje")
        'TextFieldParser1.Delimiters = New String() {"|"}
        'While Not TextFieldParser1.EndOfData
        '    Dim Row1 As String() = TextFieldParser1.ReadFields()


        '    dtr.Rows.Add(Row1)
        '    '  dgvRemesas.Rows.Add(Row1)
        '    If Row1(1).ToString = "DEBUG" Then


        '    End If
        '    Form1.DataGridView1.Rows.Add(Row1)
        'End While

        'dgvRemesas.DataSource = dtr


        '' dgvRemesas.DataSource = dt

     

    End Sub

    Private Sub txtpedimento_TextChanged(sender As Object, e As EventArgs) Handles txtpedimento.TextChanged
       
      

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim consultaemb As String = String.Format("SELECT * from [Pedimentos 5001 Encabezado] where pedimento = {0}", txtpedimento.Text.Trim)
        Dim dt As New DataTable
        dt = objProc.llenaDataSet(consultaemb, "ACC")
        dgvRemesas.DataSource = dt
    End Sub

    Private Sub dgvRemesas_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvRemesas.DataBindingComplete
        'For i = 0 To dgvRemesas.Rows.Count - 1

        '    Select Case dgvRemesas.Rows(i).Cells(1).Value
        '        Case "DEBUG"
        '            dgvRemesas.Rows(i).DefaultCellStyle.BackColor = Color.Green

        '        Case "INFO"
        '            dgvRemesas.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue

        '        Case "WARN"
        '            dgvRemesas.Rows(i).DefaultCellStyle.BackColor = Color.Yellow

        '        Case "ERROR"
        '            dgvRemesas.Rows(i).DefaultCellStyle.BackColor = Color.Red

        '        Case "FATAL"
        '            dgvRemesas.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed

        '    End Select


        'Next
    End Sub

    Private Sub dgvRemesas_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvRemesas.RowsAdded
  
    End Sub

    Private Sub hiloSegundoPlano_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles hiloSegundoPlano.DoWork

    End Sub
End Class