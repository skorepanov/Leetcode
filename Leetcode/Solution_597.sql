-- 597. Friend Requests I: Overall Acceptance Rate
with requests as (
    select distinct
        sender_id,
        send_to_id
    from FriendRequest
), accepted as (
    select distinct
        requester_id,
        accepter_id
    from RequestAccepted
)
select
    case
        when (select count(*) from requests) = 0 then 0
        else
            round(
                cast((select count(*) from accepted) as decimal) / (select count(*) from requests),
                2)
    end as accept_rate