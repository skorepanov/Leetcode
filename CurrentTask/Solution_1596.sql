-- 1596. The Most Frequently Ordered Products for Each Customer
with counts as (
    select
        customer_id,
        product_id,
        rank() over (partition by customer_id order by count(product_id) desc) as rank
    from Orders
    group by customer_id, product_id
)
select
    c.customer_id,
    c.product_id,
    p.product_name
from counts c
    inner join Products p
        on c.product_id = p.product_id
where c.rank = 1