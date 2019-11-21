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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        ds = New DataSet
        If Trim(txtID.Text) = "" Then
            MsgBox(”IDを入力してください”,, ”確認”)
            txtID.Text = ""
            txtID.Focus()
        Else
            Ret = MsgBox(”図書を貸与しますか？”, vbYesNo, ”確認”)

            If Ret = vbYes Then
                SQL = "Select * from member where m_id='" + txtID.Text + "'"
                DA = New OleDb.OleDbDataAdapter(SQL, Con) 'SQL의 결과를 DA(어댑터)에 임시저장
                DA.Fill(ds, "member")

                If ds.Tables("member").Rows.Count = 0 Then
                    MsgBox("登録された会員ではありません。", vbOKOnly, "確認")
                    txtID.Text = ""
                    txtID.Focus()
                    Return
                End If
                P_BookLent(txtID.Text, main.txtFind2.Text)
                main.list_search("", "")
                main.lent_id()
                main.txtFind2.Text = ""
                MsgBox("貸与されました。" & vbCrLf & "貸与期限を守ってください。", vbOKOnly, "確認")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk.PerformClick()
        End If
    End Sub
End Class