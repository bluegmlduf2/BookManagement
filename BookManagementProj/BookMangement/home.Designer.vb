<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.도서관리ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.회원관리ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.情報ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.도서관리ToolStripMenuItem, Me.회원관리ToolStripMenuItem1, Me.情報ToolStripMenuItem, Me.終了ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '도서관리ToolStripMenuItem
        '
        Me.도서관리ToolStripMenuItem.Name = "도서관리ToolStripMenuItem"
        Me.도서관리ToolStripMenuItem.Size = New System.Drawing.Size(82, 24)
        Me.도서관리ToolStripMenuItem.Text = "図書館利"
        '
        '회원관리ToolStripMenuItem1
        '
        Me.회원관리ToolStripMenuItem1.Name = "회원관리ToolStripMenuItem1"
        Me.회원관리ToolStripMenuItem1.Size = New System.Drawing.Size(82, 24)
        Me.회원관리ToolStripMenuItem1.Text = "会員管理"
        '
        '情報ToolStripMenuItem
        '
        Me.情報ToolStripMenuItem.Name = "情報ToolStripMenuItem"
        Me.情報ToolStripMenuItem.Size = New System.Drawing.Size(51, 24)
        Me.情報ToolStripMenuItem.Text = "情報"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(51, 24)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 578)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "図書管理システム"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 도서관리ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 회원관리ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 情報ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
End Class
