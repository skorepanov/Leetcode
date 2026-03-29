-- 2072. The Winner University
with new_york_count as (
    select
        count(*) as count
    from NewYork
    where score >= 90
),
california_count as (
    select
        count(*) as count
    from California
    where score >= 90
)
select
    case
        when new_york_count.count > california_count.count then 'New York University'
        when california_count.count > new_york_count.count then 'California University'
        else 'No Winner'
    end as winner
from new_york_count, california_count