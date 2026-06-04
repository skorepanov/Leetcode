-- 1364. Number of Trusted Contacts of a Customer
select
    i.invoice_id,
    c.customer_name,
    i.price,
    count(distinct cn.contact_name) as contacts_cnt,
    sum(case when cn.contact_email in (select email from customers) then 1 else 0 end) as trusted_contacts_cnt
from customers c
    inner join invoices i on c.customer_id = i.user_id
    left join contacts cn on c.customer_id = cn.user_id
group by i.invoice_id, c.customer_name, i.price
order by i.invoice_id