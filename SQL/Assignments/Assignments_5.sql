use Assignments

/*
   1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition
 
   a) HRA as 10% of Salary
   b) DA as 20% of Salary
   c) PF as 8% of Salary
   d) IT as 5% of Salary
   e) Deductions as sum of PF and IT
   f) Gross Salary as sum of Salary, HRA, DA
   g) Net Salary as Gross Salary - Deductions
 
Print the payslip neatly with all details
*/
 
create or alter proc sp_paySlip
(@empno int,@salary int)
as
begin
	declare @HRA float
	declare @DA float
	declare @PF float
	declare @IT float
	declare @deductions float
	declare @grossSalary float
	declare @netSalary float
 
	set @HRA = @salary * 0.1
	set @DA = @salary * 0.2
	set @PF = @salary * 0.08
	set @IT = @salary * 0.05
	set @deductions = @PF + @IT
	set @grossSalary = @salary + @HRA + @DA
	set @netSalary = @grossSalary - @deductions
 
	print 'Employee Pay Slip'
	print 'Employee Number: '  + cast(@empno as varchar(10))
	print 'Salary: ' +  cast(@salary as varchar(10))
	print 'HRA: ' +  cast(@HRA as varchar(10))
	print 'DA: ' + cast(@DA  as varchar(10))
	print 'IT: ' + cast(@IT  as varchar(10))
	print 'Dedections: ' + cast( @deductions  as varchar(10))
	print 'Gross Salary: '+  cast(@grossSalary  as varchar(10))
	print 'Net Salary: ' +  cast(@netSalary  as varchar(10))
end
 
exec sp_paySlip @empno = 1806637 , @salary = 30000

/*
2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 
*/

--create
create table holidays (
    holiday_date date,
    holiday_name varchar(100))


-- insert 
insert into holidays values ('2025-08-15', 'Independence Day'),
('2025-10-23', 'Diwali'),
('2025-01-26', 'Republic Day'),
('2025-12-25', 'Christmas')

select * from holidays

select * from emp

-- Trigger 
create or alter trigger trg_BlockManipulationOnHolidays
on emp
instead of insert, update, delete
as
begin
    declare @today date = cast(getdate() as date)
    declare @holiday_name varchar(100)

    select top 1 @holiday_name = holiday_name from holidays
    where cast(holiday_date as date) = @today

    if @holiday_name is not null
    begin
        raiserror ('Due to %s, you cannot manipulate data.', 16, 1, @holiday_name)
        return
    end

    if exists (select * from inserted)
    begin
        if exists (select * from deleted)
        begin
            update e set e.ename = i.ename, e.job = i.job, e.mgr_id = i.mgr_id,
            e.hire_date = i.hire_date, e.salary = i.salary, e.comm = i.comm, e.deptno = i.deptno
            from emp e join inserted i on e.empno = i.empno
        end
        else
        begin
            insert into emp select empno, ename, job, mgr_id, hire_date, salary, comm, deptno from inserted
        end
    end
    else
    begin
        delete e from emp e join deleted d on e.empno = d.empno
    end
end

insert into emp values (7901, 'TEST', 'CLERK', 7566, '2025-08-15', 1234, null, 20)

