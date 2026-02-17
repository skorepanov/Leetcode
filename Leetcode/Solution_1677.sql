-- 1677. Product's Worth Over Invoices
select
    p.name,
    coalesce(sum(rest), 0) as rest,
    coalesce(sum(paid), 0) as paid,
    coalesce(sum(canceled), 0) as canceled,
    coalesce(sum(refunded), 0) as refunded
from Product p
    left join Invoice i on p.product_id = i.product_id
group by p.name
order by p.name