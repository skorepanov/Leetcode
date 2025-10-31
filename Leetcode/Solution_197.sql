-- 197. Rising Temperature
select w1.id
from Weather w1
    inner join Weather w2 on w2.recordDate = w1.recordDate - interval '1 day'
where w1.temperature > w2.temperature
