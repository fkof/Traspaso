Imports System.Text.RegularExpressions
Imports FirebirdSql.Data.FirebirdClient
Imports System.Text

Public Class Form2
    Dim objsql As New ClsProcesos
    Dim isString As Boolean
    Private Sub txtconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtconsulta.KeyDown
        Dim I As Integer
        Dim cadena As String = txtconsulta.Text
        If txtconsulta.Text <> "" Then
            If e.KeyCode = 32 Then

                '   Buscar_Coincidencia("SELECT", txtconsulta, Color.Blue, Color.Red)
                '  Buscar_Coincidencia("FROM", txtconsulta, Color.Blue, Color.Red)

                'For I = 0 To txtconsulta.TextLength - 6
                '    If cadena.Substring(I, 6) = "SELECT" Then
                '        txtconsulta.Select(I, 6)
                '        txtconsulta.SelectionColor = Color.Red
                '        I = I + 1
                '    End If
                'Next
                'For I = 0 To txtconsulta.TextLength - 8
                '    If cadena.Substring(I, 8) = "function" Then
                '        txtconsulta.Select(I, 8)
                '        txtconsulta.SelectionColor = Color.Red
                '        I = I + 1
                '    End If
                'Next
            End If
        End If
    End Sub

    Private Sub txtconsulta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconsulta.KeyPress
        Dim text_query As String = ""
        text_query = txtconsulta.Text

        'If e.KeyChar = "'" Then
        '    isString = True
        'End If
        'If txtconsulta.Text <> "" Then


        Dim COMIENZO As Integer = txtconsulta.SelectionStart()
        Dim cadena As String = txtconsulta.Text
        For I = 0 To txtconsulta.TextLength - 6
            If UCase(cadena.Substring(I, 6)) = "SELECT" Then
                txtconsulta.Select(I, 6)
                txtconsulta.SelectionColor = Color.SteelBlue
                txtconsulta.SelectionFont = New Font("Tahoma", 12, FontStyle.Bold)
                txtconsulta.Select(txtconsulta.Text.Length(), txtconsulta.Text.Length())
                If isString Then
                    txtconsulta.SelectionColor = Color.Red
                Else
                    txtconsulta.SelectionColor = Color.Black
                    isString = False
                End If
                I = I + 1
            End If
        Next


        For I = 0 To txtconsulta.TextLength - 4
            If UCase(cadena.Substring(I, 4)) = "FROM" Then
                txtconsulta.Select(I, 4)
                txtconsulta.SelectionColor = Color.SteelBlue
                txtconsulta.Select(txtconsulta.Text.Length(), txtconsulta.Text.Length())
                If isString Then
                    txtconsulta.SelectionColor = Color.Red
                Else
                    txtconsulta.SelectionColor = Color.Black
                    isString = False
                End If
                I = I + 1
            End If
        Next

        For I = 0 To txtconsulta.TextLength - 5
            If UCase(cadena.Substring(I, 5)) = "WHERE" Then
                txtconsulta.Select(I, 5)
                txtconsulta.SelectionColor = Color.SteelBlue
                txtconsulta.Select(txtconsulta.TextLength, txtconsulta.TextLength)
                If isString Then
                    txtconsulta.SelectionColor = Color.Red
                Else
                    txtconsulta.SelectionColor = Color.Black
                    isString = False
                End If
                I = I + 1
            End If
        Next

        If e.KeyChar = "'" Then
            If isString Then
                txtconsulta.SelectionColor = Color.Black
                isString = False
            Else
                txtconsulta.SelectionColor = Color.Red
                isString = True
            End If
        End If

        txtconsulta.SelectionStart = COMIENZO

    End Sub

    Private Sub txtconsulta_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtconsulta.KeyUp
        If e.KeyCode = 32 Then


        
        End If
    End Sub
    Private Sub Buscar_Coincidencia(ByVal pattern As String, ByVal RichTextBox As RichTextBox, ByVal cColor As Color, ByVal BackColor As Color)
        Dim Resultados As MatchCollection
        Dim Palabra As Match

        Try
            ' PAsar el pattern e indicar que ignore las mayúsculas y minúsculas al mosmento de buscar  
            Dim obj_Expresion As New Regex(pattern.ToString, RegexOptions.IgnoreCase)

            ' Ejecutar el método Matches para buscar la cadena en el texto del control  
            ' y retornar un MatchCollection con los resultados  
            Resultados = obj_Expresion.Matches(RichTextBox.Text)

            ' quitar el coloreado anterior  
            With RichTextBox
                .SelectAll()
                .SelectionColor = Color.Black

            End With

            ' Si se encontraron coincidencias recorre las colección    
            For Each Palabra In Resultados
                With RichTextBox
                    .SelectionStart = Palabra.Index ' comienzo de la selección  
                    .SelectionLength = Palabra.Length ' longitud de la cadena a seleccionar  
                    .SelectionColor = cColor ' color de la selección  
                    .SelectionBackColor = BackColor
                    .Text = Palabra.Value
                    '   Debug.Print(Palabra.Value)
                End With
            Next Palabra

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sCmd As FbCommand
        Dim sql As String = ""
        Dim i As Integer
        Dim dt As New Data.DataTable



        sql = txtconsulta.Text
        dt = objsql.llenaDataSet(sql, "FB")
        DataGridView1.DataSource = dt

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtconsulta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtconsulta.TextChanged

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtpass.Focus()
        hiloSegundoPlano.RunWorkerAsync()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Function getdatabaseinfo() As List(Of TreeNode)
        Dim sCmd As FbCommand
        Dim sqltablas As New StringBuilder
        Dim sqlcampostablas As New StringBuilder
        Dim i As Integer
        Dim dttablas As New Data.DataTable
        Dim dtcampos As New Data.DataTable
        Dim ArbolHijo As New List(Of TreeNode)
        Dim listacampos As New List(Of TreeNode)

        sqltablas.AppendLine("SELECT RDB$RELATION_NAME")
        sqltablas.AppendLine("FROM RDB$RELATIONS")
        sqltablas.AppendLine("WHERE RDB$SYSTEM_FLAG = 0 AND")
        sqltablas.AppendLine("RDB$RELATION_NAME NOT IN (SELECT RDB$VIEW_NAME")
        sqltablas.AppendLine("FROM RDB$VIEW_RELATIONS)")
        '   sqltablas.AppendLine("AND( RDB$RELATION_NAME LIKE 'SAAIO%' OR RDB$RELATION_NAME LIKE 'CTRAC%'")
        '   sqltablas.AppendLine("OR RDB$RELATION_NAME LIKE 'CTRAO%')")
        sqltablas.AppendLine("ORDER BY RDB$RELATION_NAME ASC")

        dttablas = objsql.llenaDataSet(sqltablas.ToString(), "FB")
        For Each dr As DataRow In dttablas.Rows
            listacampos = New List(Of TreeNode)
            sqlcampostablas = New StringBuilder()
            sqlcampostablas.AppendLine("SELECT RDB$FIELD_NAME     AS NombreColumna,")
            sqlcampostablas.AppendLine("RDB$FIELD_POSITION AS PosicionColumna,")
            sqlcampostablas.AppendLine("RDB$DESCRIPTION    AS DescripcionColumna,")
            sqlcampostablas.AppendLine("RDB$DEFAULT_VALUE  AS ValorPorDefecto,")
            sqlcampostablas.AppendLine("RDB$NULL_FLAG      AS ColumnaNoNula")
            sqlcampostablas.AppendLine("FROM RDB$RELATION_FIELDS")
            sqlcampostablas.AppendLine(String.Format("WHERE    RDB$RELATION_NAME='{0}'", dr(0).ToString))

            dtcampos = objsql.llenaDataSet(sqlcampostablas.ToString(), "FB")

            For Each drc As DataRow In dtcampos.Rows
                Dim node1 As New TreeNode(drc(0).ToString())

                listacampos.Add(node1)

            Next

            Dim treeNode As TreeNode = New TreeNode(dr(0).ToString().Trim, listacampos.ToArray())
            ArbolHijo.Add(treeNode)

        Next
        Return ArbolHijo
    End Function

    Private Sub hiloSegundoPlano_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles hiloSegundoPlano.DoWork
        e.Result = getdatabaseinfo()
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub hiloSegundoPlano_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles hiloSegundoPlano.RunWorkerCompleted
        For Each var As TreeNode In e.Result
            treenav.Nodes.Add(var)
        Next

    End Sub

    Private Sub hiloSegundoPlano_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles hiloSegundoPlano.ProgressChanged
        'Dim algo As String
    End Sub

    Private Sub treenav_DoubleClick(sender As Object, e As EventArgs) Handles treenav.DoubleClick
       
    End Sub

    Private Sub treenav_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treenav.AfterSelect
        Dim node As TreeNode
        node = treenav.SelectedNode
        Dim FBSELECT As New StringBuilder()
        Dim FBFIELD As String = ""
        FBSELECT.AppendLine("SELECT FIRST 100 ")
        For Each nodos As TreeNode In node.Nodes
            If FBFIELD = "" Then
                FBFIELD += nodos.Text.Trim
            Else
                FBFIELD += "," + nodos.Text.Trim
            End If
        Next
        FBSELECT.AppendLine(FBFIELD)
        FBSELECT.AppendLine(" FROM " + node.Text)
        txtconsulta.Text = FBSELECT.ToString()
        If CheckBox1.Checked And FBFIELD <> "" Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If txtpass.Text.ToUpper = "HOLAMUNDO" Then
            Panel1.Hide()
        Else
            MsgBox("Password Erroneo!!")
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class