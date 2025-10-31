-- 1965. Employees With Missing Information
select
    coalesce(e.employee_id, s.employee_id) as employee_id
from Employees e
    full join Salaries s on e.employee_id = s.employee_id
where e.employee_id is null or s.employee_id is null
order by employee_id
