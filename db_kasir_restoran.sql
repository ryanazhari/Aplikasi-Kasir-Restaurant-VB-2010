-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 14, 2019 at 09:10 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kasir_restoran_beta2`
--

-- --------------------------------------------------------

--
-- Table structure for table `level`
--

CREATE TABLE `level` (
  `nama_level` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `level`
--

INSERT INTO `level` (`nama_level`) VALUES
('Kasir'),
('Manajer');

-- --------------------------------------------------------

--
-- Table structure for table `meja`
--

CREATE TABLE `meja` (
  `id_meja` int(11) NOT NULL,
  `no_meja` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `meja`
--

INSERT INTO `meja` (`id_meja`, `no_meja`) VALUES
(1, '01'),
(2, '02'),
(3, '03'),
(4, '04'),
(5, '05'),
(6, '06'),
(7, '07'),
(8, '08'),
(9, '09'),
(12, '10'),
(13, '11'),
(14, '13'),
(15, '14');

-- --------------------------------------------------------

--
-- Table structure for table `tbadmin`
--

CREATE TABLE `tbadmin` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `level` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbadmin`
--

INSERT INTO `tbadmin` (`username`, `password`, `nama`, `level`) VALUES
('admin', 'admin', 'Admin kasir', 'Kasir'),
('panda', 'panda', 'Zero Two', 'Manajer'),
('ryan', '123', 'Ryan Azhari', 'Manajer'),
('sasuke', 'admin', 'Abu', 'Kasir');

-- --------------------------------------------------------

--
-- Table structure for table `tbjenismasakan`
--

CREATE TABLE `tbjenismasakan` (
  `jenismasakan` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbjenismasakan`
--

INSERT INTO `tbjenismasakan` (`jenismasakan`) VALUES
('Makanan'),
('Minuman');

-- --------------------------------------------------------

--
-- Table structure for table `tbmasakan`
--

CREATE TABLE `tbmasakan` (
  `kodemasakan` varchar(6) NOT NULL,
  `namamasakan` varchar(30) NOT NULL,
  `jenismasakan` varchar(10) NOT NULL,
  `harga` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbmasakan`
--

INSERT INTO `tbmasakan` (`kodemasakan`, `namamasakan`, `jenismasakan`, `harga`) VALUES
('M1', 'Nasi Goreng', 'Makanan', 15000),
('M2', 'Baso Ichiraku', 'Makanan', 12000),
('M3', 'Teh Jus', 'Minuman', 10000),
('M4', 'Jeruk Peras', 'Minuman', 10000),
('M5', 'soto', 'Makanan', 12000);

-- --------------------------------------------------------

--
-- Table structure for table `tbpelanggan`
--

CREATE TABLE `tbpelanggan` (
  `kodepelanggan` varchar(6) NOT NULL,
  `namapelanggan` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbpelanggan`
--

INSERT INTO `tbpelanggan` (`kodepelanggan`, `namapelanggan`) VALUES
('P1', 'Mitsuha'),
('P2', 'Kaori Miyazono'),
('P3', 'Udin Parudin');

-- --------------------------------------------------------

--
-- Table structure for table `tbpenjualan`
--

CREATE TABLE `tbpenjualan` (
  `no_transaksi` varchar(5) NOT NULL,
  `namapelanggan` varchar(50) NOT NULL,
  `meja_pesanan` varchar(5) NOT NULL,
  `totalpesanan` int(11) NOT NULL,
  `totalharga` int(11) NOT NULL,
  `tanggalpembelian` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbpenjualan`
--

INSERT INTO `tbpenjualan` (`no_transaksi`, `namapelanggan`, `meja_pesanan`, `totalpesanan`, `totalharga`, `tanggalpembelian`) VALUES
('T1', 'Mitsuha', '03', 5, 49000, '2019-12-09 04:23:59'),
('T2', 'Kaori Miyazono', '07', 3, 34000, '2019-12-09 04:24:29'),
('T3', 'Mikasa', '10', 1, 34000, '2019-12-09 04:27:46'),
('T4', 'Udin Parudin', '04', 5, 60000, '2019-12-14 03:38:31');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `level`
--
ALTER TABLE `level`
  ADD PRIMARY KEY (`nama_level`);

--
-- Indexes for table `meja`
--
ALTER TABLE `meja`
  ADD PRIMARY KEY (`id_meja`);

--
-- Indexes for table `tbadmin`
--
ALTER TABLE `tbadmin`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `tbjenismasakan`
--
ALTER TABLE `tbjenismasakan`
  ADD PRIMARY KEY (`jenismasakan`);

--
-- Indexes for table `tbmasakan`
--
ALTER TABLE `tbmasakan`
  ADD PRIMARY KEY (`kodemasakan`);

--
-- Indexes for table `tbpelanggan`
--
ALTER TABLE `tbpelanggan`
  ADD PRIMARY KEY (`kodepelanggan`);

--
-- Indexes for table `tbpenjualan`
--
ALTER TABLE `tbpenjualan`
  ADD PRIMARY KEY (`no_transaksi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `meja`
--
ALTER TABLE `meja`
  MODIFY `id_meja` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
