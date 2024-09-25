
IF OBJECT_ID('AddParty', 'P') IS NOT NULL
BEGIN
	DROP PROCEDURE AddParty;
END;
GO

CREATE PROCEDURE AddParty
	@PartyId INT,
	@Name NVARCHAR(100),
	@Colour NVARCHAR(50)
AS
BEGIN
IF NOT EXISTS (SELECT 1 FROM Parties WHERE PartyId = @PartyId)
	BEGIN
		INSERT INTO Parties (PartyId, Name, Colour)
		VALUES (@PartyId, @Name, @Colour);
	END
END;
GO

