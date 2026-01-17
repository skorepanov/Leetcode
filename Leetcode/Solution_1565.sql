-- 1565. Unique Orders and Customers Per Month
select
    to_char(order_date, 'YYYY-MM') as month,
    count(order_id) as order_count,
    count(distinct customer_id) as customer_count
from Orders
where invoice > 20
group by month
