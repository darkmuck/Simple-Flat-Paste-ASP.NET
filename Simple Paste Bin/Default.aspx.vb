Imports System.IO

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listPastes()
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As System.EventArgs) Handles btnPaste.Click
        If saveFile(txtSubject.Text, txtText.Text) = False Then
            spanErrorMessage.InnerText = "Error: file not saved"
        Else
            spanErrorMessage.InnerText = "Success: file saved"
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Private Function deleteFile(ByVal filename As String) As Boolean
        Dim returnVal As Boolean = False

        Try
            If IO.File.Exists(filename) Then
                IO.File.Delete(filename)
                returnVal = True
            End If
        Catch ex As IOException
            Throw
        End Try

        Return returnVal
    End Function

    Private Sub listPastes()
        Dim dirInfo As New IO.DirectoryInfo(MapPath("pastes"))
        Dim diar1 As IO.FileInfo() = dirInfo.GetFiles()
        Dim dra As IO.FileInfo

        For Each dra In diar1
            spanFileList.InnerHtml = spanFileList.InnerHtml + _
                "<br />" + _
                "<a href='#' id='' onClick='' runat='server'>X</a>" + _
                "&nbsp;&nbsp;" + _
                "<a href='pastes/" + dra.Name + "'>" + dra.Name + "</a>"
        Next
    End Sub

    Private Function saveFile(ByVal subject As String, ByVal text As String) As Boolean
        Dim returnVal As Boolean = False
        Dim filename As String = System.IO.Path.Combine(MapPath("pastes"), subject + ".txt")

        Try
            Dim fileExists As Boolean = File.Exists(filename)
            Using sw As New StreamWriter(File.Open(filename, FileMode.OpenOrCreate))
                sw.WriteLine(IIf(fileExists, text, text))
            End Using

            returnVal = True
        Catch ex As IOException
            Throw
        End Try

        Return returnVal
    End Function
End Class