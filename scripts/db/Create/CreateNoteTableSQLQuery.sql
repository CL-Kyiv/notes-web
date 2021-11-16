use test_db

create table note
(id int primary key identity(1, 1),
title nvarchar(max),
body nvarchar(max),
created_date datetime2,
is_active bit DEFAULT 1
)


