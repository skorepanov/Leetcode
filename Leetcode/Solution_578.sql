-- 578. Get Highest Answer Rate Question
with counts as (
    select
        question_id,
        sum(case when action = 'answer' then 1 else 0 end) as answer_count,
        sum(case when action = 'show' then 1 else 0 end) as show_count
    from SurveyLog
    group by question_id
)
select
    question_id as survey_log
from counts
order by
    answer_count::numeric / show_count desc,
    question_id asc
limit 1