<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class book
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtPublishing = New System.Windows.Forms.TextBox()
        Me.txtData2 = New System.Windows.Forms.TextBox()
        Me.txtData1 = New System.Windows.Forms.TextBox()
        Me.txtData0 = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LibraryDataSet = New BookMangement.libraryDataSet()
        Me.BookBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BookTableAdapter = New BookMangement.libraryDataSetTableAdapters.bookTableAdapter()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LibraryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Location = New System.Drawing.Point(13, 45)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 27
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(419, 322)
        Me.DataGridView1.TabIndex = 46
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(753, 340)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 23)
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Text = "取り消し"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(675, 340)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(77, 23)
        Me.btnDel.TabIndex = 44
        Me.btnDel.Text = "削除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(597, 340)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(77, 23)
        Me.btnEdit.TabIndex = 43
        Me.btnEdit.Text = "修正"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(519, 340)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 23)
        Me.btnSave.TabIndex = 42
        Me.btnSave.Text = "セーブ"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(441, 340)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(77, 23)
        Me.btnAdd.TabIndex = 40
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtPublishing
        '
        Me.txtPublishing.Location = New System.Drawing.Point(522, 195)
        Me.txtPublishing.Name = "txtPublishing"
        Me.txtPublishing.Size = New System.Drawing.Size(152, 25)
        Me.txtPublishing.TabIndex = 38
        Me.txtPublishing.Tag = "出版社"
        '
        'txtData2
        '
        Me.txtData2.Location = New System.Drawing.Point(666, 245)
        Me.txtData2.Name = "txtData2"
        Me.txtData2.Size = New System.Drawing.Size(66, 25)
        Me.txtData2.TabIndex = 37
        Me.txtData2.Tag = "日"
        '
        'txtData1
        '
        Me.txtData1.Location = New System.Drawing.Point(594, 245)
        Me.txtData1.Name = "txtData1"
        Me.txtData1.Size = New System.Drawing.Size(66, 25)
        Me.txtData1.TabIndex = 36
        Me.txtData1.Tag = "月"
        '
        'txtData0
        '
        Me.txtData0.Location = New System.Drawing.Point(522, 245)
        Me.txtData0.Name = "txtData0"
        Me.txtData0.Size = New System.Drawing.Size(66, 25)
        Me.txtData0.TabIndex = 35
        Me.txtData0.Tag = "年度"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(522, 95)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(286, 25)
        Me.txtTitle.TabIndex = 34
        Me.txtTitle.Tag = "タイトル"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(524, 45)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(152, 25)
        Me.txtCode.TabIndex = 33
        Me.txtCode.Tag = "図書コード"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(466, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "発行日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(466, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "出版社"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(481, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "著者"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(451, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "タイトル"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(439, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 15)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "図書コード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(353, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "総０００冊"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(522, 295)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(152, 25)
        Me.txtPrice.TabIndex = 49
        Me.txtPrice.Tag = "価格"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(481, 298)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 48
        Me.Label7.Tag = "図書コード"
        Me.Label7.Text = "価格"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(522, 145)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(152, 25)
        Me.txtName.TabIndex = 50
        Me.txtName.Tag = "著者"
        '
        'LibraryDataSet
        '
        Me.LibraryDataSet.DataSetName = "libraryDataSet"
        Me.LibraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BookBindingSource
        '
        Me.BookBindingSource.DataMember = "book"
        Me.BookBindingSource.DataSource = Me.LibraryDataSet
        '
        'BookTableAdapter
        '
        Me.BookTableAdapter.ClearBeforeFill = True
        '
        'book
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 384)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtPublishing)
        Me.Controls.Add(Me.txtData2)
        Me.Controls.Add(Me.txtData1)
        Me.Controls.Add(Me.txtData0)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "book"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "図書管理"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LibraryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnDel As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtPublishing As TextBox
    Friend WithEvents txtData2 As TextBox
    Friend WithEvents txtData1 As TextBox
    Friend WithEvents txtData0 As TextBox
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents LibraryDataSet As libraryDataSet
    Friend WithEvents BookBindingSource As BindingSource
    Friend WithEvents BookTableAdapter As libraryDataSetTableAdapters.bookTableAdapter
End Class
