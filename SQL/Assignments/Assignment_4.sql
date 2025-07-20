use Assignments

--Query 1
--Write a T-SQL Program to find the factorial of a given number.

declare @numberToCalcFactorial int
set @numberToCalcFactorial = 4
declare @factorialResult int = 1
declare @count int = 1

while (@count <= @numberToCalcFactorial)
	begin
		set @factorialResult = @factorialResult * @count
		set @count = @count + 1
	end

print 'Factorial of ' + cast(@numberToCalcFactorial as varchar(20)) + ' is ' + cast(@factorialResult as varchar(30))



--Query 2
--create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 

create or alter proc sp_multiplication_Table (@number int,@final int) as
begin
	declare @count int = 1
	while(@count <= @final)
		begin
			print cast(@count as varchar(10)) + 'x' + cast(@number as varchar(10)) + '='+ cast(@count * @number as varchar(50))
			set @count = @count + 1
		end
end

exec sp_multiplication_Table @number = 2, @final = 10

--Query 3
--Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create table Student(Sid int primary key,Sname varchar(30))

create table Marks(Mid int primary key,Sid int references Student(Sid),Score int)

insert into Student values
(1,'Jack'),
(2,'Rithvik'),
(3,'Jaspreeth'),
(4,'Praveen'),
(5,'Bisa'),
(6,'Suraj')

insert into Marks values
(1,1,23),
(2,6,95),
(3,4,98),
(4,2,17),
(5,3,53),
(6,5,13)
		
create function fn_getMarkStatus(@score int)
returns nvarchar(10) as
begin
	return case
	when (@score >= 50) then 'Pass'
	else 'Fail'
	end
end

select s.Sid,s.Sname,m.Score,dbo.fn_getMarkStatus(m.Score) [Score Status]
from Student s join marks m on s.Sid = m.Sid