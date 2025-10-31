-- 1934. Confirmation Rate
select
    s.user_id,
    round(coalesce(conf_confs.count, 0)::decimal / coalesce(all_confs.count, 1)::decimal, 2) as confirmation_rate
from Signups s
    left join (
        select
            user_id,
            count(*) as count
        from Confirmations
        group by user_id
    ) as all_confs on s.user_id = all_confs.user_id
    left join (
        select
            user_id,
            count(*) as count
        from Confirmations
        where action = 'confirmed'
        group by user_id
    ) as conf_confs on s.user_id = conf_confs.user_id
