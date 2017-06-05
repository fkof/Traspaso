<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ESTRUCTURA
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.treenav = New System.Windows.Forms.TreeView()
        Me.hiloSegundoPlano = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'treenav
        '
        Me.treenav.Location = New System.Drawing.Point(3, 32)
        Me.treenav.Name = "treenav"
        Me.treenav.Size = New System.Drawing.Size(270, 467)
        Me.treenav.TabIndex = 6
        '
        'hiloSegundoPlano
        '
        Me.hiloSegundoPlano.WorkerReportsProgress = True
        Me.hiloSegundoPlano.WorkerSupportsCancellation = True
        '
        'ESTRUCTURA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 503)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.treenav)
        Me.Name = "ESTRUCTURA"
        Me.Text = "ESTRUCTURA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents treenav As System.Windows.Forms.TreeView
    Friend WithEvents hiloSegundoPlano As System.ComponentModel.BackgroundWorker
End Class
