Imports System.Data.Odbc
Public Class frmTransaksiJual

    Sub bersih()
        TextBox1.Text = ""
        Label3.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""

    End Sub

    Sub hitungItem()
        Dim cari As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cari = cari + DataGridView1.Rows(i).Cells(0).Value
            Label9.Text = cari
        Next
    End Sub

    Sub hitungTotal()
        Dim cari As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cari = cari + DataGridView1.Rows(i).Cells(1).Value
            Label10.Text = cari
        Next
    End Sub

    Sub isiCombo()
        Call bukaDB()
        cmd = New OdbcCommand("SELECT namapelanggan From tbpelanggan", conn)
        RD = CMD.ExecuteReader
        ComboBox1.Items.Clear()
        Do While RD.Read
            ComboBox1.Items.Add(RD.Item(0))
        Loop
        CMD.Dispose()
        RD.Close()
        Conn.Close()
    End Sub

    Sub Otomatis()
        modConnection.bukaDB()
        cmd = New OdbcCommand("SELECT * FROM tbpenjualan order by no_transaksi desc", conn)
        Dim urutan As String
        Dim hitung As Long
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            hitung = Strings.Right(rd.Item(0), 1) + 1
            urutan = "T" + hitung.ToString
            TextBox1.Text = urutan
        End If
    End Sub

    Sub isiCombo2()
        Call bukaDB()
        cmd = New OdbcCommand("SELECT no_meja From meja", conn)
        rd = cmd.ExecuteReader
        ComboBox2.Enabled = True
        ComboBox2.Items.Clear()
        Do While rd.Read
            ComboBox2.Items.Add(rd.Item(0))
        Loop
        cmd.Dispose()
        rd.Close()
        conn.Close()
    End Sub

    Sub AturKolom()
        'DataGridView1.Columns(0).Width = 60
        'DataGridView1.Columns(1).Width = 180
        'DataGridView1.Columns(2).Width = 110
        'DataGridView1.Columns(3).Width = 75
        'DataGridView1.Columns(4).Width = 120
    End Sub


    Sub BuatKolomDGV()
        'DataGridView1.Columns.Add("kodemasakan", "Kode")
        'DataGridView1.Columns.Add("namamasakan", "Makanan")
        'DataGridView1.Columns.Add("harga", "Harga")
        DataGridView1.Columns.Add("jumlah", "Jumlah")
        DataGridView1.Columns.Add("total", "Total")
        AturKolom()
    End Sub

    Private Sub frmTransaksiJual_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call Otomatis()
    End Sub

    Private Sub frmTransaksiJual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call bukaDB()
        Call Otomatis()
        Call BuatKolomDGV()
        'AturKolom()
        Call isiGrid()
        Call bersih()
        Call isiCombo()
        Call isiCombo2()
        Label3.Text = Format(Now, "dd MMM yyyy")
    End Sub

    Sub TotalItem()
        Dim HitungItem As Integer = 0
        For I As Integer = 0 To DataGridView1.Rows.Count - 1
            HitungItem = HitungItem + Val(DataGridView1.Rows(I).Cells(7).Value)
            'TxtJumlah.Text = HitungItem
        Next
    End Sub

    Sub isiGrid()
        modConnection.bukaDB()
        da = New OdbcDataAdapter("SELECT namamasakan, jenismasakan, harga from tbmasakan", conn)
        ds = New DataSet
        da.Fill(ds, "tbmasakan")
        DataGridView1.DataSource = ds.Tables("tbmasakan")
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

            DataGridView1.Rows(e.RowIndex).Cells(1).Value = DataGridView1.Rows(e.RowIndex).Cells(4).Value * DataGridView1.Rows(e.RowIndex).Cells(0).Value

            Call hitungTotal()
        Call hitungItem()

    End Sub
    
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Nomor Transaksi Belum di isi !! ", MsgBoxStyle.Exclamation, "Peringatan")
        ElseIf ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Exclamation, "Peringatan")
        Else
            Call bukaDB()
            simpan = "INSERT INTO tbpenjualan (no_transaksi,namapelanggan,meja_pesanan,totalpesanan,totalharga) VALUES " & _
            "('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & Label9.Text & "','" & Label10.Text & "')"
            cmd = New Odbc.OdbcCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            cmd.Dispose()
            MsgBox("Data Transaksi " & TextBox1.Text & " Berhasil Disimpan", vbOK, "Transaksi Berhasil")
            bersih()
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class