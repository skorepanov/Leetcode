-- 1327. List the Products Ordered in a Period
select
    p.product_name,
    sum(o.unit) as unit
from Orders o
    inner join Products p on o.product_id = p.product_id
where o.order_date between '20200201' and '20200229'
group by p.product_name
having sum(o.unit) >= 100
