-- 1633. Percentage of Users Attended a Contest
select
    r.contest_id,
    round(count(*) / (select count(*) from Users)::decimal * 100, 2) as percentage
from Register r
group by r.contest_id
order by percentage desc, r.contest_id
