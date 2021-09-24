-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Sep 25, 2021 at 12:10 AM
-- Server version: 10.3.30-MariaDB
-- PHP Version: 7.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gubclub_test123`
--

-- --------------------------------------------------------

--
-- Table structure for table `admit`
--

CREATE TABLE `admit` (
  `studentId` int(11) NOT NULL,
  `semesterId` int(11) NOT NULL,
  `paymenyStatus` varchar(30) DEFAULT NULL,
  `admitType` varchar(30) NOT NULL,
  `approval` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `alluser`
--

CREATE TABLE `alluser` (
  `userId` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `role` varchar(20) NOT NULL,
  `created` datetime NOT NULL DEFAULT current_timestamp(),
  `modified` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `alluser`
--

INSERT INTO `alluser` (`userId`, `password`, `role`, `created`, `modified`) VALUES
('1', '1234', 'FacultyMember', '2021-09-25 00:08:53', '2021-09-25 00:08:53');

-- --------------------------------------------------------

--
-- Table structure for table `batch`
--

CREATE TABLE `batch` (
  `batchId` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `circularDate` date DEFAULT NULL,
  `deadline` date DEFAULT NULL,
  `classStartDate` date DEFAULT NULL,
  `month` date DEFAULT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `batch`
--

INSERT INTO `batch` (`batchId`, `name`, `circularDate`, `deadline`, `classStartDate`, `month`, `created`, `modified`) VALUES
(162, 'Summer-16', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(163, 'Fall-16', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(171, 'Spring-17', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(172, 'Summer-17', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(173, 'Fall-17', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(181, 'Spring-18', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(182, 'Summer-18', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(183, 'Fall-18', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(191, 'Spring-19', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(192, 'Summer-19', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(193, 'Fall-19', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(201, 'Spring-20', NULL, NULL, NULL, NULL, '2020-03-31 11:22:48', '2020-03-31 11:23:53'),
(202, 'Summer-20', NULL, NULL, NULL, NULL, '2021-09-09 14:09:56', '2021-09-09 14:09:56'),
(203, 'Fall-20', NULL, NULL, NULL, NULL, '2021-09-09 14:09:56', '2021-09-09 14:09:56'),
(211, 'Spring-21', NULL, NULL, NULL, NULL, '2021-09-09 14:09:56', '2021-09-09 14:09:56'),
(212, 'Summer-21', NULL, NULL, NULL, NULL, '2021-09-09 14:09:56', '2021-09-09 14:09:56'),
(213, 'Fall-21', NULL, NULL, NULL, NULL, '2021-09-09 14:09:56', '2021-09-09 14:09:56');

-- --------------------------------------------------------

--
-- Table structure for table `book`
--

CREATE TABLE `book` (
  `bookId` varchar(30) NOT NULL,
  `bookName` varchar(100) DEFAULT NULL,
  `author1` varchar(100) DEFAULT NULL,
  `author2` varchar(100) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `category` varchar(50) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `courseCode` varchar(20) NOT NULL,
  `courseTitle` varchar(80) NOT NULL,
  `credit` decimal(2,1) NOT NULL,
  `type` varchar(25) NOT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `shortDesc` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`courseCode`, `courseTitle`, `credit`, `type`, `created`, `modified`, `shortDesc`) VALUES
('BS-103', 'Bangladesh Studies', 3.0, 'Theory', '2021-09-13 09:31:05', '2021-09-13 09:31:05', ''),
('CSE-101', 'Fundamentals of Computer and Computin', 2.0, 'Theory', '2021-09-13 09:30:22', '2021-09-13 09:30:22', ''),
('CSE-105', 'Fundamentals of Computer and Computing Lab', 1.5, 'Lab', '2021-09-13 09:31:54', '2021-09-13 09:31:54', ''),
('CSE-106', 'Fundamentals of programming', 3.0, 'Theory', '2021-09-19 05:56:16', '2021-09-19 05:56:16', ''),
('CSE-107', 'Discrete Mathematics', 3.0, 'Theory', '2021-09-13 10:15:36', '2021-09-13 10:15:36', ''),
('CSE-108', 'Chemistry', 3.0, 'Theory', '2021-09-19 06:05:19', '2021-09-19 06:05:19', ''),
('CSE-109', 'Fundamentals of programming Lab', 1.5, 'Lab', '2021-09-19 05:56:46', '2021-09-19 05:56:46', ''),
('CSE-111', 'Digital Logic Design', 3.0, 'Theory', '2021-09-19 06:03:35', '2021-09-19 06:03:35', ''),
('CSE-112', 'Electrical Circuits', 3.0, 'Theory', '2021-09-19 05:57:34', '2021-09-19 05:57:34', ''),
('CSE-114', 'Degital Logic Design Lab', 1.5, 'Lab', '2021-09-19 06:03:56', '2021-09-19 06:03:56', ''),
('CSE-115', 'Electrical Circuits Lab', 1.5, 'Lab', '2021-09-19 05:57:58', '2021-09-19 05:57:58', ''),
('CSE-201', 'Object oriented programming language', 3.0, 'Theory', '2021-09-19 06:04:26', '2021-09-19 06:04:26', ''),
('CSE-202', 'Electronic Devices and Circuits', 3.0, 'Theory', '2021-09-19 06:00:56', '2021-09-19 06:00:56', ''),
('CSE-204', 'Object oriented programming language Lab', 1.5, 'Lab', '2021-09-19 06:04:47', '2021-09-19 06:04:47', ''),
('CSE-205', 'Electronic Devices and Circuits Lab', 1.5, 'Lab', '2021-09-19 06:02:29', '2021-09-19 06:02:29', ''),
('CSE-206', 'Data Structures', 3.0, 'Theory', '2021-09-19 05:58:29', '2021-09-19 05:58:29', ''),
('CSE-207', 'Database Management System-1', 3.0, 'Theory', '2021-09-19 06:06:47', '2021-09-19 06:06:47', ''),
('CSE-208', 'Physics', 2.0, 'Theory', '2021-09-19 06:02:50', '2021-09-19 06:02:50', ''),
('CSE-209', 'Introduction to Mechatronics', 2.0, 'Theory', '2021-09-19 06:09:11', '2021-09-19 06:09:11', ''),
('CSE-210', 'Data Structures Lab', 1.5, 'Lab', '2021-09-19 06:00:27', '2021-09-19 06:00:27', ''),
('CSE-211', 'Database Management System-1 Lab', 1.5, 'Lab', '2021-09-19 06:07:16', '2021-09-19 06:07:16', ''),
('CSE-212', 'Design and analysis of Algorithms', 3.0, 'Theory', '2021-09-19 06:10:31', '2021-09-19 06:10:31', ''),
('CSE-213', 'Data and Telecommunication ', 3.0, 'Theory', '2021-09-19 06:09:31', '2021-09-19 06:09:31', ''),
('CSE-214', 'Computer Architectures and Organization', 3.0, 'Theory', '2021-09-19 06:11:38', '2021-09-19 06:11:38', ''),
('CSE-215', 'Design and analysis of Algorithms Lab', 1.5, 'Lab', '2021-09-19 06:11:01', '2021-09-19 06:11:01', ''),
('CSE-216', 'Data and Telecommunication  Lab', 1.5, 'Lab', '2021-09-19 06:10:03', '2021-09-19 06:10:03', ''),
('CSE-217', 'Application Development Lab', 1.5, 'Lab', '2021-09-19 06:12:59', '2021-09-19 06:12:59', ''),
('CSE-301', 'Operating System', 3.0, 'Theory', '2021-09-19 06:11:59', '2021-09-19 06:11:59', ''),
('CSE-302', 'Software Engineering', 3.0, 'Theory', '2021-09-19 06:07:42', '2021-09-19 06:07:42', ''),
('CSE-303', 'Database Management System-2', 3.0, 'Theory', '2021-09-19 06:17:38', '2021-09-19 06:17:38', ''),
('CSE-304', 'Operating System Lab', 1.5, 'Lab', '2021-09-19 06:12:19', '2021-09-19 06:12:19', ''),
('CSE-305', 'Software Engineering Lab', 1.5, 'Lab', '2021-09-19 06:08:02', '2021-09-19 06:08:02', ''),
('CSE-307', 'Microprocessor and Microcontroller', 3.0, 'Theory', '2021-09-19 06:14:44', '2021-09-19 06:14:44', ''),
('CSE-309', 'Numarical Methods', 3.0, 'Theory', '2021-09-19 06:19:44', '2021-09-19 06:19:44', ''),
('CSE-310', 'Microprocessor and Assembly Language Lab', 1.5, 'Lab', '2021-09-19 06:15:09', '2021-09-19 06:15:09', ''),
('CSE-311', 'Microcontroller Lab', 1.5, 'Lab', '2021-09-19 06:15:54', '2021-09-19 06:15:54', ''),
('CSE-312', 'Numarical Methods Lab', 1.5, 'Lab', '2021-09-19 06:20:04', '2021-09-19 06:20:04', ''),
('CSE-313', 'Computer Networking', 3.0, 'Theory', '2021-09-19 06:21:31', '2021-09-19 06:21:31', ''),
('CSE-314', 'Finite language Automata and computability', 3.0, 'Theory', '2021-09-19 06:23:12', '2021-09-19 06:23:12', ''),
('CSE-317', 'Computer Networking Lab', 1.5, 'Lab', '2021-09-19 06:21:49', '2021-09-19 06:21:49', ''),
('CSE-401', 'Artificial Intelligence', 3.0, 'Theory', '2021-09-19 06:13:49', '2021-09-19 08:33:20', ''),
('CSE-402', 'Mathematical  and statistical  analysis for engineers', 3.0, 'Theory', '2021-09-19 06:17:55', '2021-09-19 06:17:55', ''),
('CSE-403', 'Computer Graphics', 3.0, 'Theory', '2021-09-19 06:18:18', '2021-09-19 06:18:18', ''),
('CSE-404', 'Artificial Intelligence Lab', 1.5, 'Lab', '2021-09-19 06:14:06', '2021-09-19 06:14:06', ''),
('CSE-405', 'Internet Programming Lab', 1.5, 'Lab', '2021-09-19 06:20:53', '2021-09-19 06:20:53', ''),
('CSE-406', 'Computer Graphics Lab', 1.5, 'Lab', '2021-09-19 06:18:39', '2021-09-19 06:18:39', ''),
('CSE-407', 'Parallel and distributed system', 3.0, 'Theory', '2021-09-19 06:23:33', '2021-09-19 06:23:33', ''),
('CSE-408', 'Cryptography and Security', 3.0, 'Theory', '2021-09-19 06:19:04', '2021-09-19 06:19:04', ''),
('CSE-410', 'Parallel and distributed system Lab', 1.5, 'Lab', '2021-09-19 06:24:00', '2021-09-19 06:24:00', ''),
('CSE-411', 'Cryptography and Security Lab', 1.5, 'Lab', '2021-09-19 06:19:26', '2021-09-19 06:19:26', ''),
('CSE-415', 'Project', 6.0, 'Intern/Project /Thesis', '2021-09-19 06:29:29', '2021-09-19 06:29:29', ''),
('CSE-419', 'Compiler Design', 2.0, 'Theory', '2021-09-19 06:16:46', '2021-09-19 06:16:46', ''),
('CSE-420', 'Compiler Design Lab', 1.5, 'Lab', '2021-09-19 06:17:16', '2021-09-19 06:17:16', ''),
('ENG-102', 'Basic English', 2.5, 'Theory', '2021-09-19 05:55:18', '2021-09-19 05:55:18', ''),
('ENG-110', 'Developing English Language Skill Lab', 1.5, 'Lab', '2021-09-19 06:08:21', '2021-09-19 06:08:21', ''),
('ENG-306', 'Technical Writing and Presentation Lab', 1.5, 'Lab', '2021-09-19 06:14:24', '2021-09-19 06:14:24', ''),
('MAT-104', 'Differential and Integral Calculus', 3.0, 'Theory', '2021-09-13 09:28:49', '2021-09-13 09:28:49', ''),
('MAT-113', 'Method of Integration, Differential Equations and Series', 3.0, 'Theory', '2021-09-19 06:06:19', '2021-09-19 06:06:19', ''),
('MAT-203', 'Linear Algebra', 3.0, 'Theory', '2021-09-19 06:08:42', '2021-09-19 06:08:42', ''),
('MAT-308', 'Multivariable Calculus and Geometry', 3.0, 'Theory', '2021-09-19 06:13:18', '2021-09-19 06:13:18', ''),
('SCO-216', 'Economics', 2.0, 'Theory', '2021-09-19 06:16:17', '2021-09-19 06:16:17', ''),
('SCO-409', 'Society and Technology', 2.0, 'Theory', '2021-09-19 06:24:22', '2021-09-19 06:24:22', ''),
('SCO-412', 'Professional ethics in engineering', 3.0, 'Theory', '2021-09-19 06:21:14', '2021-09-19 06:21:14', ''),
('STA-315', 'Introduction to Statistics and Probability', 3.0, 'Theory', '2021-09-19 06:13:31', '2021-09-19 06:13:31', '');

-- --------------------------------------------------------

--
-- Table structure for table `CourseProgram`
--

CREATE TABLE `CourseProgram` (
  `programId` int(11) NOT NULL,
  `courseCode` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `CourseProgram`
--

INSERT INTO `CourseProgram` (`programId`, `courseCode`) VALUES
(11, 'BS-103'),
(11, 'CSE-101'),
(11, 'CSE-105'),
(11, 'CSE-106'),
(11, 'CSE-107'),
(11, 'CSE-108'),
(11, 'CSE-109'),
(11, 'CSE-111'),
(11, 'CSE-112'),
(11, 'CSE-114'),
(11, 'CSE-115'),
(11, 'CSE-201'),
(11, 'CSE-202'),
(11, 'CSE-204'),
(11, 'CSE-205'),
(11, 'CSE-206'),
(11, 'CSE-207'),
(11, 'CSE-208'),
(11, 'CSE-209'),
(11, 'CSE-210'),
(11, 'CSE-211'),
(11, 'CSE-212'),
(11, 'CSE-213'),
(11, 'CSE-214'),
(11, 'CSE-215'),
(11, 'CSE-216'),
(11, 'CSE-217'),
(11, 'CSE-301'),
(11, 'CSE-302'),
(11, 'CSE-303'),
(11, 'CSE-304'),
(11, 'CSE-305'),
(11, 'CSE-307'),
(11, 'CSE-309'),
(11, 'CSE-310'),
(11, 'CSE-311'),
(11, 'CSE-312'),
(11, 'CSE-313'),
(11, 'CSE-314'),
(11, 'CSE-317'),
(11, 'CSE-401'),
(11, 'CSE-402'),
(11, 'CSE-403'),
(11, 'CSE-404'),
(11, 'CSE-405'),
(11, 'CSE-406'),
(11, 'CSE-407'),
(11, 'CSE-408'),
(11, 'CSE-410'),
(11, 'CSE-411'),
(11, 'CSE-415'),
(11, 'CSE-419'),
(11, 'CSE-420'),
(11, 'ENG-102'),
(11, 'ENG-110'),
(11, 'ENG-306'),
(11, 'MAT-104'),
(11, 'MAT-113'),
(11, 'MAT-203'),
(11, 'MAT-308'),
(11, 'SCO-216'),
(11, 'SCO-409'),
(11, 'SCO-412'),
(11, 'STA-315'),
(13, 'BS-103'),
(13, 'CSE-106'),
(13, 'CSE-107'),
(13, 'CSE-108'),
(13, 'CSE-109'),
(13, 'CSE-111'),
(13, 'CSE-112'),
(13, 'CSE-114'),
(13, 'CSE-115'),
(13, 'CSE-201'),
(13, 'CSE-202'),
(13, 'CSE-204'),
(13, 'CSE-205'),
(13, 'CSE-206'),
(13, 'CSE-207'),
(13, 'CSE-208'),
(13, 'CSE-209'),
(13, 'CSE-210'),
(13, 'CSE-211'),
(13, 'CSE-212'),
(13, 'CSE-213'),
(13, 'CSE-214'),
(13, 'CSE-215'),
(13, 'CSE-216'),
(13, 'CSE-217'),
(13, 'CSE-301'),
(13, 'CSE-302'),
(13, 'CSE-303'),
(13, 'CSE-304'),
(13, 'CSE-305'),
(13, 'CSE-307'),
(13, 'CSE-309'),
(13, 'CSE-310'),
(13, 'CSE-311'),
(13, 'CSE-312'),
(13, 'CSE-313'),
(13, 'CSE-314'),
(13, 'CSE-317'),
(13, 'CSE-401'),
(13, 'CSE-402'),
(13, 'CSE-403'),
(13, 'CSE-404'),
(13, 'CSE-405'),
(13, 'CSE-406'),
(13, 'CSE-407'),
(13, 'CSE-408'),
(13, 'CSE-410'),
(13, 'CSE-411'),
(13, 'CSE-415'),
(13, 'CSE-419'),
(13, 'CSE-420'),
(13, 'ENG-102'),
(13, 'ENG-110'),
(13, 'ENG-306'),
(13, 'MAT-104'),
(13, 'MAT-113'),
(13, 'MAT-203'),
(13, 'MAT-308'),
(13, 'SCO-216'),
(13, 'SCO-409'),
(13, 'SCO-412'),
(13, 'STA-315');

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `departmentId` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `head` int(11) DEFAULT NULL,
  `facultyId` int(11) NOT NULL,
  `location` varchar(150) NOT NULL,
  `contact` varchar(20) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`departmentId`, `name`, `head`, `facultyId`, `location`, `contact`, `created`, `modified`) VALUES
(11, 'Computer Science and Engineering', NULL, 11, 'GUB second Campus', '017362345545', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(12, 'Electrical and Electronics Engineering', NULL, 11, 'GUB second Campus', '0174645454', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(13, 'Business Administration', NULL, 12, 'GUB 1st Campus', '01565656456', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(14, 'Law', NULL, 13, 'GUB 1st campus', '01898966565', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(15, 'Library and Information Science', NULL, 14, 'GUB 1st campus', '017362345545', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(16, 'English', NULL, 14, 'GUB 1st campus', '017362345545', '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `education`
--

CREATE TABLE `education` (
  `educationId` int(11) NOT NULL,
  `exam` varchar(50) NOT NULL,
  `year` int(11) NOT NULL,
  `rollID` varchar(25) NOT NULL,
  `department` varchar(50) DEFAULT NULL,
  `baord` varchar(80) NOT NULL,
  `resultType` varchar(20) NOT NULL,
  `resultClass` int(11) DEFAULT NULL,
  `resultGPA` decimal(6,2) DEFAULT NULL,
  `outOf` decimal(6,2) DEFAULT NULL,
  `institute` varchar(80) DEFAULT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `education`
--

INSERT INTO `education` (`educationId`, `exam`, `year`, `rollID`, `department`, `baord`, `resultType`, `resultClass`, `resultGPA`, `outOf`, `institute`, `created`, `modified`) VALUES
(172011001, 'asa', 2020, '256', 'asa', 'asas', 'GPA', NULL, 4.00, 5.00, NULL, '2021-09-13 11:11:25', '2021-09-13 11:11:25'),
(213011002, 'ok', 2021, '1234', 'jk', 's;', 'CLASS', 1, NULL, 3.00, NULL, '2021-09-09 18:41:06', '2021-09-09 18:41:06'),
(213011002, 'tes', 2019, '445', 'sa', 'as', 'GPA', NULL, 3.50, 5.00, NULL, '2021-09-09 18:41:06', '2021-09-09 18:41:06');

-- --------------------------------------------------------

--
-- Table structure for table `experience`
--

CREATE TABLE `experience` (
  `studentId` int(11) NOT NULL,
  `position` varchar(50) DEFAULT NULL,
  `organization` varchar(100) DEFAULT NULL,
  `organizationAddress` varchar(200) DEFAULT NULL,
  `jobLocation` varchar(200) DEFAULT NULL,
  `contact` varchar(30) DEFAULT NULL,
  `joining` date DEFAULT NULL,
  `resign` date DEFAULT NULL,
  `responsiblities` varchar(150) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `faculty`
--

CREATE TABLE `faculty` (
  `facultyId` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `dean` int(11) DEFAULT NULL,
  `contact` varchar(20) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `faculty`
--

INSERT INTO `faculty` (`facultyId`, `name`, `dean`, `contact`, `created`, `modified`) VALUES
(11, 'Science and Technology', NULL, '+456465', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(12, 'Business Administration', NULL, '+456465', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(13, 'Law', NULL, '+456465', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(14, 'Arts and Social Science', NULL, '+456465', '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `facultymember`
--

CREATE TABLE `facultymember` (
  `facultyMemberId` int(11) NOT NULL,
  `name` varchar(60) NOT NULL,
  `departmentId` int(11) DEFAULT NULL,
  `father` varchar(60) NOT NULL,
  `mother` varchar(60) NOT NULL,
  `contact` varchar(20) NOT NULL,
  `alternativeContact` varchar(20) DEFAULT NULL,
  `mailingAddress` varchar(150) NOT NULL,
  `permanentAddress` varchar(150) NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `gender` varchar(20) NOT NULL,
  `reilgion` varchar(20) NOT NULL,
  `bloodGroup` varchar(10) NOT NULL,
  `NID` varchar(20) NOT NULL,
  `birthReg` varchar(20) NOT NULL,
  `nationality` varchar(20) NOT NULL,
  `dob` date NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facultymember`
