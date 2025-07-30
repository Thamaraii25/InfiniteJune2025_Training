use CodeChallenge

/*
1. Write a stored Procedure that inserts records in the Employee_Details table
 
The procedure should generate the EmpId automatically to insert and should return the generated value to the user
 
Also the Salary Column is a calculated column (Salary is givenSalary - 10%)
 
Table : Employee_Details (Empid, Name, Salary, Gender)
Hint(User should not give the EmpId)
 
Test the Procedure using ADO classes and show the generated Empid and Salary
*/

--select * from Employee_Details

create table Employee_Details(EmpId int Identity(101,1) primary key , Name varchar(30), Gender varchar(10), Salary float, NetSalary float);

create or alter proc sp_InsertEmployeeDetails(@EmpName varchar(30),
@EmpGender varchar(10),
@EmpSalary float
)
as
begin
	declare @EmpNetSalary float
	declare @GeneratedEmpId int
	set @EmpNetSalary = (@EmpSalary - (0.1 * @EmpSalary))
	insert into Employee_Details(Name,Gender,Salary,NetSalary) values(@EmpName,@EmpGender,@EmpSalary,@EmpNetSalary)
    set @GeneratedEmpId = (select Max(EmpId) from Employee_Details)
    return @GeneratedEmpId
end

--exec
declare @genEmpId int
exec @genEmpId = sp_InsertEmployeeDetails @EmpName = 'Thamarai' , @EmpGender = 'Female', @EmpSalary = 40000
print 'Generated Employee ID:' + cast(@genEmpId as varchar(20))



/*
2. Write a procedure that takes empid as input and outputs the updated salary as current salary + 100 for the give employee.
 
  Test the procedure using ADO classes and display the Employee details of that employee whose salary has been updated
*/

create or alter proc sp_GetUpdatedSalary(@EmpId int, @UpdatedSalary float output)
as
begin
	update Employee_Details set salary = salary + 100 where EmpId = @EmpId
	set @UpdatedSalary = (select salary from Employee_Details where EmpId = @EmpId)
end

--exec
declare @U_Salary float
exec sp_GetUpdatedSalary @EmpId = 101, @UpdatedSalary = @U_Salary Output
print 'Updated Salary: ' + cast(@U_Salary as varchar(20));




