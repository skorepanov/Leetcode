-- 1098. Unpopular Books
select
    b.book_id,
    b.name
from Books b
    left join Orders o on b.book_id = o.book_id
        and o.dispatch_date between '20180623' and '20190623'
where b.available_from <= '20190523'
group by b.book_id, b.name
having coalesce(sum(o.quantity), 0) < 10