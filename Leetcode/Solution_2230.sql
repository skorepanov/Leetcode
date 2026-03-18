-- 2230. The Users That Are Eligible for Discount
CREATE OR REPLACE FUNCTION getUserIDs(startDate DATE, endDate DATE, minAmount INT)
RETURNS TABLE (user_id INT) AS $$
BEGIN
  RETURN QUERY (
      select distinct
          p.user_id
      from Purchases p
      where time_stamp between startDate and endDate
          and amount >= minAmount
      order by p.user_id
  );
END;
$$ LANGUAGE plpgsql;