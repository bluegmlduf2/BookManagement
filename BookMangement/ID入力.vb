Public Class memid
    Dim ds As DataSet

    Private Sub memid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub P_BookLent(ByVal Mid As String, ByVal Bcode As String)
        ds = New DataSet

        SQL = "update member set "
        SQL += " m_lent=m_lent+1,"
        SQL += " m_total_lent=m_total_lent+1"
        SQL += " where m_id='" & Mid & "'"

        Console.WriteLine(SQL)

        DCom.CommandText = SQL
        DCom.ExecuteNonQuery()
        DA.Fill(ds, "member")

        SQL = "update book set "
        SQL += " b_lent='" & Mid & "',"
        SQL += " b_lent_date='" & Now() & "',"
        SQL += " b_lent_num=b_lent_num+1"
        SQL += " where b_code='" & Bcode & "'"

        Console.WriteLine(SQL)

        DCom.CommandText = SQL
        DCom.ExecuteNonQuery()
        DA.Fill(ds, "book")
    End Sub
End Class