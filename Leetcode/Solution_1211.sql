-- 1211. Queries Quality and Percentage
select
    query_name,
    round(
        sum(rating / position::decimal) / count(*),
        2) as quality,
    round(
        count(*) filter (where rating < 3) / count(*)::decimal * 100,
        2) as poor_query_percentage
from Queries
where query_name is not null
group by query_name
