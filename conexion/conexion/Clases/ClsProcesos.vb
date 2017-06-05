

Imports FirebirdSql.Data.FirebirdClient
Imports System.Xml
Imports System.Text
Imports System.IO

Public Class ClsProcesos

    Dim conec As New OleDb.OleDbConnection
    Public fb_string As New StringBuilder
    ' Dim casa As String = "Server=192.168.1.76;User=admin;Password=admin;database=192.168.1.76:C:\CASA.GDB"
    Dim Conexion As New FbConnection

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger("ClsProcesos.vb")
    Public rutaacess As String ' = "Z:\SCS 4-8 Base.accdb" ' "D:\New folder\Dropbox\covos\SCS 4-8 Base.accdb" '"\\Nowgroup7\0 scs\Base\SCS 4-8 Base.accdb"
    Function conectarfb() As Boolean
        '      fb_string.ServerType = FbServerType.Embedded
        log4net.Config.XmlConfigurator.Configure()
        ' conectaracc()

        '        fb_string.UserID = "SYSDBA"
        '        fb_string.Password = "admin"
        '        fb_string.Dialect = 3
        '        fb_string.DataSource = "fkof-PC"
        '        fb_string.Port = 305
        '        fb_string.Database = "192.168.1.76:Z:\casa.gdb" ' "Nowgroup7:c:\CASAWIN\CSAAIWIN\DATOS\CASA.GDB"
        ''       fb_string.Pooling = False

        ' se realiza la conexion

        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Dim rutafb As String = String.Empty
            'Creamos el "XML Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(Application.StartupPath & "\config.xml")
            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("CONEXION")
            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo
                fb_string.Append("Server=")
                fb_string.Append(m_node.ChildNodes.Item(2).InnerText)
                fb_string.Append(";UserId=")
                fb_string.Append(m_node.ChildNodes.Item(0).InnerText)
                fb_string.Append(";Password=")
                fb_string.Append(m_node.ChildNodes.Item(1).InnerText)
                fb_string.Append(";database=")
                fb_string.Append(m_node.ChildNodes.Item(2).InnerText)
                fb_string.Append(":")
                fb_string.Append(m_node.ChildNodes.Item(3).InnerText)
                rutafb = m_node.ChildNodes.Item(2).InnerText + ":" + m_node.ChildNodes.Item(3).InnerText
                rutaacess = m_node.ChildNodes.Item(4).InnerText

            Next


            Conexion.ConnectionString = fb_string.ToString() '"Server=fkof-PC;UserId=SYSDBA;Password=masterkey;database=fkof-PC:C:\casa\kasatest\CASA.GDB;"
            'Conexion.ConnectionString = fb_string.ToString

            'Conexion.ConnectionString = "Driver={INTERSOLV InterBase ODBC Driver (*.gdb)};Server=192.168.1.76;Database=fkof-PC:C:\casa\CASA.gdb;Uid=admin;Pwd=admin"
            '"Password=admin;Dialect=3;Database=fkof-PC:C:\CASA.GDB"
            ' "User=admin;Password=admin;Database=fkof-PC:C:\CASA.GDB;DataSource=fkof-PC;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=1;" ' fb_string.ToString
            ' Conexion.ConnectionString = "Driver={INTERSOLV InterBase ODBC Driver (*.gdb)};Server=localhost;Database=localhost:C:\cassa\CASA.gdb;Uid=admin;Pwd=admin"
            'MsgBox(Conexion.DataSource)
            Conexion.Open()
            'crealog("CONEXION EXITOSA A CASA!!")
            If Conexion.State = ConnectionState.Open Then
                Form1.tslRutaCasa.Text = rutafb
                Return True
            End If

        Catch err As FbException
            '  MsgBox("Error: No se pudo realizar la conexión a [" & fb_string.Database & "]")
            MsgBox(err.Message)
            log.Error(err.Message)

            ' crealog(err.Message)
            Form1.TextBox1.Text = Form1.TextBox1.Text + err.Message + vbCrLf
            Form1.TextBox1.Visible = True
            Return False
        End Try
    End Function
    Function conectaracc() As Boolean
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Dim rutafb As String = String.Empty
            'Creamos el "XML Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(Application.StartupPath & "\config.xml")
            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("CONEXION")
            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo
             
                rutaacess = m_node.ChildNodes.Item(4).InnerText

            Next
        Catch err As FbException
            '  MsgBox("Error: No se pudo realizar la conexión a [" & fb_string.Database & "]")

            log.Error(err.Message)
            Form1.TextBox1.Text = Form1.TextBox1.Text + err.Message + vbCrLf
            Form1.TextBox1.Visible = True
            Return False
        End Try

        Dim cadenaaccess As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", rutaacess)
        '    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Nowgroup7\0 scs\Base\SCS 4-8 Base.accdb;Persist Security Info=False;"

        conec.ConnectionString = cadenaaccess
        Form1.tslRutaAcces.Text = rutaacess
        Try
            conec.Open()
            ' crealog("CONEXION EXITOSA A ACCESS!!")
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            log.Error(ex.Message)
            Form1.TextBox1.Text = Form1.TextBox1.Text + ex.Message + vbCrLf
            Form1.TextBox1.Visible = True
            Return False
        End Try

    End Function
    Sub closefb()
        Conexion.Close()
    End Sub
    Sub closeacc()
        conec.Close()
    End Sub
    Sub crealog(query As String)


        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String = Application.StartupPath & "\log.txt"

        'verificamos si existe el archivo

        If File.Exists(PathArchivo) Then
            strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
        Else
            strStreamW = File.Create(PathArchivo) ' lo creamos
        End If
        strStreamW.Close()
        Dim linea As String = String.Empty
        Dim CADENA As String = String.Empty
        Try

        
        Dim lector As New IO.StreamReader(PathArchivo)
       
        ' Leer el contenido mientras no se llegue al final

        While lector.Peek() <> -1


            linea = lector.ReadLine()

            ' Si no está vacía, añadirla al control

            ' Si está vacía, continuar el bucle

            If String.IsNullOrEmpty(linea) Then

                Continue While

            End If
                CADENA = CADENA + vbCrLf + linea

            'Aqui ya haces segun lo que deseas con la variable "linea"

            'tu modificas a tu necesidad 



        End While

        ' Cerrar el fichero

        lector.Close()

        Catch ex As Exception

        End Try
        Try
            strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


            'escribimos en el archivo
            CADENA = CADENA + vbCrLf + query
            strStreamWriter.WriteLine(CADENA)


            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("Error al Guardar la ingormacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
    End Sub
    ''' <summary>
    ''' regresa un data table
    ''' </summary>
    ''' <param name="query"> consulta en la base de datos</param>
    ''' <param name="bd">FB si es para bd Firebird</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function llenaDataSet(ByVal query As String, ByVal bd As String) As Data.DataTable
        Dim tblSQL As New Data.DataTable
        Try

            If bd = "FB" Then
                closefb()
                conectarfb()
                Dim daSQL As New FbDataAdapter(query, Conexion)
                daSQL.Fill(tblSQL)
                closefb()
            Else
                closeacc()
                conectaracc()
                Dim dasacc As New OleDb.OleDbDataAdapter(query, conec)
                dasacc.Fill(tblSQL)
                closeacc()
            End If

            ' crealog(query)
            llenaDataSet = tblSQL

        Catch ex As Exception
            MsgBox(ex.Message)
            log.Error(quitarSaltosLinea(ex.Message, ""))
            log.Info(query)
            ' crealog(query)
            log.Fatal(quitarSaltosLinea(ex.StackTrace, ""))
            Form1.TextBox1.Text = Form1.TextBox1.Text + "****Llena Data set*****" + vbCrLf + ex.Message + vbCrLf
            Form1.TextBox1.Visible = True
        End Try
    End Function
    Private Function quitarSaltosLinea(ByVal texto As String,
                    caracterReemplazar As String) As String
        quitarSaltosLinea = Replace(Replace(texto, Chr(10),
                caracterReemplazar), Chr(13), caracterReemplazar)
    End Function
    ''' <summary>
    ''' Ejecuta consulta simple (insert, update, delete)
    ''' </summary>
    ''' <param name="query">Cadena </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ejecutaQuery(ByVal query As String) As Boolean
        ' ''Dim trans As SqlTransaction
        Dim cmd As FbCommand

        Try
            closefb()
            If conectarfb() Then


                ' ''trans = cnnSQL.BeginTransaction()
                cmd = New FbCommand(query, Conexion)
                ' ''cmd.Transaction = trans
                cmd.ExecuteNonQuery()
                ' ''trans.Commit()
                '  crealog(query)
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error: ", ex.Message)
            log.Info(query)

            log.Error(quitarSaltosLinea(ex.Message, ""))
            log.Fatal(quitarSaltosLinea(ex.StackTrace, ""))
            Form1.TextBox1.Text = Form1.TextBox1.Text + "****Ejecuta Query*****" + vbCrLf + query + vbCrLf + ex.Message + vbCrLf
            Form1.TextBox1.Visible = True
            ' ''trans.Rollback()
            ' ''Throw ex.InnerException
            Return False
        Finally
            Conexion.Close()
        End Try
    End Function
End Class



