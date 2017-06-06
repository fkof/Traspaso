Imports System.Xml

Public Class Config

    Private Sub btnAbrirAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrirAccess.Click
        Dim abrir As New OpenFileDialog
        If abrir.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtrutaacc.Text = abrir.FileName
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim arbol As New XmlDocument
            Dim nodo As XmlNode

            nodo = arbol.CreateElement("CONEXION")

            arbol.AppendChild(nodo)
            nodo = arbol.CreateElement("usuario")
            nodo.InnerText = txtusuario.Text
            arbol.DocumentElement.AppendChild(nodo)


            nodo = arbol.CreateElement("password")
            nodo.InnerText = txtpass.Text
            arbol.DocumentElement.AppendChild(nodo)

            nodo = arbol.CreateElement("servidor")
            nodo.InnerText = txtserver.Text
            arbol.DocumentElement.AppendChild(nodo)

            nodo = arbol.CreateElement("rutafb")
            nodo.InnerText = txtrutasvr.Text
            arbol.DocumentElement.AppendChild(nodo)

            nodo = arbol.CreateElement("rutaacc")
            nodo.InnerText = txtrutaacc.Text
            arbol.DocumentElement.AppendChild(nodo)
            arbol.Save(Application.StartupPath & "\config.xml")
            Dim fb As New ClsProcesos
            If fb.conectarfb() Then
                MsgBox("Conexion Exitosa!!", MsgBoxStyle.Information, "Traspaso")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Config_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If System.IO.File.Exists(Application.StartupPath & "\config.xml") Then
            loadconfig()
           
        Else
            createconfig()
            loadconfig()

        End If
    End Sub
    Sub loadconfig()
        Try

            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Creamos el "XML Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(Application.StartupPath & "\config.xml")
            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("CONEXION")
            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo
                txtusuario.Text = m_node.ChildNodes.Item(0).InnerText
                'Obtenemos el Elemento nombre
                txtpass.Text = m_node.ChildNodes.Item(1).InnerText
                'Obtenemos el Elemento apellido
                txtserver.Text = m_node.ChildNodes.Item(2).InnerText
                txtrutasvr.Text = m_node.ChildNodes.Item(3).InnerText
                txtrutaacc.Text = m_node.ChildNodes.Item(4).InnerText
                'Escribimos el resultado en la consola, 
                'pero tambien podriamos utilizarlos en
                'donde deseemos

            Next

        Catch ex As Exception

            'Error trapping

            Console.Write(ex.ToString())

        End Try

    End Sub
    Sub createconfig()
        Try
            Dim arbol As New XmlDocument
            Dim nodo As XmlNode

            nodo = arbol.CreateElement("CONEXION")

            arbol.AppendChild(nodo)
            nodo = arbol.CreateElement("usuario")
            nodo.InnerText = "SYSDBA"
            arbol.DocumentElement.AppendChild(nodo)


            nodo = arbol.CreateElement("password")
            nodo.InnerText = "masterkey"
            arbol.DocumentElement.AppendChild(nodo)

            nodo = arbol.CreateElement("servidor")
            nodo.InnerText = ""
            arbol.DocumentElement.AppendChild(nodo)

            nodo = arbol.CreateElement("rutafb")
            nodo.InnerText = ""
            arbol.DocumentElement.AppendChild(nodo)

            nodo = arbol.CreateElement("archivo")
            nodo.InnerText = ""
            arbol.DocumentElement.AppendChild(nodo)
            arbol.Save(Application.StartupPath & "\config.xml")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class