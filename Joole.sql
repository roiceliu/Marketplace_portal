CREATE DATABASE [Joole];
GO

USE [Joole]

DROP TABLE [dbo].[tblUser]
GO
DROP TABLE [dbo].[tblManufacturer]
GO
DROP TABLE [dbo].[tblProperty]
GO
DROP TABLE [dbo].[tblProduct]
GO
DROP TABLE [dbo].[tblPropertyValue]
GO
DROP TABLE [dbo].[tblTypeFilter]
GO
DROP TABLE [dbo].[tblTechSpecsFilter]
GO
DROP TABLE [dbo].[tblDepartment]
GO
DROP TABLE [dbo].[tblSubCategory]
GO

/****** Object:  Table [dbo].[tblUser]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [varchar](100) NOT NULL,
	[UserPassword] [varchar](100) NOT NULL,
	[UserName] [varchar](100)  NOT NULL,
	[UserProfileImage] [varchar](100)  NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON
INSERT [dbo].[tblUser] ([UserID], [UserEmail], [UserPassword], [UserName], [UserProfileImage]) VALUES (1, N'admin@email.com', N'admin', N'admin', NULL)
SET IDENTITY_INSERT [dbo].[tblUser] OFF



/****** Object:  Table [dbo].[tblManufacturer]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblManufacturer](
	[ManufacturerID] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblManufacturer] PRIMARY KEY CLUSTERED 
(
	[ManufacturerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblManufacturer] ON
INSERT [dbo].[tblManufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (1, N'BigAss')
INSERT [dbo].[tblManufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (2, N'DKCars')
/**INSERT [dbo].[tblManufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (3, N'Emerson')
INSERT [dbo].[tblManufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (4, N'Crompton')
**/
SET IDENTITY_INSERT [dbo].[tblManufacturer] OFF



/****** Object:  Table [dbo].[tblDepartment]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerID] [int] FOREIGN KEY REFERENCES tblManufacturer(ManufacturerID),
	[DepartmentName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED  
(
	[DepartmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/**!!!!!!!why manufacturing id is associated with department id. 1 department has only 1 manufacturer? **/
SET IDENTITY_INSERT [dbo].[tblDepartment] ON
INSERT [dbo].[tblDepartment] ([DepartmentID], [ManufacturerID], [DepartmentName]) VALUES (1,1, N'Electrical')
INSERT [dbo].[tblDepartment] ([DepartmentID], [ManufacturerID], [DepartmentName]) VALUES (2,2, N'Cars')
--INSERT [dbo].[tblDepartment] ([DepartmentID], [ManufacturerID], [DepartmentName]) VALUES (3,3, N'Electrical')
--INSERT [dbo].[tblDepartment] ([DepartmentID], [ManufacturerID], [DepartmentName]) VALUES (4,4, N'Electrical')
 
SET IDENTITY_INSERT [dbo].[tblDepartment] OFF


