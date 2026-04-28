-- 3150. Invalid Tweets II
select
    tweet_id
from Tweets
where length(content) > 140
    or regexp_count(content, '@') > 3
    or regexp_count(content, '#') > 3
order by tweet_id