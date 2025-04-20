-- 534. Game Play Analysis III

-- solution 2 - window function
select
    player_id,
    event_date,
    sum(games_played) over (partition by player_id order by event_date) as games_played_so_far
from Activity

-- solution 1 - my solution, too slow
/*
select
    a1.player_id,
    a1.event_date,
    (
        select
            sum(a2.games_played)
        from Activity a2
        where a2.player_id = a1.player_id and a2.event_date <= a1.event_date
    ) as games_played_so_far
from Activity a1
*/