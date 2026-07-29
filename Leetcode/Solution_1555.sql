-- 1555. Bank Account Summary
with outcome as (
    select
        paid_by as user_id,
        sum(amount) as amount
    from Transactions
    group by paid_by
), income as (
    select
        paid_to as user_id,
        sum(amount) as amount
    from Transactions
    group by paid_to
)
select
    u.user_id,
    u.user_name,
    u.credit - coalesce(o.amount, 0) + coalesce(i.amount, 0) as credit,
    case when u.credit - coalesce(o.amount, 0) + coalesce(i.amount, 0) < 0 then 'Yes' else 'No' end
        as credit_limit_breached
from Users u
    left join outcome o on u.user_id = o.user_id
    left join income i on u.user_id = i.user_id