-- 1084. Sales Analysis III

-- Вариант 1 - Runtime 1043 ms, Beats 29.93%
select
    product_id,
    product_name
from Product
where product_id in (
    select distinct
        product_id
    from Sales
    where sale_date between '20190101' and '20190331'
        except
    select
        product_id
    from Sales
    where sale_date < '20190101' or sale_date > '20190331'
)

-- Вариант 2 - Runtime 876 ms, Beats 83.92%
select distinct
    p.product_id,
    p.product_name
from Product p
    inner join Sales s
        on p.product_id = s.product_id
group by p.product_id, p.product_name
having min(s.sale_date) >= '20190101'
    and max(s.sale_date) <= '20190331'
