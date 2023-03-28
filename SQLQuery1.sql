create proc proc_login
@username nvarchar(50),
@password nvarchar(50)
as
begin
	select * from dbo.Login where username = @username and password = @password
end