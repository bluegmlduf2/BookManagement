Public Class information
    Dim ds1, ds2 As DataSet
    Private Sub 情報_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        information()
    End Sub

    Public Sub information()
        ds1 = New DataSet
        ds2 = New DataSet

        SQL = "select count(*) from book"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds1, "book")
        Label5.Text = ds1.Tables("book").Rows(0).Item(0) & “冊”

        SQL = "select count(*) from member"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds1, "member")
        Label7.Text = ds1.Tables("member").Rows(0).Item(0) & “名”

        SQL = "select count(*) from book where b_lent<>'0'"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds2, "book")
        Label6.Text = ds2.Tables("book").Rows(0).Item(0) & “冊”

        SQL = "select count(*) from member where m_lent<>0"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds2, "member")
        Label8.Text = ds2.Tables("member").Rows(0).Item(0) & “名”

    End Sub
End Class