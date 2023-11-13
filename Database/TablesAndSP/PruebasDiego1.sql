--CREATE TABLE tbl_Locations(
--    Id BIGINT PRIMARY KEY,
--	Fsq_Id NVARCHAR(MAX),
--    [Name] NVARCHAR(255),
--    Adress NVARCHAR(MAX),
--    Latitude NVARCHAR(255),
--    Longitude NVARCHAR(255)
--);

--GO

--CREATE TABLE tbl_Users (
--    Id BIGINT PRIMARY KEY IDENTITY,
--    [Name] NVARCHAR(255),
--    Email NVARCHAR(255) UNIQUE,
--    [Password] NVARCHAR(255),
--    UserName NVARCHAR(255) UNIQUE
--);

--GO

--CREATE TABLE tbl_UserLocations (
--    UserId BIGINT,
--    LocationId BIGINT,
--    FOREIGN KEY (UserId) REFERENCES tbl_Users(Id),
--    FOREIGN KEY (LocationId) REFERENCES tbl_Locations(Id)
--);


--CREATE PROCEDURE get_UserById
--    @Id INT
--AS
--BEGIN
--    SELECT * FROM tbl_Users WHERE Id = @Id
--END

--ALTER PROCEDURE get_UserByUserNameEmail
--    @UserNameOrEmail VARCHAR(255)
--AS
--BEGIN
--     SELECT *
--    FROM tbl_Users
--    WHERE UserName = @UserNameOrEmail OR Email = @UserNameOrEmail;
--END


--GO
--CREATE PROCEDURE get_AllUsers
--AS
--BEGIN
--    SELECT * FROM tbl_Users
--END

--GO

--ALTER PROCEDURE insert_User
--    @Name NVARCHAR(50),
--    @Email NVARCHAR(50),
--    @Password NVARCHAR(50),
--    @Username NVARCHAR(50)
--AS
--BEGIN
--    INSERT INTO tbl_Users(Name, Email, Password, Username)
--    VALUES (@Name, @Email, @Password, @Username)
--END

--GO

--CREATE PROCEDURE upd_User
--    @Id INT,
--    @Name NVARCHAR(50),
--    @Email NVARCHAR(50),
--    @Password NVARCHAR(50),
--    @Username NVARCHAR(50)
--AS
--BEGIN
--    UPDATE tbl_Users
--    SET Name = @Name, Email = @Email, Password = @Password, Username = @Username
--    WHERE Id = @Id
--END

--GO 

--CREATE PROCEDURE delete_User
--    @Id INT
--AS
--BEGIN
--    DELETE FROM tbl_Users
--    WHERE Id = @Id
--END
--GO
--ALTER PROCEDURE get_LocationById
--    @Id INT
--AS
--BEGIN
--    SELECT *
--    FROM tbl_Locations
--    WHERE Id = @Id;
--END
--GO
--ALTER PROCEDURE get_AllLocations
--AS
--BEGIN
--    SELECT *
--    FROM tbl_Locations;
--END

--CREATE PROCEDURE insert_Location
--    @Fsq_Id NVARCHAR(255),
--    @Name NVARCHAR(255),
--    @Adress NVARCHAR(255),
--    @Latitude NVARCHAR(50),
--    @Longitude NVARCHAR(50)
--AS
--BEGIN
--    INSERT INTO tbl_Locations (Fsq_Id, Name, Adress, Latitude, Longitude)
--    VALUES (@Fsq_Id, @Name, @Adress, @Latitude, @Longitude);
--END

--GO

--CREATE PROCEDURE upd_Location
--    @Id INT,
--    @Fsq_Id NVARCHAR(255),
--    @Name NVARCHAR(255),
--    @Adress NVARCHAR(255),
--    @Latitude NVARCHAR(50),
--    @Longitude NVARCHAR(50)
--AS
--BEGIN
--    UPDATE tbl_Locations
--    SET Fsq_Id = @Fsq_Id,
--        Name = @Name,
--        Adress = @Adress,
--        Latitude = @Latitude,
--        Longitude = @Longitude
--    WHERE Id = @Id;

--END

--CREATE PROCEDURE delete_Location
--    @Id INT
--AS
--BEGIN
--    DELETE FROM tbl_Locations
--    WHERE Id = @Id;

--END


--ALTER PROCEDURE get_UserByUserNameEmail
--    @UserNameOrEmail VARCHAR(255)
--AS
--BEGIN
--    SELECT *
--    FROM tbl_Users
--    WHERE UserName = @UserNameOrEmail OR Email = @UserNameOrEmail;
--END
