-- 1978. Employees Whose Manager Left the Company
select
    subordinates.employee_id
from Employees subordinates
    left join Employees managers on subordinates.manager_id = managers.employee_id
where subordinates.manager_id is not null
    and subordinates.salary < 30000
    and managers.employee_id is null
order by subordinates.employee_id
