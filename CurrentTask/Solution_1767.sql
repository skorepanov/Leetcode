-- 1767. Find the Subtasks That Did Not Execute
with recursive subtask_ids as (
    select 1 as id
        union all
    select
        id + 1
    from subtask_ids
    where id + 1 <= 20
)
select
    t.task_id,
    si.id as subtask_id
from subtask_ids si
    inner join Tasks t
        on si.id <= t.subtasks_count
    except
select
    task_id,
    subtask_id
from Executed