Imports System.Text.RegularExpressions
Imports FirebirdSql.Data.FirebirdClient
Imports System.Text
Public Class ESTRUCTURA
    Dim objsql As New ClsProcesos
    Private Sub ESTRUCTURA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        hiloSegundoPlano.RunWorkerAsync()
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
        sqltablas.AppendLine("AND( RDB$RELATION_NAME LIKE 'SAAIO%' OR RDB$RELATION_NAME LIKE 'CTRAC%'")
        sqltablas.AppendLine("OR RDB$RELATION_NAME LIKE 'CTRAO%')")
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

                'Dim node2 As New TreeNode(drc(1).ToString())
                'Dim node3 As New TreeNode(drc(2).ToString())
                'Dim node4 As New TreeNode(drc(3).ToString())
                'Dim node5 As New TreeNode(drc(4).ToString())

                listacampos.Add(node1)
                'listacampos.Add(node2)
                'listacampos.Add(node3)
                'listacampos.Add(node4)
                'listacampos.Add(node5)
                'TreeNode[] array = new TreeNode[] { node2, node3 };

            Next

            Dim treeNode As TreeNode = New TreeNode(dr(0).ToString().Trim, listacampos.ToArray())
            ArbolHijo.Add(treeNode)

        Next
        Return ArbolHijo
    End Function

    Private Sub hiloSegundoPlano_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles hiloSegundoPlano.DoWork
        e.Result = getdatabaseinfo()
    End Sub

    Private Sub hiloSegundoPlano_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles hiloSegundoPlano.RunWorkerCompleted
        For Each var As TreeNode In e.Result
            treenav.Nodes.Add(var)
        Next

    End Sub
End Class