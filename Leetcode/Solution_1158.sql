﻿-- 1158. Market Analysis I
select
    u.user_id as buyer_id,
    u.join_date,
    count(o.order_id) as orders_in_2019
from Users u
    left join Orders o on u.user_id = o.buyer_id
        and date_part('year', o.order_date) = 2019
group by u.user_id, u.join_date
