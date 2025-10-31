-- 1112. Highest Grade For Each Student
select distinct on (student_id)
    student_id,
    course_id,
    grade
from Enrollments
order by student_id, grade desc, course_id
