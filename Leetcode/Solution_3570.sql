-- 3570. Find Books with No Available Copies
with borrowed_books as (
    select
        book_id,
        count(record_id) as current_borrowers
    from borrowing_records
    where return_date is null
    group by book_id
)
select
    lb.book_id,
    lb.title,
    lb.author,
    lb.genre,
    lb.publication_year,
    bb.current_borrowers
from borrowed_books bb
    inner join library_books lb on bb.book_id = lb.book_id
where lb.total_copies = bb.current_borrowers
order by
    bb.current_borrowers desc,
    lb.title asc