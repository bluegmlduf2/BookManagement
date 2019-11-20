Module Module1
    Public Ret As String '반납여부YN
    Public SQL As String
    Public Con As New OleDb.OleDbConnection
    Public DCom As New OleDb.OleDbCommand
    Public DA As New OleDb.OleDbDataAdapter

    Public Sub DB_Acces()
        Dim My_con As String
        My_con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\YOON\Documents\library.accdb"
        Con.ConnectionString = My_con
        DCom.Connection = Con
        Con.Open()
    End Sub

End Module
