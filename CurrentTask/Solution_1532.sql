-- 1532. The Most Recent Three Orders
with recent_orders as (
    select
        order_id,
        row_number() over (partition by customer_id order by order_date desc) as row_number
    from Orders
)
select
    c.name as customer_name,
    c.customer_id,
    o.order_id,
    o.order_date
from recent_orders ro
    inner join Orders o
        on ro.order_id = o.order_id
    inner join Customers c
        on o.customer_id = c.customer_id
where ro.row_number <= 3
order by c.name, c.customer_id, o.order_date desc