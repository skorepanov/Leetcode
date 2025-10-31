-- 1141. User Activity for the Past 30 Days I
select
    activity_date as day,
    count(distinct user_id) as active_users
from Activity
where activity_date between ('20190727'::date - interval '29 DAYS') and '20190727'::date
group by activity_date
