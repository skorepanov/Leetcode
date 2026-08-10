-- 1613. Find the Missing IDs
with all_ids as (
    select
        ids
    from generate_series(
        1,
        (select
            max(customer_id)
        from Customers)
    ) as ids
)
select
    ids
from all_ids
    except
select
    customer_id
from Customers
order by ids