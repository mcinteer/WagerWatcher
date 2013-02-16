USE [WagerWatcher]

BEGIN TRANSACTION
INSERT INTO [dbo].[BetType]
           ([BetTypeID]
           ,[BetTypeDesc]
		   ,[XmlDesc])
     VALUES
           ('25892e17-80f6-415f-9c65-7395632f0223', 'Win', 'WIN'),
		   ('a53e98e4-0197-4513-be6d-49836e406aaa', 'Place', 'PLC'),
		   ('e33898de-6302-4756-8f0c-5f6c5218e02e', 'Quenella', 'QLA'),
		   ('3a768eea-cbda-4926-a82d-831cb89092aa', 'Trifecta', 'TFA'),
		   ('cd171f7c-560d-4a62-8d65-16b87419a58c', 'First4', 'FT4')
--ROLLBACK
COMMIT
