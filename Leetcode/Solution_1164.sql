-- 1164. Product Price at a Given Date
with max_dates as (
    select
        product_id,
        max(change_date) as max_change_date
    from Products
    where change_date <= '20190816'
    group by product_id
)
select
    p.product_id,
    p.new_price as price
from Products p
    inner join max_dates on p.product_id = max_dates.product_id
        and p.change_date = max_dates.max_change_date
    union
select
    product_id,
    10 as price
from Products
group by product_id
having min(change_date) > '20190816'
