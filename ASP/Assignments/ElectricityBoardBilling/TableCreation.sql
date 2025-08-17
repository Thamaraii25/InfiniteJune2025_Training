create database ElectricityBillDB

use ElectricityBillDB

create table ElectricityBill(
Consumer_number varchar(20) primary key,
Consumer_name varchar(50),
Units_consumed int,
Bill_amount float)

select * from ElectricityBill