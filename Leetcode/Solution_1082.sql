-- 1082. Sales Analysis I
with max_total_sum as (
    select
        seller_id,
        sum(s.price) as total_price
    from Sales s
    group by s.seller_id
)
select seller_id
from max_total_sum
where total_price = (select max(total_price) from max_total_sum)