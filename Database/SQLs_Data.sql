/*

select * from tblUser
select * from tblMenu
select * from tblUserMenu

*/

Insert into tblUser
select 'Administrator', 'admin@gmail.com', '9876543210', 'admin', 'A'
union
select 'Sabapathy',	'tkspathy@yahoo.com', '8095094141', 'saba', 'U'
union
select 'Viswa',	'viswa@gmail.com', '9876543210', 'viswa', 'U'
union
select 'Vedant', 'vedant@gmail.com', '8972342456', 'vedant', 'U'

Insert into tblMenu
select 'Country', '/Country/List'
union
select 'State', '/State/List'
union
select 'City', '/City/List'
union
select 'Category', '/Category/List'
union
select 'Product', '/Product/List'
union
select 'Customer', '/Customer/List'
