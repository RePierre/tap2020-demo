declare @accountTypes table
(	
	TypeId int not null,
	TypeName nvarchar(50) not null
)

insert into @accountTypes (TypeId, TypeName)
values
(1, N'Credit account'),
(2, N'Debit account'),
(3, N'Deposit account'),
(4, N'Savings account')

merge dbo.AccountTypes as target
using @accountTypes as source
on (target.Id = source.TypeId)
when matched then 
	update set Name = source.TypeName
when not matched then
	insert(Id, Name)
	values(source.TypeId, source.TypeName);