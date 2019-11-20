Public Class main
    Dim ds As DataSet

    Public book_code As String
    Public id_code As String

    ''' <summary>
    ''' 1번 그리드
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <param name="dataset"></param>
    Public Sub sql_execute(ByVal sql As String, ByVal dataset As DataSet)
        'DB-> dataset(table) -> BindingSource -> GridView
        DCom.CommandText = sql '이거 왜 있는지 모르겠음
        DA = New OleDb.OleDbDataAdapter(sql, Con) '여기서 이미 DB에 쿼리를 호출한 후 DA에 쿼리 결과값을 받음
        DA.Fill(dataset, "book") 'DA(쿼리결과) -> Dataset(book)테이블로 데이터 전달
        'FILL(넣을데이터셋,가져온테이블명) :임의로 book이라는 테이블을 데이터셋에 생성

        'SQL확인
        Console.WriteLine(sql)

        'item(0)은 칼럼을 나타내고 0부터 시작된다 
        Dim i As Integer
        i = 0
        Do While i < dataset.Tables("book").Rows.Count
            If dataset.Tables("book").Rows(i).Item(6).ToString Like "0" Then
                dataset.Tables("book").Rows(i).Item(6) = "가능"
            Else
                dataset.Tables("book").Rows(i).Item(6) = "불가능"
            End If
            i = i + 1
        Loop

        BindingSource1.DataSource = dataset.Tables("book") 'dataset의 book테이블의 정보를 바인딩함
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
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).HeaderText = "貸与"
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False

        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 150
        DataGridView1.Columns(2).Width = 90
        DataGridView1.Columns(3).Width = 110
        DataGridView1.Columns(6).Width = 80
    End Sub

    Public Sub list_search(ByVal find As String, ByVal sort As String)
        ds = New DataSet

        If find = "" And sort = "" Then 'case1
            SQL = "select * from book order by b_title asc"
            sql_execute(SQL, ds)
        ElseIf find = "" And sort <> "" Then 'case2
            If sort = "code" Then
                SQL = "select * from book order by CInt(b_" + sort + ") asc"
            Else
                SQL = "select * from book order by b_" + sort + " asc"
                sql_execute(SQL, ds)
            End If
        ElseIf find <> "" Then 'case3
            If RadioButton1.Checked Then
                SQL = "select * from book where b_title like '%" + find + "%' order by b_title asc" '액세스도 like '%'사용가능
            ElseIf RadioButton2.Checked Then
                SQL = "select * from book where b_code ='CInt(" + find + ")'"
            End If
            sql_execute(SQL, ds)
            If ds.Tables("book").Rows.Count = 0 Then
                MsgBox("図書がございません",, "確認")
                SQL = "select * from book order by b_title asc"
                sql_execute(SQL, ds)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        inforbook.Label20.Text =
        DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        '다음화면에 클릭한 타이틀 값을 전달함
        inforbook.Show()
    End Sub



    ''' <summary>
    '''  2번 그리드
    ''' </summary>
    ''' <param name="SQL"></param>
    ''' <param name="dataset"></param>
    Public Sub sql_execute2(ByVal SQL As String, ByVal dataset As DataSet)
        DCom.CommandText = SQL '이미 이 부분에서 DB에 
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(dataset, "member")

        'SQL확인
        Console.WriteLine(SQL)

        'dataSource형태로 전달함..그리고 BindingDataSource를 이용하여 접근
        BindingSource2.DataSource = dataset.Tables("member") 'dataset의 book테이블의 정보를 바인딩함
        DataGridView2.DataSource = BindingSource2 '바인딩한 정보를 그리드 뷰에 박음

        lentm_counter()
        lentm_header()

        DataGridView2.Refresh()

    End Sub

    Public Sub lentm_counter()
        Dim i As Integer
        i = DataGridView2.RowCount
        Label2.Text = "総" + i.ToString + "名"

    End Sub

    Public Sub lent_id()
        ds = New DataSet
        SQL = "select * from member where m_lent<>0 order by m_id asc"
        sql_execute2(SQL, ds)
    End Sub

    Public Sub lentm_header()
        DataGridView2.Columns(0).HeaderText = "ID"
        DataGridView2.Columns(1).HeaderText = "名前"
        DataGridView2.Columns(2).Visible = False
        DataGridView2.Columns(3).Visible = False
        DataGridView2.Columns(4).Visible = False
        DataGridView2.Columns(5).Visible = False
        DataGridView2.Columns(6).HeaderText = "冊数"
        DataGridView2.Columns(7).Visible = False

        DataGridView2.Columns(0).Width = 80
        DataGridView2.Columns(1).Width = 80
        DataGridView2.Columns(6).Width = 80
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        inforLentUser.Label1.Text =
        DataGridView2.Item(0, Int(DataGridView2.CurrentRow.Index.ToString)).Value
        inforLentUser.Show()
    End Sub

    ''' <summary>
    '''  3번 그리드
    ''' </summary>
    ''' <param name="SQL"></param>
    ''' <param name="dataset"></param>
    Public Sub sql_execute3(ByVal sql As String, ByVal DataSet As DataSet)
        DCom.CommandText = sql
        DA = New OleDb.OleDbDataAdapter(sql, Con) 'SQL의 결과를 DA(어댑터)에 임시저장
        DA.Fill(DataSet, "book") 'DA의 SQL결과를 가지고 데이터셋의 book이라는 가상의 데이터테이블에 넣어줌

        'SQL확인
        Console.WriteLine(sql)

        Dim i As Integer
        i = 0

        DataSet.Tables("book").Columns.Add("連帯日付")

        Do While i < DataSet.Tables("book").Rows.Count
            DataSet.Tables("book").Rows(i).Item(3) =
             Strings.Left(DataSet.Tables("book").Rows(i).Item(3), 10)

            Dim lentdiff As String

            Dim ti As Date
            ti = DataSet.Tables("book").Rows(0).Item(3)
            lentdiff = DateDiff("d", ti, Now()) - 10
            DataSet.Tables("book").Rows(i).Item(4) = lentdiff.ToString & "일"
            i = i + 1
        Loop

        BindingSource3.DataSource = DataSet.Tables("book")
        DataGridView3.DataSource = BindingSource3

        'DataGridView3.ColumnCount -->이 경우에는 columnCount가 0을 제외하고 카운트된다

        blackm_counter()
        blackm_header()

        DataGridView3.Refresh()
    End Sub


    Public Sub blackm_counter()
        Dim i As Integer
        i = DataGridView3.RowCount
        Label4.Text = "総" + i.ToString + "名"


    End Sub
    Public Sub blackm_header()
        DataGridView3.Columns(0).HeaderText = "名前"
        DataGridView3.Columns(1).HeaderText = "コード"
        DataGridView3.Columns(2).HeaderText = "タイトル"
        DataGridView3.Columns(3).HeaderText = "貸与日付"


        DataGridView3.Columns(0).Width = 60
        DataGridView3.Columns(1).Width = 60
        DataGridView3.Columns(2).Width = 100
        DataGridView3.Columns(3).Width = 80
        DataGridView3.Columns(4).Width = 70
    End Sub

    Public Sub blacklist()
        ds = New DataSet
        SQL = "select m_name,b_code,b_title,b_lent_date from book a inner join member b on a.b_lent =b.m_id "
        SQL += "where a.b_lent_date + 10 < now() order by a.b_lent_date asc"
        sql_execute3(SQL, ds)
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call list_search("", "")
        Call lent_id()
        Call blacklist()

        Left = 0
        Top = 0
    End Sub

    '도서검색 확인
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If Trim(txtFind1.Text) = "" Then
            MsgBox("検索未入力”，， “確認”)
        Else
            list_search(txtFind1.Text, "")
        End If
    End Sub

    '도서반납 대여 확인
    Private Sub btnLentOrReturn_Click(sender As Object, e As EventArgs) Handles btnLentOrReturn.Click
        ds = New DataSet

        Dim v_code As String = Trim(txtFind2.Text)

        If v_code = "" Then
            MsgBox("未入力”，， “確認”)
            txtFind2.Focus()
            Return
        End If

        If RadioButton3.Checked = True Then
            SQL = "select * from book where b_code ='" + v_code + "'"
            DCom.CommandText = SQL
            DA = New OleDb.OleDbDataAdapter(SQL, Con)
            DCom.ExecuteNonQuery()
            DA.Fill(ds, "book")

            If ds.Tables("book").Rows.Count = 0 Then
                MsgBox("図書がありません",, "確認")
                txtFind2.Clear()
                txtFind2.Focus()
            Else
                If ds.Tables("book").Rows(0).Item(6).ToString Like "0" Then
                    memid.Show()
                Else
                    MsgBox("貸与中です",, "確認")
                    txtFind2.Clear()
                    txtFind2.Focus()
                End If
            End If
        ElseIf RadioButton4.Checked = True Then
            Ret = MsgBox("この図書を返納しますか？", vbYesNo, "確認")

            If Ret = vbYes Then
                SQL = "select * from book where b_code='" + v_code + "'"
                DCom.CommandText = SQL
                DA = New OleDb.OleDbDataAdapter(SQL, Con)
                DA.Fill(ds, "book")

                If ds.Tables("book").Rows.Count = 0 Then
                    MsgBox("図書がありません",, "確認")
                    txtFind2.Clear()
                    txtFind2.Focus()
                    Return
                End If

                If ds.Tables("book").Rows(0).Item(6).ToString Like "0" Then
                    MsgBox("貸与されていない図書です",, "確認")
                    txtFind2.Clear()
                    txtFind2.Focus()
                    Return
                End If

                id_code = ds.Tables("book").Rows(0).Item(6)
                SQL = "update book set b_lent ='0' ,b_lent_date= Null where b_code='" + v_code + "'"
                DCom.CommandText = SQL
                DCom.ExecuteNonQuery()
                DA.Fill(ds, "book") '여기서 DA.FILL을 사용하면 ..

                SQL = "update member set m_lent = m_lent-1 where m_id='" + id_code + "'"
                DCom.CommandText = SQL
                DCom.ExecuteNonQuery()
                DA.Fill(ds, "member")

                txtFind2.Clear()
                txtFind2.Focus()

                list_search("", "")
                lent_id()
                blacklist()

            End If
        End If

    End Sub

    '이전 버튼
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Call list_search("", "")
    End Sub
    '정렬버튼 1
    Private Sub btnSortByTitle_Click(sender As Object, e As EventArgs) Handles btnSortByTitle.Click
        Call list_search("", "title")
    End Sub
    '정렬버튼 2
    Private Sub btnSortByAuthor_Click(sender As Object, e As EventArgs) Handles btnSortByAuthor.Click
        Call list_search("", "name")
    End Sub
    '정렬버튼 3
    Private Sub btnSortByPublisher_Click(sender As Object, e As EventArgs) Handles btnSortByPublisher.Click
        Call list_search("", "publishing")
    End Sub
    '정렬버튼 4
    Private Sub btnSortByLending_Click(sender As Object, e As EventArgs) Handles btnSortByLending.Click
        Call list_search("", "lent")
    End Sub

    '라디오버튼1클릭시 포커스 텍스트1 에 포커스 이동
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        txtFind1.Focus()
    End Sub
    '라디오버튼2클릭시 포커스 텍스트1 에 포커스 이동
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        txtFind1.Focus()
    End Sub
    '라디오버튼3클릭시 포커스 텍스트2 에 포커스 이동
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        txtFind2.Focus()
    End Sub
    '라디오버튼4클릭시 포커스 텍스트2 에 포커스 이동
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        txtFind2.Focus()
    End Sub

    Private Sub txtFind1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFind1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnFind.PerformClick()

            Console.Write(e.KeyData.ToString() + ("###테스트1"))
            Console.Write(e.KeyCode.ToString() + ("###테스트2"))
            Console.Write(e.KeyValue.ToString() + ("###테스트3"))
        End If
        '속성값 => 해당 속성이 가진 필드값 (속성-필드(속성안에 변수))
        'MS API에서 속성값은 해당 속성안에 또 속성이 있는것이고 
        '반환값은 더이상 속성이 없고 반환값만 있는것.
        '속성.속성값1(속성1,속성2..) -->필드값(*중요)
        'EX) KeyEventArgs.KeyCode .속성값1(필드1,필드2,필드3..) .//속성값안에 필드값이 존재함으로 체이닝이 됨
        'EX)e.KeyValue ->속성값 int //하지만 필드값가 없으므로 체이닝이 안됨

        'System.Windows.Forms 네임스페이스 아래의 내용은 별도의 임포트없이 사용가능
        'System.Windows.Forms.Control 도 해당 버튼이라는 control을 상속받은 메서드안에서 임포트없이 사용 가능
        'System 네임스페이스 아래의 내용도 그냥 사용가능함 ex)String ,console,random
    End Sub

    Private Sub txtFind2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFind2.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLentOrReturn.PerformClick()
        End If
    End Sub
End Class