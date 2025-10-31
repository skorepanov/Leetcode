-- 1280. Students and Examinations
select
    st.student_id,
    st.student_name,
    sj.subject_name,
    count(*) filter (where e.student_id is not null) as attended_exams
from students st
    inner join subjects sj on true
    left join examinations e on st.student_id = e.student_id
        and sj.subject_name = e.subject_name
group by st.student_id, st.student_name, sj.subject_name
order by st.student_id, sj.subject_name
