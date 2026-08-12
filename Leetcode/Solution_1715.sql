-- 1715. Count Apples and Oranges
select
    sum(b.apple_count + coalesce(c.apple_count, 0)) as apple_count,
    sum(b.orange_count + coalesce(c.orange_count, 0)) as orange_count
from Boxes b
    left join Chests c on b.chest_id = c.chest_id