use PAW_FinalProyect;

CREATE TABLE [Item] (
  [Id_Item] int,
  [Id_Status] int,
  [Id_SubCategory] int,
  [Description] varchar(100),
  [Picture] varchar(100),
  [Date] Datetime,
  [Comments] varchar(300),
  PRIMARY KEY ([Id_Item])
);

CREATE INDEX [FK] ON  [Item] ([Id_Status], [Id_SubCategory]);

CREATE TABLE [Category] (
  [Id_Category] int,
  [NameCategory] varchar(50),
  PRIMARY KEY ([Id_Category])
);

CREATE TABLE [LostReport] (
  [Id_Report] int,
  [Id_User] int,
  [Description] varchar(100),
  [Status] varchar(25),
  [Id_SubCategory] int,
  PRIMARY KEY ([Id_Report])
);

CREATE INDEX [FK] ON  [LostReport] ([Id_User], [Id_SubCategory]);

CREATE TABLE [SubCategory] (
  [Id_SubCategory] int,
  [NameSubCategory] varchar(50),
  [Id_Category] int,
  PRIMARY KEY ([Id_SubCategory])
);

CREATE INDEX [FK] ON  [SubCategory] ([Id_Category]);

CREATE TABLE [Usuario] (
  [Id_User] int,
  [Name] varchar(30),
  [Lastname] varchar(30),
  [ID_Number] varchar(25),
  [Email] varchar(100),
  [Id_UserType] int,
  [User] varchar(50),
  [Password] varchar(150),
  PRIMARY KEY ([Id_User])
);

CREATE INDEX [FK] ON  [Usuario] ([Id_UserType]);

CREATE TABLE [Status] (
  [Id_Status] int,
  [Name] varchar(50),
  PRIMARY KEY ([Id_Status])
);

CREATE TABLE [UserType] (
  [Id_UserType] int,
  [Name] varchar(50),
  PRIMARY KEY ([Id_UserType])
);

CREATE TABLE [Receipt] (
  [ID_receipt] int,
  [Id_User] int,
  [ItemID] int,
  [Date] datetime,
  PRIMARY KEY ([ID_receipt])
);

CREATE INDEX [FK] ON  [Receipt] ([Id_User], [ItemID]);

