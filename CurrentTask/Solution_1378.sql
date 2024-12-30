-- 1378. Replace Employee ID With The Unique Identifier
select euni.unique_id, e.name
from Employees e
    left join EmployeeUNI euni on e.id = euni.id