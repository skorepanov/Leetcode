-- 1445. Apples & Oranges

-- 2 вариант - без CTE
select
    apples.sale_date,
    sum(apples.sold_num - oranges.sold_num) as diff
from sales apples
         left join sales oranges on apples.sale_date = oranges.sale_date
where apples.fruit = 'apples' and oranges.fruit = 'oranges'
group by apples.sale_date
order by apples.sale_date

-- 1 вариант - с CTE
/*
with sales_by_date as (
    select sale_date, fruit, sum(sold_num) as sold_num
    from sales
    group by sale_date, fruit
)
select
    apples.sale_date,
    apples.sold_num - oranges.sold_num as diff
from sales_by_date apples
    left join sales_by_date oranges
        on apples.sale_date = oranges.sale_date and oranges.fruit = 'oranges'
where apples.fruit = 'apples'
order by apples.sale_date
*/