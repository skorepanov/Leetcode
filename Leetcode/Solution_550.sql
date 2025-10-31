-- 550. Game Play Analysis IV
select
    round(count(*) / (select count(distinct player_id) from Activity)::decimal, 2) as fraction
from Activity
where (player_id, event_date - interval '1 DAY') in (
    select
        player_id,
        min(event_date)
    from Activity
    group by player_id
)
