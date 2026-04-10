-- 612. Shortest Distance in a Plane
select
    min(round(sqrt(pow(p2.x - p1.x, 2) + pow(p2.y - p1.y, 2))::numeric, 2)) as shortest
from Point2D p1
    inner join Point2D p2 on p1.x != p2.x or p1.y != p2.y