-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Dec 20, 2018 at 11:04 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

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
(109, 'Paniz', 0, 50, 7, '2011-12-14', 1),
(110, 'Pauline', 1, 55, 6, '2010-01-01', 1),
(111, 'Kate', 1, 45, 8, '2011-12-03', 1),
(112, 'Mark', 0, 50, 6, '2010-03-05', 0),
(113, 'Julius', 0, 50, 5, '2015-05-02', 1);

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
(1061, 109, 1, '2012-03-02'),
(1062, 109, 2, '2012-04-04'),
(1063, 109, 3, '2012-06-04'),
(1064, 109, 4, '2012-09-03'),
(1065, 109, 5, '2012-12-05'),
(1066, 109, 6, '2013-02-12'),
(1067, 109, 7, '2013-04-05'),
(1068, 109, 8, '2013-07-07'),
(1069, 109, 9, '2013-10-23'),
(1070, 109, 10, '2013-12-12'),
(1071, 109, 11, '2014-03-04'),
(1072, 109, 12, '2014-06-22'),
(1073, 109, 13, '2015-09-20'),
(1074, 109, 14, '2015-12-20'),
(1075, 110, 1, '2010-02-07'),
(1076, 110, 2, '2010-05-16'),
(1077, 110, 3, '2010-08-23'),
(1078, 110, 4, '2010-12-30'),
(1079, 110, 5, '2010-02-03'),
(1080, 110, 6, '2010-04-06'),
(1081, 110, 7, '2010-09-09'),
(1082, 110, 8, '2010-12-06'),
(1083, 110, 9, '2011-04-08'),
(1084, 110, 10, '2011-09-03'),
(1085, 110, 11, '2011-02-09'),
(1086, 110, 12, '2011-07-18'),
(1087, 110, 13, '2011-12-05'),
(1088, 110, 14, '2012-05-07'),
(1089, 111, 1, '2012-01-03'),
(1090, 111, 2, '2012-03-06'),
(1091, 111, 3, '2012-07-23'),
(1092, 111, 4, '2012-10-01'),
(1093, 111, 5, '2013-01-09'),
(1094, 111, 6, '2013-05-17'),
(1095, 111, 7, '2013-08-01'),
(1096, 111, 8, '2013-11-04'),
(1097, 111, 9, '2014-03-19'),
(1098, 111, 10, '2014-05-30'),
(1099, 111, 11, '2014-08-23'),
(1100, 111, 12, '2014-12-03'),
(1101, 111, 13, '2015-02-03'),
(1102, 111, 14, '2015-06-23'),
(1103, 112, 1, '2010-04-05'),
(1104, 112, 2, '2010-07-21'),
(1105, 112, 3, '2010-10-01'),
(1106, 112, 4, '2011-01-08'),
(1107, 112, 5, '2011-05-19'),
(1108, 112, 6, '2011-09-30'),
(1109, 112, 7, '2011-12-30'),
(1110, 112, 8, '2012-03-06'),
(1111, 112, 9, '2012-07-04'),
(1112, 112, 10, '2012-12-05'),
(1113, 112, 11, '2013-03-06'),
(1114, 112, 12, '2013-07-04'),
(1115, 112, 13, '2013-10-18'),
(1116, 112, 14, '2014-01-09'),
(1117, 113, 1, '2015-06-03'),
(1118, 113, 2, '2015-09-02'),
(1119, 113, 3, '2016-03-03'),
(1120, 113, 4, '2016-05-02'),
(1121, 113, 5, '2016-09-05'),
(1122, 113, 6, '2016-12-09'),
(1123, 113, 7, '2017-03-07'),
(1124, 113, 8, '2017-07-04'),
(1125, 113, 9, '2017-10-23'),
(1126, 113, 10, '2017-12-04'),
(1127, 113, 11, '2018-04-12'),
(1128, 113, 12, '2018-06-25'),
(1129, 113, 13, '2018-08-23'),
(1130, 113, 14, '2018-12-20');

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
('Alex', '123', 0),
('Glen', '123', 0),
('Gulzat', '123', 0),
('Kaveh', '234', 0),
('Stuart', '123', 0);

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

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `children`
--
ALTER TABLE `children`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=114;
--
-- AUTO_INCREMENT for table `child_events`
--
ALTER TABLE `child_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1131;
--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
