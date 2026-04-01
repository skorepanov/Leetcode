-- 574. Winning Candidate
with max_vote_id as (
    select
        v.candidateId,
        count(*) as count
    from Vote v
    group by v.candidateId
    order by count desc
    limit 1
)
select
    c.name
from max_vote_id
    inner join Candidate c on max_vote_id.candidateId = c.id