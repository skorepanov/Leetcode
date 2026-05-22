-- 1355. Activity Participants
with counts as (
    select
        activity,
        count(id) as count
    from Friends
    group by activity
)
select
    activity
from counts
where count <> (select min(count) from counts)
    and count <> (select max(count) from counts)