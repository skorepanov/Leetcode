-- 1412. Find the Quiet Students in All Exams
with ranked_students as (
    select
        student_id,
        rank() over (partition by exam_id order by score asc) as lowest_rank,
        rank() over (partition by exam_id order by score desc) as highest_rank
    from Exam
),
non_quite_student_ids as (
    select
        student_id
    from ranked_students
    where lowest_rank = 1 or highest_rank = 1
),
quite_student_ids as (
    select distinct
        student_id
    from Exam
        except
    select
        student_id
    from non_quite_student_ids
)
select
    s.student_id,
    s.student_name
from quite_student_ids qsi
    inner join Student s
        on qsi.student_id = s.student_id
order by qsi.student_id