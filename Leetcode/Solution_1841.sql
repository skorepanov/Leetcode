-- 1841. League Statistics
with home_points as (
    select
        home_team_id as team_id,
        sum(
            case
                when home_team_goals > away_team_goals then 3
                when home_team_goals = away_team_goals then 1
                else 0
            end
        ) as points,
        count(home_team_id) as match_count,
        sum(home_team_goals) as goals
    from Matches
    group by home_team_id
), away_points as (
     select
        away_team_id as team_id,
        sum(
            case
                when away_team_goals > home_team_goals then 3
                when away_team_goals = home_team_goals then 1
                else 0
            end
        ) as points,
        count(away_team_id) as match_count,
        sum(away_team_goals) as goals
    from Matches
    group by away_team_id
), goal_against_home as (
    select
        home_team_id as team_id,
        sum(away_team_goals) as goals
    from Matches
    group by home_team_id
), goal_against_away as (
    select
        away_team_id as team_id,
        sum(home_team_goals) as goals
    from Matches
    group by away_team_id
), goal_agains_all as (
    select
        *
    from goal_against_home
        union all
    select
        *
    from goal_against_away
), goal_against1 as (
    select
        team_id,
        sum(goals) as goals
    from goal_agains_all
    group by team_id
)
select
    t.team_name,
    coalesce(hp.match_count, 0) + coalesce(ap.match_count, 0) as matches_played,
    coalesce(hp.points, 0) + coalesce(ap.points, 0) as points,
    coalesce(hp.goals, 0) + coalesce(ap.goals, 0) as goal_for,
    coalesce(ga.goals, 0) as goal_against,
    (coalesce(hp.goals, 0) + coalesce(ap.goals, 0)) - coalesce(ga.goals, 0) as goal_diff
from Teams t
    left join home_points hp on t.team_id = hp.team_id
    left join away_points ap on t.team_id = ap.team_id
    left join goal_against1 ga on t.team_id = ga.team_id
where coalesce(hp.match_count, 0) + coalesce(ap.match_count, 0) > 0
order by
    coalesce(hp.points, 0) + coalesce(ap.points, 0) desc,
    (coalesce(hp.goals, 0) + coalesce(ap.goals, 0)) - coalesce(ga.goals, 0) desc,
    t.team_name asc