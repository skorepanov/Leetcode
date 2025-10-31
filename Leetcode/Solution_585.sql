-- 585. Investments in 2016
select
    round(sum(tiv_2016)::decimal, 2) as tiv_2016
from Insurance i1
where exists (
    select
        i2.tiv_2015
    from Insurance i2
    where i1.pid != i2.pid and i1.tiv_2015 = i2.tiv_2015
)
    and (i1.lat, i1.lon) not in (
        select
            i3.lat,
            i3.lon
        from Insurance i3
        where i1.pid != i3.pid
    )
