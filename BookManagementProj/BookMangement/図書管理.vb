Imports System.Reflection

Public Class book
    Dim ds As DataSet

    Public addBYesNo As Boolean
    Public updateBYesNo As Boolean

    Private b_title As String
    Private b_name As String
    Private b_publishing As String
    Private b_date As String

    Public Sub booklist()
        ds = New DataSet
        SQL = "select * from book order by CInt(b_code) asc"
        'DCom.CommandText = SQL
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        ''여기까지 DB에서 데이터얻어오는 과정 그 뒤로 book이라는 가상 테이블을 만들어서 에 데이터 박음
        DA.Fill(ds, "book")

        'SQL확인
        Console.WriteLine(SQL)

        BindingSource1.DataSource = ds.Tables("book") 'dataset의 book테이블의 정보를 바인딩함
        DataGridView1.DataSource = BindingSource1 '바인딩한 정보를 그리드 뷰에 박음

        book_counter()

        book_header()

        DataGridView1.Refresh()
    End Sub

    Public Sub book_counter()
        Dim i As Integer
        i = DataGridView1.RowCount
        Label3.Text = "総" + i.ToString + "冊"
    End Sub

    '그리드에서 column은 헤드부분을 뜻함
    '그리드에서 item은 행의 컬럼부분을 뜻함
    Public Sub book_header()
        DataGridView1.Columns(0).HeaderText = "コード"
        DataGridView1.Columns(1).HeaderText = "タイトル"
        DataGridView1.Columns(2).HeaderText = "著者"
        DataGridView1.Columns(3).HeaderText = "出版社"
        DataGridView1.Columns(4).HeaderText = "発行日"
        DataGridView1.Columns(5).HeaderText = "価格"
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False

        'DataGridView1.Columns(0).Width = 60
        'DataGridView1.Columns(1).Width = 110
        'DataGridView1.Columns(2).Width = 80
        'DataGridView1.Columns(3).Width = 80
        'DataGridView1.Columns(4).Width = 80
        'DataGridView1.Columns(5).Width = 60
    End Sub

    Private Sub book_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: 이 코드는 데이터를 'LibraryDataSet.book' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
        Me.BookTableAdapter.Fill(Me.LibraryDataSet.book)
        Call booklist()
        Left = 0

        txtCode.Enabled = False
        txtTitle.Enabled = False
        txtName.Enabled = False
        txtPublishing.Enabled = False
        txtData0.Enabled = False
        txtData1.Enabled = False
        txtData2.Enabled = False
        txtPrice.Enabled = False

        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = True
        btnDel.Enabled = True
        btnCancel.Enabled = False

    End Sub

    '추가버튼
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        txtCode.Enabled = True
        txtTitle.Enabled = True
        txtName.Enabled = True
        txtPublishing.Enabled = True
        txtData0.Enabled = True
        txtData1.Enabled = True
        txtData2.Enabled = True
        txtPrice.Enabled = True

        txtCode.Text = ""
        txtTitle.Text = ""
        txtName.Text = ""
        txtPublishing.Text = ""
        txtData0.Text = ""
        txtData1.Text = ""
        txtData2.Text = ""
        txtPrice.Text = ""

        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnDel.Enabled = False
        btnCancel.Enabled = True

        txtCode.Focus()
        addBYesNo = True

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ds = New DataSet
        '새로운 데이터셋을 만들어줘야함 아니면 다른곳에서 쓰던 데이터셋 그대로 사용
        '예를들어서 전에 사용하던 데이터셋에서
        'book이라는 테이블을 만들어서 데이터를 4개 넣고 여기서 다시 book이라는 테이블에 데이터를 1개 넣으면 
        '중복되어서 해당 Dataset의 book이라는 테이블에 데이터는 5개가 된다

        If addBYesNo = True Then
            '동적호출알아볼것..
            'Dim arr() As String = {"Code", "Title", "Name", "Publishing", "Data0", "Data1", "Data2", "Price"}
            '동적  속성 호출 불가..eval같은 함수 찾는데 못찾음
            'For i = 1 To UBound(arr)
            '    Dim rVal As String = "txt" + arr(i)

            '    If Trim(rVal + ".Text") = "" Then
            '        MsgBox(rVal + ".tag" + "を入力してください", vbOKOnly, "確認")
            '        'rVal+".tag" + ".Focus()"
            '        Return
            '    End If
            'Next

            If Trim(txtCode.Text) = "" Then
                MsgBox(txtCode.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtTitle.Text) = "" Then
                MsgBox(txtTitle.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtName.Text) = "" Then
                MsgBox(txtName.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtPublishing.Text) = "" Then
                MsgBox(txtPublishing.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtData0.Text) = "" Then
                MsgBox(txtData0.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtData1.Text) = "" Then
                MsgBox(txtData1.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtData2.Text) = "" Then
                MsgBox(txtData2.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtPrice.Text) = "" Then
                MsgBox(txtPrice.Tag + "を入力してください", vbOKOnly, "確認")
            Else
                '모두 만족 할 경우 db에 쿼리 날림'
                SQL = "select * from book where b_code='" + txtCode.Text + "'"
                DA = New OleDb.OleDbDataAdapter(SQL, Con)
                DA.Fill(ds, "book")

                Console.WriteLine(SQL)

                If ds.Tables("book").Rows.Count = 0 Then
                    b_title = txtTitle.Text
                    b_name = txtName.Text
                    b_publishing = txtPublishing.Text
                    b_date = txtData0.Text + "-" + txtData1.Text + "-" + txtData2.Text

                    SQL = "insert into book(b_code,b_title,b_name,b_publishing,b_date,b_price,b_lent,b_lent_num) values ("
                    SQL += "'" + txtCode.Text + "',"
                    SQL += "'" + b_title + "',"
                    SQL += "'" + b_name + "',"
                    SQL += "'" + b_publishing + "',"
                    SQL += "'" + b_date + "',"
                    SQL += "'" + txtPrice.Text + "','0','0')"

                    Console.WriteLine(SQL)

                    DCom.CommandText = SQL
                    DCom.ExecuteNonQuery()

                    txtCode.Text = ""
                    txtTitle.Text = ""
                    txtName.Text = ""
                    txtPublishing.Text = ""
                    txtData0.Text = ""
                    txtData1.Text = ""
                    txtData2.Text = ""
                    txtPrice.Text = ""

                    txtCode.Enabled = False
                    txtTitle.Enabled = False
                    txtName.Enabled = False
                    txtPublishing.Enabled = False
                    txtData0.Enabled = False
                    txtData1.Enabled = False
                    txtData2.Enabled = False
                    txtPrice.Enabled = False

                    btnAdd.Enabled = True
                    btnSave.Enabled = False
                    btnEdit.Enabled = True
                    btnDel.Enabled = True
                    btnCancel.Enabled = False

                    addBYesNo = False
                    MsgBox("図書登録完了", vbOKOnly, "確認")
                Else
                    MsgBox("既に登録された図書がございます", , "確認")
                    txtCode.Text = ""
                    txtCode.Focus()
                End If
                booklist()
                main.list_search("", "")
            End If
        ElseIf updateBYesNo = True Then
            If txtCode.Text = "" Then
                MsgBox("修正するコードを選んでください", vbOKOnly, "確認")
            Else
                Ret = MsgBox("本当に修正しますか？", vbYesNo, "確認")
                If Ret = vbYes Then
                    b_title = txtTitle.Text
                    b_name = txtName.Text
                    b_publishing = txtPublishing.Text
                    b_date = txtData0.Text + "-" + txtData1.Text + "-" + txtData2.Text

                    SQL = "update book set "
                    SQL += "b_title='" + b_title + "',"
                    SQL += "b_name='" + b_name + "',"
                    SQL += "b_publishing='" + b_publishing + "',"
                    SQL += "b_date='" + b_date + "'"
                    SQL += " where b_code='" + txtCode.Text + "'"

                    Console.WriteLine(SQL)

                    DCom.CommandText = SQL
                    DCom.ExecuteNonQuery()

                    booklist()
                    main.list_search("", "")
                    btnCancel.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtCode.Enabled = False
        txtTitle.Enabled = False
        txtName.Enabled = False
        txtPublishing.Enabled = False
        txtData0.Enabled = False
        txtData1.Enabled = False
        txtData2.Enabled = False
        txtPrice.Enabled = False

        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = True
        btnDel.Enabled = True
        btnCancel.Enabled = False

        addBYesNo = False
        updateBYesNo = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtCode.Text = "" Then
            MsgBox("データを選んでください", , "確認")
            Return
        End If

        txtCode.Enabled = True
        txtTitle.Enabled = True
        txtName.Enabled = True
        txtPublishing.Enabled = True
        txtData0.Enabled = True
        txtData1.Enabled = True
        txtData2.Enabled = True
        txtPrice.Enabled = True

        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnDel.Enabled = False
        btnCancel.Enabled = True

        updateBYesNo = True
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        ds = New DataSet

        If txtCode.Text = "" Then
            MsgBox("データを選んでください", , "確認")
            Return
        End If

        SQL = "select b_lent from book where b_code='" + txtCode.Text + "'"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds, "book")

        Ret = MsgBox("本当に削除しますか？", vbYesNo, "確認")

        Console.WriteLine(SQL)
        Console.WriteLine(ds.Tables("book").Rows.Count)

        If Ret = vbYes Then
            If ds.Tables("book").Rows(0).Item(0).ToString <> "0" Then
                MsgBox("今貸与中です", , "確認")
            Else
                SQL = "delete from book where b_code='" + txtCode.Text + "'"
                DCom.CommandText = SQL
                DCom.ExecuteNonQuery()

                txtCode.Text = ""
                txtTitle.Text = ""
                txtName.Text = ""
                txtPublishing.Text = ""
                txtData0.Text = ""
                txtData1.Text = ""
                txtData2.Text = ""
                txtPrice.Text = ""

                booklist()
                main.list_search("", "")
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If addBYesNo = True Or updateBYesNo = True Then
            txtCode.Text = ""
            txtTitle.Text = ""
            txtName.Text = ""
            txtPublishing.Text = ""
            txtData0.Text = ""
            txtData1.Text = ""
            txtData2.Text = ""
            txtPrice.Text = ""
        Else
            Dim data_split() As String '문자열의 배열
            b_date = DataGridView1.Item(4, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            data_split = Split(b_date, "-") '앞서 정의해둔 문자열의 매열에 -를 경계로 하나씩 저장함

            txtCode.Text = DataGridView1.Item(0, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            txtTitle.Text = DataGridView1.Item(1, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            txtName.Text = DataGridView1.Item(2, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            txtPublishing.Text = DataGridView1.Item(3, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            txtCode.Text = DataGridView1.Item(0, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            txtData0.Text = data_split(0)
            txtData1.Text = data_split(1)
            txtData2.Text = data_split(2)
            txtPrice.Text = DataGridView1.Item(5, Int(DataGridView1.CurrentRow.Index)).Value.ToString
        End If
    End Sub
End Class