-- 1501. Countries You Can Safely Invest In

-- 2nd way - runtime 813 ms, beats 63.09%
select
    country.name as country
from person
    inner join country on left(person.phone_number, 3) = country.country_code
    inner join calls on person.id in (calls.caller_id, calls.callee_id)
group by country.name
having avg(calls.duration) > (select avg(duration) from calls)

-- 1st way - runtime 700 ms, beats 78.54%
with calls_by_countries as (
    select
        country.name,
        calls.duration
    from calls
        inner join person on calls.caller_id = person.id
        inner join country on left(person.phone_number, 3) = country.country_code
        union all
    select
        country.name,
        calls.duration
    from calls
        inner join person on calls.callee_id = person.id
        inner join country on left(person.phone_number, 3) = country.country_code
), averages_by_countries as (
    select
        name,
        avg(duration) as avg_duration
    from calls_by_countries
    group by name
), total_average as (
    select avg(duration) as duration
    from calls
)
select
    avgs.name as country
from averages_by_countries avgs
    inner join total_average on 1 = 1
where avgs.avg_duration > total_average.duration