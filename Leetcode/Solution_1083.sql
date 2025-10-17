-- 1083. Sales Analysis II
select distinct
    s.buyer_id
from Sales s
    inner join Product p
        on s.product_id = p.product_id
where p.product_name = 'S8'
    except
select
    distinct s.buyer_id
from Sales s
    inner join Product p
        on s.product_id = p.product_id
where p.product_name = 'iPhone'
