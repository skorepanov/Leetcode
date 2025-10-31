-- 1142. User Activity for the Past 30 Days II
with sessions as (
    select
        user_id,
        count(distinct session_id) as session_count
    from Activity
    where activity_date between '20190628' and '20190727'
    group by user_id
)
select
    coalesce(round(avg(session_count), 2), 0) as average_sessions_per_user
from sessions
