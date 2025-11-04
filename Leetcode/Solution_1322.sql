-- 1322. Ads Performance
with counts as (
    select
        ad_id,
        count(*) filter (where action = 'Clicked') as clicked,
        count(*) filter (where action = 'Viewed') as viewed
    from Ads
    group by ad_id
)
select
    ad_id,
    case
        when (clicked + viewed) = 0 then 0
        else round((clicked::decimal / (clicked + viewed)) * 100, 2)
        end as ctr
from counts
order by ctr desc, ad_id asc
