-- 1853. Convert Date Format

-- вариант 1
-- Runtime 269 ms, Beats 45.16%
select
    to_char(day, 'FMDay')
        || ', '
        || to_char(day, 'FMMonth')
        || ' '
        || extract(day from day)::varchar
        || ', '
        || extract(year from day) as day
from Days

-- вариант 2
-- Runtime 298 ms, Beats 22.58%
select
    to_char(day, 'FMDay, FMMonth FMDD, YYYY') as day
from Days
