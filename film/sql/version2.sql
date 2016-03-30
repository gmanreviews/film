-- ================================================
USE [film]
GO
/****** Object:  StoredProcedure [dbo].[get_mamo_team]    Script Date: 29/3/2016 7:01:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_mamo_team]
	-- Add the parameters for the stored procedure here
	@team_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		mto.locked, u.id [user_id], p.id [person_id], p.first_name, p.last_name, my.id [year_id], my.mamo_year [year]
	FROM mamo_team_owner mto
		LEFT JOIN users u ON mto.[user_id] = u.id
		LEFT JOIN person p ON u.person_id = p.id
		LEFT JOIN mamo_years my ON mto.mamo_year_id = my.id
	WHERE mto.id = @team_id;
END
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE get_mamo_team_films
	-- Add the parameters for the stored procedure here
	@team_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		f.id, f.name, mt.box_office_total, mt.box_office_opening, f.release_date, mt.[rank] 
	FROM 
		mamo_team mt LEFT JOIN film f ON mt.film_id = f.id
	WHERE mt.team_id = @team_id
	ORDER BY mt.[rank];
END
GO

GO
/****** Object:  StoredProcedure [dbo].[all_posible_films_for_mamo_game]    Script Date: 29/3/2016 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[all_posible_films_for_mamo_game] 
	-- Add the parameters for the stored procedure here
	@team_id int,
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
	LEFT JOIN mamo_team mt ON f.id = mt.film_id
	WHERE my.id = @year AND MONTH(f.release_date) > 4 AND MONTH(f.release_date) < 9
	AND mt.film_id IS NULL
	ORDER BY release_date;
END