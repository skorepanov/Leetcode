-- 608. Tree Node
select distinct
    parent.id,
    case
        when parent.p_id is null then 'Root'
        when child.id is null then 'Leaf'
        else 'Inner'
    end as type
from Tree parent
    left join Tree child on parent.id = child.p_id