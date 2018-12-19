-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Dec 19, 2018 at 08:46 AM
-- Server version: 5.7.23
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `child_development`
--
CREATE DATABASE IF NOT EXISTS `child_development` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `child_development`;

-- --------------------------------------------------------

--
-- Table structure for table `children`
--

CREATE TABLE `children` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `gender` tinyint(1) NOT NULL,
  `weight` int(11) NOT NULL,
  `height` int(11) NOT NULL,
  `birthdate` date NOT NULL,
  `breastfeeding` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `children`
--

INSERT INTO `children` (`id`, `name`, `gender`, `weight`, `height`, `birthdate`, `breastfeeding`) VALUES
(3, 'Keivan', 0, 300, 36, '0001-01-01', 1),
(4, 'Keivan', 0, 300, 36, '0001-01-01', 1);

-- --------------------------------------------------------

--
-- Table structure for table `child_events`
--

CREATE TABLE `child_events` (
  `id` int(11) NOT NULL,
  `child_id` int(11) NOT NULL,
  `event_id` int(11) NOT NULL,
  `time` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `child_events`
--

INSERT INTO `child_events` (`id`, `child_id`, `event_id`, `time`) VALUES
(20, 3, 1, '2016-11-11'),
(21, 3, 2, '2016-12-20'),
(22, 3, 3, '2017-01-13'),
(23, 3, 4, '2017-03-03'),
(24, 4, 1, '2016-11-11'),
(25, 4, 2, '2016-12-20'),
(26, 4, 3, '2017-01-13'),
(27, 4, 4, '2017-03-03');

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE `events` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `events`
--

INSERT INTO `events` (`id`, `name`) VALUES
(1, 'hold_head'),
(2, 'roll_over'),
(3, 'first_teeth'),
(4, 'sit'),
(5, 'crawl'),
(6, 'walk'),
(7, 'first_words'),
(8, 'self_feeding'),
(9, 'make_believe'),
(10, 'two_word_sentences'),
(11, 'potty_trained'),
(12, 'dresses_self'),
(13, 'tell_story'),
(14, 'read_write');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `child_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`username`, `password`, `child_id`) VALUES
('Kaveh', '234', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `children`
--
ALTER TABLE `children`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `child_events`
--
ALTER TABLE `child_events`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`id`);

  -- Indexes for table `events`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `children`
--
ALTER TABLE `children`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `child_events`
--
ALTER TABLE `child_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;