Public Class Log
    Dim dtr As New DataTable
    Private Sub Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        log4net.Config.XmlConfigurator.Configure()

        Dim TextFieldParser1 As New Microsoft.VisualBasic.FileIO.TextFieldParser("log.log")

        dtr.Columns.Add("Hora")
        dtr.Columns.Add("Tipo")
        dtr.Columns.Add("Objeto")
        dtr.Columns.Add("Mensaje")

        TextFieldParser1.Delimiters = New String() {"|"}
        While Not TextFieldParser1.EndOfData
            Dim Row1 As String() = TextFieldParser1.ReadFields()


            dtr.Rows.Add(Row1)

            Form1.DataGridView1.Rows.Add(Row1)
        End While
        Dim results As DataRow() = dtr.Select("", "Hora desc")
        Dim dtr2 As New DataTable
        dtr2.Columns.Add("Hora")
        dtr2.Columns.Add("Tipo")
        dtr2.Columns.Add("Objeto")
        dtr2.Columns.Add("Mensaje")

        For Each row As DataRow In results

            dtr2.Rows.Add(row(0), row(1), row(2), row(3))
        Next
        dgvlog.DataSource = dtr2
        dgvlog.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        dgvlog.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub dgvlog_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvlog.DataBindingComplete
        For i = 0 To dgvlog.Rows.Count - 1

            Select Case dgvlog.Rows(i).Cells(1).Value
                Case "DEBUG"
                    dgvlog.Rows(i).DefaultCellStyle.BackColor = Color.Green

                Case "INFO"
                    dgvlog.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue

                Case "WARN"
                    dgvlog.Rows(i).DefaultCellStyle.BackColor = Color.Yellow

                Case "ERROR"
                    dgvlog.Rows(i).DefaultCellStyle.BackColor = Color.Red

                Case "FATAL"
                    dgvlog.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed

            End Select


        Next
    End Sub

    Private Sub rbError_CheckedChanged(sender As Object, e As EventArgs) Handles rbError.CheckedChanged
        Dim results As DataRow() = dtr.Select("Tipo = 'Error'", "Hora desc")
        Dim dtr2 As New DataTable
        dtr2.Columns.Add("Hora")
        dtr2.Columns.Add("Tipo")
        dtr2.Columns.Add("Objeto")
        dtr2.Columns.Add("Mensaje")

        For Each row As DataRow In results

            dtr2.Rows.Add(row(0), row(1), row(2), row(3))
        Next
        dgvlog.DataSource = dtr2
        dgvlog.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        dgvlog.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
        'dgvlog.SortOrder.Descending = SortOrder.Descending

    End Sub

    Private Sub rbFatal_CheckedChanged(sender As Object, e As EventArgs) Handles rbFatal.CheckedChanged
        Dim results As DataRow() = dtr.Select("Tipo = 'Fatal'", "Hora desc")
        Dim dtr2 As New DataTable
        dtr2.Columns.Add("Hora")
        dtr2.Columns.Add("Tipo")
        dtr2.Columns.Add("Objeto")
        dtr2.Columns.Add("Mensaje")

        For Each row As DataRow In results

            dtr2.Rows.Add(row(0), row(1), row(2), row(3))
        Next
        dgvlog.DataSource = dtr2
        dgvlog.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        dgvlog.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
        'dgvlog.SortOrder.Descending = SortOrder.Descending

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Dim results As DataRow() = dtr.Select("Tipo = 'Info'", "Hora desc")
        Dim dtr2 As New DataTable
        dtr2.Columns.Add("Hora")
        dtr2.Columns.Add("Tipo")
        dtr2.Columns.Add("Objeto")
        dtr2.Columns.Add("Mensaje")

        For Each row As DataRow In results

            dtr2.Rows.Add(row(0), row(1), row(2), row(3))
        Next
        dgvlog.DataSource = dtr2
        dgvlog.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        dgvlog.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
        'dgvlog.SortOrder.Descending = SortOrder.Descending

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim results As DataRow() = dtr.Select("", "Hora desc")
        Dim dtr2 As New DataTable
        dtr2.Columns.Add("Hora")
        dtr2.Columns.Add("Tipo")
        dtr2.Columns.Add("Objeto")
        dtr2.Columns.Add("Mensaje")

        For Each row As DataRow In results

            dtr2.Rows.Add(row(0), row(1), row(2), row(3))
        Next
        dgvlog.DataSource = dtr2
        dgvlog.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        dgvlog.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
        'dgvlog.SortOrder.Descending = SortOrder.Descending

    End Sub
End Class