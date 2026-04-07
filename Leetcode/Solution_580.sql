-- 580. Count Student Number in Departments

-- вариант 1 - Runtime 269 ms, Beats 23.31%
select
    d.dept_name,
    count(s.student_id) as student_number
from Department d
    left join Student s on d.dept_id = s.dept_id
group by d.dept_name
order by
    student_number desc,
    d.dept_name asc

-- вариант 2 - Runtime 290 ms, Beats 14.29%
with student_count as (
    select
        dept_id,
        count(*) as count
    from Student
    group by dept_id
)
select
    d.dept_name,
    coalesce(student_count.count, 0) as student_number
from Department d
    left join student_count on d.dept_id = student_count.dept_id
order by
    student_number desc,
    d.dept_name asc