-- 1179. Reformat Department Table
select
    id,
    sum(revenue) filter (where month = 'Jan') as "Jan_Revenue",
    sum(revenue) filter (where month = 'Feb') as "Feb_Revenue",
    sum(revenue) filter (where month = 'Mar') as "Mar_Revenue",
    sum(revenue) filter (where month = 'Apr') as "Apr_Revenue",
    sum(revenue) filter (where month = 'May') as "May_Revenue",
    sum(revenue) filter (where month = 'Jun') as "Jun_Revenue",
    sum(revenue) filter (where month = 'Jul') as "Jul_Revenue",
    sum(revenue) filter (where month = 'Aug') as "Aug_Revenue",
    sum(revenue) filter (where month = 'Sep') as "Sep_Revenue",
    sum(revenue) filter (where month = 'Oct') as "Oct_Revenue",
    sum(revenue) filter (where month = 'Nov') as "Nov_Revenue",
    sum(revenue) filter (where month = 'Dec') as "Dec_Revenue"
from Department
group by id
