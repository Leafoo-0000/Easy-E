-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 10, 2025 at 10:09 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `easy_ev3`
--

-- --------------------------------------------------------

--
-- Table structure for table `announcements`
--

CREATE TABLE `announcements` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `body` text NOT NULL,
  `created_by_user_id` int(11) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `announcements`
--

INSERT INTO `announcements` (`id`, `title`, `body`, `created_by_user_id`, `created_at`) VALUES
(1, 'Announcement', 'Test', 2, '2025-11-10 17:47:17');

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE `events` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text DEFAULT NULL,
  `start_utc` datetime NOT NULL,
  `end_utc` datetime NOT NULL,
  `location` varchar(255) DEFAULT NULL,
  `owner_user_id` int(11) NOT NULL,
  `status` tinyint(4) NOT NULL DEFAULT 1 COMMENT '0=Draft,1=PendingApproval,2=Approved,3=Rejected',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `events`
--

INSERT INTO `events` (`id`, `title`, `description`, `start_utc`, `end_utc`, `location`, `owner_user_id`, `status`, `created_at`) VALUES
(1, 'Testev', 'This is a test event', '2025-11-02 21:12:46', '2025-11-14 21:12:46', 'testeve', 1, 2, '2025-11-02 05:13:07'),
(2, 'Test2', 'Test2 this is a testest', '2025-11-02 21:24:12', '2025-11-13 21:24:12', 'testeve', 1, 2, '2025-11-02 05:24:24'),
(3, 'Exam', 'Exam for blabla', '2025-11-05 11:53:37', '2025-11-12 11:53:37', 'Auditorium', 1, 2, '2025-11-04 19:53:57'),
(4, 'Testev4', 'Another', '2025-11-05 11:54:33', '2025-11-13 11:54:33', 'Auditorium', 1, 2, '2025-11-04 19:54:44'),
(6, 'TesteventFromUser', 'testing only', '2025-11-11 03:14:37', '2025-11-20 03:14:37', 'Forest', 1, 1, '2025-11-10 11:14:57'),
(7, 'USERTEST', '123', '2025-11-11 03:25:46', '2025-11-13 03:25:46', 'Auditorium', 1, 3, '2025-11-10 11:25:55'),
(8, 'TesteventADMIN', 'tetwrw423', '2025-11-11 04:03:18', '2025-11-14 04:03:18', 'Auditorium', 1, 2, '2025-11-10 12:03:27'),
(9, 'TestAGAIN', '13123213', '2025-11-11 04:06:57', '2025-11-21 04:06:57', 'Auditorium', 2, 2, '2025-11-10 12:07:05'),
(10, 'Testuser', '313213', '2025-11-11 04:11:19', '2025-11-21 04:11:19', 'testeve', 1, 1, '2025-11-10 12:11:26');

-- --------------------------------------------------------

--
-- Table structure for table `event_log`
--

