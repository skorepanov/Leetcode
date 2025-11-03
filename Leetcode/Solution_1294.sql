-- 1294. Weather Type in Each Country
select
    c.country_name,
    case
        when avg(w.weather_state) <= 15 then 'Cold'
        when avg(w.weather_state) >= 25 then 'Hot'
        else 'Warm'
        end as weather_type
from Weather w
    inner join Countries c on w.country_id = c.country_id
where day between '20191101' and '20191130'
group by c.country_name
