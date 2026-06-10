-- 1454. Active Users
select distinct
    l1.id,
    a.name
from Logins l1
    inner join Logins l2 on l1.id = l2.id and l1.login_date + interval '1 day' = l2.login_date
    inner join Logins l3 on l1.id = l3.id and l2.login_date + interval '1 day' = l3.login_date
    inner join Logins l4 on l1.id = l4.id and l3.login_date + interval '1 day' = l4.login_date
    inner join Logins l5 on l1.id = l5.id and l4.login_date + interval '1 day' = l5.login_date
    inner join Accounts a on l1.id = a.id
order by l1.id