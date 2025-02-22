-- 1511. Customer Order Frequency

-- 2nd way - runtime 315 ms, beats 84.58%
select
    c.customer_id,
    c.name
from customers c
    inner join orders o on c.customer_id = o.customer_id
    inner join product p on o.product_id = p.product_id
where date_part('year', o.order_date) = 2020
group by c.customer_id, c.name
having sum(p.price * case when date_part('month', o.order_date) = 6 then o.quantity end) >= 100
    and sum(p.price * case when date_part('month', o.order_date) = 7 then o.quantity end) >= 100

-- 1st way - my solution - has duplication - runtime 318 ms, beats 84.58%
select
    c.customer_id,
    c.name
from customers c
    inner join orders o on c.customer_id = o.customer_id
    inner join product p on o.product_id = p.product_id
where date_part('year', o.order_date) = 2020
    and date_part('month', o.order_date) = 6
group by c.customer_id, c.name
having sum(p.price * o.quantity) >= 100
    intersect
select
    c.customer_id,
    c.name
from customers c
    inner join orders o on c.customer_id = o.customer_id
    inner join product p on o.product_id = p.product_id
where date_part('year', o.order_date) = 2020
    and date_part('month', o.order_date) = 7
group by c.customer_id, c.name
having sum(p.price * o.quantity) >= 100