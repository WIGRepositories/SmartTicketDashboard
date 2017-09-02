----insert default data
INSERT INTO [POSDashboard].[dbo].[Company]([Name],[Code],[Desc],[Address],[ContactNo1],[EmailId],[Active])
VALUES ('INTERBUS','INTERBUS','INTERBUS company','ZWB',95000,'admin@interbus.com',1)

INSERT INTO [POSDashboard].[dbo].[Users]
           ([FirstName]
           ,[LastName] 		              
           ,[EmpNo]
           ,[EmailId]
           ,[Address]
           ,[ContactNo1]           
           ,[Active]
           ,[MiddleName]
           ,[CompanyId]
           ,[GenderId])
     VALUES
           ('Admin','Admin','EMP001','admin@interbus.com',null,null,1,null,1,1)


INSERT INTO [POSDashboard].[dbo].[UserLogins]
           ([LoginInfo]
           ,[PassKey]
           ,[UserId]
           ,[salt]
           ,[Active])
     VALUES
           ('admin','admin',1,null,1)

Set IDENTITY_INSERT  [TypeGroups] ON

INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (1,'BT POS Status','BT POS Status',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (2,'Categories','Categories',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (3,'License Categories','License Categories',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (4,'Vehicle Type','Vehicle Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (5,'Vehicle Service Type','Vehicle Service Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (6,'Vehicle Layout Type','Vehicle Layout Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (7,'Renewal Frequency','Renewal Frequency',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (8,'Pricing Type','Pricing Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (9,'License Features','License Features',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (10,'Vehicle Model','License Features',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (11,'Vehicle Group','License Features',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (12,'Status','Status',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (13,'Card Types','Card Types',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (14,'Card Models','Card Models',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (15,'Card Categories','Card Categories',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (16,'Cards','For Transactions',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (17,'Transactions','To Make a Payment',1)


Set IDENTITY_INSERT  [TypeGroups] OFF
----btpos status
Set IDENTITY_INSERT  [Types] ON
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (1,'New',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (2,'Active',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (3,'InActive',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (4,'To be activated',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (5,'Suspended',null,1,1,null,null)

---categories
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (6,'Inventory Category',null,1,2,null,null)

--license categories
--INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (7,'BT POS License',null,1,3,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (8,'Fleet Owner License',null,1,3,null,null)

--vehicle types
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (9,'AC',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (10,'Non-AC',null,1,4,null,null)

--vehicle service types
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (11,'Hire',null,1,5,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (12,'Non-Hire',null,1,5,null,null)

--vehicle layout types
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (13,'27-seater',null,1,6,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (14,'56-seater',null,1,6,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (15,'Weekly',null,1,7,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (16,'Monthly',null,1,7,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (17,'Quarterly',null,1,7,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (18,'Half Yearly',null,1,7,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (19,'Yearly',null,1,7,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (20,'Per Unit Pricing',null,1,8,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (21,'Stage to Stage',null,1,8,null,null)
--license features
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (22,'BT POS',null,1,9,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (23,'Trouble Tickets',null,1,9,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (24,'Support',null,1,9,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (25,'Indigo',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (26,'Indica',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (27,'Tavera',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (28,'Innova',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (29,'Swift',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (30,'Ertiga',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (31,'Cab',null,1,11,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (32,'Ambulance',null,1,11,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (33,'Truck',null,1,11,null,null)

--Cards features
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (34,'Contact card',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (35,'Contact less',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (36,'Silver',null,1,14,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (37,'Gold',null,1,14,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (38,'Platinum',null,1,14,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (39,'Visa',null,1,13,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (40,'MasterCard',null,1,13,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (41,'Mastro',null,1,13,null,null)




Set IDENTITY_INSERT  [Types] OFF



----sub category btpos
Set IDENTITY_INSERT  [SubCategory] ON

INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (1,'BT POS',null,6,1)

Set IDENTITY_INSERT  [SubCategory] OFF

----inventory item btpos
Set IDENTITY_INSERT  [InventoryItem] ON

INSERT INTO [POSDashboard].[dbo].[InventoryItem](Id,[ItemName],[Code],[Description],[CategoryId],[SubCategoryId],[ReOrderPoint]) VALUES (1,'BT POS 8110','BTPOS 8110',null,6,1,20)

Set IDENTITY_INSERT  [InventoryItem] OFF

--
---- Objects 
Set IDENTITY_INSERT  [Objects] ON

INSERT INTO [POSDashboard].[dbo].[Objects](Id,[Name],[Description],[Path],[Active],[ParentId],[RootObjectId]) VALUES (1,'SmartTicketDashboard','SmartTicketDashboard','SmartTicketDashboard',1,null,1)

Set IDENTITY_INSERT  [Objects] OFF