-- 1174. Immediate Food Delivery II
select
    round(avg(percentage::decimal) * 100, 2) as immediate_percentage
from (
    select
        customer_id,
        case when min(order_date) = min(customer_pref_delivery_date) then 1 else 0 end as percentage
    from Delivery
    group by customer_id
)
