-- 2504. Concatenate the Name and the Profession
select
    person_id,
    name || '(' || substring(profession, 1, 1) || ')' as name
from Person
order by person_id desc