Option Strict On
Option Explicit On

Imports objSQLite = Finisar.SQLite


Public Class clsDatabase
    Private SQL_CONN As objSQLite.SQLiteConnection
    Private SQL_CMD As objSQLite.SQLiteCommand
    Private DB As objSQLite.SQLiteDataAdapter
    Private DS As New DataSet
    Private DT As New DataTable

    Private Sub SetConnection()
        SQL_CONN = New objSQLite.SQLiteConnection("Data Source=DemoT.db;Version=3;New=False;Compress=True;")
    End Sub

    Public Function ExecuteQuery(ByVal query As String) As Boolean
        Dim returnVal As Boolean = False
        Dim objDB As New clsDatabase()

        Try
            objDB.SetConnection()
            SQL_CONN.Open()
            SQL_CMD = SQL_CONN.CreateCommand()
            SQL_CMD.CommandText = query
            SQL_CMD.ExecuteNonQuery()
            SQL_CONN.Close()

            returnVal = True
        Catch ex As Exception
            Throw
        End Try

        Return returnVal
    End Function

End Class
