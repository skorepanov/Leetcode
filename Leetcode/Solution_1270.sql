-- 1270. All People Report to the Given Manager
with employees_to_manager as (
    select
        e.employee_id,
        manager1.employee_id as manager1_id,
        manager2.employee_id as manager2_id
    from Employees e
        inner join Employees manager1 on e.manager_id = manager1.employee_id
        inner join Employees manager2 on manager1.manager_id = manager2.employee_id
    where manager2.manager_id = 1
)
select
    employee_id
from employees_to_manager
    union
select
    manager1_id
from employees_to_manager
    union
select
    manager2_id
from employees_to_manager
    except
select 1