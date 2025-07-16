
--Creating Database
create database CodeChallenge

use CodeChallenge

--Creating Table Books
create table books(id int primary key, title varchar(50),author varchar(30), isbn numeric unique, published_date datetime)

insert into books values(1,'My First SQL Book','Mary Parker',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL Book','John Mayer',857300923713,'1972-07-03 09:22:45'),
(3,'My Third SQL Book','Cary Flint',523120967812,'2015-10-18 14:05:44')


--Query 1
-- Write a query to fetch the details of the books written by author whose name ends with er.
select * from books where author like '%er'

--Creating Table Reviews
create table reviews(id int primary key, book_id int, reviewer_name varchar(30), content varchar(50), rating int, published_date datetime, foreign key (book_id) references books(id))

insert into reviews values(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11.1'),
(2,2,'John Smith','My Second review',5,'2017-10-13 15:05:12.6'),
(3,2,'Alice Walker','Another review',1,'2017-10-22 23:47:10')



--Query 2
--Display the Title ,Author and ReviewerName for all the books from the above table
select b.title,b.author,r.reviewer_name from books b,reviews r where b.id = r.book_id


--Query 3
--Display the reviewer name who reviewed more than one book.
select reviewer_name , count(book_id) [Total Books Received] from reviews 
group by reviewer_name
having count(book_id) > 1

--Creating table Customer
create table customer(Id int primary key, Name varchar(30),Age int, Address varchar(30),Salary float)

insert into customer values (1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',4500.00),
(7,'Muffy',24,'Indore',10000.00)

--Query 4
--Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
select Name,Address from customer where Address like '%o%'

--Creating Table Orders
create table orders(OId int primary key, Date datetime,Customer_Id int,Amount int,foreign key(Customer_Id) references Customer(Id))

insert into orders values(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)


--Query 5
--Write a query to display the Date,Total no of customer placed order on same Date
select Date,count(Customer_id) [Total Customers Placed Order In That Date] from orders group by date

--Creating Table Employee
create table Employee(Id int primary key, Name varchar(30),Age int, Address varchar(30),Salary float)

insert into Employee values (1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00)

insert into Employee(Id,Name,Age,Address) values (6,'Komal',22,'MP'),
(7,'Muffy',24,'Indore')

--Query 6
--Display the Names of the Employee in lower case, whose salary is null
select Lower(Name) NameInLowerCase ,Salary from Employee where Salary Is Null;

--Creating Table StudentDetails
create table StudentDetails(RegisterNo int,Name varchar(30),Age int,Qualification varchar(30),MobileNo numeric,Mail_id varchar(60),Location varchar(30),Gender varchar(1))

insert into StudentDetails values(2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'B.SC',7890125648,'Kumar@gmail.com','Madurai','M'),
(4,'Selvi',22,'B.Tech',890467342,'selvi@gmail.com','Salem','F'),
(5,'Nisha',25,'M.E',7834672310,'Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A',7890345678,'saran@gmail.com','Madurai','F'),
(7,'Tom',23,'BCA',8901234675,'Tom@gmail.com','Pune','M')

--Query 7
--Write a sql server query to display the Gender,Total no of male and female from the above relation
select Gender,count(Gender) [Total Members] from StudentDetails group by Gender