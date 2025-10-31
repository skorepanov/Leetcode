-- 1607. Sellers With No Sales
select
    s.seller_name
from Seller s
    left join Orders o on s.seller_id = o.seller_id
        and date_part('year', o.sale_date) = 2020
where o.seller_id is null
order by s.seller_name
