-- 2853. Highest Salaries Difference
with max_marketing as (
    select
        max(salary) as salary
    from Salaries
    where department = 'Marketing'
),
max_engineering as (
    select
        max(salary) as salary
    from Salaries
    where department = 'Engineering'
)
select
    abs(max_marketing.salary - max_engineering.salary) as salary_difference
from max_marketing, max_engineering