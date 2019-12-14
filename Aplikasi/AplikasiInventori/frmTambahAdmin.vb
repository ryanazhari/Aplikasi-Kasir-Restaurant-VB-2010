Imports System.Data.Odbc

Public Class frmTambahAdmin

    Sub isiGrid()
        modConnection.bukaDB()
        da = New OdbcDataAdapter("SELECT username,nama,level from tbadmin", conn)
        ds = New DataSet
        da.Fill(ds, "tbadmin")
        DataGridView1.DataSource = ds.Tables("tbadmin")
        DataGridView1.ReadOnly = True
    End Sub

    Sub EnabledKomponen()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        ComboBox1.Enabled = False

        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Sub Bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        TextBox1.Focus()
        Button1.Text = "Tambah"
        Button4.Text = "Edit"
    End Sub

    Sub isiCombo()
        Call bukaDB()
        cmd = New OdbcCommand("SELECT nama_level From level", conn)
        rd = cmd.ExecuteReader
        ComboBox1.Enabled = True
        ComboBox1.Items.Clear()
        Do While rd.Read
            ComboBox1.Items.Add(rd.Item(0))
        Loop
        cmd.Dispose()
        rd.Close()
        conn.Close()
    End Sub

    Private Sub frmTambahAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call bukaDB()
        Call isiGrid()
        Call isiCombo()
        Call Bersih()
        Call EnabledKomponen()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            Button1.Text = "Simpan"

            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True

            ComboBox1.Enabled = True

            TextBox1.Focus()
        Else
            Try
                TextBox1.Enabled = True
                TextBox1.Focus()
                Call bukaDB()
                cmd = New OdbcCommand("SELECT username from tbadmin WHERE username = '" & TextBox1.Text & "'", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    MsgBox("Maaf, Data dengan username tersebut telah ada", MsgBoxStyle.Exclamation, "Peringatan")
                ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                    MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call bukaDB()
                    simpan = "INSERT INTO tbadmin (username,password,nama,level) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')"
                    cmd = New OdbcCommand(simpan, conn)
                    cmd.ExecuteNonQuery()
                    Call isiGrid()
                    Call Bersih()
                    Call isiCombo()
                    Call EnabledKomponen()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Call bukaDB()
            ubah = "UPDATE tbadmin SET password='" & TextBox2.Text & "',nama='" & TextBox3.Text & "',level='" & ComboBox1.Text & "' WHERE username = '" & TextBox1.Text & "'"
            cmd = New OdbcCommand(ubah, conn)
            cmd.ExecuteNonQuery()
            Call Bersih()
            Call isiGrid()
            Call isiCombo()
            Call EnabledKomponen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Call bukaDB()
            hapus = "DELETE FROM tbadmin WHERE username='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            Call Bersih()
            Call isiGrid()
            Call isiCombo()
            Call EnabledKomponen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub


    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.ColumnIndex = 0 Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True

            ComboBox1.Enabled = True

            Button3.Enabled = True
            Button4.Enabled = True
            'DataGridView1.Rows(e.RowIndex).Cells(0).Value = UCase(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            TextBox1.Enabled = False
            Call bukaDB()
            cmd = New OdbcCommand("SELECT * from tbadmin WHERE username = '" & DataGridView1.Rows(e.RowIndex).Cells(0).Value & "'", conn)
            rd = cmd.ExecuteReader
            If rd.Read Then
                TextBox1.Text = rd.Item("username")
                TextBox2.Text = rd.Item("password")
                TextBox3.Text = rd.Item("nama")
                ComboBox1.Text = rd.Item("level")
            Else
                MsgBox("Maaf, Data tidak Ditemukan", MsgBoxStyle.Exclamation, "Peringatan")
                DataGridView1.Focus()
            End If
        End If
    End Sub
End Class

