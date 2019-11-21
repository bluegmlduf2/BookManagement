Public Class inforLentUser
    Dim ds As DataSet

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub inforLentUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds = New DataSet
        SQL = "Select m_name from member where m_id='" + Label1.Text + "'"
        DA = New OleDb.OleDbDataAdapter(SQL, Con) 'SQL의 결과를 DA(어댑터)에 임시저장
        DA.Fill(ds, "member")

        GroupBox1.Text = ds.Tables("member").Rows(0).Item(0) & "(ID:" & Label1.Text & ")"

        inforUser()
    End Sub

    Public Sub inforUser()
        ds = New DataSet
        SQL = "select b_code,b_title,b_name,b_lent_date from book where b_lent='" + Label1.Text + "' order by cint(b_code) asc"
        DA = New OleDb.OleDbDataAdapter(SQL, Con) 'SQL의 결과를 DA(어댑터)에 임시저장
        Console.WriteLine(SQL)
        DA.Fill(ds, "book")

        Dim i As Integer
        Dim lentDate As String
        Dim returnDate As String

        i = 0
        ds.Tables("book").Columns.Add("대여일")
        ds.Tables("book").Columns.Add("반납일")

        Console.WriteLine(SQL)

        Do While i < ds.Tables("book").Rows.Count
            lentDate = Strings.Left(ds.Tables("book").Rows(i).Item(3), 10)
            returnDate = Strings.Left(DateAdd(DateInterval.Day, 10, ds.Tables("book").Rows(i).Item(3)), 10)
            ds.Tables("book").Rows(i).Item(4) = lentDate
            ds.Tables("book").Rows(i).Item(5) = returnDate
            i += 1
        Loop

        BindingSource1.DataSource = ds.Tables("book")
        DataGridView1.DataSource = BindingSource1
        infor_header()
        DataGridView1.Refresh()

    End Sub

    Public Sub infor_header()
        DataGridView1.Columns(0).HeaderText = "コード"
        DataGridView1.Columns(1).HeaderText = "タイトル"
        DataGridView1.Columns(2).HeaderText = "著者"
        DataGridView1.Columns(3).Visible = False
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        If TextBox1.Text = "" Then
            MsgBox("選択してください。",, “確認”)
        Else
            main.txtFind2.Text = TextBox1.Text
            Me.Close()
            main.RadioButton4.Checked = True
            main.btnLentOrReturn.PerformClick()

        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.Item(0, Int(DataGridView1.CurrentRow.Index)).Value
    End Sub
End Class