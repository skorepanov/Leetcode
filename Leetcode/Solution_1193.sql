-- 1193. Monthly Transactions I
select
    to_char(date_trunc('month', trans_date), 'YYYY-MM') as month,
    country,
    count(*) as trans_count,
    count(*) filter (where state = 'approved') as approved_count,
    sum(amount) as trans_total_amount,
    coalesce(sum(amount) filter (where state = 'approved'), 0) as approved_total_amount
from Transactions
group by month, country
