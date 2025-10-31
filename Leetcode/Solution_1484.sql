﻿-- 1484. Group Sold Products By The Date
select
    sell_date,
    count(distinct product) as num_sold,
    string_agg(distinct product, ',') as products
from Activities
group by sell_date
order by sell_date
