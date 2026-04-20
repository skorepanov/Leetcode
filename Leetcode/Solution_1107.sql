-- 1107. New Users Daily Count
with first_login as (
    select distinct on (user_id)
        user_id,
        activity_date as login_date
    from Traffic
    where activity = 'login'
    order by user_id, activity_date
)
select
    login_date,
    count(user_id) as user_count
from first_login
where login_date between '20190630'::date - interval '90 days' and '20190630'
group by login_date