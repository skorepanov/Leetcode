-- 3051. Find Candidates for Data Scientist Position
select
    candidate_id
from Candidates
where skill in ('Python', 'Tableau', 'PostgreSQL')
group by candidate_id
having count(skill) = 3
order by candidate_id