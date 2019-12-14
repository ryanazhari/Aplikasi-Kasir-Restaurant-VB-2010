Imports System.Data.Odbc
Module modConnection
    Public conn As OdbcConnection
    Public rd As OdbcDataReader
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public cmd As OdbcCommand
    Public str As String
    Public simpan, ubah, hapus As String

    Public Sub bukaDB()
        str = "driver={mysql odbc 3.51 driver};database=kasir_restoran_beta2;server=localhost;uid=root"
        conn = New OdbcConnection(str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
