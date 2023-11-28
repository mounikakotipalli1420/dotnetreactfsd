CREATE TABLE ITEM (
    itemname VARCHAR(255) PRIMARY KEY,
    itemtype CHAR(1),
    itemcolor VARCHAR(255)
);
INSERT INTO ITEM (itemname, itemtype, itemcolor)
VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', '--'),
('Geo positioning system', 'N', '--'),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', '--'),
('Map Measure', 'N', '--'),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', '--'),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', '--'),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');

CREATE TABLE DEPARTMENT (
    deptname VARCHAR(255) PRIMARY KEY,
    floor INT,
    phone INT,
    empno INT NOT NULL,
	FOREIGN KEY(empno) REFERENCES EMP(empno)
);
INSERT INTO DEPARTMENT (deptname, floor, phone, empno)
VALUES
('Management', 5, 34, 1),
('Books', 1, 81, 4),
('Clothes', 2, 24, 4),
('Equipment', 3, 57, 3),
('Furniture', 4, 14, 3),
('Navigation', 1, 41, 3),
('Recreation', 2, 29, 4),
('Accounting', 5, 35, 5),
('Purchasing', 5, 36, 7),
('Personnel', 5, 37, 9),
('Marketing', 5, 38, 2);

CREATE TABLE SALES (
    salesno INT PRIMARY KEY,
    saleqty INT,
    itemname VARCHAR(255) NOT NULL,
    deptname VARCHAR(255) NOT NULL
);

INSERT INTO SALES (salesno, saleqty, itemname, deptname)
VALUES
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(117, 1, '', 'Equipment'),
(118, 1, '', 'Recreation'),
(119, 1, '', 'Furniture'),
(120, 1, 'Pocket Knife-Nile', ''),
(121, 1, 'Exploring in 10 easy lessons', 'Books'),
(122, 1, 'How to win foreign friends', ''),
(123, 1, 'Compass', ''),
(124, 1, 'Pith Helmet', ''),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation');
	

CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    empname VARCHAR(255),
    salary INT,
    deptname VARCHAR(255),
    bossno INT,
    FOREIGN KEY (deptname) REFERENCES DEPARTMENT (deptname),
    FOREIGN KEY (bossno) REFERENCES EMP (empno)
);


INSERT INTO EMP (empno, empname, salary, deptname, bossno)
VALUES
(1, 'Alice', 75000, 'Management', NULL),
(2, 'Ned', 45000, 'Marketing', 1),
(3, 'Andrew', 25000, 'Marketing', 2),
(4, 'Clare', 22000, 'Marketing', 2),
(5, 'Todd', 38000, 'Accounting', 1),
(6, 'Nancy', 22000, 'Accounting', 5),
(7, 'Brier', 43000, 'Purchasing', 1),
(8, 'Sarah', 56000, 'Purchasing', 7),
(9, 'Sophile', 35000, 'Personnel', 1),
(10, 'Sanjay', 15000, 'Navigation', 3),
(11, 'Rita', 15000, 'Books', 4),
(12, 'Gigi', 16000, 'Clothes', 4),
(13, 'Maggie', 11000, 'Clothes', 4),
(14, 'Paul', 15000, 'Equipment', 3),
(15, 'James', 15000, 'Equipment', 3),
(16, 'Pat', 15000, 'Furniture', 3),
(17, 'Mark', 15000, 'Recreation', 3);


