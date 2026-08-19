-- 1843. Suspicious Bank Accounts
with incomes as (
    select
        t.account_id,
        date_trunc('month', t.day) as year_month,
        sum(t.amount) as amount_sum,
        a.max_income
    from Transactions t
        inner join Accounts a on t.account_id = a.account_id
    where t.type = 'Creditor'
    group by t.account_id, year_month, a.max_income
    having sum(t.amount) > a.max_income
)
select distinct
    i1.account_id
from incomes i1
    inner join incomes i2 on i1.account_id = i2.account_id
        and i1.year_month + interval '1 month' = i2.year_month