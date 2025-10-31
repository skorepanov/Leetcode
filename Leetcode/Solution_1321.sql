-- 1321. Restaurant Growth
select
    c1.visited_on,
    (
        select
            sum(amount) as sum_amount
        from Customer c2
        where visited_on between (c1.visited_on + interval '-6 day') and c1.visited_on
    ) as amount,
    round((
        select
            sum(amount) / 7::decimal as average_amount
        from Customer c2
        where visited_on between (c1.visited_on + interval '-6 day') and c1.visited_on
    ), 2) as average_amount
from Customer c1
where c1.visited_on >= (
    select
        min(visited_on) + interval '6 days'
    from Customer c2
)
group by visited_on
order by visited_on
