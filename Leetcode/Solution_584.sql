-- 584. Find Customer Referee
select name
from customer
where coalesce(referee_id, 0) <> 2