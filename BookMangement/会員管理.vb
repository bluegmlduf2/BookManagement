Public Class member
    Dim ds As DataSet

    Public addUYesNo As Boolean
    Public updateUYesNo As Boolean

    Private t_phone As String
    Private t_name As String
    Private t_address As String

    Public Sub member_list()
        ds = New DataSet
        SQL = "select * from member order by Cint(m_id) asc"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds, "member")
        BindingSource1.DataSource = ds.Tables("member")
        DataGridView1.DataSource = BindingSource1
        member_header()
        member_counter()
        DataGridView1.Refresh()

    End Sub

    Public Sub member_header()
        DataGridView1.Columns(0).HeaderText = "ID"
        DataGridView1.Columns(1).HeaderText = "名前"
        DataGridView1.Columns(2).HeaderText = "電話番号"
        DataGridView1.Columns(3).HeaderText = "住所"
        DataGridView1.Columns(4).HeaderText = "性別"
        DataGridView1.Columns(5).HeaderText = "加入日"
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).HeaderText = "総貸与図書"

    End Sub
    Public Sub member_counter()
        Dim i As Integer
        i = DataGridView1.RowCount
        Label3.Text = "総" + i.ToString + "名"
    End Sub

    Private Sub member_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Left = 0
        member_list()
        Init(3)
    End Sub

    Public Sub init(ByVal i As Integer)
        Select Case i
            Case 1
                txtID.Text = ""
                txtName.Text = ""
                txtPhone0.Text = ""
                txtPhone1.Text = ""
                txtPhone2.Text = ""
                txtAddress.Text = ""

                txtID.Enabled = True
                txtName.Enabled = True
                txtPhone0.Enabled = True
                txtPhone1.Enabled = True
                txtPhone2.Enabled = True
                txtAddress.Enabled = True
            Case 2
                txtID.Text = ""
                txtName.Text = ""
                txtPhone0.Text = ""
                txtPhone1.Text = ""
                txtPhone2.Text = ""
                txtAddress.Text = ""

                txtID.Enabled = False
                txtName.Enabled = False
                txtPhone0.Enabled = False
                txtPhone1.Enabled = False
                txtPhone2.Enabled = False
                txtAddress.Enabled = False
            Case 3
                txtID.Enabled = False
                txtName.Enabled = False
                txtPhone0.Enabled = False
                txtPhone1.Enabled = False
                txtPhone2.Enabled = False
                txtAddress.Enabled = False

                btnAdd.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = True
                btnDel.Enabled = True
                btnCancel.Enabled = False
            Case Else
                txtID.Enabled = True
                txtName.Enabled = True
                txtPhone0.Enabled = True
                txtPhone1.Enabled = True
                txtPhone2.Enabled = True
                txtAddress.Enabled = True

                btnAdd.Enabled = False
                btnSave.Enabled = True
                btnEdit.Enabled = False
                btnDel.Enabled = False
                btnCancel.Enabled = True
        End Select
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        init(1)

        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnDel.Enabled = False
        btnCancel.Enabled = True

        addUYesNo = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ds = New DataSet

        If addUYesNo = True Then

            If Trim(txtID.Text) = "" Then
                MsgBox(txtID.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtName.Text) = "" Then
                MsgBox(txtName.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtName.Text) = "" Then
                MsgBox(txtName.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtPhone0.Text) = "" Then
                MsgBox(txtPhone0.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtPhone1.Text) = "" Then
                MsgBox(txtPhone1.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtPhone2.Text) = "" Then
                MsgBox(txtPhone2.Tag + "を入力してください", vbOKOnly, "確認")
            ElseIf Trim(txtAddress.Text) = "" Then
                MsgBox(txtAddress.Tag + "を入力してください", vbOKOnly, "確認")
            Else
                '모두 만족 할 경우 db에 쿼리 날림'
                SQL = "select * from member where m_id='" + txtID.Text + "'"
                DA = New OleDb.OleDbDataAdapter(SQL, Con)
                DA.Fill(ds, "member")

                Console.WriteLine(SQL)

                If ds.Tables("member").Rows.Count = 0 Then
                    Dim sex As String

                    If RadioButton1.Checked = True Then
                        sex = "남성"
                    Else
                        sex = "여성"
                    End If

                    t_name = txtName.Text
                    t_address = txtAddress.Text
                    t_phone = txtPhone0.Text + "-" + txtPhone1.Text + "-" + txtPhone2.Text

                    SQL = "insert into member(m_id,m_name,m_phone,m_address,m_sex,m_date,m_lent,m_total_lent) values ("
                    SQL += "'" + txtID.Text + "',"
                    SQL += "'" + t_name + "',"
                    SQL += "'" + t_phone + "',"
                    SQL += "'" + t_address + "',"
                    SQL += "'" + sex + "',"
                    SQL += "'" + Now() + "','0','0')"

                    Console.WriteLine(SQL)

                    DCom.CommandText = SQL
                    DCom.ExecuteNonQuery()

                    init(2)
                    addUYesNo = False
                    MsgBox("新規会員登録完了", vbOKOnly, "確認")
                Else
                    MsgBox("既に登録された会員がいます。", , "確認")
                    init(1)
                End If
                btnCancel.PerformClick()
                member_list()
            End If
        ElseIf updateUYesNo = True Then
            If txtID.Text = "" Then
                MsgBox("修正するIDを選んでください", vbOKOnly, "確認")
            Else
                Ret = MsgBox("本当に修正しますか？", vbYesNo, "確認")
                If Ret = vbYes Then
                    Dim sex As String

                    If RadioButton1.Checked = True Then
                        sex = "남성"
                    Else
                        sex = "여성"
                    End If

                    t_name = txtName.Text
                    t_address = txtAddress.Text
                    t_phone = txtPhone0.Text + "-" + txtPhone1.Text + "-" + txtPhone2.Text

                    SQL = "update member set "
                    SQL += "m_name='" + t_name + "',"
                    SQL += "m_address='" + t_address + "',"
                    SQL += "m_phone='" + t_phone + "',"
                    SQL += "m_sex='" + sex + "'"
                    SQL += " where m_id='" + txtID.Text + "'"

                    Console.WriteLine(SQL)

                    DCom.CommandText = SQL
                    DCom.ExecuteNonQuery()

                    btnCancel.PerformClick()
                    member_list()
                    MsgBox("修正しました。", vbOKOnly, "確認")
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        init(3)
        addUYesNo = False
        updateUYesNo = False

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtID.Text) = "" Then
            MsgBox(txtID.Tag + "を入力してください", vbOKOnly, "確認")
            Return
        End If
        updateUYesNo = True
        init(4)

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If Trim(txtID.Text) = "" Then
            MsgBox(txtID.Tag + "を入力してください", vbOKOnly, "確認")
            Return
        End If

        ds = New DataSet

        SQL = "select m_lent from member where m_id='" + txtID.Text + "'"
        DA = New OleDb.OleDbDataAdapter(SQL, Con)
        DA.Fill(ds, "member")

        Ret = MsgBox("本当に削除しますか？", vbYesNo, "確認")

        Console.WriteLine(SQL)

        If Ret = vbYes Then
            If ds.Tables("member").Rows(0).Item(0).ToString <> "0" Then
                MsgBox("今貸与中です", , "確認")
            Else
                SQL = "delete from member where m_id='" + txtid.Text + "'"
                DCom.CommandText = SQL
                DCom.ExecuteNonQuery()

                txtID.Text = ""
                txtName.Text = ""
                txtPhone0.Text = ""
                txtPhone1.Text = ""
                txtPhone2.Text = ""
                txtAddress.Text = ""

                member_list()
                main.lent_id()
                main.blacklist()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If addUYesNo = True Or updateUYesNo = True Then
            txtID.Text = ""
            txtName.Text = ""
            txtPhone0.Text = ""
            txtPhone1.Text = ""
            txtPhone2.Text = ""
            txtAddress.Text = ""
        Else
            t_phone = DataGridView1.Item(2, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            Dim sex As String
            Dim phone_split() As String '문자열의 배열
            txtID.Text = DataGridView1.Item(0, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            phone_split = Split(t_phone, "-") '앞서 정의해둔 문자열의 매열에 -를 경계로 하나씩 저장함

            txtID.Text = DataGridView1.Item(0, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            txtName.Text = DataGridView1.Item(1, Int(DataGridView1.CurrentRow.Index)).Value.ToString
            txtAddress.Text = DataGridView1.Item(3, Int(DataGridView1.CurrentRow.Index)).Value.ToString

            txtPhone0.Text = phone_split(0)
            txtPhone1.Text = phone_split(1)
            txtPhone2.Text = phone_split(2)
            sex = DataGridView1.Item(4, Int(DataGridView1.CurrentRow.Index)).Value.ToString

            If sex = "남성" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
        End If
    End Sub
End Class