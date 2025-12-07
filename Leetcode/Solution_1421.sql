-- 1421. NPV Queries
select
    q.id,
    q.year,
    coalesce(npv.npv, 0) as npv
from queries q
    left join npv on q.id = npv.id and q.year = npv.year
