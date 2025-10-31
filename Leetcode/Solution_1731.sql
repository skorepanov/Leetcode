-- 1731. The Number of Employees Which Report to Each Employee
select
    managers.employee_id,
    managers.name,
    count(subordinates.employee_id) as reports_count,
    round(avg(subordinates.age)) as average_age
from Employees managers
    inner join Employees subordinates on managers.employee_id = subordinates.reports_to
group by managers.employee_id, managers.name
order by managers.employee_id
