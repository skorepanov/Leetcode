﻿-- 1407. Top Travellers
select
    u.name,
    sum(coalesce(r.distance, 0)) as travelled_distance
from Users u
    left join Rides r on u.id = r.user_id
group by u.id, u.name
order by travelled_distance desc, u.name
