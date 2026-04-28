-- 2990. Loan Types
select
    user_id
from Loans
where loan_type = 'Refinance'
    intersect
select
    user_id
from Loans
where loan_type = 'Mortgage'
order by user_id