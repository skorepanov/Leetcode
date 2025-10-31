-- 1440. Evaluate Boolean Expression
select
    e.left_operand,
    e.operator,
    e.right_operand,
    case
        when (e.operator = '>' and v_left.value > v_right.value) then 'true'
        when (e.operator = '<' and v_left.value < v_right.value) then 'true'
        when (e.operator = '=' and v_left.value = v_right.value) then 'true'
        else 'false'
    end as value
from Expressions e
    inner join Variables v_left on e.left_operand = v_left.name
    inner join Variables v_right on e.right_operand = v_right.name
