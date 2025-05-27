-- 1212. Team Scores in Football Tournament
with points as (
    select host_team,
           guest_team,
           case when host_goals > guest_goals then 3
                when host_goals = guest_goals then 1
                else 0
               end as host_points,
           case when guest_goals > host_goals then 3
                when guest_goals = host_goals then 1
                else 0
               end as guest_points
    from matches
), total_points as (
    select t.team_id,
           t.team_name,
           case when t.team_id = p.host_team then p.host_points
                when t.team_id = p.guest_team then p.guest_points
                else 0
               end as num_points
    from teams t
             left join points p on t.team_id = p.host_team or t.team_id = p.guest_team
)
select team_id, team_name, sum(num_points) as num_points
from total_points
group by team_id, team_name
order by num_points desc, team_id asc