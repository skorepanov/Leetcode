-- 1264. Page Recommendations
select distinct
    l.page_id as recommended_page
from Friendship f
    inner join Likes l on l.user_id in (f.user1_id, f.user2_id)
where f.user1_id = 1 or f.user2_id = 1
    except
select page_id
from Likes
where user_id = 1