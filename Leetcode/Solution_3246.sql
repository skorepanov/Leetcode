-- 3246. Premier League Table Ranking
select
    team_id,
    team_name,
    wins * 3 + draws as points,
    rank() over (order by wins * 3 + draws desc) as position
from TeamStats
order by
    points desc,
    team_name asc