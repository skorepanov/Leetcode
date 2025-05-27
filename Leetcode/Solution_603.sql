-- 603. Consecutive Available Seats

-- 2nd way - runtime 493 ms, beats 19.86%
select distinct
    c1.seat_id
from Cinema c1
    inner join Cinema c2 on c1.seat_id in (c2.seat_id - 1, c2.seat_id + 1)
where c1.free = 1 and c2.free = 1
order by c1.seat_id

-- 1st way - runtime 344 ms, beats 55.60%
select
    c1.seat_id
from Cinema c1
    left join Cinema c2 on c1.seat_id = c2.seat_id - 1
    left join Cinema c3 on c1.seat_id = c3.seat_id + 1
where c1.free = 1
    and (c2.free = 1 or c3.free = 1)
order by c1.seat_id