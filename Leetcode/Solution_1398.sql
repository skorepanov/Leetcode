-- 1398. Customers Who Bought Products A and B but Not C
with a_and_b as (
    select
        customer_id
    from Orders
    where product_name in ('A', 'B')
    group by customer_id
    having count(distinct product_name) = 2
), ids as (
    select
        customer_id
    from a_and_b
        except
    select
        customer_id
    from Orders
    where product_name = 'C'
)
select
    ids.customer_id,
    c.customer_name
from ids
    inner join Customers c on ids.customer_id = c.customer_id
order by ids.customer_id
