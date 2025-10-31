﻿-- 1667. Fix Names in a Table
select
    user_id,
    upper(left(name, 1)) || lower(right(name, length(name) - 1)) as name
from Users
order by user_id
