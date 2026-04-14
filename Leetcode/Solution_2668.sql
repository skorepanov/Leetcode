-- 2668. Find Latest Salaries
select distinct on (emp_id)
    emp_id,
    firstname,
    lastname,
    salary,
    department_id
from Salary
order by
    emp_id asc,
    salary desc