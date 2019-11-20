Public Class home
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        main.MdiParent = Me
        member.MdiParent = Me
        book.MdiParent = Me
        information.MdiParent = Me

        DB_Acces()
        main.Show()

    End Sub

    Private Sub 도서관리ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 도서관리ToolStripMenuItem.Click
        book.Show()
    End Sub

    Private Sub 회원관리ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 회원관리ToolStripMenuItem1.Click
        member.Show()
    End Sub

    Private Sub 情報ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 情報ToolStripMenuItem.Click
        information.Show()
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
