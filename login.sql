create table login(
username varchar(25) primary key,
password varchar(25),
role varchar(25)
)
insert into login values('alqama','123456','customer')
insert into login values('ashhad','123456','staff')
insert into login values('uzair','123456','admin')
select * from login