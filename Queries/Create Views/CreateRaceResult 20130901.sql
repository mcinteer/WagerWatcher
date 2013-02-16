USE [WagerWatcher]
GO

/****** Object:  View [dbo].[RaceResult]    Script Date: 9/01/2013 7:22:51 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[RaceResult] AS 
	SELECT Meeting.MeetingID, meeting.JetBetCode,Meeting.MDate, Race.RaceID, race.racenum   FROM Meeting, Race
	WHERE Meeting.MeetingID = race.MeetingID 
GO

