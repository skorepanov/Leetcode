-- 1285. Find the Start and End Number of Continuous Ranges

-- solution 2 - Runtime 209 ms, beats 59.62%
with logs as (
    select
        log_id,
        row_number() over (order by log_id) as row_number
    from Logs
)
select
    min(log_id) as start_id,
    max(log_id) as end_id
from logs
group by log_id - row_number
order by start_id

-- solution 1 - my solution, too complicated. Runtime 183 ms, beats 78.87%
with logs as (
    select
        l_lower.log_id as log_id_lower,
        l.log_id,
        l_bigger.log_id as log_id_bigger
    from Logs l
        left join Logs l_lower
            on l.log_id - 1 = l_lower.log_id
        left join Logs l_bigger
            on l.log_id + 1 = l_bigger.log_id
),
ranges as (
    select
        case when log_id_lower is null then log_id end as start_id,
        case when log_id_bigger is null then log_id end as end_id
    from logs
    where log_id_lower is null or log_id_bigger is null
)
select distinct
    coalesce(start_id, lag(start_id, 1, null) over (order by coalesce(start_id, end_id))) as start_id,
    coalesce(end_id, lag(end_id, -1, null) over (order by coalesce(start_id, end_id))) as end_id
from ranges
order by start_id