-- 3172. Second Day Verification
select
    e.user_id
from emails e
    inner join texts t on e.email_id = t.email_id
where t.signup_action = 'Verified'
    and (e.signup_date + interval '1 day')::date = t.action_date::date
order by e.user_id