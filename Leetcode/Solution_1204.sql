-- 1204. Last Person to Fit in the Bus
with weights as (
    select
        person_id,
        person_name,
        sum(weight) over (order by turn) as sum
    from Queue
)
select
    person_name
from weights
where sum <= 1000
order by sum desc
limit 1
