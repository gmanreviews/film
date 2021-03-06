USE [film]
GO
/****** Object:  Table [dbo].[country]    Script Date: 28/3/2016 7:54:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [varchar](50) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[film]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[film](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[release_month] [int] NULL,
	[box_office_total] [varchar](30) NULL,
	[box_office_opening] [varchar](30) NULL,
	[bo_mojo_slug] [varchar](100) NOT NULL,
	[release_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[bo_mojo_slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mamo_final_top_ten]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mamo_final_top_ten](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NOT NULL,
	[rank] [int] NOT NULL,
	[box_office_total] [varchar](30) NOT NULL,
	[box_office_opening] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[film_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[rank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mamo_team]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mamo_team](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NOT NULL,
	[rank] [int] NOT NULL,
	[box_office_opening] [varchar](30) NULL,
	[box_office_total] [varchar](30) NULL,
	[rank_point] [int] NULL,
	[five_mil_point] [bit] NULL,
	[ten_mil_point] [bit] NULL,
	[twenty_mil_point] [bit] NULL,
	[one_mil_opnening_point] [bit] NULL,
	[five_mil_opening_point] [bit] NULL,
	[ten_mil_opening_point] [bit] NULL,
	[rank_gross_opening] [bit] NULL,
	[team_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mamo_team_owner]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mamo_team_owner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[locked] [bit] NOT NULL DEFAULT ((0)),
	[mamo_year_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mamo_years]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mamo_years](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mamo_year] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[mamo_year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[person]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user_type]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_code] [varchar](5) NOT NULL,
	[type] [varchar](50) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[type_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[person_id] [int] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[user_type_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[mamo_final_top_ten]  WITH CHECK ADD FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[mamo_team]  WITH CHECK ADD FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[mamo_team]  WITH CHECK ADD  CONSTRAINT [fk_team_id] FOREIGN KEY([team_id])
REFERENCES [dbo].[mamo_team_owner] ([id])
GO
ALTER TABLE [dbo].[mamo_team] CHECK CONSTRAINT [fk_team_id]
GO
ALTER TABLE [dbo].[mamo_team_owner]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[mamo_team_owner]  WITH CHECK ADD  CONSTRAINT [fk_myid] FOREIGN KEY([mamo_year_id])
REFERENCES [dbo].[mamo_years] ([id])
GO
ALTER TABLE [dbo].[mamo_team_owner] CHECK CONSTRAINT [fk_myid]
GO
ALTER TABLE [dbo].[person]  WITH CHECK ADD FOREIGN KEY([country_id])
REFERENCES [dbo].[country] ([id])
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD FOREIGN KEY([person_id])
REFERENCES [dbo].[person] ([id])
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_utid] FOREIGN KEY([user_type_id])
REFERENCES [dbo].[user_type] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_utid]
GO
/****** Object:  StoredProcedure [dbo].[add_movie]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_movie]
	-- Add the parameters for the stored procedure here
	@film_name varchar(200),
	@bo_mojo_slug varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM film WHERE bo_mojo_slug = @bo_mojo_slug)
		SELECT id, CAST(1 as bit) as result FROM film WHERE bo_mojo_slug = @bo_mojo_slug;
	ELSE
	BEGIN
		INSERT INTO film (name, bo_mojo_slug) VALUES (@film_name, @bo_mojo_slug);
		SELECT @@IDENTITY as id, CAST(1 as bit) as result;
	END
END

GO
/****** Object:  StoredProcedure [dbo].[add_team_member]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_team_member]
	-- Add the parameters for the stored procedure here
	@team_id int,
	@film_id int,
	@rank int,
	@bo_open varchar(30),
	@bo_total varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO mamo_team (team_id, film_id, [rank], box_office_opening, box_office_total)
	VALUES (@team_id, @film_id, @rank, @bo_open, @bo_total);

END

GO
/****** Object:  StoredProcedure [dbo].[all_posible_films_for_mamo_game]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[all_posible_films_for_mamo_game] 
	-- Add the parameters for the stored procedure here
	@year int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT f.id, f.name FROM 
	film f LEFT JOIN 
	mamo_years my ON YEAR(f.release_date) = CAST(my.mamo_year as int)
	WHERE my.id = 1 AND MONTH(f.release_date) > 4 AND MONTH(f.release_date) < 9
	ORDER BY release_date;
END

GO
/****** Object:  StoredProcedure [dbo].[am_i_playing]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[am_i_playing]
	@user_id int,
	@year int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM mamo_team_owner mo LEFT JOIN mamo_years my ON mo.mamo_year_id = my.id WHERE mo.[user_id] = @user_id AND my.mamo_year = CAST(@year as varchar(10)))
		SELECT CAST (1 as bit) as result;
	ELSE
		SELECT CAST (0 as bit) as result;
END

GO
/****** Object:  StoredProcedure [dbo].[are_there_past_games]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[are_there_past_games]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT (CASE WHEN COUNT(*) > 0 THEN CAST (1 as bit) ELSE CAST (0 as bit) END) as result
	FROM mamo_years WHERE CAST(mamo_year as int) < YEAR(CURRENT_TIMESTAMP);
END

GO
/****** Object:  StoredProcedure [dbo].[create_country]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_country]
	-- Add the parameters for the stored procedure here
	@country varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @result int;
	SELECT @result = id FROM country WHERE country_name = @country;
	IF (@result IS NULL)
	BEGIN
		INSERT INTO country (country_name) VALUES (@country);
		SELECT @result = @@IDENTITY;
	END

	SELECT @result as result;

END



GO
/****** Object:  StoredProcedure [dbo].[create_person]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_person]
	-- Add the parameters for the stored procedure here
	@first_name varchar(50),
	@last_name varchar(50),
	@country_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @result int;
	IF (SELECT COUNT(*) FROM person WHERE first_name = @first_name AND last_name = @last_name) = 0
	BEGIN
		INSERT INTO person (first_name, last_name, country_id) VALUES (@first_name, @last_name, @country_id);
		SELECT @result = @@IDENTITY;
	END
	ELSE
	BEGIN
		SELECT @result = id FROM person WHERE first_name = @first_name AND last_name = @last_name;
	END

	SELECT @result as result;
END



GO
/****** Object:  StoredProcedure [dbo].[create_post_category]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_post_category]
	-- Add the parameters for the stored procedure here
	@post_category varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM post_category WHERE post_category = @post_category)
		SELECT CAST(0 as bit) result;
	ELSE
	BEGIN
		INSERT INTO post_category (post_category) VALUES (@post_category);
		SELECT @@IDENTITY as id, CAST (1 as bit) as result;
	END

END



GO
/****** Object:  StoredProcedure [dbo].[create_team]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_team]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@year varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT * FROM mamo_team_owner WHERE [user_id] = @user_id AND mamo_year_id = (SELECT id FROM mamo_years WHERE mamo_year = @year))
	BEGIN
		INSERT INTO mamo_team_owner([user_id],mamo_year_id)
		VALUES (@user_id, (SELECT id FROM mamo_years WHERE mamo_year = @year));

		SELECT @@IDENTITY as id;
	END
	ELSE
	BEGIN
		SELECT id FROM mamo_team_owner WHERE [user_id] = @user_id AND mamo_year_id = (SELECT id FROM mamo_years WHERE mamo_year = @year)
	END

END

GO
/****** Object:  StoredProcedure [dbo].[create_user]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_user]
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@password varchar(50),
	@email varchar(100),
	@person_id int,
	@user_type_id int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @success bit, @result int;
	IF EXISTS(SELECT * FROM users WHERE username = @username)
	BEGIN
		SET @success = 0;
		SELECT @result = id FROM users WHERE username = @username;
	END
	ELSE
	BEGIN
		INSERT INTO users (username, [password], person_id, email, user_type_id) 
		VALUES (@username, @password, @person_id, @email, CASE WHEN @user_type_id <> 0 THEN @user_type_id ELSE (SELECT id FROM user_type WHERE [type] = 'user') END);
		SELECT @result = @@IDENTITY;
		SET @success = 1;
	END

	SELECT CAST (@success as bit) as success, @result as result;

END



GO
/****** Object:  StoredProcedure [dbo].[get_all_user_types]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_all_user_types]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, type_code, [type] as [type_desc]
	FROM user_type;

END



GO
/****** Object:  StoredProcedure [dbo].[get_current_game]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_current_game] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 id, mamo_year FROM mamo_years ORDER BY CAST(mamo_year as int) desc;
END

GO
/****** Object:  StoredProcedure [dbo].[get_hashed_password]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_hashed_password]
	-- Add the parameters for the stored procedure here
	@username varchar (50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM users where username = @username)
		SELECT [password], CAST (1 as bit) as result FROM users WHERE username = @username;
	ELSE
		SELECT CAST (0 as bit) as result;
END

GO
/****** Object:  StoredProcedure [dbo].[get_mamo_team_member]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_mamo_team_member]
	-- Add the parameters for the stored procedure here
	@mt_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT mt.[rank], mt.box_office_opening, mt.box_office_total, f.name, f.id as film_id
	FROM mamo_team mt
	LEFT JOIN film f ON mt.film_id = f.id
	WHERE mt.id = @mt_id;

END

GO
/****** Object:  StoredProcedure [dbo].[get_mamo_top_ten]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_mamo_top_ten]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	f.id, f.name, f.box_office_total, f.release_date, m.[rank]
	FROM 
	mamo_final_top_ten m 
	INNER JOIN film f ON m.film_id = f.id
	ORDER BY m.[rank];
			
END

GO
/****** Object:  StoredProcedure [dbo].[get_movie_on_slug]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_movie_on_slug]
	-- Add the parameters for the stored procedure here
	@bo_slug varchar (100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id FROM film WHERE bo_mojo_slug = @bo_slug;
END

GO
/****** Object:  StoredProcedure [dbo].[get_player_mamo_team]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_player_mamo_team]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@year_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT mt.[rank], mt.film_id as id, f.name, mt.box_office_total, mt.box_office_opening, mo.locked as lock, f.release_date
	FROM mamo_team_owner mo LEFT JOIN mamo_team mt ON mo.id = mt.team_id
							LEFT JOIN film f ON mt.film_id = f.id
	WHERE mo.[user_id] = @user_id and mo.mamo_year_id = @year_id;
END

GO
/****** Object:  StoredProcedure [dbo].[get_post_categories]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_post_categories]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT id, post_category as category
	FROM post_category;
END



GO
/****** Object:  StoredProcedure [dbo].[get_user]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_user]
	-- Add the parameters for the stored procedure here
	@username varchar (50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM users where username = @username)
		SELECT u.id as [user_id], p.id as person_id, p.first_name, p.last_name, c.country_name, CAST (1 as bit) as result 
		FROM users u LEFT JOIN person p ON u.person_id = p.id
					 LEFT JOIN country c ON p.country_id = c.id
		WHERE username = @username;
	ELSE
		SELECT CAST (0 as bit) as result;
END

GO
/****** Object:  StoredProcedure [dbo].[get_user_password]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_user_password] 
	-- Add the parameters for the stored procedure here
	@id int,
	@username varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [password], CASE WHEN @@ROWCOUNT = 1 THEN 1 ELSE 0 END [success]
	FROM users WHERE (username = @username OR @username is null) AND (id = @id OR id is null);
END



GO
/****** Object:  StoredProcedure [dbo].[get_years]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_years]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, mamo_year as [year]
	FROM mamo_years ORDER BY CAST(mamo_year as int) DESC;
END

GO
/****** Object:  StoredProcedure [dbo].[is_team_submitted]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[is_team_submitted]
	-- Add the parameters for the stored procedure here
	@team_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT locked as submitted FROM mamo_team_owner where id = @team_id;

END

GO
/****** Object:  StoredProcedure [dbo].[is_there_a_game_this_year]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[is_there_a_game_this_year]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT (CASE WHEN COUNT(*) = 1 THEN CAST (1 as bit) ELSE CAST (0 as bit) END) as result
	FROM mamo_years WHERE mamo_year = YEAR(CURRENT_TIMESTAMP);
END

GO
/****** Object:  StoredProcedure [dbo].[mamo_team_point_break_down]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[mamo_team_point_break_down]
	-- Add the parameters for the stored procedure here
	@user_id int,
	@year_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		(mftt.[rank] - mt.[rank]) as [rank_point_diff],
		mftt.box_office_total [actual_gross_total],
		mt.box_office_total [predicted_total],
		mftt.box_office_opening [actual_opening],
		mt.box_office_opening [predicted_opening],
		f.id [film_id],
		f.name [film_name]
	FROM mamo_team mt
		LEFT JOIN mamo_team_owner mto ON mt.team_id = mto.id
		LEFT JOIN mamo_final_top_ten mftt ON mt.film_id = mftt.film_id
		LEFT JOIN film f ON mt.film_id = f.id
	WHERE mto.[user_id] = @user_id AND mto.mamo_year_id = @year_id;
END

GO
/****** Object:  StoredProcedure [dbo].[scoreboard]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[scoreboard]
	-- Add the parameters for the stored procedure here
	@year_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT 
		p.first_name, 
		p.last_name, 
		mt.team_id, 
		u.id as [user_id],
		SUM(
		(CASE WHEN ((((mftt.box_office_opening/1000000) - mt.box_office_opening) <= 5) AND (mt.box_office_opening - (mftt.box_office_opening/1000000)) <= 5) THEN 16
		      WHEN ((((mftt.box_office_opening/1000000) - mt.box_office_opening) <= 10) AND ((mt.box_office_opening - (mftt.box_office_opening/1000000)) <= 10)) THEN 6
			  WHEN (((mftt.box_office_opening/1000000) - mt.box_office_opening) <= 20 AND ((mt.box_office_opening - (mftt.box_office_opening/1000000)) <= 20)) THEN 1
			  ELSE 0 
		END)
		) +
		SUM(
		(CASE WHEN ((((mftt.box_office_total/1000000) - mt.box_office_total) <= 1) AND (mt.box_office_total - (mftt.box_office_total/1000000)) <= 1) THEN 16
		      WHEN ((((mftt.box_office_total/1000000) - mt.box_office_total) <= 5) AND ((mt.box_office_total - (mftt.box_office_total/1000000)) <= 5)) THEN 6
			  WHEN (((mftt.box_office_total/1000000) - mt.box_office_total) <= 20 AND ((mt.box_office_total - (mftt.box_office_total/1000000)) <= 10)) THEN 1
			  ELSE 0 
		END)) +
		SUM(
		(CASE WHEN (mftt.[rank] - mt.[rank]) > 10 OR (mt.[rank] - mftt.[rank]) > 10 THEN 0
			  WHEN (mftt.[rank] - mt.[rank]) > 0 THEN 10 - (mftt.[rank] - mt.[rank])
			  ELSE 10 - (mt.[rank] - mftt.[rank])
		END)) +
		SUM(
		(CASE WHEN (mt.[rank] = mftt.[rank]) AND 
				   ((((mftt.box_office_total/1000000) - mt.box_office_total) <= 1) AND (mt.box_office_total - (mftt.box_office_total/1000000)) <= 1) AND
				   ((((mftt.box_office_opening/1000000) - mt.box_office_opening) <= 5) AND (mt.box_office_opening - (mftt.box_office_opening/1000000)) <= 5)
		      THEN 10
			  ELSE 0 END))
				  		 as total_points
	FROM mamo_team mt
		LEFT JOIN mamo_team_owner mto ON mt.team_id = mto.id
		LEFT JOIN users u ON mto.[user_id] = u.id
		LEFT JOIN person p ON u.person_id = p.id
		LEFT JOIN mamo_final_top_ten mftt ON mt.film_id = mftt.film_id
	WHERE mto.mamo_year_id = @year_id
	GROUP BY p.first_name, p.last_name, mt.team_id, u.id
	; 
END

GO
/****** Object:  StoredProcedure [dbo].[submit_team]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[submit_team]
	-- Add the parameters for the stored procedure here
	@team_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE mamo_team_owner
	SET locked = 1
	WHERE id = @team_id;

END

GO
/****** Object:  StoredProcedure [dbo].[update_bo_data]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_bo_data]
	-- Add the parameters for the stored procedure here
	@film_id int,
	@film_release_month int,
	@film_release_date date,
	@film_name varchar(200),
	@film_bo_total varchar(30),
	@film_bo_opening varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM film WHERE id = @film_id)
		UPDATE film 
		SET release_month = @film_release_month,
			release_date = @film_release_date,
			name = @film_name,
			box_office_total = @film_bo_total,
			box_office_opening = @film_bo_opening
		WHERE id = @film_id;
			
END

GO
/****** Object:  StoredProcedure [dbo].[update_mamo_top_ten]    Script Date: 28/3/2016 7:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_mamo_top_ten]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE mamo_final_top_ten;

	INSERT INTO mamo_final_top_ten ([rank],film_id, box_office_total, box_office_opening)
	SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 100)) as [rank], id, box_office_total, box_office_opening FROM film 
	--WHERE release_month > 4 AND release_month < 9
	ORDER BY CAST(box_office_total as int) DESC;
			
END

GO
