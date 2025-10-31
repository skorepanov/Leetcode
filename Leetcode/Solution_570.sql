-- 570. Managers with at Least 5 Direct Reports
select name
from Employee
where id in (
    select managerId
    from Employee
    where managerId is not null
    group by managerId
    having count(*) >= 5
)
