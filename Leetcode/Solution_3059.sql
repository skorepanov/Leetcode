-- 3059. Find All Unique Email Domains
select
    split_part(email, '@', 2) as email_domain,
    count(*) as count
from Emails
where email like '%.com'
group by email_domain
order by email_domain