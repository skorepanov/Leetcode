-- 1587. Bank Account Summary II
select
    u.name,
    sum(t.amount) as balance
from transactions t
    inner join users u on t.account = u.account
group by u.name
having sum(t.amount) > 10000