-- 1173. Immediate Food Delivery I
select
    round(
        (cast(count(*) filter (where order_date = customer_pref_delivery_date) as decimal(7,2)) / count(*)) * 100,
        2
    ) as immediate_percentage
from delivery