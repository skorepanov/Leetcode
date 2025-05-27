-- 1225. Report Contiguous Dates
with dates as (
    select
        fail_date as date,
        'failed' as period_state
    from Failed
    where fail_date between '20190101' and '20191231'
        union all
    select
        success_date as date,
        'succeeded' as period_state
    from Succeeded
    where success_date between '20190101' and '20191231'
), starts_and_ends as (
    select
        d1.period_state,
        d1.date as start_date,
        (
            select
                date(coalesce(
                    min(d2.date) - interval '1 day',
                    (select max(date) from dates)
                ))
            from dates d2
            where d1.date < d2.date and d1.period_state <> d2.period_state
        ) as end_date
    from dates d1
)
select
    period_state,
    min(start_date) as start_date,
    end_date
from starts_and_ends
group by period_state, end_date
order by start_date