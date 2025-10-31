-- 1341. Movie Rating
with user_with_greatest_number as (
    select
        u.name,
        count(mr.rating) as rating_count
    from MovieRating mr
        inner join Users u on mr.user_id = u.user_id
    group by u.name
    order by rating_count desc, u.name
    limit 1
), movie_with_highest_rating as (
    select
        m.title,
        avg(mr.rating) as avg_rating
    from MovieRating mr
        inner join Movies m on mr.movie_id = m.movie_id
    where mr.created_at between '20200201' and '20200229'
    group by m.title
    order by avg_rating desc, m.title
    limit 1
)
select
    name as results
from user_with_greatest_number
    union all
select
    title as results
from movie_with_highest_rating
