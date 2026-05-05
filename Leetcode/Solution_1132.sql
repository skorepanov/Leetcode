-- 1132. Reported Posts II
with daily_rates as (
    select
        a.action_date,
        count(distinct case when a.post_id = r.post_id then r.post_id end)::numeric
            / count(distinct a.post_id) as daily_rate
    from Actions a
        left join Removals r on a.post_id = r.post_id
    where a.action = 'report' and a.extra = 'spam'
    group by a.action_date
)
select
    round(avg(daily_rate) * 100, 2) as average_daily_percent
from daily_rates