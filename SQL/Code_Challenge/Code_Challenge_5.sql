use CodeChallenge

--Query 1
--1. Write a query to display your birthday( day of week)

select DATENAME(WEEKDAY,'2004-01-25') [Birthday_Using_DayOfWeek]

--Query 2
--2. Write a query to display your age in days

select DATEDIFF(DAY,'2004-01-25',CURRENT_TIMESTAMP) [Age In Days] 

--Query 3
--3. Write a query to display all employees information those who joined before 5 years in the current month
--(Hint : If required update some HireDates in your EMP table of the assignment)

use Assignments

select * from emp
 
update emp set hire_date = '2025-03-11' where deptno = 20
update emp set hire_date = '2019-07-25' where deptno = 10

select * from emp where DATEDIFF(YEAR,hire_date,CURRENT_TIMESTAMP) >= 5 and month(hire_date) = month(CURRENT_TIMESTAMP);


--Query 4
/* 4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
	a. First insert 3 rows 
	b. Update the second row sal with 15% increment  
    c. Delete first row.
After completing above all actions, recall the deleted row without losing increment of second row. */

begin tran
create table EmployeeTransaction(Empno int, Ename varchar(30),Sal int,DOJ datetime)

insert into EmployeeTransaction values(1,'Thamarai',25000,'2025-06-25'),
(2,'Priya',50000,'2024-06-25'),
(3,'Ram',70000,'2023-06-25')
update EmployeeTransaction set Sal = Sal + (sal * 0.15) where Empno = 2
save tran BeforeDelete
delete from EmployeeTransaction where Empno = 1

--select * from EmployeeTransaction
rollback tran BeforeDelete

--Query 5
/*
5. Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	a.     For Deptno 10 employees 15% of sal as bonus.
	b.     For Deptno 20 employees  20% of sal as bonus
	c      For Others employees 5%of sal as bonus
*/

create or alter function CalcBonus (@salary float, @deptNo int)
returns	varchar(100)
as
begin
	declare @bonusAmount float
	if(@deptNo = 10)
		set @bonusAmount = @salary * 0.15
	else if(@deptNo = 20)
		set @bonusAmount = @salary * 0.20
	else
		set @bonusAmount = @salary * 0.05
	return @bonusAmount
end

select * from emp
select EmpNo, EName,Salary, deptno, dbo.CalcBonus(deptno,salary) [Bonus Amount for That Department] from emp

--Query 6
--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

create or alter proc sp_Update_Salary
as 
begin
	update e set e.salary = e.salary + 500 from emp e join
	dept d on e.deptno = d.deptno
    where d.dname = 'Sales' and e.salary < 1500
end

exec sp_Update_Salary

select * from emp
