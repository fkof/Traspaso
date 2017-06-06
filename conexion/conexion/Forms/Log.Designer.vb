<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Log
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
        Me.dgvlog = New System.Windows.Forms.DataGridView()
        Me.rbError = New System.Windows.Forms.RadioButton()
        Me.rbFatal = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        CType(Me.dgvlog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvlog
        '
        Me.dgvlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlog.Location = New System.Drawing.Point(12, 58)
        Me.dgvlog.Name = "dgvlog"
        Me.dgvlog.Size = New System.Drawing.Size(1149, 414)
        Me.dgvlog.TabIndex = 0
        '
        'rbError
        '
        Me.rbError.AutoSize = True
        Me.rbError.Location = New System.Drawing.Point(22, 24)
        Me.rbError.Name = "rbError"
        Me.rbError.Size = New System.Drawing.Size(47, 17)
        Me.rbError.TabIndex = 1
        Me.rbError.TabStop = True
        Me.rbError.Text = "Error"
        Me.rbError.UseVisualStyleBackColor = True
        '
        'rbFatal
        '
        Me.rbFatal.AutoSize = True
        Me.rbFatal.Location = New System.Drawing.Point(88, 24)
        Me.rbFatal.Name = "rbFatal"
        Me.rbFatal.Size = New System.Drawing.Size(48, 17)
        Me.rbFatal.TabIndex = 2
        Me.rbFatal.TabStop = True
        Me.rbFatal.Text = "Fatal"
        Me.rbFatal.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(158, 24)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(43, 17)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Info"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(221, 24)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(62, 17)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.Text = "General"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 484)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.rbFatal)
        Me.Controls.Add(Me.rbError)
        Me.Controls.Add(Me.dgvlog)
        Me.Name = "Log"
        Me.Text = "Log"
        CType(Me.dgvlog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvlog As System.Windows.Forms.DataGridView
    Friend WithEvents rbError As System.Windows.Forms.RadioButton
    Friend WithEvents rbFatal As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
