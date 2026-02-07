-- 1939. Users That Actively Request Confirmation Messages
select distinct
    c1.user_id
from Confirmations c1
    inner join Confirmations c2
        on c1.user_id = c2.user_id and c1.time_stamp <> c2.time_stamp
where abs(extract(epoch from c1.time_stamp) - extract(epoch from c2.time_stamp)) <= 60*60*24
