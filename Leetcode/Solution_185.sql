-- 185. Department Top Three Salaries
with ranks as (
    select
        id,
        name as employee,
        salary,
        departmentId,
        dense_rank() over (partition by departmentId order by salary desc) as rank
    from Employee
)
select
    d.name as department,
    r.employee,
    r.salary
from ranks r
    inner join Department d on r.departmentId = d.id
where r.rank <= 3
