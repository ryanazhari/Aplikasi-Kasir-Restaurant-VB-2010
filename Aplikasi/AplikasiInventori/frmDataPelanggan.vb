Imports System.Data.Odbc
Public Class frmDataPelanggan

    Private Sub frmDataPelanggan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        Call bukaDB()
        Call isiGrid()
        Call isiCombo()
        Call Otomatis()
        Call EnabledKomponen()
    End Sub

    Sub EnabledKomponen()
        TextBox1.Enabled = False
        TextBox2.Enabled = False

        ComboBox1.Enabled = False

        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Sub isiGrid()
        modConnection.bukaDB()
        da = New OdbcDataAdapter("SELECT * from tbpelanggan", conn)
        ds = New DataSet
        da.Fill(ds, "tbpelanggan")
        DataGridView1.DataSource = ds.Tables("tbpelanggan")
        DataGridView1.ReadOnly = True
    End Sub

    Sub Bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
        Button1.Text = "Tambah"
    End Sub

    Sub isiCombo()
        Call bukaDB()
        cmd = New OdbcCommand("SELECT kodepelanggan From tbpelanggan", conn)
        rd = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While rd.Read
            ComboBox1.Items.Add(rd.Item(0))
        Loop
        cmd.Dispose()
        rd.Close()
        conn.Close()
    End Sub

    Sub Bersih2()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
        Button1.Text = "Tambah"
    End Sub

    Sub Otomatis()
        modConnection.bukaDB()
        cmd = New OdbcCommand("SELECT* FROM tbpelanggan order by kodepelanggan desc", conn)
        Dim urutan As String
        Dim hitung As Long
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            hitung = Strings.Right(rd.Item(0), 1) + 1
            urutan = "P" + hitung.ToString
            TextBox1.Text = urutan
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call bukaDB()
        cmd = New OdbcCommand("SELECT kodepelanggan,namapelanggan FROM tbpelanggan WHERE kodepelanggan = '" & ComboBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TextBox1.Text = rd.Item(0)
            TextBox2.Text = rd.Item(1)
            TextBox1.Enabled = False
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            Call Otomatis()
            Button1.Text = "Simpan"
            TextBox2.Enabled = True
            TextBox2.Focus()
        Else
            Try
                Call bukaDB()
                cmd = New OdbcCommand("SELECT kodepelanggan from tbpelanggan WHERE kodepelanggan = '" & TextBox1.Text & "'", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    MsgBox("Maaf, Data pelanggan dengan kode tersebut telah ada", MsgBoxStyle.Exclamation, "Peringatan")
                ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Then
                    MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call bukaDB()
                    simpan = "INSERT INTO tbpelanggan (kodepelanggan,namapelanggan) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "')"
                    cmd = New OdbcCommand(simpan, conn)
                    cmd.ExecuteNonQuery()
                    Call isiGrid()
                    Call Bersih2()
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
            ubah = "UPDATE tbpelanggan SET namapelanggan='" & TextBox2.Text & "' WHERE kodepelanggan = '" & TextBox1.Text & "'"
            cmd = New OdbcCommand(ubah, conn)
            cmd.ExecuteNonQuery()
            Call Bersih2()
            Call isiGrid()
            Call isiCombo()
            EnabledKomponen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Call bukaDB()
            hapus = "DELETE FROM tbpelanggan WHERE kodepelanggan='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            Call Bersih2()
            Call isiGrid()
            Call isiCombo()
            EnabledKomponen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub


    Private Sub DataGridView1_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        TextBox2.Enabled = True

        ComboBox1.Enabled = True

        Button3.Enabled = True
        Button4.Enabled = True
        If e.ColumnIndex = 0 Then
            'DataGridView1.Rows(e.RowIndex).Cells(0).Value = UCase(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            Call bukaDB()
            cmd = New OdbcCommand("SELECT * from tbpelanggan WHERE kodepelanggan = '" & DataGridView1.Rows(e.RowIndex).Cells(0).Value & "'", conn)
            rd = cmd.ExecuteReader
            If rd.Read Then
                TextBox1.Text = rd.Item("kodepelanggan")
                TextBox2.Text = rd.Item("namapelanggan")
                ComboBox1.Text = rd.Item("kodepelanggan")
            Else
                MsgBox("Maaf, Data tidak Ditemukan", MsgBoxStyle.Exclamation, "Peringatan")
                DataGridView1.Focus()
            End If
        End If
    End Sub
End Class