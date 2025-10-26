-- 1076. Project Employees II

-- вариант 1 - Runtime 691 ms, Beats 81.70%
with counts as (
    select
        project_id,
        count(project_id) as employee_count
    from Project
    group by project_id
)
select
    project_id
from counts
where employee_count = (
    select
        max(employee_count)
    from counts
)

-- вариант 2 - Runtime 684 ms, Beats 84.60%
with counts as (
    select
        project_id,
        rank() over(order by count(employee_id) desc) as ranking
    from Project
    group by project_id
)
select
    project_id
from counts
where ranking = 1
