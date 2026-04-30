-- 3465. Find Products with Valid Serial Numbers
select
    product_id,
    product_name,
    description
from products
where regexp_like(description, '( |^)SN\d{4}-\d{4}( |$)')
order by product_id