--

INSERT INTO `facultymember` (`facultyMemberId`, `name`, `departmentId`, `father`, `mother`, `contact`, `alternativeContact`, `mailingAddress`, `permanentAddress`, `email`, `gender`, `reilgion`, `bloodGroup`, `NID`, `birthReg`, `nationality`, `dob`, `created`, `modified`) VALUES
(1, 'test1', 11, 'test', 'test', 'test', 'test', 'test', 'tetst', 'test', 'test', 'test', 'test', 'test', 'test', 'test', '2021-07-11', '2021-08-31 00:22:43', '2021-08-31 00:22:43');

-- --------------------------------------------------------

--
-- Table structure for table `guardian`
--

CREATE TABLE `guardian` (
  `studentId` int(11) NOT NULL,
  `name` varchar(60) DEFAULT NULL,
  `contact` varchar(20) DEFAULT NULL,
  `mailingAddress` varchar(200) DEFAULT NULL,
  `permanentAddress` varchar(200) DEFAULT NULL,
  `relationWithStudent` varchar(30) DEFAULT NULL,
  `remark` varchar(30) DEFAULT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `guardian`
--

INSERT INTO `guardian` (`studentId`, `name`, `contact`, `mailingAddress`, `permanentAddress`, `relationWithStudent`, `remark`, `created`, `modified`) VALUES
(172011001, 'test', 'test', 'test', NULL, 'test', NULL, '2021-09-13 11:11:24', '2021-09-13 11:11:24'),
(213011002, 'test update g', '5', 'test update g', NULL, 'da', NULL, '2021-09-09 18:41:05', '2021-09-20 19:30:03');

-- --------------------------------------------------------

--
-- Table structure for table `history`
--

CREATE TABLE `history` (
  `target` varchar(55) NOT NULL,
  `command` varchar(250) NOT NULL,
  `remark` int(11) NOT NULL,
  `hitTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `notregister`
--

CREATE TABLE `notregister` (
  `studentId` int(11) NOT NULL,
  `semesterId` int(11) NOT NULL,
  `remark` varchar(200) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `offeredcourse`
--

CREATE TABLE `offeredcourse` (
  `courseCode` varchar(30) NOT NULL,
  `batchId` int(11) NOT NULL,
  `semesterId` int(11) NOT NULL,
  `programId` int(11) NOT NULL,
  `facultyMemberId` int(11) DEFAULT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `offeredcourse`
--

INSERT INTO `offeredcourse` (`courseCode`, `batchId`, `semesterId`, `programId`, `facultyMemberId`, `created`, `modified`) VALUES
('BS-103', 173, 20173, 11, 1, '2021-09-19 08:13:48', '2021-09-19 08:13:48'),
('CSE-101', 173, 20173, 11, 1, '2021-09-19 08:13:51', '2021-09-19 08:13:51'),
('CSE-105', 173, 20173, 11, 1, '2021-09-19 08:13:52', '2021-09-19 08:13:52'),
('CSE-106', 173, 20181, 11, NULL, '2021-09-19 08:15:36', '2021-09-19 08:15:36'),
('CSE-107', 173, 20181, 11, NULL, '2021-09-19 08:15:38', '2021-09-19 08:15:38'),
('CSE-108', 173, 20183, 11, NULL, '2021-09-19 08:20:27', '2021-09-19 08:20:27'),
('CSE-109', 173, 20181, 11, NULL, '2021-09-19 08:15:37', '2021-09-19 08:15:37'),
('CSE-111', 173, 20183, 11, 1, '2021-09-19 08:20:23', '2021-09-19 08:20:23'),
('CSE-112', 173, 20181, 11, NULL, '2021-09-19 08:15:39', '2021-09-19 08:15:39'),
('CSE-114', 173, 20183, 11, 1, '2021-09-19 08:20:24', '2021-09-19 08:20:24'),
('CSE-115', 173, 20181, 11, NULL, '2021-09-19 08:15:40', '2021-09-19 08:15:40'),
('CSE-201', 173, 20183, 11, NULL, '2021-09-19 08:20:25', '2021-09-19 08:20:25'),
('CSE-202', 173, 20182, 11, NULL, '2021-09-19 08:17:54', '2021-09-19 08:17:54'),
('CSE-204', 173, 20183, 11, NULL, '2021-09-19 08:20:26', '2021-09-19 08:20:26'),
('CSE-205', 173, 20182, 11, NULL, '2021-09-19 08:17:54', '2021-09-19 08:17:54'),
('CSE-206', 173, 20182, 11, NULL, '2021-09-19 08:17:52', '2021-09-19 08:17:52'),
('CSE-207', 173, 20191, 11, NULL, '2021-09-19 08:22:04', '2021-09-19 08:22:04'),
('CSE-208', 173, 20182, 11, NULL, '2021-09-19 08:17:55', '2021-09-19 08:17:55'),
('CSE-209', 173, 20192, 11, NULL, '2021-09-19 08:23:55', '2021-09-19 08:23:55'),
('CSE-210', 173, 20182, 11, NULL, '2021-09-19 08:17:53', '2021-09-19 08:17:53'),
('CSE-211', 173, 20191, 11, NULL, '2021-09-19 08:22:04', '2021-09-19 08:22:04'),
('CSE-212', 173, 20193, 11, NULL, '2021-09-19 08:24:55', '2021-09-19 08:24:55'),
('CSE-213', 173, 20192, 11, NULL, '2021-09-19 08:23:56', '2021-09-19 08:23:56'),
('CSE-214', 173, 20193, 11, NULL, '2021-09-19 08:24:57', '2021-09-19 08:24:57'),
('CSE-215', 173, 20193, 11, NULL, '2021-09-19 08:24:56', '2021-09-19 08:24:56'),
('CSE-216', 173, 20192, 11, NULL, '2021-09-19 08:23:57', '2021-09-19 08:23:57'),
('CSE-217', 173, 20201, 11, NULL, '2021-09-19 08:36:40', '2021-09-19 08:36:40'),
('CSE-301', 173, 20193, 11, NULL, '2021-09-19 08:24:58', '2021-09-19 08:24:58'),
('CSE-302', 173, 20191, 11, NULL, '2021-09-19 08:22:05', '2021-09-19 08:22:05'),
('CSE-303', 173, 20203, 11, NULL, '2021-09-19 08:40:38', '2021-09-19 08:40:38'),
('CSE-304', 173, 20193, 11, NULL, '2021-09-19 08:24:59', '2021-09-19 08:24:59'),
('CSE-305', 173, 20191, 11, NULL, '2021-09-19 08:22:06', '2021-09-19 08:22:06'),
('CSE-307', 173, 20202, 11, NULL, '2021-09-19 08:39:15', '2021-09-19 08:39:15'),
('CSE-309', 173, 20211, 11, NULL, '2021-09-19 08:47:33', '2021-09-19 08:47:33'),
('CSE-310', 173, 20202, 11, NULL, '2021-09-19 08:39:16', '2021-09-19 08:39:16'),
('CSE-311', 173, 20202, 11, NULL, '2021-09-19 08:39:17', '2021-09-19 08:39:17'),
('CSE-312', 173, 20211, 11, NULL, '2021-09-19 08:47:34', '2021-09-19 08:47:34'),
('CSE-313', 173, 20211, 11, NULL, '2021-09-19 08:47:37', '2021-09-19 08:47:37'),
('CSE-314', 173, 20212, 11, NULL, '2021-09-19 08:49:07', '2021-09-19 08:49:07'),
('CSE-317', 173, 20211, 11, NULL, '2021-09-19 08:47:38', '2021-09-19 08:47:38'),
('CSE-401', 173, 20201, 11, NULL, '2021-09-19 08:36:43', '2021-09-19 08:36:43'),
('CSE-402', 173, 20203, 11, NULL, '2021-09-19 08:40:39', '2021-09-19 08:40:39'),
('CSE-403', 173, 20203, 11, NULL, '2021-09-19 08:40:39', '2021-09-19 08:40:39'),
('CSE-404', 173, 20201, 11, NULL, '2021-09-19 08:36:44', '2021-09-19 08:36:44'),
('CSE-405', 173, 20211, 11, NULL, '2021-09-19 08:47:35', '2021-09-19 08:47:35'),
('CSE-406', 173, 20203, 11, NULL, '2021-09-19 08:40:40', '2021-09-19 08:40:40'),
('CSE-407', 173, 20212, 11, NULL, '2021-09-19 08:49:08', '2021-09-19 08:49:08'),
('CSE-408', 173, 20203, 11, NULL, '2021-09-19 08:40:41', '2021-09-19 08:40:41'),
('CSE-410', 173, 20212, 11, NULL, '2021-09-19 08:49:09', '2021-09-19 08:49:09'),
('CSE-411', 173, 20203, 11, NULL, '2021-09-19 08:40:42', '2021-09-19 08:40:42'),
('CSE-415', 173, 20211, 11, NULL, '2021-09-19 08:47:39', '2021-09-19 08:47:39'),
('CSE-415', 173, 20212, 11, NULL, '2021-09-19 08:49:11', '2021-09-19 08:49:11'),
('CSE-419', 173, 20202, 11, NULL, '2021-09-19 08:39:19', '2021-09-19 08:39:19'),
('CSE-420', 173, 20202, 11, NULL, '2021-09-19 08:39:19', '2021-09-19 08:39:19'),
('ENG-102', 173, 20173, 11, 1, '2021-09-19 08:13:49', '2021-09-19 08:13:49'),
('ENG-110', 173, 20192, 11, NULL, '2021-09-19 08:23:53', '2021-09-19 08:23:53'),
('ENG-306', 173, 20202, 11, NULL, '2021-09-19 08:39:14', '2021-09-19 08:39:14'),
('MAT-104', 173, 20173, 11, 1, '2021-09-19 08:13:50', '2021-09-19 08:13:50'),
('MAT-113', 173, 20191, 11, NULL, '2021-09-19 08:22:03', '2021-09-19 08:22:03'),
('MAT-203', 173, 20192, 11, NULL, '2021-09-19 08:23:54', '2021-09-19 08:23:54'),
('MAT-308', 173, 20201, 11, NULL, '2021-09-19 08:36:41', '2021-09-19 08:36:41'),
('SCO-216', 173, 20202, 11, NULL, '2021-09-19 08:39:18', '2021-09-19 08:39:18'),
('SCO-409', 173, 20212, 11, NULL, '2021-09-19 08:49:10', '2021-09-19 08:49:10'),
('SCO-412', 173, 20211, 11, NULL, '2021-09-19 08:47:36', '2021-09-19 08:47:36'),
('STA-315', 173, 20201, 11, NULL, '2021-09-19 08:36:42', '2021-09-19 08:36:42');

-- --------------------------------------------------------

--
-- Table structure for table `officer`
--

CREATE TABLE `officer` (
  `officerId` int(11) NOT NULL,
  `position` varchar(50) DEFAULT NULL,
  `name` varchar(60) NOT NULL,
  `father` varchar(60) NOT NULL,
  `mother` varchar(60) NOT NULL,
  `contact` varchar(20) NOT NULL,
  `alternativeContact` varchar(20) DEFAULT NULL,
  `mailingAddress` varchar(150) NOT NULL,
  `permanentAddress` varchar(150) NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `gender` varchar(20) NOT NULL,
  `reilgion` varchar(20) NOT NULL,
  `bloodGroup` varchar(10) NOT NULL,
  `NID` varchar(20) NOT NULL,
  `birthReg` varchar(20) NOT NULL,
  `nationality` varchar(20) NOT NULL,
  `dob` date NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `orderbook`
--

CREATE TABLE `orderbook` (
  `orderId` int(11) NOT NULL,
  `bookId` varchar(30) NOT NULL,
  `orderBy` int(11) NOT NULL,
  `orderDate` datetime DEFAULT NULL,
  `receiveDate` datetime DEFAULT NULL,
  `approveBy` int(11) DEFAULT NULL,
  `status` varchar(30) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `studentId` int(11) NOT NULL,
  `semesterId` int(11) NOT NULL,
  `installmentNo` int(11) NOT NULL,
  `acmount` decimal(10,0) DEFAULT NULL,
  `status` varchar(30) DEFAULT NULL,
  `paymentDate` datetime DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `program`
--

CREATE TABLE `program` (
  `programId` int(11) NOT NULL,
  `departmentId` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `shift` varchar(20) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `program`
--

INSERT INTO `program` (`programId`, `departmentId`, `name`, `shift`, `created`, `modified`) VALUES
(11, 11, 'B.Sc in CSE', 'Regular', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(12, 12, 'B.Sc in EEE', 'Regular', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(13, 11, 'B.Sc in CSE', 'Evening', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(14, 12, 'B.Sc in EEE', 'Evening', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(15, 13, 'BBA', 'Regular', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(16, 13, 'MBA', 'Evening', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(17, 13, 'EMBA', 'Evening', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(18, 14, 'LLB', 'Regular', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(19, 14, 'LLM', 'Evening', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(20, 16, 'B.A in English', 'Regular', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(21, 16, 'M.A in English', 'Regular', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(22, 15, 'Library Science', 'Evening', '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `registration`
--

CREATE TABLE `registration` (
  `registrationId` varchar(15) NOT NULL,
  `studentId` int(11) NOT NULL,
  `courseCode` varchar(20) NOT NULL,
  `semesterId` int(11) NOT NULL,
  `remarkFaculty` varchar(50) DEFAULT NULL,
  `facultyMemberId` int(11) DEFAULT NULL,
  `reamrkRegister` varchar(50) DEFAULT NULL,
  `staffId` int(11) DEFAULT NULL,
  `regDate` datetime NOT NULL,
  `regType` varchar(20) DEFAULT NULL,
  `attendance` decimal(4,2) DEFAULT NULL,
  `assignment` decimal(4,2) DEFAULT NULL,
  `classMark` decimal(4,2) DEFAULT NULL,
  `midViva` decimal(4,2) DEFAULT NULL,
  `final` decimal(4,2) DEFAULT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `registration`
--

INSERT INTO `registration` (`registrationId`, `studentId`, `courseCode`, `semesterId`, `remarkFaculty`, `facultyMemberId`, `reamrkRegister`, `staffId`, `regDate`, `regType`, `attendance`, `assignment`, `classMark`, `midViva`, `final`, `created`, `modified`) VALUES
('20213172011001', 172011001, 'BS-103', 20213, NULL, NULL, 'NULL', NULL, '2021-09-13 05:13:41', NULL, NULL, NULL, 5.00, 5.00, 55.00, '2021-09-13 11:13:40', '2021-09-13 11:14:39'),
('20213172011001', 172011001, 'CSE-101', 20213, NULL, NULL, 'NULL', NULL, '2021-09-13 05:13:42', NULL, NULL, NULL, 0.00, 55.00, 5.00, '2021-09-13 11:13:41', '2021-09-13 11:14:40'),
('20213172011001', 172011001, 'CSE-105', 20213, NULL, NULL, 'NULL', NULL, '2021-09-13 05:13:43', NULL, 8.00, 8.00, 8.00, 8.00, 8.00, '2021-09-13 11:13:42', '2021-09-13 11:14:41'),
('20213172011001', 172011001, 'CSE-107', 20213, NULL, NULL, 'NULL', NULL, '2021-09-13 05:13:43', NULL, NULL, 8.00, 4.00, 4.00, 10.00, '2021-09-13 11:13:43', '2021-09-13 11:14:41'),
('20213172011001', 172011001, 'MAT-104', 20213, NULL, NULL, 'NULL', NULL, '2021-09-13 05:13:44', NULL, NULL, 50.00, 4.00, 4.00, 4.00, '2021-09-13 11:13:43', '2021-09-13 11:14:42'),
('20173173011002', 173011002, 'BS-103', 20173, NULL, NULL, 'NULL', NULL, '2021-09-19 04:09:08', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:09:09', '2021-09-19 10:55:18'),
('20173173011002', 173011002, 'CSE-101', 20173, NULL, NULL, 'NULL', NULL, '2021-09-19 04:09:09', NULL, 15.00, 15.00, 15.00, 20.00, 15.00, '2021-09-19 10:09:09', '2021-09-19 10:55:19'),
('20173173011002', 173011002, 'CSE-105', 20173, NULL, NULL, 'NULL', NULL, '2021-09-19 04:09:09', NULL, 14.00, 15.00, 15.00, 15.00, 10.00, '2021-09-19 10:09:10', '2021-09-19 10:55:20'),
('20181173011002', 173011002, 'CSE-106', 20181, NULL, NULL, 'NULL', NULL, '2021-09-19 04:29:22', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:29:23', '2021-09-19 11:15:38'),
('20181173011002', 173011002, 'CSE-107', 20181, NULL, NULL, 'NULL', NULL, '2021-09-19 04:29:23', NULL, 14.00, 15.00, 15.00, 10.00, 15.00, '2021-09-19 10:29:24', '2021-09-19 11:15:39'),
('20183173011002', 173011002, 'CSE-108', 20183, NULL, NULL, 'NULL', NULL, '2021-09-19 04:32:05', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:32:05', '2021-09-19 11:15:47'),
('20181173011002', 173011002, 'CSE-109', 20181, NULL, NULL, 'NULL', NULL, '2021-09-19 04:29:24', NULL, 14.00, 15.00, 15.00, 10.00, 10.00, '2021-09-19 10:29:25', '2021-09-19 11:15:40'),
('20183173011002', 173011002, 'CSE-111', 20183, NULL, NULL, 'NULL', NULL, '2021-09-19 04:32:05', NULL, 15.00, 20.00, 10.00, 10.00, 10.00, '2021-09-19 10:32:06', '2021-09-19 11:15:48'),
('20181173011002', 173011002, 'CSE-112', 20181, NULL, NULL, 'NULL', NULL, '2021-09-19 04:29:25', NULL, 15.00, 15.00, 15.00, 20.00, 20.00, '2021-09-19 10:29:26', '2021-09-19 11:15:41'),
('20183173011002', 173011002, 'CSE-114', 20183, NULL, NULL, 'NULL', NULL, '2021-09-19 04:32:06', NULL, 14.00, 14.00, 14.00, 14.00, 14.00, '2021-09-19 10:32:07', '2021-09-19 11:15:49'),
('20181173011002', 173011002, 'CSE-115', 20181, NULL, NULL, 'NULL', NULL, '2021-09-19 04:29:26', NULL, 0.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:29:26', '2021-09-19 11:15:42'),
('20183173011002', 173011002, 'CSE-201', 20183, NULL, NULL, 'NULL', NULL, '2021-09-19 04:32:07', NULL, 16.00, 16.00, 16.00, 16.00, 16.00, '2021-09-19 10:32:08', '2021-09-19 11:15:50'),
('20182173011002', 173011002, 'CSE-202', 20182, NULL, NULL, 'NULL', NULL, '2021-09-19 04:30:58', NULL, 10.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:30:59', '2021-09-19 11:15:43'),
('20183173011002', 173011002, 'CSE-204', 20183, NULL, NULL, 'NULL', NULL, '2021-09-19 04:32:08', NULL, 13.00, 17.00, 16.00, 14.00, 15.00, '2021-09-19 10:32:09', '2021-09-19 11:15:51'),
('20182173011002', 173011002, 'CSE-205', 20182, NULL, NULL, 'NULL', NULL, '2021-09-19 04:30:59', NULL, 15.00, 15.00, 15.00, 15.00, 20.00, '2021-09-19 10:31:00', '2021-09-19 11:15:44'),
('20182173011002', 173011002, 'CSE-206', 20182, NULL, NULL, 'NULL', NULL, '2021-09-19 04:31:00', NULL, 15.00, 15.00, 10.00, 10.00, 10.00, '2021-09-19 10:31:01', '2021-09-19 11:15:45'),
('20191173011002', 173011002, 'CSE-207', 20191, NULL, NULL, 'NULL', NULL, '2021-09-19 04:35:41', NULL, 15.00, 10.00, 15.00, 14.00, 15.00, '2021-09-19 10:35:42', '2021-09-19 11:15:51'),
('20182173011002', 173011002, 'CSE-208', 20182, NULL, NULL, 'NULL', NULL, '2021-09-19 04:31:01', NULL, 20.00, 20.00, 20.00, 15.00, 15.00, '2021-09-19 10:31:02', '2021-09-19 11:15:45'),
('20192173011002', 173011002, 'CSE-209', 20192, NULL, NULL, 'NULL', NULL, '2021-09-19 04:36:34', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:36:35', '2021-09-19 11:15:56'),
('20182173011002', 173011002, 'CSE-210', 20182, NULL, NULL, 'NULL', NULL, '2021-09-19 04:31:02', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:31:03', '2021-09-19 11:15:46'),
('20191173011002', 173011002, 'CSE-211', 20191, NULL, NULL, 'NULL', NULL, '2021-09-19 04:35:42', NULL, 20.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:35:43', '2021-09-19 11:15:52'),
('20193173011002', 173011002, 'CSE-212', 20193, NULL, NULL, 'NULL', NULL, '2021-09-19 04:37:40', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:37:41', '2021-09-19 11:16:00'),
('20192173011002', 173011002, 'CSE-213', 20192, NULL, NULL, 'NULL', NULL, '2021-09-19 04:36:35', NULL, 10.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:36:36', '2021-09-19 11:15:57'),
('20193173011002', 173011002, 'CSE-214', 20193, NULL, NULL, 'NULL', NULL, '2021-09-19 04:37:41', NULL, 15.00, 14.00, 17.00, 16.00, 16.00, '2021-09-19 10:37:41', '2021-09-19 11:16:01'),
('20193173011002', 173011002, 'CSE-215', 20193, NULL, NULL, 'NULL', NULL, '2021-09-19 04:37:41', NULL, 15.00, 15.00, 15.00, 10.00, 10.00, '2021-09-19 10:37:42', '2021-09-19 11:16:02'),
('20192173011002', 173011002, 'CSE-216', 20192, NULL, NULL, 'NULL', NULL, '2021-09-19 04:36:36', NULL, 5.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:36:37', '2021-09-19 11:15:57'),
('20201173011002', 173011002, 'CSE-217', 20201, NULL, NULL, 'NULL', NULL, '2021-09-19 04:38:34', NULL, 15.00, 15.00, 15.00, 10.00, 15.00, '2021-09-19 10:38:35', '2021-09-19 11:16:04'),
('20193173011002', 173011002, 'CSE-301', 20193, NULL, NULL, 'NULL', NULL, '2021-09-19 04:37:42', NULL, 15.00, 10.00, 10.00, 20.00, 20.00, '2021-09-19 10:37:43', '2021-09-19 11:16:03'),
('20191173011002', 173011002, 'CSE-302', 20191, NULL, NULL, 'NULL', NULL, '2021-09-19 04:35:43', NULL, 14.00, 14.00, 14.00, 14.00, 14.00, '2021-09-19 10:35:44', '2021-09-19 11:15:53'),
('20203173011002', 173011002, 'CSE-303', 20203, NULL, NULL, 'NULL', NULL, '2021-09-19 04:40:04', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:40:04', '2021-09-19 11:16:15'),
('20193173011002', 173011002, 'CSE-304', 20193, NULL, NULL, 'NULL', NULL, '2021-09-19 04:37:43', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:37:44', '2021-09-19 11:16:04'),
('20191173011002', 173011002, 'CSE-305', 20191, NULL, NULL, 'NULL', NULL, '2021-09-19 04:35:44', NULL, 16.00, 14.00, 14.00, 20.00, 15.00, '2021-09-19 10:35:45', '2021-09-19 11:15:54'),
('20202173011002', 173011002, 'CSE-307', 20202, NULL, NULL, 'NULL', NULL, '2021-09-19 04:39:16', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:39:16', '2021-09-19 11:16:09'),
('20211173011002', 173011002, 'CSE-309', 20211, NULL, NULL, 'NULL', NULL, '2021-09-19 04:41:43', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:41:44', '2021-09-19 11:16:20'),
('20202173011002', 173011002, 'CSE-310', 20202, NULL, NULL, 'NULL', NULL, '2021-09-19 04:39:16', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:39:17', '2021-09-19 11:16:10'),
('20202173011002', 173011002, 'CSE-311', 20202, NULL, NULL, 'NULL', NULL, '2021-09-19 04:39:17', NULL, 15.00, 15.00, 20.00, 15.00, 15.00, '2021-09-19 10:39:18', '2021-09-19 11:16:11'),
('20211173011002', 173011002, 'CSE-312', 20211, NULL, NULL, 'NULL', NULL, '2021-09-19 04:41:44', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:41:45', '2021-09-19 11:16:21'),
('20211173011002', 173011002, 'CSE-313', 20211, NULL, NULL, 'NULL', NULL, '2021-09-19 04:41:45', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:41:46', '2021-09-19 11:16:22'),
('20212173011002', 173011002, 'CSE-314', 20212, NULL, NULL, 'NULL', NULL, '2021-09-19 04:42:24', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:42:25', '2021-09-19 11:19:20'),
('20211173011002', 173011002, 'CSE-317', 20211, NULL, NULL, 'NULL', NULL, '2021-09-19 04:41:46', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:41:47', '2021-09-19 11:16:23'),
('20201173011002', 173011002, 'CSE-401', 20201, NULL, NULL, 'NULL', NULL, '2021-09-19 04:38:35', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:38:36', '2021-09-19 11:16:05'),
('20203173011002', 173011002, 'CSE-402', 20203, NULL, NULL, 'NULL', NULL, '2021-09-19 04:40:04', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:40:05', '2021-09-19 11:16:16'),
('20203173011002', 173011002, 'CSE-403', 20203, NULL, NULL, 'NULL', NULL, '2021-09-19 04:40:05', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:40:06', '2021-09-19 11:16:17'),
('20201173011002', 173011002, 'CSE-404', 20201, NULL, NULL, 'NULL', NULL, '2021-09-19 04:38:35', NULL, 15.00, 15.00, 15.00, 20.00, 15.00, '2021-09-19 10:38:36', '2021-09-19 11:16:06'),
('20211173011002', 173011002, 'CSE-405', 20211, NULL, NULL, 'NULL', NULL, '2021-09-19 04:41:47', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:41:48', '2021-09-19 11:16:24'),
('20203173011002', 173011002, 'CSE-406', 20203, NULL, NULL, 'NULL', NULL, '2021-09-19 04:40:06', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:40:07', '2021-09-19 11:16:17'),
('20212173011002', 173011002, 'CSE-407', 20212, NULL, NULL, 'NULL', NULL, '2021-09-19 04:42:25', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:42:26', '2021-09-19 11:19:21'),
('20203173011002', 173011002, 'CSE-408', 20203, NULL, NULL, 'NULL', NULL, '2021-09-19 04:40:07', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:40:08', '2021-09-19 11:16:18'),
('20212173011002', 173011002, 'CSE-410', 20212, NULL, NULL, 'NULL', NULL, '2021-09-19 04:42:26', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:42:27', '2021-09-19 11:19:21'),
('20203173011002', 173011002, 'CSE-411', 20203, NULL, NULL, 'NULL', NULL, '2021-09-19 04:40:08', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:40:09', '2021-09-19 11:16:19'),
('20212173011002', 173011002, 'CSE-415', 20212, NULL, NULL, 'NULL', NULL, '2021-09-19 04:42:27', NULL, NULL, NULL, NULL, 80.00, NULL, '2021-09-19 10:42:28', '2021-09-19 11:16:25'),
('20202173011002', 173011002, 'CSE-419', 20202, NULL, NULL, 'NULL', NULL, '2021-09-19 04:39:18', NULL, 15.00, 15.00, 20.00, 15.00, 15.00, '2021-09-19 10:39:19', '2021-09-19 11:16:11'),
('20202173011002', 173011002, 'CSE-420', 20202, NULL, NULL, 'NULL', NULL, '2021-09-19 04:39:19', NULL, 15.00, 11.00, 15.00, 15.00, 15.00, '2021-09-19 10:39:20', '2021-09-19 11:16:12'),
('20173173011002', 173011002, 'ENG-102', 20173, NULL, NULL, 'NULL', NULL, '2021-09-19 04:09:10', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:09:11', '2021-09-19 10:55:21'),
('20192173011002', 173011002, 'ENG-110', 20192, NULL, NULL, 'NULL', NULL, '2021-09-19 04:36:37', NULL, 15.00, 15.00, 15.00, 20.00, 15.00, '2021-09-19 10:36:38', '2021-09-19 11:15:58'),
('20202173011002', 173011002, 'ENG-306', 20202, NULL, NULL, 'NULL', NULL, '2021-09-19 04:39:20', NULL, 15.00, 10.00, 15.00, 15.00, 15.00, '2021-09-19 10:39:21', '2021-09-19 11:16:13'),
('20173173011002', 173011002, 'MAT-104', 20173, NULL, NULL, 'NULL', NULL, '2021-09-19 04:09:11', NULL, 10.00, 15.00, 15.00, 10.00, 10.00, '2021-09-19 10:09:12', '2021-09-19 10:55:21'),
('20191173011002', 173011002, 'MAT-113', 20191, NULL, NULL, 'NULL', NULL, '2021-09-19 04:35:45', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:35:46', '2021-09-19 11:15:55'),
('20192173011002', 173011002, 'MAT-203', 20192, NULL, NULL, 'NULL', NULL, '2021-09-19 04:36:38', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:36:39', '2021-09-19 11:15:59'),
('20201173011002', 173011002, 'MAT-308', 20201, NULL, NULL, 'NULL', NULL, '2021-09-19 04:38:36', NULL, 15.00, 15.00, 15.00, 20.00, 15.00, '2021-09-19 10:38:37', '2021-09-19 11:16:07'),
('20202173011002', 173011002, 'SCO-216', 20202, NULL, NULL, 'NULL', NULL, '2021-09-19 04:39:21', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:39:22', '2021-09-19 11:16:14'),
('20212173011002', 173011002, 'SCO-409', 20212, NULL, NULL, 'NULL', NULL, '2021-09-19 04:42:28', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:42:29', '2021-09-19 11:19:22'),
('20211173011002', 173011002, 'SCO-412', 20211, NULL, NULL, 'NULL', NULL, '2021-09-19 04:41:49', NULL, 15.00, 15.00, 15.00, 15.00, 15.00, '2021-09-19 10:41:49', '2021-09-19 11:16:26'),
('20201173011002', 173011002, 'STA-315', 20201, NULL, NULL, 'NULL', NULL, '2021-09-19 04:38:37', NULL, 15.00, 15.00, 15.00, 10.00, 15.00, '2021-09-19 10:38:38', '2021-09-19 11:16:08');

-- --------------------------------------------------------

--
-- Table structure for table `semester`
--

CREATE TABLE `semester` (
  `semesterId` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `SemesterLength` int(11) DEFAULT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `semester`
--

INSERT INTO `semester` (`semesterId`, `name`, `SemesterLength`, `created`, `modified`) VALUES
(20162, 'summer2016', 4, '2021-09-19 07:21:39', '2021-09-19 07:21:39'),
(20163, 'fall2016', 4, '2021-09-19 07:22:01', '2021-09-19 07:22:01'),
(20171, 'spring2017', 4, '2021-09-19 07:22:29', '2021-09-19 07:22:29'),
(20172, 'summer2017', 4, '2021-09-19 07:22:52', '2021-09-19 07:22:52'),
(20173, 'fall2017', 4, '2021-09-19 07:23:13', '2021-09-19 07:23:13'),
(20181, 'spring2018', 4, '2021-09-19 07:23:40', '2021-09-19 07:23:40'),
(20182, 'summer2018', 4, '2021-09-19 07:24:02', '2021-09-19 07:24:02'),
(20183, 'fall2018', 4, '2021-09-19 07:24:37', '2021-09-19 07:24:37'),
(20191, 'spring2019', 4, '2021-09-19 07:26:10', '2021-09-19 07:26:10'),
(20192, 'summer2019', 4, '2021-09-19 07:26:34', '2021-09-19 07:26:34'),
(20193, 'fall2019', 4, '2021-09-19 07:27:55', '2021-09-19 07:27:55'),
(20201, 'spring2020', 4, '2020-03-29 22:23:00', '2020-03-29 22:30:46'),
(20202, 'summer2020', 4, '2020-03-29 22:23:52', '2020-03-29 22:30:46'),
(20203, 'fall2020', 4, '2020-03-29 22:24:09', '2020-03-29 22:30:46'),
(20211, 'spring2021', 4, '2021-09-19 07:29:38', '2021-09-19 07:29:38'),
(20212, 'summer2021', 4, '2021-09-19 07:29:58', '2021-09-19 07:29:58'),
(20213, 'fall2021', 4, '2021-09-06 16:38:54', '2021-09-06 16:38:54');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `studentId` int(11) NOT NULL,
  `batchId` int(11) DEFAULT NULL,
  `programId` int(11) DEFAULT NULL,
  `name` varchar(60) DEFAULT NULL,
  `contact` varchar(20) DEFAULT NULL,
  `father` varchar(60) DEFAULT NULL,
  `fatherContact` varchar(20) DEFAULT NULL,
  `fatherProfession` varchar(50) DEFAULT NULL,
  `mother` varchar(60) DEFAULT NULL,
  `motherContact` varchar(20) DEFAULT NULL,
  `motherProfession` varchar(50) DEFAULT NULL,
  `mailingAddress` varchar(150) DEFAULT NULL,
  `permanentAddress` varchar(150) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `gender` varchar(20) DEFAULT NULL,
  `reilgion` varchar(20) DEFAULT NULL,
  `bloodGroup` varchar(10) DEFAULT NULL,
  `NID` varchar(20) DEFAULT NULL,
  `birthReg` varchar(20) DEFAULT NULL,
  `nationality` varchar(20) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `remark` varchar(150) DEFAULT NULL,
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`studentId`, `batchId`, `programId`, `name`, `contact`, `father`, `fatherContact`, `fatherProfession`, `mother`, `motherContact`, `motherProfession`, `mailingAddress`, `permanentAddress`, `email`, `gender`, `reilgion`, `bloodGroup`, `NID`, `birthReg`, `nationality`, `dob`, `remark`, `created`, `modified`) VALUES
(11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2020-03-31 15:26:23', '2020-03-31 15:28:13'),
(172011001, 172, 11, 'test', '0152', 'test', 'test', NULL, 'test', 'test', NULL, 'test', 'test', 'teste', 'teste', 'testr', 'A-', '485', '985', 'testn', '2021-09-13', 'iglk', '2021-09-13 11:11:23', '2021-09-20 14:46:47'),
(173011002, 173, 11, 'Ahmad Nafis Hasan', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2020-03-31 16:29:22', '2020-03-31 16:29:22'),
(173011003, 173, 11, 'Reshma', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2020-03-31 16:30:44', '2020-03-31 16:30:44'),
(173011006, 173, 11, 'Ariful Islam Read', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2020-03-31 16:31:30', '2020-03-31 16:31:30'),
(173011007, 173, 11, 'Johora Islam', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2020-03-31 16:32:29', '2020-03-31 16:32:29'),
(173011008, 173, 11, 'Jakaria Alam', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2020-03-31 16:33:32', '2020-03-31 16:33:32'),
(213011001, 213, 11, 'asa', '00021', 'sa', '213', NULL, 'asaas', '458', NULL, 'saa', 'asa', 'asas', 'asas', 'sa', 'O-', '562', '124', 'sa', '2021-09-09', 'sasa', '2021-09-09 16:35:07', '2021-09-09 16:35:07'),
(213011002, 213, 11, 'tetsasaa', '012', 'add', '454', NULL, 'ad', '45', NULL, 'test', 'add', 'test', 'test', 'test', 'B+', '44', '353', 'dad', '2021-09-10', 'test', '2021-09-09 18:41:04', '2021-09-09 18:41:04');

-- --------------------------------------------------------

--
-- Table structure for table `stuff`
--

CREATE TABLE `stuff` (
  `stuffId` int(11) NOT NULL,
  `position` varchar(50) DEFAULT NULL,
  `name` varchar(60) NOT NULL,
  `father` varchar(60) NOT NULL,
  `mother` varchar(60) NOT NULL,
  `contact` varchar(20) NOT NULL,
  `alternativeContact` varchar(20) DEFAULT NULL,
  `mailingAddress` varchar(150) NOT NULL,
  `permanentAddress` varchar(150) NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `gender` varchar(20) NOT NULL,
  `reilgion` varchar(20) NOT NULL,
  `bloodGroup` varchar(10) NOT NULL,
  `NID` varchar(20) NOT NULL,
  `birthReg` varchar(20) NOT NULL,
  `nationality` varchar(20) NOT NULL,
  `dob` date NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `weiver`
--

CREATE TABLE `weiver` (
  `studentId` int(11) NOT NULL,
  `semesterId` int(11) NOT NULL,
  `weiver` int(11) DEFAULT NULL,
  `scholership` int(11) DEFAULT NULL,
  `remark` varchar(200) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admit`
--
ALTER TABLE `admit`
  ADD PRIMARY KEY (`studentId`,`semesterId`,`admitType`),
  ADD KEY `admitfk2` (`semesterId`);

--
-- Indexes for table `alluser`
--
ALTER TABLE `alluser`
  ADD PRIMARY KEY (`userId`);

--
-- Indexes for table `batch`
--
ALTER TABLE `batch`
  ADD PRIMARY KEY (`batchId`);

--
-- Indexes for table `book`
--
ALTER TABLE `book`
  ADD PRIMARY KEY (`bookId`);

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`courseCode`);

--
-- Indexes for table `CourseProgram`
--
ALTER TABLE `CourseProgram`
  ADD PRIMARY KEY (`programId`,`courseCode`),
  ADD KEY `CourseProgramFk1` (`programId`),
  ADD KEY `CourseProgramFk2` (`courseCode`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`departmentId`),
  ADD KEY `mykey2` (`head`),
  ADD KEY `mykey11` (`facultyId`);

--
-- Indexes for table `education`
--
ALTER TABLE `education`
  ADD PRIMARY KEY (`educationId`,`exam`);

--
-- Indexes for table `experience`
--
ALTER TABLE `experience`
  ADD PRIMARY KEY (`studentId`);

--
-- Indexes for table `faculty`
--
ALTER TABLE `faculty`
  ADD PRIMARY KEY (`facultyId`),
  ADD KEY `fk2` (`dean`);

--
-- Indexes for table `facultymember`
--
ALTER TABLE `facultymember`
  ADD PRIMARY KEY (`facultyMemberId`),
  ADD KEY `forkey` (`departmentId`);

--
-- Indexes for table `guardian`
--
ALTER TABLE `guardian`
  ADD PRIMARY KEY (`studentId`);

--
-- Indexes for table `notregister`
--
ALTER TABLE `notregister`
  ADD PRIMARY KEY (`studentId`,`semesterId`),
  ADD KEY `notRegisterfk2` (`semesterId`);

--
-- Indexes for table `offeredcourse`
--
ALTER TABLE `offeredcourse`
  ADD PRIMARY KEY (`courseCode`,`batchId`,`semesterId`,`programId`),
  ADD KEY `offeredcoursefk2` (`batchId`),
  ADD KEY `offeredcourseFkProgram` (`programId`),
  ADD KEY `offeredcourseFkSemester` (`semesterId`),
  ADD KEY `FK_facultyMember` (`facultyMemberId`);

--
-- Indexes for table `officer`
--
ALTER TABLE `officer`
  ADD PRIMARY KEY (`officerId`);

--
-- Indexes for table `orderbook`
--
ALTER TABLE `orderbook`
  ADD PRIMARY KEY (`orderId`),
  ADD KEY `orderfk1` (`bookId`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`studentId`,`semesterId`,`installmentNo`),
  ADD KEY `paymentfk2` (`semesterId`);

--
-- Indexes for table `program`
--
ALTER TABLE `program`
  ADD PRIMARY KEY (`programId`),
  ADD KEY `ekashd` (`departmentId`);

--
-- Indexes for table `registration`
--
ALTER TABLE `registration`
  ADD PRIMARY KEY (`studentId`,`courseCode`,`semesterId`),
  ADD KEY `registrationFk2` (`courseCode`),
  ADD KEY `registrationFk3` (`semesterId`);

--
-- Indexes for table `semester`
--
ALTER TABLE `semester`
  ADD PRIMARY KEY (`semesterId`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`studentId`),
  ADD KEY `studentfk` (`batchId`),
  ADD KEY `studentfk2` (`programId`);

--
-- Indexes for table `stuff`
--
ALTER TABLE `stuff`
  ADD PRIMARY KEY (`stuffId`);

--
-- Indexes for table `weiver`
--
ALTER TABLE `weiver`
  ADD PRIMARY KEY (`studentId`,`semesterId`),
  ADD KEY `weiverfk2` (`semesterId`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `admit`
--
ALTER TABLE `admit`
  ADD CONSTRAINT `admitfk1` FOREIGN KEY (`studentId`) REFERENCES `student` (`studentId`),
  ADD CONSTRAINT `admitfk2` FOREIGN KEY (`semesterId`) REFERENCES `semester` (`semesterId`);

--
-- Constraints for table `CourseProgram`
--
ALTER TABLE `CourseProgram`
  ADD CONSTRAINT `CourseProgramFk1` FOREIGN KEY (`programId`) REFERENCES `program` (`programId`),
  ADD CONSTRAINT `CourseProgramFk2` FOREIGN KEY (`courseCode`) REFERENCES `course` (`courseCode`);

--
-- Constraints for table `department`
--
ALTER TABLE `department`
  ADD CONSTRAINT `mykey11` FOREIGN KEY (`facultyId`) REFERENCES `faculty` (`facultyId`),
  ADD CONSTRAINT `mykey2` FOREIGN KEY (`head`) REFERENCES `facultymember` (`facultyMemberId`);

--
-- Constraints for table `education`
--
ALTER TABLE `education`
  ADD CONSTRAINT `educationFk` FOREIGN KEY (`educationId`) REFERENCES `student` (`studentId`);

--
-- Constraints for table `experience`
--
ALTER TABLE `experience`
  ADD CONSTRAINT `experienceFk` FOREIGN KEY (`studentId`) REFERENCES `student` (`studentId`);

--
-- Constraints for table `faculty`
--
ALTER TABLE `faculty`
  ADD CONSTRAINT `fk` FOREIGN KEY (`dean`) REFERENCES `facultymember` (`facultyMemberId`),
  ADD CONSTRAINT `fk2` FOREIGN KEY (`dean`) REFERENCES `facultymember` (`facultyMemberId`);

--
-- Constraints for table `facultymember`
--
ALTER TABLE `facultymember`
  ADD CONSTRAINT `forkey` FOREIGN KEY (`departmentId`) REFERENCES `department` (`departmentId`);

--
-- Constraints for table `guardian`
--
ALTER TABLE `guardian`
  ADD CONSTRAINT `guardianFk` FOREIGN KEY (`studentId`) REFERENCES `student` (`studentId`);

--
-- Constraints for table `notregister`
--
ALTER TABLE `notregister`
  ADD CONSTRAINT `notRegisterfk1` FOREIGN KEY (`studentId`) REFERENCES `student` (`studentId`),
  ADD CONSTRAINT `notRegisterfk2` FOREIGN KEY (`semesterId`) REFERENCES `semester` (`semesterId`);

--
-- Constraints for table `offeredcourse`
--
ALTER TABLE `offeredcourse`
  ADD CONSTRAINT `FK_facultyMember` FOREIGN KEY (`facultyMemberId`) REFERENCES `facultymember` (`facultyMemberId`),
  ADD CONSTRAINT `offeredcourseFkProgram` FOREIGN KEY (`programId`) REFERENCES `program` (`programId`),
  ADD CONSTRAINT `offeredcourseFkSemester` FOREIGN KEY (`semesterId`) REFERENCES `semester` (`semesterId`),
  ADD CONSTRAINT `offeredcoursefk1` FOREIGN KEY (`courseCode`) REFERENCES `course` (`courseCode`),
  ADD CONSTRAINT `offeredcoursefk2` FOREIGN KEY (`batchId`) REFERENCES `batch` (`batchId`);

--
-- Constraints for table `orderbook`
--
ALTER TABLE `orderbook`
  ADD CONSTRAINT `orderfk1` FOREIGN KEY (`bookId`) REFERENCES `book` (`bookId`);

--
-- Constraints for table `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `paymentfk1` FOREIGN KEY (`studentId`) REFERENCES `student` (`studentId`),
  ADD CONSTRAINT `paymentfk2` FOREIGN KEY (`semesterId`) REFERENCES `semester` (`semesterId`);

--
-- Constraints for table `program`
--
ALTER TABLE `program`
  ADD CONSTRAINT `ekashd` FOREIGN KEY (`departmentId`) REFERENCES `department` (`departmentId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk5` FOREIGN KEY (`departmentId`) REFERENCES `department` (`departmentId`);

--
-- Constraints for table `registration`
--
ALTER TABLE `registration`
  ADD CONSTRAINT `registrationCourse` FOREIGN KEY (`courseCode`) REFERENCES `course` (`courseCode`),
  ADD CONSTRAINT `registrationFk1` FOREIGN KEY (`studentId`) REFERENCES `student` (`studentId`),
  ADD CONSTRAINT `registrationFk3` FOREIGN KEY (`semesterId`) REFERENCES `semester` (`semesterId`);

--
-- Constraints for table `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `studentfk` FOREIGN KEY (`batchId`) REFERENCES `batch` (`batchId`),
  ADD CONSTRAINT `studentfk2` FOREIGN KEY (`programId`) REFERENCES `program` (`programId`);

--
-- Constraints for table `weiver`
--
ALTER TABLE `weiver`
  ADD CONSTRAINT `weiverfk1` FOREIGN KEY (`studentId`) REFERENCES `student` (`studentId`),
  ADD CONSTRAINT `weiverfk2` FOREIGN KEY (`semesterId`) REFERENCES `semester` (`semesterId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
