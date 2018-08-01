-- Adminer 4.6.3 MySQL dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

DROP DATABASE IF EXISTS `rental`;
CREATE DATABASE `rental` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `rental`;

DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin` (
  `id_admin` int(4) NOT NULL AUTO_INCREMENT,
  `nama` varchar(30) NOT NULL,
  `email` varchar(30) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `telp` varchar(12) NOT NULL,
  `username` varchar(15) NOT NULL,
  `password` varchar(60) NOT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'admin',
  PRIMARY KEY (`id_admin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `admin` (`id_admin`, `nama`, `email`, `alamat`, `telp`, `username`, `password`, `status`) VALUES
(1,	'admin',	'admin@gmail.com',	'jogja',	'08123456789',	'admin',	'd033e22ae348aeb5660fc2140aec35850c4da997',	'admin');

DROP TABLE IF EXISTS `detail_transaksi`;
CREATE TABLE `detail_transaksi` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT,
  `id_transaksi` int(11) NOT NULL,
  `id_supir` int(11) NOT NULL,
  `jasa_supir` int(7) NOT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `fk_transaksi` (`id_transaksi`),
  KEY `fk_supir` (`id_supir`),
  CONSTRAINT `detail_transaksi_ibfk_1` FOREIGN KEY (`id_transaksi`) REFERENCES `transaksi` (`id_transaksi`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `detail_transaksi_ibfk_3` FOREIGN KEY (`id_supir`) REFERENCES `supir` (`id_supir`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


DROP TABLE IF EXISTS `konfirmasi`;
CREATE TABLE `konfirmasi` (
  `id_konfirmasi` int(11) NOT NULL AUTO_INCREMENT,
  `id_transaksi` int(11) NOT NULL,
  `bukti` varchar(100) NOT NULL,
  PRIMARY KEY (`id_konfirmasi`),
  KEY `fk_transaksi` (`id_transaksi`),
  CONSTRAINT `konfirmasi_ibfk_1` FOREIGN KEY (`id_transaksi`) REFERENCES `transaksi` (`id_transaksi`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


DROP TABLE IF EXISTS `mobil`;
CREATE TABLE `mobil` (
  `id_mobil` int(11) NOT NULL AUTO_INCREMENT,
  `jenis_mobil` varchar(30) NOT NULL,
  `no_mobil` varchar(10) NOT NULL,
  `merk` varchar(20) NOT NULL,
  `nama_mobil` varchar(30) NOT NULL,
  `harga` int(7) NOT NULL,
  `status` enum('Tidak Tersedia','Tersedia') NOT NULL,
  PRIMARY KEY (`id_mobil`),
  KEY `fk_jenis` (`jenis_mobil`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `mobil` (`id_mobil`, `jenis_mobil`, `no_mobil`, `merk`, `nama_mobil`, `harga`, `status`) VALUES
(5,	'Hatchback',	'12345',	'Honda',	'Jazz',	800000,	'Tidak Tersedia'),
(6,	'Hatchback',	'09876',	'Toyota',	'Yaris',	850000,	'Tersedia');

DROP TABLE IF EXISTS `pelanggan`;
CREATE TABLE `pelanggan` (
  `id_pelanggan` int(11) NOT NULL AUTO_INCREMENT,
  `no_ktp` char(16) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `email` varchar(30) NOT NULL,
  `no_telp` char(12) NOT NULL,
  `alamat` varchar(50) DEFAULT NULL,
  `username` varchar(10) NOT NULL,
  `password` varchar(60) NOT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'pelanggan',
  PRIMARY KEY (`id_pelanggan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `pelanggan` (`id_pelanggan`, `no_ktp`, `nama`, `email`, `no_telp`, `alamat`, `username`, `password`, `status`) VALUES
(5,	'3467236473217238',	'John Doe',	'john@doe.com',	'087736447716',	'Sukoharjo',	'john',	'D6B4E84EE7F31D88617A6B60421451272EBF1A3A',	'pelanggan');

DROP TABLE IF EXISTS `supir`;
CREATE TABLE `supir` (
  `id_supir` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(30) NOT NULL,
  `telp` char(12) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `status` enum('Tidak Tersedia','Tersedia') NOT NULL,
  PRIMARY KEY (`id_supir`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `supir` (`id_supir`, `nama`, `telp`, `alamat`, `status`) VALUES
(2,	'Febri',	'087736447890',	'Banyuwangi',	'Tersedia');

DROP TABLE IF EXISTS `transaksi`;
CREATE TABLE `transaksi` (
  `id_transaksi` int(11) NOT NULL AUTO_INCREMENT,
  `id_pelanggan` int(11) NOT NULL,
  `id_mobil` int(11) NOT NULL,
  `tgl_sewa` datetime NOT NULL,
  `tgl_ambil` datetime DEFAULT NULL,
  `tgl_kembali` datetime DEFAULT NULL,
  `lama` int(1) NOT NULL,
  `total_harga` int(7) NOT NULL,
  `status` enum('0','1') NOT NULL,
  `jaminan` varchar(30) NOT NULL,
  `denda` int(7) DEFAULT '0',
  `jatuh_tempo` datetime DEFAULT CURRENT_TIMESTAMP,
  `konfirmasi` enum('0','1') DEFAULT NULL,
  `pembatalan` enum('0','1') DEFAULT NULL,
  PRIMARY KEY (`id_transaksi`),
  KEY `fk_pelanggan` (`id_pelanggan`),
  KEY `fk_mobil` (`id_mobil`),
  CONSTRAINT `transaksi_ibfk_1` FOREIGN KEY (`id_pelanggan`) REFERENCES `pelanggan` (`id_pelanggan`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `transaksi_ibfk_2` FOREIGN KEY (`id_mobil`) REFERENCES `mobil` (`id_mobil`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- 2018-08-01 12:58:42
