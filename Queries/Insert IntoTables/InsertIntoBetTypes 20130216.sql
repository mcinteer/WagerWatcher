USE [WagerWatcher]

BEGIN TRANSACTION
INSERT INTO [dbo].[BetType]
           ([BetTypeID]
           ,[BetTypeDesc]
		   ,[XmlDesc])
     VALUES
           ('25892e17-80f6-415f-9c65-7395632f0223', 'Win', 'WIN'),
		   ('a53e98e4-0197-4513-be6d-49836e406aaa', 'Place', 'PLC'),
		   ('e33898de-6302-4756-8f0c-5f6c5218e02e', 'Quinella', 'QLA'),
		   ('3a768eea-cbda-4926-a82d-831cb89092aa', 'Trifecta', 'TFA'),
		   ('cd171f7c-560d-4a62-8d65-16b87419a58c', 'First4', 'FT4'),
		   ('30e7358a-dbe9-4335-98ce-da19d3c08f5e', 'Double', 'DBL'),
		   ('d16c941a-6915-472a-9e7b-8455703ecb65', 'Treble', 'TRB'),
		   ('5f38422b-e6f0-4965-b1fb-1287e0c1cf71', 'Quaddie', 'QAD'),
		   ('88c03276-53b4-4794-b20c-a05908655dac', 'Place Six', 'PL6'),
		   ('a0590276-53b4-4794-b20c-88c038655dac','Pick Six', 'PK6')

--ROLLBACK
COMMIT
