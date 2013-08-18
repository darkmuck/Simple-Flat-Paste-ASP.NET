Imports System.IO

Public Class _Default
    Inherits System.Web.UI.Page

    WithEvents hl As New LinkButton

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

    Private Sub listPastes()
        Dim dirInfo As New IO.DirectoryInfo(MapPath("pastes"))
        Dim diar1 As IO.FileInfo() = dirInfo.GetFiles()
        Dim dra As IO.FileInfo
        Dim sw As StringWriter
        Dim w As HtmlTextWriter
        Dim lbl As New Label
        Dim lbl2 As New Label

        'For Each dra In diar1
        ' spanFileList.InnerHtml = spanFileList.InnerHtml + _
        '     "<br />" + _
        '     "<a href='#' id='' onClick='' runat='server'>X</a>" + _
        '     "&nbsp;&nbsp;" + _
        '     "<a href='pastes/" + dra.Name + "'>" + dra.Name + "</a>"
        ' Next

        For Each dra In diar1
            hl = New LinkButton
            hl.Text = "X"
            hl.ID = "lnkDel_" + dra.Name.Replace(" ", "_")
            AddHandler hl.Click, New EventHandler(AddressOf deleteLink)

            lbl2 = New Label
            lbl2.Text = "&nbsp;&nbsp;<a href='" + "pastes/" + dra.Name + "'>" + dra.Name + "</a>"

            sw = New StringWriter
            sw.WriteLine("<br/>")
            w = New HtmlTextWriter(sw)
            lbl = New Label
            lbl.Text = sw.GetStringBuilder().ToString

            mainDiv.Controls.Add(lbl)
            mainDiv.Controls.Add(hl)
            mainDiv.Controls.Add(lbl2)
        Next
    End Sub

    Private Sub deleteLink(ByVal sender As Object, ByVal e As System.EventArgs) Handles hl.Click
        Dim ctrl As System.Web.UI.Control
        Dim ctrlID As String

        Try
            ctrl = New System.Web.UI.Control
            ctrl = DirectCast(sender, System.Web.UI.Control)
            ctrlID = ctrl.ID.Replace("lnkDel_", "")

            File.Delete(System.IO.Path.Combine(MapPath("pastes"), ctrlID))
            Response.Redirect("Default.aspx")
        Catch ex As Exception
            spanErrorMessage.InnerText = "Error: file not deleted"
            Throw
        End Try
    End Sub

    Private Function saveFile(ByVal subject As String, ByVal text As String) As Boolean
        Dim returnVal As Boolean = False
        Dim filename As String = System.IO.Path.Combine(MapPath("pastes"), subject.Replace(" ", "_") + ".txt")

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