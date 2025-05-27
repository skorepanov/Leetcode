-- 1747. Leetflex Banned Accounts
select distinct
    li1.account_id
from LogInfo li1
    inner join LogInfo li2
        on li1.account_id = li2.account_id
            and li1.ip_address <> li2.ip_address
            and li1.login between li2.login and li2.logout