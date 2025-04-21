-- 1709. Biggest Window Between Visits
with visits as (
    select
        uv1.user_id,
        uv1.visit_date,
        (
            select
                coalesce(min(visit_date), '20210101')
            from UserVisits uv2
            where uv2.user_id = uv1.user_id
                and uv2.visit_date > uv1.visit_date
        ) as next_visit_date
    from UserVisits uv1
)
select
    user_id,
    max(next_visit_date - visit_date) as biggest_window
from visits
group by user_id