-- 1811. Find Interview Candidates
with consecutive as (
    select
        u.user_id
    from Users u
        inner join Contests c1
            on u.user_id in (c1.gold_medal, c1.silver_medal, c1.bronze_medal)
        inner join Contests c2
            on c1.contest_id + 1 = c2.contest_id
                and u.user_id in (c2.gold_medal, c2.silver_medal, c2.bronze_medal)
        inner join Contests c3
            on c2.contest_id + 1 = c3.contest_id
                and u.user_id in (c3.gold_medal, c3.silver_medal, c3.bronze_medal)
), gold_medals as (
    select
        gold_medal as user_id
    from Contests
    group by gold_medal
    having count(gold_medal) >= 3
), user_ids as (
    select
        user_id
    from consecutive
        union
    select
        user_id
    from gold_medals
)
select
    u.name,
    u.mail
from user_ids ui
    inner join Users u on ui.user_id = u.user_id