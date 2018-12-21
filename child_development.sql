-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Dec 21, 2018 at 07:44 PM
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
(114, 'Keivan', 0, 95, 20, '2015-07-31', 1),
(115, 'Keivan', 0, 95, 20, '2015-07-31', 1),
(116, 'Mike', 0, 90, 19, '2012-12-14', 1);

-- --------------------------------------------------------

--
-- Table structure for table `child_events`
--

CREATE TABLE `child_events` (
  `id` int(11) NOT NULL,
  `child_id` int(11) NOT NULL,
  `event_id` int(11) NOT NULL,
  `time` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `child_events`
--

INSERT INTO `child_events` (`id`, `child_id`, `event_id`, `time`) VALUES
(1131, 114, 1, 10),
(1132, 114, 2, 15),
(1133, 114, 3, 20),
(1134, 114, 4, 27),
(1135, 114, 5, 36),
(1136, 114, 6, 49),
(1137, 114, 7, 63),
(1138, 114, 8, 79),
(1139, 114, 9, 95),
(1140, 114, 10, 116),
(1141, 114, 11, 127),
(1142, 114, 12, 140),
(1143, 114, 13, 160),
(1144, 114, 14, 175),
(1145, 115, 1, 10),
(1146, 115, 2, 15),
(1147, 115, 3, 20),
(1148, 115, 4, 27),
(1149, 115, 5, 36),
(1150, 115, 6, 49),
(1151, 115, 7, 63),
(1152, 115, 8, 79),
(1153, 115, 9, 95),
(1154, 115, 10, 116),
(1155, 115, 11, 127),
(1156, 115, 12, 140),
(1157, 115, 13, 160),
(1158, 115, 14, 175),
(1159, 116, 1, 9),
(1160, 116, 2, 17),
(1161, 116, 3, 26),
(1162, 116, 4, 40),
(1163, 116, 5, 48),
(1164, 116, 6, 52),
(1165, 116, 7, 58),
(1166, 116, 8, 75),
(1167, 116, 9, 91),
(1168, 116, 10, 104),
(1169, 116, 11, 120),
(1170, 116, 12, 138),
(1171, 116, 13, 159),
(1172, 116, 14, 199);

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
('Glen', '234', 0),
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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=117;

--
-- AUTO_INCREMENT for table `child_events`
--
ALTER TABLE `child_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1173;

--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
