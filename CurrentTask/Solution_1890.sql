-- 1890. The Latest Login in 2020
-- my solution - faster
select distinct on (user_id)
    user_id,
    time_stamp as last_stamp
from logins
where date_part('year', time_stamp) = 2020
order by user_id, time_stamp desc

-- with max() - slower
select user_id,
       max(time_stamp) as last_stamp
from logins
where date_part('year', time_stamp) = 2020
group by user_id
