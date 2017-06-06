<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Remesas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpatente = New System.Windows.Forms.TextBox()
        Me.txtpedimento = New System.Windows.Forms.TextBox()
        Me.txtaduana = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtobscove = New System.Windows.Forms.TextBox()
        Me.dgvRemesas = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pbwait = New System.Windows.Forms.PictureBox()
        Me.hiloSegundoPlano = New System.ComponentModel.BackgroundWorker()
        CType(Me.dgvRemesas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbwait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(255, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Aduana"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Patente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Pedimento"
        '
        'txtpatente
        '
        Me.txtpatente.Location = New System.Drawing.Point(140, 66)
        Me.txtpatente.Name = "txtpatente"
        Me.txtpatente.Size = New System.Drawing.Size(100, 20)
        Me.txtpatente.TabIndex = 18
        Me.txtpatente.Text = "3805"
        '
        'txtpedimento
        '
        Me.txtpedimento.Location = New System.Drawing.Point(16, 66)
        Me.txtpedimento.Name = "txtpedimento"
        Me.txtpedimento.Size = New System.Drawing.Size(100, 20)
        Me.txtpedimento.TabIndex = 17
        Me.txtpedimento.Text = "17"
        '
        'txtaduana
        '
        Me.txtaduana.Location = New System.Drawing.Point(258, 66)
        Me.txtaduana.Name = "txtaduana"
        Me.txtaduana.Size = New System.Drawing.Size(100, 20)
        Me.txtaduana.TabIndex = 16
        Me.txtaduana.Text = "800"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(376, 63)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Ver Remesas"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(475, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Procesar!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtobscove
        '
        Me.txtobscove.Location = New System.Drawing.Point(16, 122)
        Me.txtobscove.Multiline = True
        Me.txtobscove.Name = "txtobscove"
        Me.txtobscove.Size = New System.Drawing.Size(342, 52)
        Me.txtobscove.TabIndex = 23
        Me.txtobscove.Text = "Informacion de remesas para el cove"
        '
        'dgvRemesas
        '
        Me.dgvRemesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRemesas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgvRemesas.Location = New System.Drawing.Point(12, 216)
        Me.dgvRemesas.Name = "dgvRemesas"
        Me.dgvRemesas.Size = New System.Drawing.Size(585, 150)
        Me.dgvRemesas.TabIndex = 24
        '
        'Column1
        '
        Me.Column1.FillWeight = 50.0!
        Me.Column1.HeaderText = "..."
        Me.Column1.Name = "Column1"
        '
        'pbwait
        '
        Me.pbwait.Image = Global.conexion.My.Resources.Resources.loading
        Me.pbwait.Location = New System.Drawing.Point(386, 12)
        Me.pbwait.Name = "pbwait"
        Me.pbwait.Size = New System.Drawing.Size(154, 107)
        Me.pbwait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbwait.TabIndex = 26
        Me.pbwait.TabStop = False
        Me.pbwait.Visible = False
        '
        'hiloSegundoPlano
        '
        Me.hiloSegundoPlano.WorkerReportsProgress = True
        Me.hiloSegundoPlano.WorkerSupportsCancellation = True
        '
        'Remesas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 448)
        Me.Controls.Add(Me.pbwait)
        Me.Controls.Add(Me.dgvRemesas)
        Me.Controls.Add(Me.txtobscove)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtpatente)
        Me.Controls.Add(Me.txtpedimento)
        Me.Controls.Add(Me.txtaduana)
        Me.Controls.Add(Me.Button2)
        Me.Name = "Remesas"
        Me.Text = "Remesas"
        CType(Me.dgvRemesas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbwait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpatente As System.Windows.Forms.TextBox
    Friend WithEvents txtpedimento As System.Windows.Forms.TextBox
    Friend WithEvents txtaduana As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtobscove As System.Windows.Forms.TextBox
    Friend WithEvents dgvRemesas As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pbwait As System.Windows.Forms.PictureBox
    Friend WithEvents hiloSegundoPlano As System.ComponentModel.BackgroundWorker
End Class
