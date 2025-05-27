-- 1741. Find Total Time Spent by Each Employee
select
    event_day as day,
    emp_id,
    sum(out_time - in_time) as total_time
from employees
group by day, emp_id