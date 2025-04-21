-- 184. Department Highest Salary
with max_salaries as (
    select
        departmentId,
        max(salary) as salary
    from Employee
    group by departmentId
)
select
    d.name as department,
    e.name as employee,
    ms.salary
from max_salaries ms
    inner join Employee e
        on ms.departmentId = e.departmentId and ms.salary = e.salary
    inner join Department d
        on ms.departmentId = d.id