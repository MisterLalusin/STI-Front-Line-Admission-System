-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 14, 2018 at 06:45 AM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.10

CREATE DATABASE dbfrontline;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbfrontline`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblenrollees`
--

CREATE TABLE `tblenrollees` (
  `id` int(11) NOT NULL,
  `transactionid` varchar(255) NOT NULL,
  `studentid` varchar(255) NOT NULL,
  `student` varchar(255) NOT NULL,
  `course` varchar(255) NOT NULL,
  `schoolyear` varchar(255) NOT NULL,
  `file` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblofficers`
--

CREATE TABLE `tblofficers` (
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `age` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `contactnumber` varchar(255) NOT NULL,
  `userlevel` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblofficers`
--

INSERT INTO `tblofficers` (`username`, `password`, `fullname`, `age`, `address`, `contactnumber`, `userlevel`) VALUES
('admin@sti.edu', '12345678', 'Lalusin, John Rovic D.', '17', 'Niing, 4324 San Antonio Quezon', '09158869980', 'Admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblenrollees`
--
ALTER TABLE `tblenrollees`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tblofficers`
--
ALTER TABLE `tblofficers`
  ADD PRIMARY KEY (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblenrollees`
--
ALTER TABLE `tblenrollees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
