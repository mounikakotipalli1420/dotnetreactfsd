use pubs

select * from publishers

select * from titles
--select publisher name and the title name--
select pub_name 'Publisher Name', title 'Book Name' from publishers join titles
on publishers.pub_id = titles.pub_id

select pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id

select p.pub_id 'Publisher Id', pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id
order by [Publisher Name]

--outer JOin
select pub_name 'Publisher Name', title 'Book Name' 
from publishers left outer join titles
on publishers.pub_id = titles.pub_id

select t.title Book_Name, s.qty Quantity_Sold
from sales s right outer join titles t
on s.title_id = t.title_id

select fname 'Employee Name',pub_name 'Publisher Name' from employee e left outer join publishers p
on e.pub_id=p.pub_id order by [Employee Name]

--print the publisher name and employee name

select * from authors
select * from titles
select * from titleauthor

select title 'Book Name', CONCAT(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta
on t.title_id = ta.title_id 
join authors a on ta.au_id = a.au_id
--Select the publisher name, title name and the sold quantity

select pub_name as publisher_name, title as title_name,qty as sold_quantity
from publishers p join titles t
on p.pub_id = t.pub_id
join sales s on t.title_id=s.title_id
--cross join
select * from sales cross join employee

create table tbl1
(f1 int,
f2 varchar(20))

insert into tbl1 values(1,'abc'),(2,'efg'),(3,'klj'),(4,'jjj')
--data injection
select * from tbl1 where f1=1;delete  from tbl1;

create procedure proc_First
as
begin
    select * from authors
end

execute proc_First

create proc proc_InsertSample(@f1 int, @f2 varchar(20))
as
begin
   insert into tbl1 values(@f1,@f2)
end

exec proc_InsertSample 5,'GYH'
exec proc_InsertSample 5,'GYH;delete from tbl1'

alter proc proc_Select(@f2 varchar(20))
as
begin
   select * from tbl1 where f2=@f2
end

exec proc_Select '1;delete from tbl1'

--create a proc that will take a author name and fetch the total sales done on his books
alter proc proc_GetTotalSaleAmount(@authorName varchar(20),@salemount float out)
as
begin
    declare
	@saleamt float
	set @saleamt = (select s.qty * t.price from sales s join titles t
	                      on s.title_id=t.title_id
						  where title in
						  (select title_id from titleauthor where au_id=
						  (select au_id from authors where au_fname = @authorName)))
						  set @salemount = @saleamt
end

select * from authors

declare @amt float
begin
exec proc_GetTotalSaleAmount 'Cheryl',@amt out
print @amt
end

alter function fn_CalculateTax(@price float)
returns float
as
begin
    declare @totalPrice float
	set @totalPrice = @price +(@price*12.36/100)
	return round(@totalPrice,2)
end

select title,price,dbo.fn_CalculateTax(price) 'Nett. Price'
from titles

--create a function that will take the author's first name and last name and 
--give back the full name separated by space
alter function full_Name(@au_fname varchar(20),@au_lname varchar(40))
returns varchar(40)
as
begin
	declare @fullName varchar(40)
	set @fullName	= @au_fname+' '+@au_lname
	return @fullName
end

select au_fname,au_lname,dbo.full_Name(au_fname,au_lname) 'Author Full Name' from authors

--create a procedure that will take the publisher name and give back the total sales
--for the books published
create procedure GetTotalsalesforpublisher(@publisher_name varchar(20))
as
begin
declare
   @saleamt float
   set @saleamt=(select sum(s.qty)*sum(t.price) from sales s join titles t
                    on s.title_id=t.title_id
					where t.pub_id in
					(select pub_id from publishers where pub_name=@publisher_name))
 end
exec GetTotalsalesforpublisher @publisher_name='Scootney Books'
--View
create view vwPublisher
as
select pub_id 'Publisher Id', pub_name 'Publisher Name'  from Publishers

select * from vwPublisher

create view vwInvoice
as
 select t.title 'Book Name', sum(s.qty)*sum(t.price) 'Sale Amount' from sales s join titles t
                    on s.title_id=t.title_id
					group by t.title 

select * from vwInvoice

create index idxSample 
on tbl1(f1)

sp_help tbl1

create trigger trg_InsertTbl1
on tbl1
for insert
as
begin
   print 'Hello'
end

insert into tbl1 values(101,'UUU')

use dbCompany26Oct2023

select * from EmployeesSkills

alter trigger trgInsertEmployeeSkill 
on EmployeesSkills
instead of insert
as
begin
   declare 
	 @skillName varchar(20),
	 @empId int,
	 @level int
	 set @SkillName = (select skill_name from inserted)
	 set @empId =  (select employee_id from inserted)
	 set @level =  (select skill_level from inserted)
	 if((select count(skill) from Skills where skill= @skillName) =0)
	 begin
			print 'Skill not present in skill table'
	end
	else
	begin
	    insert into EmployeesSkills values(@empId,@skillName,@level)	
	end
end

insert into EmployeesSkills values(101,'SQ',8)

SELECT p.pub_name AS 'Publisher Name',
       t.title AS 'Book Name',
       s.qty AS 'Quantity',
       s.qty * t.price AS 'Sale Amount',
       a.au_fname + ' ' + a.au_lname AS 'Author Name'
FROM publishers p
JOIN titles t ON p.pub_id = t.pub_id
JOIN sales s ON t.title_id = s.title_id
JOIN titleauthor ta ON t.title_id = ta.title_id
JOIN authors a ON ta.au_id = a.au_id;