CREATE TABLE `event_log` (
  `id` int(11) NOT NULL,
  `original_event_id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text DEFAULT NULL,
  `start_utc` datetime NOT NULL,
  `end_utc` datetime NOT NULL,
  `location` varchar(255) DEFAULT NULL,
  `owner_user_id` int(11) DEFAULT NULL,
  `status` tinyint(4) NOT NULL DEFAULT 2,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `archived_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `event_log`
--

INSERT INTO `event_log` (`id`, `original_event_id`, `title`, `description`, `start_utc`, `end_utc`, `location`, `owner_user_id`, `status`, `created_at`, `archived_at`) VALUES
(1, 5, 'EVNETLOGTEST', 'this event is done', '2025-11-01 17:51:26', '2025-11-03 17:51:26', 'Auditorium', 1, 2, '2025-11-05 01:51:44', '2025-11-05 13:58:22');

-- --------------------------------------------------------

--
-- Table structure for table `participants`
--

CREATE TABLE `participants` (
  `id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `qr_code` varchar(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `participants`
--

INSERT INTO `participants` (`id`, `user_id`, `name`, `email`, `qr_code`, `created_at`) VALUES
(3, NULL, 'Julian A. Tandug', 'jTandug@mcm.edu.ph', 'Julian A. Tandug|jTandug@mcm.edu.ph|638984158340859898', '2025-11-10 14:49:05'),
(4, NULL, 'Lester Arigo', 'lArigo@mcm.edi.ph', 'Lester Arigo|lArigo@mcm.edi.ph|638984177662199405', '2025-11-10 16:29:27'),
(5, NULL, 'Jeff Big', 'Jbig@mcm.edu.ph', 'Jeff Big|Jbig@mcm.edu.ph|638984194140965390', '2025-11-10 16:56:55');

-- --------------------------------------------------------

--
-- Table structure for table `participants_log`
--

CREATE TABLE `participants_log` (
  `id` int(11) NOT NULL,
  `event_log_id` int(11) NOT NULL,
  `original_participant_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `participant_event`
--

CREATE TABLE `participant_event` (
  `id` int(11) NOT NULL,
  `participant_id` int(11) NOT NULL,
  `event_id` int(11) NOT NULL,
  `assigned_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `participant_event`
--

INSERT INTO `participant_event` (`id`, `participant_id`, `event_id`, `assigned_at`) VALUES
(2, 3, 3, '2025-11-10 23:12:16'),
(3, 3, 4, '2025-11-10 23:12:16'),
(7, 5, 2, '2025-11-11 01:03:02'),
(9, 3, 2, '2025-11-11 01:03:38'),
(10, 5, 1, '2025-11-11 04:50:53'),
(11, 5, 6, '2025-11-11 04:51:41'),
(12, 4, 10, '2025-11-11 04:55:01');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` tinyint(4) NOT NULL DEFAULT 2 COMMENT '1 = Admin, 2 = User',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`, `role`, `created_at`) VALUES
(1, 'Testuser', 'Testemail@gmai.com', '123', 2, '2025-11-02 11:33:12'),
(2, 'Admin', 'admin@example.com', 'Admin123', 1, '2025-11-02 11:37:51');

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_approved_events`
-- (See below for the actual view)
--
CREATE TABLE `vw_approved_events` (
`id` int(11)
,`title` varchar(255)
,`description` text
,`start_utc` datetime
,`end_utc` datetime
,`location` varchar(255)
,`owner_user_id` int(11)
,`owner_username` varchar(100)
,`created_at` timestamp
);

-- --------------------------------------------------------

--
-- Structure for view `vw_approved_events`
--
DROP TABLE IF EXISTS `vw_approved_events`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_approved_events`  AS SELECT `e`.`id` AS `id`, `e`.`title` AS `title`, `e`.`description` AS `description`, `e`.`start_utc` AS `start_utc`, `e`.`end_utc` AS `end_utc`, `e`.`location` AS `location`, `e`.`owner_user_id` AS `owner_user_id`, `u`.`username` AS `owner_username`, `e`.`created_at` AS `created_at` FROM (`events` `e` join `users` `u` on(`u`.`id` = `e`.`owner_user_id`)) WHERE `e`.`status` = 2 ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `announcements`
--
ALTER TABLE `announcements`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_ann_created_by` (`created_by_user_id`);

--
-- Indexes for table `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_events_owner` (`owner_user_id`),
  ADD KEY `idx_events_status` (`status`);

--
-- Indexes for table `event_log`
--
ALTER TABLE `event_log`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_event_log_original` (`original_event_id`),
  ADD KEY `idx_event_log_owner` (`owner_user_id`);

--
-- Indexes for table `participants`
--
ALTER TABLE `participants`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `qr_code` (`qr_code`),
  ADD KEY `idx_participants_user` (`user_id`);

--
-- Indexes for table `participants_log`
--
ALTER TABLE `participants_log`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_participants_log_event_log` (`event_log_id`),
  ADD KEY `fk_participants_log_user` (`user_id`);

--
-- Indexes for table `participant_event`
--
ALTER TABLE `participant_event`
  ADD PRIMARY KEY (`id`),
  ADD KEY `participant_id` (`participant_id`),
  ADD KEY `event_id` (`event_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uq_users_username` (`username`),
  ADD UNIQUE KEY `uq_users_email` (`email`),
  ADD KEY `idx_users_role` (`role`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `announcements`
--
ALTER TABLE `announcements`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `event_log`
--
ALTER TABLE `event_log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `participants`
--
ALTER TABLE `participants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `participants_log`
--
ALTER TABLE `participants_log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `participant_event`
--
ALTER TABLE `participant_event`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `announcements`
--
ALTER TABLE `announcements`
  ADD CONSTRAINT `fk_ann_created_by` FOREIGN KEY (`created_by_user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `events`
--
ALTER TABLE `events`
  ADD CONSTRAINT `fk_events_owner_user` FOREIGN KEY (`owner_user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `event_log`
--
ALTER TABLE `event_log`
  ADD CONSTRAINT `fk_event_log_owner_user` FOREIGN KEY (`owner_user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `participants`
--
ALTER TABLE `participants`
  ADD CONSTRAINT `fk_participants_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `participants_log`
--
ALTER TABLE `participants_log`
  ADD CONSTRAINT `fk_participants_log_event_log` FOREIGN KEY (`event_log_id`) REFERENCES `event_log` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_participants_log_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `participant_event`
--
ALTER TABLE `participant_event`
  ADD CONSTRAINT `participant_event_ibfk_1` FOREIGN KEY (`participant_id`) REFERENCES `participants` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `participant_event_ibfk_2` FOREIGN KEY (`event_id`) REFERENCES `events` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
