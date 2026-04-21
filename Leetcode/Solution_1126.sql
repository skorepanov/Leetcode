-- 1126. Active Businesses
with middle as (
    select
        event_type,
        avg(occurrences) as average
    from Events
    group by event_type
)
select
    e.business_id
from Events e
    inner join middle m on e.event_type = m.event_type
where e.occurrences > m.average
group by e.business_id
having count(*) > 1