-- 1699. Number of Calls Between Two Persons

-- 3rd way - runtime 850 ms, beats 33.67%
select
    least(from_id, to_id) as person1,
    greatest(to_id, from_id) as person2,
    count(*) as call_count,
    sum(duration) as total_duration
from calls
group by person1, person2

-- 2nd way - runtime 662 ms, beats 72.36%
with filtered_calls as (
    select
        from_id as person1,
        to_id as person2,
        duration
    from calls
    where from_id < to_id
        union all
    select
        to_id as person1,
        from_id as person2,
        duration
    from calls
    where to_id < from_id
)
select
    person1,
    person2,
    count(*) as call_count,
    sum(duration) as total_duration
from filtered_calls
group by person1, person2

-- 1st way - runtime 1064 ms, beats 13.57%
with grouped_calls as (
    select
        from_id as person1,
        to_id as person2,
        count(*) as call_count,
        sum(duration) as total_duration
    from calls
    where from_id < to_id
    group by from_id, to_id
        union all
    select
        to_id as person1,
        from_id as person2,
        count(*) as call_count,
        sum(duration) as total_duration
    from calls
    where to_id < from_id
    group by to_id, from_id
)
select
    person1,
    person2,
    sum(call_count) as call_count,
    sum(total_duration) as total_duration
from grouped_calls
group by person1, person2
