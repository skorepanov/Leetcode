-- 2480. Form a Chemical Bond
select
    e1.symbol as metal,
    e2.symbol as nonmetal
from Elements e1
    inner join Elements e2
        on e1.type = 'Metal' and e2.type = 'Nonmetal'