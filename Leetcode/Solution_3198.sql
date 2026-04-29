-- 3198. Find Cities in Each State
select
    state,
    string_agg(city, ', ' order by city) as cities
from cities
group by state
order by state