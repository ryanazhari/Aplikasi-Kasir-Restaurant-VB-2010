Imports System.Data.Odbc

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmDataMakanan.MdiParent = Me
        frmDataMakanan.Show()
        frmDataPelanggan.Close()
        frmTransaksiJual.Close()
        frmTambahAdmin.Close()
        Transaksi.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmDataPelanggan.MdiParent = Me
        frmDataPelanggan.Show()
        frmDataMakanan.Close()
        frmTransaksiJual.Close()
        frmTambahAdmin.Close()
        Transaksi.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmTransaksiJual.MdiParent = Me
        frmDataPelanggan.Close()
        frmDataMakanan.Close()
        frmTransaksiJual.Show()
        frmTambahAdmin.Close()
        Transaksi.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmTambahAdmin.MdiParent = Me
        frmDataPelanggan.Close()
        frmDataMakanan.Close()
        frmTransaksiJual.Close()
        frmTambahAdmin.Show()
        Transaksi.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Transaksi.MdiParent = Me
        frmDataPelanggan.Close()
        frmDataMakanan.Close()
        frmTransaksiJual.Close()
        frmTambahAdmin.Close()
        Transaksi.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = Format(Now, "dd MMM yyyy")
        ToolStripStatusLabel4.Text = Format(Now, "hh:mm:ss")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
