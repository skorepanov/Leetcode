-- 3436. Find Valid Emails
select
    user_id,
    email
from Users
where regexp_like(email, '^\w{1,}@[a-z_]{1,}\.com$')
order by user_id