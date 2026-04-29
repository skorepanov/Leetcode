-- 3415. Find Products with Three Consecutive Digits
select
    product_id,
    name
from Products
where regexp_like(name, '\d{3}')
    and not regexp_like(name, '\d{4,}')
order by product_id