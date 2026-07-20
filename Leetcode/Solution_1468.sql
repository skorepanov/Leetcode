-- 1468. Calculate Salaries
with max_salaries as (
    select
        company_id,
        max(salary) as max_salary
    from Salaries s
    group by company_id
)
select
    s.company_id,
    s.employee_id,
    s.employee_name,
    round(case when ms.max_salary < 1000 then s.salary
        when ms.max_salary between 1000 and 10000 then s.salary * 0.76
        else s.salary * 0.51
        end) as salary
from Salaries s
    inner join max_salaries ms on s.company_id = ms.company_id