-- 602. Friend Requests II: Who Has the Most Friends
with all_friends as (
    select
        requester_id as id,
        count(accepter_id) as count
    from RequestAccepted
    group by requester_id
        union all
    select
        accepter_id as id,
        count(requester_id) as count
    from RequestAccepted
    group by accepter_id
)
select
    id,
    sum(count) as num
from all_friends
group by id
order by num desc
fetch first 1 row with ties
