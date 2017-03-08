<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.chkCompareSubfolders = New System.Windows.Forms.CheckBox()
        Me.chkSensitiveSubfolders = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 165)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(268, 46)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Check hash"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(75, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(205, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "C:\GEYMER CATALOGO OK\Catalogo Geymer JPG NUEVO\Abalorios"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(75, 39)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(205, 20)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "C:\GEYMER CATALOGO OK\Catalogo Geymer JPG NUEVO\Abalorios"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Path 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Path 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(12, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Path can be Folders or Files"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 223)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(268, 23)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Fork me on GitHub!"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkCompareSubfolders
        '
        Me.chkCompareSubfolders.AutoSize = True
        Me.chkCompareSubfolders.Checked = True
        Me.chkCompareSubfolders.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompareSubfolders.Location = New System.Drawing.Point(15, 107)
        Me.chkCompareSubfolders.Name = "chkCompareSubfolders"
        Me.chkCompareSubfolders.Size = New System.Drawing.Size(119, 17)
        Me.chkCompareSubfolders.TabIndex = 7
        Me.chkCompareSubfolders.Text = "Compare subfolders"
        Me.ToolTip1.SetToolTip(Me.chkCompareSubfolders, "(Only for subfolders) If checked it will check the subfolders when path is a fold" & _
        "er.")
        Me.chkCompareSubfolders.UseVisualStyleBackColor = True
        '
        'chkSensitiveSubfolders
        '
        Me.chkSensitiveSubfolders.AutoSize = True
        Me.chkSensitiveSubfolders.Checked = True
        Me.chkSensitiveSubfolders.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSensitiveSubfolders.Location = New System.Drawing.Point(15, 130)
        Me.chkSensitiveSubfolders.Name = "chkSensitiveSubfolders"
        Me.chkSensitiveSubfolders.Size = New System.Drawing.Size(120, 17)
        Me.chkSensitiveSubfolders.TabIndex = 8
        Me.chkSensitiveSubfolders.Text = "Sensitive subfolders"
        Me.ToolTip1.SetToolTip(Me.chkSensitiveSubfolders, "(Only for subfolders) If checked, the name of the folders will affect to the end " & _
        "md5")
        Me.chkSensitiveSubfolders.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 260)
        Me.Controls.Add(Me.chkSensitiveSubfolders)
        Me.Controls.Add(Me.chkCompareSubfolders)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "MD5 File and Directory comparer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents chkCompareSubfolders As System.Windows.Forms.CheckBox
    Friend WithEvents chkSensitiveSubfolders As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
