--create procedure GetAllProducts as
use Store
go
--select Products.Id as 'Идентификатор',Products.[Name] as 'Название продукта',
--Products.Price as 'Цена',Products.[Description] as 'Описание'
--from Products 
--where Products.Id=1;
--exec GetAllProducts
select UR.ReviewId ,UR.ProductId,UR.Mark,UR.[Description],UR.UserName  
from UserReview as UR 