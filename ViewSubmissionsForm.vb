Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submission)

    Public Sub New()
        InitializeComponent()
        submissions = GetSubmissions()
        If submissions.Count > 0 Then
            ShowSubmission(currentIndex)
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            ShowSubmission(currentIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            ShowSubmission(currentIndex)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Confirm deletion
        If MessageBox.Show("Are you sure you want to delete this submission?", "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            DeleteSubmission(submissions(currentIndex))
            submissions.RemoveAt(currentIndex)
            If currentIndex > 0 Then
                currentIndex -= 1
            End If
            If submissions.Count > 0 Then
                ShowSubmission(currentIndex)
            Else
                ClearFields()
            End If
        End If
    End Sub

    Private Sub ShowSubmission(index As Integer)

        If submissions.Count > 0 Then
            Dim submission = submissions(index)
            txtName.Text = submission.Name
            txtEmail.Text = submission.Email
            txtPhoneNumber.Text = submission.PhoneNumber
            txtGitHubLink.Text = submission.GitHubLink
            txtStopwatchTime.Text = submission.StopwatchTime.ToString("hh\:mm\:ss")
        End If
    End Sub

    Private Sub ClearFields()
        txtName.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPhoneNumber.Text = String.Empty
        txtGitHubLink.Text = String.Empty
        txtStopwatchTime.Text = String.Empty
    End Sub

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.D Then
            btnDelete.PerformClick()
        End If
    End Sub

    Private Sub DeleteSubmission(submission As Submission)

    End Sub

    Private Function GetSubmissions() As List(Of Submission)

        Return New List(Of Submission) From {
            New Submission With {.Name = "Sakshi Chakraborty", .Email = "sakshi04@gmail.com", .PhoneNumber = "1234567890", .GitHubLink = "http://github.com/sakshi11", .StopwatchTime = New TimeSpan(0, 1, 23)},
            New Submission With {.Name = "Priya Majumdar", .Email = "priya29@example.com", .PhoneNumber = "0987654321", .GitHubLink = "http://github.com/priya09", .StopwatchTime = New TimeSpan(0, 2, 34)}
        }
    End Function
End Class

Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property PhoneNumber As String
    Public Property GitHubLink As String
    Public Property StopwatchTime As TimeSpan
End Class
