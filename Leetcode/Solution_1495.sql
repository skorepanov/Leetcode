-- 1495. Friendly Movies Streamed Last Month
select distinct
    c.title
from content c
    inner join tvprogram p on c.content_id = p.content_id
where c.kids_content = 'Y'
    and c.content_type = 'Movies'
    and date_part('year', p.program_date) = 2020
    and date_part('month', p.program_date) = 6