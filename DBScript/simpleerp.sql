-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 24, 2017 at 08:54 AM
-- Server version: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `simpleerp`
--

-- --------------------------------------------------------

--
-- Stand-in structure for view `cashflowreport`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `cashflowreport`;
CREATE TABLE IF NOT EXISTS `cashflowreport` (
`invoiceNumber` varchar(100)
,`invoiceDate` date
,`refference` varchar(100)
,`chequeNumber` varchar(250)
,`debit` varchar(37)
,`credit` varchar(37)
);

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `categoryID` tinyint(3) UNSIGNED NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(30) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`categoryID`),
  UNIQUE KEY `categoryName` (`categoryName`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`categoryID`, `categoryName`, `description`) VALUES
(1, 'test', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
CREATE TABLE IF NOT EXISTS `customers` (
  `customerID` int(5) NOT NULL AUTO_INCREMENT,
  `companyName` varchar(40) NOT NULL,
  `contactName` varchar(30) DEFAULT NULL,
  `contactTitle` varchar(30) DEFAULT NULL,
  `address` varchar(60) DEFAULT NULL,
  `city` varchar(15) DEFAULT NULL,
  `country` varchar(15) DEFAULT NULL,
  `phone` varchar(24) DEFAULT NULL,
  `fax` varchar(24) DEFAULT NULL,
  PRIMARY KEY (`customerID`),
  KEY `city` (`city`),
  KEY `companyName` (`companyName`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`customerID`, `companyName`, `contactName`, `contactTitle`, `address`, `city`, `country`, `phone`, `fax`) VALUES
(1, 'test', 'test', 'test', 'test', 'test', 'test', '089080', '90809809');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
CREATE TABLE IF NOT EXISTS `employees` (
  `employeeID` mediumint(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `lastName` varchar(20) NOT NULL,
  `firstName` varchar(10) NOT NULL,
  `title` varchar(30) DEFAULT NULL,
  `Address` varchar(60) DEFAULT NULL,
  `city` varchar(15) DEFAULT NULL,
  `Country` varchar(15) DEFAULT NULL,
  `mobile` varchar(24) DEFAULT NULL,
  `notes` text NOT NULL,
  `reportsTo` mediumint(8) UNSIGNED DEFAULT NULL,
  `photoPath` varchar(255) DEFAULT NULL,
  `salary` int(11) DEFAULT NULL,
  PRIMARY KEY (`employeeID`),
  KEY `lastName` (`lastName`),
  KEY `reportsTo` (`reportsTo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `inventoryreport`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `inventoryreport`;
CREATE TABLE IF NOT EXISTS `inventoryreport` (
`productName` varchar(40)
,`categoryName` varchar(30)
,`debit` varchar(28)
,`credit` varchar(28)
);

-- --------------------------------------------------------

--
-- Table structure for table `invoices`
--

DROP TABLE IF EXISTS `invoices`;
CREATE TABLE IF NOT EXISTS `invoices` (
  `invoiceID` bigint(20) NOT NULL AUTO_INCREMENT,
  `invoiceNumber` varchar(100) NOT NULL,
  `invoiceType` int(11) NOT NULL COMMENT '1 for sales 2 for purchase',
  `orderID` int(11) NOT NULL COMMENT 'either sales order or purchase order',
  `refference` varchar(100) NOT NULL COMMENT 'i.e. bank chalan, pay order or any other invoice refference',
  `payType` int(11) NOT NULL COMMENT '1 for cash 2 for cheque',
  `chequeNumber` varchar(250) NOT NULL COMMENT 'bank cheque number',
  `totalAmount` double NOT NULL,
  `orderAmount` double NOT NULL,
  `invoiceDate` date NOT NULL,
  PRIMARY KEY (`invoiceID`),
  UNIQUE KEY `invoicenumber` (`invoiceNumber`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `invoices`
--

INSERT INTO `invoices` (`invoiceID`, `invoiceNumber`, `invoiceType`, `orderID`, `refference`, `payType`, `chequeNumber`, `totalAmount`, `orderAmount`, `invoiceDate`) VALUES
(1, '001', 2, 3, 'dssd', 2, '23ss', 10, 67, '2017-12-12'),
(2, '002', 1, 3, '34434', 2, '4444AASS', 10, 67, '2017-12-12'),
(3, 'P-001', 2, 13, 'Adding 200 extra charges for packaging', 2, '4444AASS', 500, 300, '2017-12-12'),
(4, 'I-001', 2, 13, 'no order attached', 1, '', 100, 100, '2017-12-12'),
(5, 'I-002', 2, 0, 'no order attached', 1, '', 100, 100, '2017-12-12'),
(6, 'yyuuii', 1, 5, 'test', 1, '33', 100, 100, '2017-12-12'),
(7, 'yyuuii222', 1, 3, 'test222', 1, '33', 100, 100, '2017-12-12'),
(8, 'yyuuii333', 1, 5, 'test3333', 1, '33', 100, 100, '2017-12-12'),
(9, 'P-10142017', 2, 14, 'Purchase invoice', 1, 'AAA456', 100, 100, '2017-12-12');

-- --------------------------------------------------------

--
-- Table structure for table `ordedetails`
--

DROP TABLE IF EXISTS `ordedetails`;
CREATE TABLE IF NOT EXISTS `ordedetails` (
  `orderDetailID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `orderID` int(10) NOT NULL,
  `productID` int(5) UNSIGNED NOT NULL,
  `unitPrice` decimal(8,2) UNSIGNED NOT NULL DEFAULT '999999.99',
  `quantity` smallint(2) UNSIGNED NOT NULL DEFAULT '1',
  `discount` double(8,0) NOT NULL DEFAULT '0',
  `orderType` int(5) NOT NULL DEFAULT '1' COMMENT '1 for sales 2 for purchase',
  PRIMARY KEY (`orderDetailID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordedetails`
--

INSERT INTO `ordedetails` (`orderDetailID`, `orderID`, `productID`, `unitPrice`, `quantity`, `discount`, `orderType`) VALUES
(20, 4, 1, '10.00', 10, 10, 1),
(19, 14, 1, '10.00', 10, 10, 2),
(18, 14, 1, '10.00', 10, 10, 2),
(17, 14, 2, '10.00', 10, 10, 2),
(16, 13, 1, '100.00', 1, 0, 2),
(15, 13, 1, '100.00', 1, 0, 2),
(14, 13, 1, '100.00', 1, 0, 2),
(13, 3, 1, '100.00', 1, 0, 1),
(12, 3, 1, '100.00', 1, 0, 1),
(11, 3, 1, '100.00', 1, 0, 1),
(21, 5, 1, '10.00', 10, 10, 1);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `productID` smallint(5) UNSIGNED NOT NULL AUTO_INCREMENT,
  `productName` varchar(40) NOT NULL,
  `supplierID` smallint(5) UNSIGNED NOT NULL,
  `categoryID` tinyint(3) UNSIGNED NOT NULL,
  `quantityPerUnit` varchar(20) DEFAULT NULL,
  `unitPrice` decimal(10,2) UNSIGNED DEFAULT '0.00',
  `unitsInStock` smallint(6) DEFAULT '0',
  `unitsOnOrder` smallint(5) UNSIGNED DEFAULT '0',
  `reorderLevel` smallint(5) UNSIGNED DEFAULT '0',
  `discontinued` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`productID`),
  KEY `productName` (`productName`),
  KEY `categoryID` (`categoryID`),
  KEY `supplierID` (`supplierID`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`productID`, `productName`, `supplierID`, `categoryID`, `quantityPerUnit`, `unitPrice`, `unitsInStock`, `unitsOnOrder`, `reorderLevel`, `discontinued`) VALUES
(1, 'test', 1, 1, '10 boxes', '100.00', 10, 0, 0, 0),
(2, 'new product', 2, 1, '1 packet', '12.00', 33, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `purchaseorders`
--

DROP TABLE IF EXISTS `purchaseorders`;
CREATE TABLE IF NOT EXISTS `purchaseorders` (
  `purchaseOrderID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `supplierID` varchar(5) DEFAULT NULL,
  `employeeID` mediumint(8) UNSIGNED NOT NULL,
  `orderDate` datetime DEFAULT NULL,
  `requiredDate` datetime DEFAULT NULL,
  `shipName` varchar(40) DEFAULT NULL,
  `shipAddress` varchar(60) DEFAULT NULL,
  `shipCity` varchar(15) DEFAULT NULL,
  `shipCountry` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`purchaseOrderID`),
  KEY `orderDate` (`orderDate`),
  KEY `employeeID` (`employeeID`),
  KEY `supplierID` (`supplierID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `purchaseorders`
--

INSERT INTO `purchaseorders` (`purchaseOrderID`, `supplierID`, `employeeID`, `orderDate`, `requiredDate`, `shipName`, `shipAddress`, `shipCity`, `shipCountry`) VALUES
(13, '1', 1, '2017-12-12 00:00:00', '2017-12-12 00:00:00', 'test', 'test', 'test', 'test'),
(14, '1', 1, '2017-12-12 00:00:00', '2017-12-12 00:00:00', 'abc', 'abc', 'abc', 'abc');

-- --------------------------------------------------------

--
-- Table structure for table `salesorders`
--

DROP TABLE IF EXISTS `salesorders`;
CREATE TABLE IF NOT EXISTS `salesorders` (
  `salesOrderID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `customerID` varchar(5) DEFAULT NULL,
  `employeeID` mediumint(8) UNSIGNED NOT NULL,
  `orderDate` datetime DEFAULT NULL,
  `requiredDate` datetime DEFAULT NULL,
  `shipName` varchar(40) DEFAULT NULL,
  `shipAddress` varchar(60) DEFAULT NULL,
  `shipCity` varchar(15) DEFAULT NULL,
  `shipCountry` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`salesOrderID`),
  KEY `orderDate` (`orderDate`),
  KEY `customerID` (`customerID`),
  KEY `employeeID` (`employeeID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `salesorders`
--

INSERT INTO `salesorders` (`salesOrderID`, `customerID`, `employeeID`, `orderDate`, `requiredDate`, `shipName`, `shipAddress`, `shipCity`, `shipCountry`) VALUES
(4, '1', 1, '2017-12-12 00:00:00', '2017-12-12 00:00:00', 'abc', 'abc', 'abc', 'abc'),
(3, '1', 1, '2017-12-12 00:00:00', '2017-12-12 00:00:00', 'test', 'test', 'test', 'test'),
(5, '1', 1, '2017-12-12 00:00:00', '2017-12-12 00:00:00', 'abc', 'abc', 'abc', 'abc');

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
CREATE TABLE IF NOT EXISTS `suppliers` (
  `supplierID` smallint(5) UNSIGNED NOT NULL AUTO_INCREMENT,
  `companyName` varchar(40) NOT NULL,
  `contactName` varchar(30) DEFAULT NULL,
  `contactTitle` varchar(30) DEFAULT NULL,
  `address` varchar(60) DEFAULT NULL,
  `city` varchar(15) DEFAULT NULL,
  `country` varchar(15) DEFAULT NULL,
  `mobile` varchar(24) DEFAULT NULL,
  `phone` varchar(24) DEFAULT NULL,
  `homePage` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`supplierID`),
  KEY `companyName` (`companyName`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`supplierID`, `companyName`, `contactName`, `contactTitle`, `address`, `city`, `country`, `mobile`, `phone`, `homePage`) VALUES
(1, 'test', 'test', 'test', 'test', 'test', 'test', '2343333', '33333', 'www.abc.com'),
(2, 'test', 'test', 'test', 'test', 'test', 'test', '2343333', '33333', 'www.abc.com');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE IF NOT EXISTS `transactions` (
  `transID` bigint(20) NOT NULL AUTO_INCREMENT,
  `invoiceID` bigint(20) DEFAULT NULL,
  `transactionType` int(11) NOT NULL DEFAULT '1' COMMENT '1 for cash 2 for cheque',
  `amount` double NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`transID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `userName` varchar(50) NOT NULL,
  `firstName` varchar(100) NOT NULL,
  `lastName` varchar(100) NOT NULL,
  `createdOn` datetime NOT NULL,
  PRIMARY KEY (`userid`),
  UNIQUE KEY `userid` (`userid`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userid`, `userName`, `firstName`, `lastName`, `createdOn`) VALUES
(1, 'shahid', 'shahid', 'shahid', '2017-12-12 00:00:00');

-- --------------------------------------------------------

--
-- Structure for view `cashflowreport`
--
DROP TABLE IF EXISTS `cashflowreport`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `cashflowreport`  AS  select `i`.`invoiceNumber` AS `invoiceNumber`,`i`.`invoiceDate` AS `invoiceDate`,`i`.`refference` AS `refference`,`i`.`chequeNumber` AS `chequeNumber`,(select ifnull(convert(sum((`od`.`unitPrice` * `od`.`quantity`)) using utf8),`i`.`totalAmount`) from `ordedetails` `od` where (`od`.`orderID` = `i`.`orderID`)) AS `debit`,'0.00' AS `credit` from `invoices` `i` where (`i`.`invoiceType` = 1) union all select `i`.`invoiceNumber` AS `invoiceNumber`,`i`.`invoiceDate` AS `invoiceDate`,`i`.`refference` AS `refference`,`i`.`chequeNumber` AS `chequeNumber`,'0.00' AS `debit`,(select ifnull(convert(sum((`od`.`unitPrice` * `od`.`quantity`)) using utf8),`i`.`totalAmount`) from `ordedetails` `od` where (`od`.`orderID` = `i`.`orderID`)) AS `credit` from `invoices` `i` where (`i`.`invoiceType` = 2) ;

-- --------------------------------------------------------

--
-- Structure for view `inventoryreport`
--
DROP TABLE IF EXISTS `inventoryreport`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `inventoryreport`  AS  select `p`.`productName` AS `productName`,`c`.`categoryName` AS `categoryName`,(select ifnull(convert(sum(`od`.`quantity`) using utf8),0.00) from `ordedetails` `od` where ((`od`.`productID` = `p`.`productID`) and (`od`.`orderType` = 2))) AS `debit`,(select ifnull(convert(sum(`od`.`quantity`) using utf8),0.00) from `ordedetails` `od` where ((`od`.`productID` = `p`.`productID`) and (`od`.`orderType` = 1))) AS `credit` from (`products` `p` left join `categories` `c` on((`c`.`categoryID` = `p`.`categoryID`))) ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
