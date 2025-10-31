-- 1517. Find Users With Valid E-Mails
select
    user_id,
    name,
    mail
from Users
where mail ~ '^[A-Za-z]{1,}[\w.-]{0,}@leetcode\.com$'
