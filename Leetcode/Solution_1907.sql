﻿-- 1907. Count Salary Categories
select
    'Low Salary' as category,
    sum(case when income < 20000 then 1 else 0 end) as accounts_count
from Accounts
    union
select
    'Average Salary' as category,
    sum(case when income between 20000 and 50000 then 1 else 0 end) as accounts_count
from Accounts
    union
select
    'High Salary' as category,
    sum(case when income > 50000 then 1 else 0 end) as accounts_count
from Accounts
