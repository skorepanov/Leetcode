-- 1831. Maximum Transaction Each Day
with ranked_transactions as (
    select
        transaction_id,
        rank() over (partition by day order by amount desc) as rank
    from Transactions
    order by day, amount desc
)
select
    transaction_id
from ranked_transactions
where rank = 1
order by transaction_id