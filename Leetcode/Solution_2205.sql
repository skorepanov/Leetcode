-- 2205. The Number of Users That Are Eligible for Discount
CREATE OR REPLACE FUNCTION getUserIDs(startDate DATE, endDate DATE, minAmount INT) RETURNS INT AS $$
BEGIN
  RETURN (
    select
        count(distinct user_id)
    from Purchases
    where time_stamp >= startDate
        and time_stamp between startDate and endDate
        and amount >= minAmount
  );
END;
$$ LANGUAGE plpgsql;