-- 177. Nth Highest Salary

-- Решение 1 - Runtime 213 ms, Beats 65.36%
CREATE OR REPLACE FUNCTION NthHighestSalary(N INT) RETURNS TABLE (Salary INT) AS $$
BEGIN
  RETURN QUERY (
    select distinct
        (case when N > 0 then e.salary end) as Salary
    from Employee e
    order by Salary desc
    limit 1 offset (case when N > 0 then N - 1 else 0 end)
  );
END;
$$ LANGUAGE plpgsql;

-- Решение 2 - Runtime 240 ms, Beats 27.10%
CREATE OR REPLACE FUNCTION NthHighestSalary(N INT) RETURNS TABLE (Salary INT) AS $$
BEGIN
  RETURN QUERY (
    select
        e2.salary
    from (
        select
            e1.salary,
            dense_rank() over (order by e1.salary desc) as rank
        from Employee e1
    ) as e2
    where e2.rank = N
    limit 1
  );
END;
$$ LANGUAGE plpgsql;
