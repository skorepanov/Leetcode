-- 181. Employees Earning More Than Their Managers
select
    subordinate.name as Employee
from Employee subordinate
    inner join Employee manager on subordinate.managerId = manager.id
where subordinate.salary > manager.salary
