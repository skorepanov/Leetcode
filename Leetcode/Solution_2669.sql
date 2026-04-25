-- 2669. Count Artist Occurrences On Spotify Ranking List
select
    artist,
    count(*) as occurrences
from Spotify
group by artist
order by
    occurrences desc,
    artist asc