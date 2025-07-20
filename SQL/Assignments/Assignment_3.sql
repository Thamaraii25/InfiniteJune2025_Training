use Assignments

--Query 1
--Retrieve a list of MANAGERS.
select e1.empno,e1.ename,e1.job,e1.mgr_id,e2.ename [ Manager Name] 
from emp e1 left join emp e2 
on e1.mgr_id = e2.empno

--Query 2
--Find out the names and salaries of all employees earning more than 1000 per month. 
--alter table emp alter column hire_date date
select ename,salary from emp where salary > 1000

--Query 3
--Display the names and salaries of all employees except JAMES. 
select ename, salary from emp where ename <> 'JAMES'

--Query 4
--Find out the details of employees whose names begin with ‘S’.
select * from emp where ename like 'S%'

--Query 5
--Find out the names of all employees that have ‘A’ anywhere in their name. 
select ename from emp where ename like '%A%'

--Query 6
--Find out the names of all employees that have ‘L’ as their third character in their name.
select ename from emp where ename like '__L%'

--Query 7
--Compute daily salary of JONES.
select ename, (salary / 30.0) [Daily Salary] from emp where ename = 'JONES'

--Query 8
--Calculate the total monthly salary of all employees. 
select sum(Salary) [Total Monthly Salary Of All Employees] from emp

--Query 9
--Print the average annual salary . 
select avg(salary * 12) [Average Annual Salary] from emp

--Query 10
--Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 
select ename,job,salary,deptno from emp where job <> 'SALESMAN' and deptno <> 30

--Query 11
--List unique departments of the EMP table. 
select Distinct deptno from emp


--Query 12
--List the name and salary of employees who earn more than 1500 and are in department 10 or 30. 
--Label the columns Employee and Monthly Salary respectively.
select ename [Employee] , salary [Monthly Salary] from emp where salary > 1500 and (deptno = 10 or deptno = 30)

--Query 13
--Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000.
select ename,job,salary from emp where job in('MANAGER','ANALYST') and salary not in(1000,3000,5000)

--Query 14
--Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%.
select ename,salary,comm from emp where comm > Salary + (Salary * 0.1)

--Query 15
--Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782.
select ename from emp where ename like '%L%L%' and deptno = 30 or mgr_id = 7782

--Query 16
--Display the names of employees with experience of over 30 years and under 40 yrs.
--Count the total number of employees. 
With empWithExperience as 
(select ename from emp where (year(CURRENT_TIMESTAMP) - year(hire_date)) between 30 and 40)

select count(*) [Total Employee with Experience] from empWithExperience

--Query 17
--Retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname [Department Name], e.ename [Employee Name] from dept d join emp e on d.deptno = e.deptno
order by [Department Name] asc,[Employee Name] desc

--Query 18
--Find out experience of MILLER.
select ename [Employee Name],(year(Current_Timestamp) - year(hire_date)) [Experience] from emp where ename = 'MILLER'