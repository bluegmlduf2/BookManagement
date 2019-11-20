Public Class inforbook
    Dim ds As DataSet

    Private Sub inforbook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        infor_book(Label20.Text)
    End Sub

    Public Sub infor_book(ByVal book_code As String)
        ds = New DataSet
        SQL = "select * from book where b_code='" + book_code + "'"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds, "book")
        Label11.Text = ds.Tables("book").Rows(0).Item(1) '타이틀
        Label13.Text = ds.Tables("book").Rows(0).Item(2) '저자'
        Label12.Text = ds.Tables("book").Rows(0).Item(3) '출판사
        Label17.Text = ds.Tables("book").Rows(0).Item(4) '발행일
        Label16.Text = ds.Tables("book").Rows(0).Item(5) '가격
        Dim lentYN As String = ds.Tables("book").Rows(0).Item(6) '렌트여부

        If lentYN Like "0" Then
            Label15.Text = "貸与可能"
        Else
            Label15.Text = "貸与できません。ID " &
                ds.Tables("book").Rows(0).Item(6) & "様が借りました。"
            TextBox1.Text = "貸与不可能"
            TextBox1.Enabled = False
            btnLent.Enabled = False
        End If

        If ds.Tables("book").Rows(0).Item(8).ToString <> "" Then
            Label14.Text = Strings.Left(ds.Tables("book").Rows(0).Item(8).ToString, 10) 'LEFT함수는 시간분초 자르기 위해 사용
            Label19.Text = Strings.Left(DateAdd("d", 10, ds.Tables("book").Rows(0).Item(8)), 10)
        Else
            Label14.Text = ""
            Label19.Text = ""
        End If

        Label18.Text = ds.Tables("book").Rows(0).Item(7) '대여횟수 
    End Sub

    Private Sub btnLent_Click(sender As Object, e As EventArgs) Handles btnLent.Click
        ds = New DataSet
        Ret = MsgBox("",, "確認")
    End Sub
End Class