-- 1543. Fix Product Name Format
with s as (
    select
        lower(trim(product_name)) as product_name,
        date_format(sale_date, '%Y-%m') as sale_date
    from Sales
)
select
    product_name,
    sale_date,
    count(*) as total
from s
group by product_name, sale_date
order by product_name, sale_date
