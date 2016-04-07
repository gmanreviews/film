ALTER TABLE users ADD subscribe_mail bit NOT NULL DEFAULT 1;

GO
CREATE PROCEDURE unsubscribe_from_emails
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE users SET subscribe_mail = 0 WHERE id = @user_id;
END
GO

GO
CREATE PROCEDURE subscribe_to_emails
	-- Add the parameters for the stored procedure here
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE users SET subscribe_mail = 1 WHERE id = @user_id;
END
GO

ALTER PROCEDURE [dbo].[get_user]
	-- Add the parameters for the stored procedure here
	@username varchar (50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM users where username = @username)
		SELECT u.id as [user_id], p.id as person_id, p.first_name, p.last_name, c.country_name, 
			   CAST (1 as bit) as result,  subscribe_mail [mail], email 
		FROM users u LEFT JOIN person p ON u.person_id = p.id
					 LEFT JOIN country c ON p.country_id = c.id
		WHERE username = @username;
	ELSE
		SELECT CAST (0 as bit) as result;
END

GO

CREATE PROCEDURE get_all_emails_subscribed 
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT email FROM users WHERE subscribe_mail = 1;
END
GO