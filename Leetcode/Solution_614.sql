-- 614. Second Degree Follower
select
    f1.follower,
    count(distinct f2.follower) as num
from Follow f1
    inner join Follow f2 on f1.follower = f2.followee
group by f1.follower
order by f1.follower