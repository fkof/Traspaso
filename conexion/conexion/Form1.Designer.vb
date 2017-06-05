<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbaccess = New System.Windows.Forms.RadioButton()
        Me.rbFB = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslRutaCasa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslRutaAcces = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtaduana = New System.Windows.Forms.TextBox()
        Me.txtPedimento = New System.Windows.Forms.TextBox()
        Me.txtpatente = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.UntilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarTraspasoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemesasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(377, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Procesar!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 150)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(464, 132)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 150)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(464, 132)
        Me.DataGridView1.TabIndex = 3
        Me.DataGridView1.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Hora"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Tipo"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Codigo"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Mensaje"
        Me.Column4.Name = "Column4"
        '
        'rbaccess
        '
        Me.rbaccess.AutoSize = True
        Me.rbaccess.Location = New System.Drawing.Point(23, 28)
        Me.rbaccess.Name = "rbaccess"
        Me.rbaccess.Size = New System.Drawing.Size(59, 17)
        Me.rbaccess.TabIndex = 4
        Me.rbaccess.Text = "access"
        Me.rbaccess.UseVisualStyleBackColor = True
        Me.rbaccess.Visible = False
        '
        'rbFB
        '
        Me.rbFB.AutoSize = True
        Me.rbFB.Checked = True
        Me.rbFB.Location = New System.Drawing.Point(148, 28)
        Me.rbFB.Name = "rbFB"
        Me.rbFB.Size = New System.Drawing.Size(59, 17)
        Me.rbFB.TabIndex = 5
        Me.rbFB.TabStop = True
        Me.rbFB.Text = "Firebird"
        Me.rbFB.UseVisualStyleBackColor = True
        Me.rbFB.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslRutaCasa, Me.ToolStripStatusLabel3, Me.tslRutaAcces})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 133)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(488, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(80, 17)
        Me.ToolStripStatusLabel1.Text = "Conectado a: "
        '
        'tslRutaCasa
        '
        Me.tslRutaCasa.Name = "tslRutaCasa"
        Me.tslRutaCasa.Size = New System.Drawing.Size(120, 17)
        Me.tslRutaCasa.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(77, 17)
        Me.ToolStripStatusLabel3.Text = "| Base Acces: "
        '
        'tslRutaAcces
        '
        Me.tslRutaAcces.Name = "tslRutaAcces"
        Me.tslRutaAcces.Size = New System.Drawing.Size(120, 17)
        Me.tslRutaAcces.Text = "ToolStripStatusLabel2"
        '
        'txtaduana
        '
        Me.txtaduana.Location = New System.Drawing.Point(249, 77)
        Me.txtaduana.Name = "txtaduana"
        Me.txtaduana.Size = New System.Drawing.Size(100, 20)
        Me.txtaduana.TabIndex = 7
        Me.txtaduana.Text = "800"
        '
        'txtPedimento
        '
        Me.txtPedimento.Location = New System.Drawing.Point(7, 77)
        Me.txtPedimento.Name = "txtPedimento"
        Me.txtPedimento.Size = New System.Drawing.Size(100, 20)
        Me.txtPedimento.TabIndex = 8
        Me.txtPedimento.Text = "17"
        '
        'txtpatente
        '
        Me.txtpatente.Location = New System.Drawing.Point(131, 77)
        Me.txtpatente.Name = "txtpatente"
        Me.txtpatente.Size = New System.Drawing.Size(100, 20)
        Me.txtpatente.TabIndex = 9
        Me.txtpatente.Text = "3805"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UntilToolStripMenuItem, Me.BorrarTraspasoToolStripMenuItem, Me.RemesasToolStripMenuItem, Me.ConfigToolStripMenuItem, Me.LogToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(488, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'UntilToolStripMenuItem
        '
        Me.UntilToolStripMenuItem.Name = "UntilToolStripMenuItem"
        Me.UntilToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.UntilToolStripMenuItem.Text = "Until"
        '
        'BorrarTraspasoToolStripMenuItem
        '
        Me.BorrarTraspasoToolStripMenuItem.Name = "BorrarTraspasoToolStripMenuItem"
        Me.BorrarTraspasoToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.BorrarTraspasoToolStripMenuItem.Text = "Borrar Traspaso"
        '
        'RemesasToolStripMenuItem
        '
        Me.RemesasToolStripMenuItem.Name = "RemesasToolStripMenuItem"
        Me.RemesasToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.RemesasToolStripMenuItem.Text = "Remesas"
        '
        'ConfigToolStripMenuItem
        '
        Me.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem"
        Me.ConfigToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ConfigToolStripMenuItem.Text = "Config"
        '
        'LogToolStripMenuItem
        '
        Me.LogToolStripMenuItem.Name = "LogToolStripMenuItem"
        Me.LogToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.LogToolStripMenuItem.Text = "Log"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Log System"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Pedimento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(128, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Patente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(246, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Aduana"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 155)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtpatente)
        Me.Controls.Add(Me.txtPedimento)
        Me.Controls.Add(Me.txtaduana)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.rbFB)
        Me.Controls.Add(Me.rbaccess)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Enlace BETA 1.1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents rbaccess As System.Windows.Forms.RadioButton
    Friend WithEvents rbFB As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslRutaCasa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslRutaAcces As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtaduana As System.Windows.Forms.TextBox
    Friend WithEvents txtPedimento As System.Windows.Forms.TextBox
    Friend WithEvents txtpatente As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents UntilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarTraspasoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RemesasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
