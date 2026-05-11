-- 1205. Monthly Transactions II
with approved_and_chargeback as (
    select
        to_char(trans_date, 'YYYY-MM') as month,
        country,
        count(id) as approved_count,
        sum(amount) as approved_amount,
        0 as chargeback_count,
        0 as chargeback_amount
    from Transactions
    where state = 'approved'
    group by month, country
        union all
    select
        to_char(c.trans_date, 'YYYY-MM') as month,
        t.country,
        0 as approved_count,
        0 as approved_amount,
        count(t.id) as chargeback_count,
        sum(t.amount) as chargeback_amount
    from Transactions t
        inner join Chargebacks c on t.id = c.trans_id
    group by month, t.country
)
select
    month,
    country,
    sum(approved_count) as approved_count,
    sum(approved_amount) as approved_amount,
    sum(chargeback_count) as chargeback_count,
    sum(chargeback_amount) as chargeback_amount
from approved_and_chargeback
group by month, country