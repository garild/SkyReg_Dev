DECLARE @result bit = 0

IF db_id('DataBaseName') IS NOT NULL
BEGIN
	set @result = 0
END
ELSE
BEGIN
	CREATE DATABASE DataBaseName
	set @result = 1
END

SELECT @Result