/****** Object:  Table [dbo].[tblSubCategory]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSubcategory](
	[SubcategoryID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] FOREIGN KEY REFERENCES tblDepartment(DepartmentID),
	[SubcategoryName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblSubcategory] PRIMARY KEY CLUSTERED  
(
	[SubcategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
--!!!added several subcategories under 1 department
SET IDENTITY_INSERT [dbo].[tblSubcategory] ON
INSERT [dbo].[tblSubcategory] ([SubcategoryID],[DepartmentID], [SubcategoryName]) VALUES (1,1, N'Fans')
INSERT [dbo].[tblSubcategory] ([SubcategoryID],[DepartmentID], [SubcategoryName]) VALUES (2,1, N'Light')
INSERT [dbo].[tblSubcategory] ([SubcategoryID],[DepartmentID], [SubcategoryName]) VALUES (3,2, N'Sports')
INSERT [dbo].[tblSubcategory] ([SubcategoryID],[DepartmentID], [SubcategoryName]) VALUES (4,2, N'Commute')

SET IDENTITY_INSERT [dbo].[tblSubcategory] OFF

/****** Object:  Table [dbo].[tblProduct]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerID] [int] FOREIGN KEY REFERENCES tblManufacturer(ManufacturerID),
	[SubcategoryID] [int] FOREIGN KEY REFERENCES tblSubcategory(SubcategoryID),
	[ProductName] [varchar](100) NOT NULL,
	[ProductImage] [varchar](100) NULL,
	[Model] [varchar](100) NOT NULL,
	[Series] [varchar](100) NOT NULL,
	[ModelYear] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED  
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

--!!!!!!!!!add 4 products under 1 subcategory for comparison!!!!!!!!!!
SET IDENTITY_INSERT [dbo].[tblProduct] ON
INSERT [dbo].[tblProduct] ([ProductID],[ManufacturerID], [SubcategoryID], [ProductName],[ProductImage],[Model],[Series],[ModelYear]) VALUES (1,1,1, N'Haiku Fan_1',NULL,'S3-150-S0-BC-04-01-C-01','Haiku H','2016')
INSERT [dbo].[tblProduct] ([ProductID],[ManufacturerID], [SubcategoryID], [ProductName],[ProductImage],[Model],[Series],[ModelYear]) VALUES (2,2,1, N'DK Car_1',NULL,'OR-147-SA-B8','OffRoad','2016')
INSERT [dbo].[tblProduct] ([ProductID],[ManufacturerID], [SubcategoryID], [ProductName],[ProductImage],[Model],[Series],[ModelYear]) VALUES (3,2,1, N'Luray Fan_1',NULL,'CF860','Luray Eco','2014')
INSERT [dbo].[tblProduct] ([ProductID],[ManufacturerID], [SubcategoryID], [ProductName],[ProductImage],[Model],[Series],[ModelYear]) VALUES (4,2,1, N'Compton Fan_1',NULL,'CF987','Larn T','2015')
--INSERT [dbo].[tblProduct] ([ProductID],[ManufacturerID], [SubcategoryID], [ProductName],[ProductImage],[Model],[Series],[ModelYear]) VALUES (5,1,2, N'DK Car',NULL,'OR-147-SA-B8','OffRoad','2016')
--INSERT [dbo].[tblProduct] ([ProductID],[ManufacturerID], [SubcategoryID], [ProductName],[ProductImage],[Model],[Series],[ModelYear]) VALUES (6,2,3, N'Luray Fan',NULL,'CF860','Luray Eco','2014')
--INSERT [dbo].[tblProduct] ([ProductID],[ManufacturerID], [SubcategoryID], [ProductName],[ProductImage],[Model],[Series],[ModelYear]) VALUES (7,2,4, N'Compton Fan',NULL,'CF987','Larn T','2015')
SET IDENTITY_INSERT [dbo].[tblProduct] OFF

/****** Object:  Table [dbo].[tblProperty]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProperty](
	[PropertyID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyName] [varchar](100) NULL,
	[IsType] int NOT NULL,
	[IsTechSpec] int NOT NULL,

 CONSTRAINT [PK_tblProperty] PRIMARY KEY CLUSTERED  
(
	[PropertyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblProperty] ON
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (1, N'Use Type', 1, 0)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (2, N'Application', 1, 0)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (3, N'Mounting Location', 1, 0)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (4, N'Accessories', 1, 0)

INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (5, N'Air Flow', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (6, N'Power', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (7, N'Operating Vol', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (8, N'Fan Speed', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (9, N'Number of Fan Speeds', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (10, N'Sound at Max Speed', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (11, N'Fan Sweep Diameter', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (12, N'Height', 0, 1)
INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (13, N'Weight', 0, 1)

--!!!!! might add too much extra UI to our project? !!!!!!!!!!!!!!!!!!!!!!!!!!!!
--INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (14, N'MPG', 0, 1)
--INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (15, N'Fuel Tank', 0, 1)
--INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (16, N'Trunk Space', 0, 1)
--INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (17, N'Safety Rating', 0, 1)
--INSERT [dbo].[tblProperty] ([PropertyID],[PropertyName],[IsType],[IsTechSpec]) VALUES (18, N'Towing Strength', 0, 1)

SET IDENTITY_INSERT [dbo].[tblProperty] OFF



/****** Object:  Table [dbo].[tblPropertyValue]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPropertyValue](
	[PropertyID] [int] FOREIGN KEY REFERENCES tblProperty(PropertyID),
	[ProductID] [int] FOREIGN KEY REFERENCES tblProduct(ProductID),
	[Value] [varchar](100) NULL,
	[HasMinMax] [int] NOT NULL,
	[Min] float(20) NULL,
	[Max] float(20) NULL,
	 CONSTRAINT PK_tablPropertyValue PRIMARY KEY (PropertyID,ProductID)
)
GO
SET ANSI_PADDING OFF
GO

--!!!!adding the product from same subcategory 1 here!!!!!!!
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value], [HasMinMax], [Min], [Max]) VALUES (1,1, N'Commercial', 0, NULL, NULL);
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value], [HasMinMax], [Min], [Max]) VALUES (1,2, N'Commercial',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value], [HasMinMax], [Min], [Max]) VALUES (1,3, N'Non Commercial',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value], [HasMinMax],[Min], [Max]) VALUES (1,4, N'Non Commercial',0, NULL, NULL)
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (1,5, N'Commercial',0, NULL, NULL)
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (1,6, N'Non Commercial')
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (1,7, N'Non Commercial')

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (2,1, N'Indoor',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (2,2, N'Indoor',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (2,3, N'Outdoor',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (2,4, N'Indoor',0, NULL, NULL)
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (2,5, N'Indoor',)
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (2,6, N'Outdoor')
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (2,7, N'Outdoor')


INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (3,1, N'Roof',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (3,2, N'Roof',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (3,3, N'Porch',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (3,4, N'Roof',0, NULL, NULL)
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (3,5, N'Roof')
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (3,6, N'Porch')
--INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value]) VALUES (3,7, N'Porch')

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (4,1, N'With Light',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (4,2, N'With Light',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (4,3, N'With Light',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (4,4, N'With Light',0, NULL, NULL)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (5,1, N'5467',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (5,2, N'5956',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (5,3, N'5956',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (5,4, N'9999',0, NULL, NULL)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (6,1, NULL,1, 1.95,21.14)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (6,2, NULL,1, 1.01,10.34)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (6,3, NULL,1, 7.50,12.11)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (6,4, NULL,1, 1.90,26.14)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (7,1, NULL,1, 100,240)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (7,2, NULL,1, 10, 35)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (7,3, NULL,1, 77, 86)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (7,4, NULL,1, 190,262)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (8,1, NULL,1, 10,24)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (8,2, NULL,1, 10, 35)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (8,3, NULL,1, 23, 45)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (8,4, NULL,1, 19,26)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (9,1, N'7',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (9,2, N'7',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (9,3, N'7',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (9,4, N'8',0, NULL, NULL)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (10,1, N'35',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (10,2, N'35',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (10,3, N'35',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (10,4, N'38',0, NULL, NULL)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (11,1, N'60',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (11,2, N'60',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (11,3, N'60',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (11,4, N'68',0, NULL, NULL)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (12,1, NULL,1, 12,57)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (12,2, NULL,1, 10, 35)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (12,3, NULL,1, 77, 86)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (12,4, NULL,1, 13,22)

INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (13,1, N'17',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (13,2, N'17',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (13,3, N'17',0, NULL, NULL)
INSERT [dbo].[tblPropertyValue] ([PropertyID], [ProductID], [Value],[HasMinMax], [Min], [Max]) VALUES (13,4, N'18',0, NULL, NULL)


/****** Object:  Table [dbo].[tblTechSpecsFilter]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTechSpecsFilter](
	[PropertyID] [int] FOREIGN KEY REFERENCES tblProperty(PropertyID),
	[SubcategoryID] [int] FOREIGN KEY REFERENCES tblSubcategory(SubcategoryID),
	[MinValue] [float](20) NOT NULL,
	[MaxValue] [float](20) NOT NULL,
	 CONSTRAINT PK_tblTechSpecsFilter PRIMARY KEY (PropertyID,SubcategoryID)
)
GO
SET ANSI_PADDING OFF
GO

--??????? so if product is under same subCategory --> same technical property?????????
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (6,1, 1,30)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (6,2, 1,30)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (6,3, 1,30)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (6,4, 1,30)

INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (7,1, 1,100)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (7,2, 1,100)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (7,3, 1,100)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (7,4, 1,100)

INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (8,1, 5,200)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (8,2, 5,200)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (8,3, 5,200)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (8,4, 5,200)

INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (12,1, 5,100)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (12,2, 5,100)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (12,3, 5,100)
INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (12,4, 5,100)

--INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (14,1, 20,60)
--INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (15,1, 10,18)
--INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (16,1, 12,18)
--INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (17,1, 1,5)
--INSERT [dbo].[tblTechSpecsFilter] ([PropertyID], [SubcategoryID], [MinValue], [MaxValue]) VALUES (18,1, 0,12000)


/****** Object:  Table [dbo].[tblTypeFilter]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTypeFilter](
	[PropertyID] [int] FOREIGN KEY REFERENCES tblProperty(PropertyID),
	[SubcategoryID] [int] FOREIGN KEY REFERENCES tblSubcategory(SubcategoryID),
	[TypeFilterID] [int] FOREIGN KEY REFERENCES tblProduct(ProductID),
	[TypeName] [varchar](100) NOT NULL,
	[TypeValue] [varchar](100) NOT NULL,
	 CONSTRAINT PK_tblTypeFilter PRIMARY KEY (PropertyID,SubcategoryID, TypeFilterID)
)
GO
SET ANSI_PADDING OFF
GO
--?????????????????Seems like only filter on value of one type-- "Use Type" ???????????
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID], [TypeName], [TypeValue]) VALUES (1,1,1,'Use Type','Commercial')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID],[TypeName], [TypeValue]) VALUES (1,1,2,'Use Type','Non-Commercial')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID],[TypeName], [TypeValue]) VALUES (1,2,1,'Use Type','Commercial')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID],[TypeName], [TypeValue]) VALUES (1,2,2,'Use Type','Non-Commercial')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID],[TypeName], [TypeValue]) VALUES (1,3,1,'Use Type','Commercial')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID],[TypeName], [TypeValue]) VALUES (1,3,2,'Use Type','Non-Commercial')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID],[TypeName], [TypeValue]) VALUES (1,4,1,'Use Type','Commercial')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeFilterID],[TypeName], [TypeValue]) VALUES (1,4,2,'Use Type','Non-Commercial')


/*INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (2,1,'Application','Indoor')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (2,2,'Application','Indoor')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (2,4,'Application','Outdoor')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (3,1,'Mounting Location','Roof')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (3,2,'Mounting Location','Roof')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (3,4,'Mounting Location','Porch')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (4,1,'Accessories','With Light')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (4,2,'Accessories','With Light')
INSERT [dbo].[tblTypeFilter] ([PropertyID], [SubcategoryID], [TypeName], [TypeValue]) VALUES (4,4,'Accessories','With Light')
*/



