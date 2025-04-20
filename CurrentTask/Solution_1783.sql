-- 1783. Grand Slam Titles

-- solution 2 - 365 ms, beats 71.49%
with player_wins as (
    select
        p.player_id
    from Players p
        inner join Championships c on p.player_id = c.wimbledon
        union all
    select
        p.player_id
    from Players p
        inner join Championships c on p.player_id = c.fr_open
        union all
    select
        p.player_id
    from Players p
        inner join Championships c on p.player_id = c.us_open
        union all
    select
        p.player_id
    from Players p
        inner join Championships c on p.player_id = c.au_open
)
select
    pw.player_id,
    p.player_name,
    count(pw.player_id) as grand_slams_count
from player_wins pw
    inner join Players p on pw.player_id = p.player_id
group by pw.player_id, p.player_name

-- solution 1 - 335 ms, beats 79.30 %
with player_wins as (
    select
        p.player_id,
        count(p.player_id) as count
    from Players p
        inner join Championships c on p.player_id = c.wimbledon
    group by p.player_id
        union all
    select
        p.player_id,
        count(p.player_id) as count
    from Players p
        inner join Championships c on p.player_id = c.fr_open
    group by p.player_id
        union all
    select
        p.player_id,
        count(p.player_id) as count
    from Players p
        inner join Championships c on p.player_id = c.us_open
    group by p.player_id
        union all
    select
        p.player_id,
        count(p.player_id) as count
    from Players p
        inner join Championships c on p.player_id = c.au_open
    group by p.player_id
)
select
    pw.player_id,
    p.player_name,
    sum(pw.count) as grand_slams_count
from player_wins pw
    inner join Players p on pw.player_id = p.player_id
group by pw.player_id, p.player_name