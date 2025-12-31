-- 1435. Create a Session Bar Chart
select
    '[0-5>' as bin,
    sum(case when 0 <= duration and duration < 5 * 60 then 1 else 0 end) as total
from Sessions
    union
select
    '[5-10>' as bin,
    sum(case when 5 * 60 <= duration and duration < 10 * 60 then 1 else 0 end) as total
from Sessions
    union
select
    '[10-15>' as bin,
    sum(case when 10 * 60 <= duration and duration < 15 * 60 then 1 else 0 end) as total
from Sessions
    union
select
    '15 or more' as bin,
    sum(case when  15 * 60 <= duration then 1 else 0 end) as total
from Sessions
