CREATE VIEW [dbo].[AnalyzedItems]
	AS SELECT	i.[Id]			[Id],
				i.[Icon]		[Icon],
				i.[Name]		[Name],
				COUNT(*)		[ReviewCount],
				AVG(r.[Rating])	[AverageRating],
				MIN(r.[Rating])	[LowestRating],
				MAX(r.[Rating])	[HighestRating]
	FROM [dbo].[Reviews] r
	RIGHT OUTER JOIN [dbo].[Items] i ON i.[Id] = r.[Reviewing]
	GROUP BY r.[Reviewing], i.[id], i.[Icon], i.[Name]