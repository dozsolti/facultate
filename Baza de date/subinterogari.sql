-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 16 Dec 2016 la 10:10
-- Versiune server: 10.1.9-MariaDB
-- PHP Version: 5.6.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `subinterogari`
--

-- --------------------------------------------------------

--
-- Structura de tabel pentru tabelul `bursa`
--

CREATE TABLE `bursa` (
  `Tip` varchar(17) NOT NULL,
  `PMIN` int(4) DEFAULT NULL,
  `PMAX` int(4) DEFAULT NULL,
  `SUMA` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Salvarea datelor din tabel `bursa`
--

INSERT INTO `bursa` (`Tip`, `PMIN`, `PMAX`, `SUMA`) VALUES
('Bursa de exceptie', 2500, 9999, 300),
('Bursa de merit', 1800, 2499, 200),
('Bursa de studiu', 900, 1799, 150),
('Bursa sociala', 400, 899, 100),
('Fara bursa', 0, 399, NULL);

-- --------------------------------------------------------

--
-- Structura de tabel pentru tabelul `spec`
--

CREATE TABLE `spec` (
  `Cods` int(2) NOT NULL,
  `Nume` varchar(10) DEFAULT NULL,
  `Domeniu` varchar(14) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Salvarea datelor din tabel `spec`
--

INSERT INTO `spec` (`Cods`, `Nume`, `Domeniu`) VALUES
(11, 'Matematica', 'Stiinte exacte'),
(21, 'Geografie', 'Umanist'),
(24, 'Istorie', 'Umanist');

-- --------------------------------------------------------

--
-- Structura de tabel pentru tabelul `stud`
--

CREATE TABLE `stud` (
  `Matr` int(4) NOT NULL,
  `Nume` varchar(6) DEFAULT NULL,
  `An` int(1) DEFAULT NULL,
  `Grupa` varchar(5) DEFAULT NULL,
  `Datan` date DEFAULT NULL,
  `Loc` varchar(9) DEFAULT NULL,
  `Tutor` int(4) DEFAULT NULL,
  `Punctaj` int(4) DEFAULT NULL,
  `Cods` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Salvarea datelor din tabel `stud`
--

INSERT INTO `stud` (`Matr`, `Nume`, `An`, `Grupa`, `Datan`, `Loc`, `Tutor`, `Punctaj`, `Cods`) VALUES
(1325, 'Vasile', 2, '1122a', '1984-10-05', 'Pitesti', 1456, 390, 11),
(1456, 'George', 4, '1141a', '1982-03-12', 'Bucuresti', NULL, 2890, 11),
(1645, 'Maria', 3, '1131b', '1983-06-17', 'Ploiesti', NULL, 1400, 11),
(1925, 'Oana', 2, '2421a', '1984-12-20', 'Bucuresti', 4311, 760, 24),
(2101, 'Marius', 1, '2412b', '1985-09-02', 'Pitesti', 3514, 310, 24),
(2146, 'Stanca', 4, '2141a', '1982-05-15', 'Bucuresti', NULL, 620, 21),
(2215, 'Elena', 2, '2122a', '1984-08-29', 'Bucuresti', 2146, 890, 21),
(3145, 'Ion', 1, '2112b', '1985-01-24', 'Ploiesti', 3251, 1670, 21),
(3251, 'Alex', 5, '2153b', '1981-01-07', 'Brasov', NULL, 1570, 21),
(3514, 'Florea', 5, '2452b', '1981-02-03', 'Brasov', NULL, 3230, 24),
(4311, 'Adrian', 3, '2431a', '1983-07-31', 'Bucuresti', NULL, 450, 24),
(4705, 'Voicu', 2, '2421b', '1984-04-19', 'Brasov', 4311, 1290, 24);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bursa`
--
ALTER TABLE `bursa`
  ADD PRIMARY KEY (`Tip`),
  ADD UNIQUE KEY `Tip_UNIQUE` (`Tip`);

--
-- Indexes for table `spec`
--
ALTER TABLE `spec`
  ADD PRIMARY KEY (`Cods`),
  ADD UNIQUE KEY `Cods_UNIQUE` (`Cods`);

--
-- Indexes for table `stud`
--
ALTER TABLE `stud`
  ADD PRIMARY KEY (`Matr`),
  ADD UNIQUE KEY `Matr_UNIQUE` (`Matr`),
  ADD KEY `cods_idx` (`Cods`),
  ADD KEY `tutor_idx` (`Tutor`);

--
-- Restrictii pentru tabele sterse
--

--
-- Restrictii pentru tabele `stud`
--
ALTER TABLE `stud`
  ADD CONSTRAINT `cods` FOREIGN KEY (`Cods`) REFERENCES `spec` (`Cods`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `tutor` FOREIGN KEY (`Tutor`) REFERENCES `stud` (`Matr`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
