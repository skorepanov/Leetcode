-- 2026. Low-Quality Problems
select
    problem_id
from Problems
where likes::numeric / (likes + dislikes) < 0.6
order by problem_id