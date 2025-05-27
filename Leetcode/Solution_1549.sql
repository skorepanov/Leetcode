-- 1549. The Most Recent Orders for Each Product
with max_order_dates as (
    select distinct
        product_id,
        max(order_date) as order_date
    from Orders
    group by product_id
)
select
    p.product_name,
    p.product_id,
    o.order_id,
    o.order_date
from max_order_dates mod
    inner join orders o
        on mod.product_id = o.product_id and mod.order_date = o.order_date
    inner join Products p
        on mod.product_id = p.product_id
order by p.product_name, p.product_id, o.order_id