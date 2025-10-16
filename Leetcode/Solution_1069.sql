-- 1069. Product Sales Analysis II
select
    product_id,
    sum(quantity) as total_quantity
from Sales
group by product_id