----insert default data
INSERT INTO [dbo].[Company]
([Name],
[Code],
[Desc],
[Address],
[ContactNo1],
[EmailId],
[Active])

VALUES ('INTERBUS','INTERBUS','INTERBUS company','ZWB',95000,'admin@interbus.com',1)

INSERT INTO [dbo].[Users]
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


INSERT INTO [dbo].[UserLogins]
           ([LoginInfo]
           ,[PassKey]
           ,[UserId]
           ,[salt]
           ,[Active])
     VALUES
           ('admin','admin',1,null,1)

Set IDENTITY_INSERT  [TypeGroups] ON

INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (1,'Status','Statuses used in application',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (2,'Categories','Categories',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (3,'License Categories','License Categories',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (4,'Vehicle Group','Vehicle Groups such as car, ambulance etc.,',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (5,'Gender','Gender',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (6,'Frequency','Frequency',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (7,'Pricing Type','Pricing Type',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (8,'Transaction Type','Transaction Type',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (9,'Applicability','Applicability',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (10,'Fee Category','Fee Category',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (11,'Transaction Charge Type','Transaction Charge Type',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (12,'Vehicle Type','Vehicle Type',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (13,'Vehicle Model','Vehicle Model',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (14,'Vehicle Make','License Features',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (15,'Document Type','Document Types',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (16,'PaymentType','PaymentType',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (17,'Miscellaneous Types','PaymentType',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (18,'Card Categories','Card Categories',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (19,'Card Types','Card Types',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (20,'Vehicle Layout Type','Vehicle Layout Type',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (21,'License Features','License Features',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (22,'Card Models','Card Models',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (23,'Cards','For Transactions',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (24,'Transactions','To Make a Payment',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (25,'User Type','User types',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (26,'Applicable Type','To make Charge or Discount',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (27,'Authentication Type','Authentication Type',1)
INSERT INTO [dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (28,'State','Defines which state',1)


Set IDENTITY_INSERT  [TypeGroups] OFF
----btpos status
Set IDENTITY_INSERT  [Types] ON
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (1,'Accepted',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (2,'Activated',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (3,'Active',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (4,'Appropriate',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (5,'Approved',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (6,'Blocked',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (7,'Completed',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (8,'Deactivated',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (9,'Disabled',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (10,'Enabled',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (11,'Failed',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (12,'In Appropriate',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (13,'In progress',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (14,'InActive',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (15,'New',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (16,'No Response',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (17,'Offline',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (18,'OnHold',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (19,'Online',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (20,'OnTrip',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (21,'Rejected',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (22,'Resolved',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (23,'Success',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (24,'Suspended',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (25,'To be activated',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (26,'Trip Completed',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (27,'Verified',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (28,'Waiting',null,1,1,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (29,'Withdrawn',null,1,1,null,null)

---categories
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (30,'Inventory Category',null,1,2,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (31,'Fleet Owner License',null,1,3,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (32,'Advertisement License',null,1,3,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (33,'BTPOS License',null,1,3,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (34,'Hailing Car',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (35,'Metered taxi',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (36,'Ambulance',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (37,'Towing vehicle',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (38,'Parcel van',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (39,'Bus',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (40,'Train',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (41,'Cruise',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (42,'Aeroplane',null,1,4,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (43,'Hire vehicle',null,1,4,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (44,'Male',null,1,5,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (45,'Female',null,1,5,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (46,'Daily',null,1,6,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (47,'Weekly',null,1,6,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (48,'Monthly',null,1,6,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (49,'Quarterly',null,1,6,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (50,'Half Yearly',null,1,6,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (51,'Yearly',null,1,6,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (52,'Once',null,1,6,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (53,'PerUnitPricing',null,1,7,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (54,'Fixed pricing',null,1,7,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (55,'Debit',null,1,8,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (56,'Credit',null,1,8,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (57,'Refund',null,1,8,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (58,'Reversal',null,1,8,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (59,'Percentage',null,1,9,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (60,'Total',null,1,9,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (61,'AuthourizationFee',null,1,10,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (62,'TransactionFee',null,1,10,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (63,'CancellationFee',null,1,10,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (64,'AdditionalFee',null,1,10,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (65,'Charge',null,1,11,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (66,'Discount',null,1,11,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (67,'Sedan',null,1,12,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (68,'SUV',null,1,12,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (69,'Hatchback',null,1,12,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (70,'Vehicle Insurance',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (71,'Driver Insurance',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (72,'Vehicle Fitness ',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (73,'Passenger Insurance',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (74,'Medical certificate',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (75,'Route Authourity',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (76,'Operations certificate',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (77,'Vehicle registration',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (78,'driver license',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (79,'Road permit',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (80,'Road certificate',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (81,'TV/Radio license',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (82,'Pollution certificate',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (83,'Receipt',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (84,'Invoice',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (85,'Quotation',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (86,'Address proof',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (87,'Id proof',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (88,'Passport',null,1,15,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (108,'Photo',null,1,21,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (89,'Custom Card',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (90,'Cash',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (91,'Netbanking',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (92,'Paypal',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (93,'e-wallet',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (94,'Mobile Money',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (95,'QR Code',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (122,'Cedit Card',null,1,16,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (123,'Debit Card',null,1,16,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (96,'Credit',null,1,18,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (97,'debit',null,1,18,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (98,'custom',null,1,18,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (99,'Master',null,1,18,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (100,'Visa',null,1,18,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (101,'Mastero',null,1,18,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (102,'contact card',null,1,19,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (103,'contactless card',null,1,19,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (104,'Number of POS Units',null,1,21,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (105,'Number of travel tickets',null,1,21,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (106,'Support',null,1,21,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (107,'Number of Vehicles',null,1,21,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (109,'Driver',null,1,25,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (110,'Fleet Owner',null,1,25,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (111,'Supervisor',null,1,25,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (112,'Customer',null,1,25,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (113,'Application User',null,1,25,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (114,'Percentage',null,1,26,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (115,'Fixed',null,1,26,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (116,'string',null,1,27,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (117,'biometric',null,1,27,null,null)

INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (118,'Customer App',null,1,2,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (119,'Driver App',null,1,2,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (120,'Web Portal',null,1,2,null,null)
INSERT INTO [dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (121,'Admin Website',null,1,2,null,null)
Set IDENTITY_INSERT  [Types] OFF

----sub category btpos
Set IDENTITY_INSERT  [SubCategory] ON

INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (1,'BT POS',null,6,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (2,'Customer',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (3,'Driver',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (4,'Account',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (5,'Ewallet',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (6,'Payments',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (7,'Refunds',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (8,'Cancellation',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (9,'Bookings',null,117,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (10,'Customer',null,118,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (11,'Driver',null,118,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (12,'Account',null,118,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (13,'Ewallet',null,118,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (14,'Payments',null,118,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (15,'Refunds',null,118,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (16,'Cancellation',null,118,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (17,'Bookings',null,118,1)

INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (18,'Licenses',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (20,'Payments',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (21,'Renewals',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (22,'Bookings',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (23,'Refunds',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (24,'Cancellation',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (25,'Contact',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (26,'Advertisement',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (27,'User Profile',null,119,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (28,'User Account',null,119,1)

INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (28,'Driver',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (29,'Customer',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (30,'Vehicle',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (31,'Fleetowner',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (32,'User profile',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (33,'User Account',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (34,'Routes',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (35,'Charges',null,120,1)
INSERT INTO [dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (36,'Payments',null,120,1)

Set IDENTITY_INSERT  [SubCategory] OFF
---CurrentState
Set IDENTITY_INSERT  [CurrentState] ON
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(1,'Mobile OTP pending','Mobile OTP pending',1) 
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(2,'Email OTP Pending','Email OTP Pending',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(3,'User Photo pending','User Photo pending',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(4,'User Docs pending','User Docs pending',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(5,'Vehicle photo pending','Vehicle photo pending',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(6,'vehice docs pending','vehice docs pending',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(7,'Pending verification','Pending verification',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(8,'pending approval','pending approval',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(9,'Approved ','Approved ',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(10,'Online','Online',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(11,'Offline','Offline',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(12,'On Trip','On Trip',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(13,'Blocked','Blocked',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(14,'In Active','In Active',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(15,'Payment pending','Payment pending',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(16,'Payment overdue','Payment overdue',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(17,'Rejected','Rejected',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(18,'Alert ','Alert ',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(19,'notification','notification',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(20,'Account locked','Account locked',1)
INSERT INTO [dbo].[CurrentState]([Id],[Name],[Description],[Active])  VALUES(21,'Vehicle Not assigned','Driver is not assigned any vehicle',1)
Set IDENTITY_INSERT  [CurrentState] OFF

----inventory item btpos
Set IDENTITY_INSERT  [InventoryItem] ON

INSERT INTO [dbo].[InventoryItem](Id,[ItemName],[Code],[Description],[CategoryId],[SubCategoryId],[ReOrderPoint]) VALUES (1,'BT POS 8110','BTPOS 8110',null,6,1,20)

Set IDENTITY_INSERT  [InventoryItem] OFF

--
---- Objects 
Set IDENTITY_INSERT  [Objects] ON

INSERT INTO [dbo].[Objects](Id,[Name],[Description],[Path],[Active],[ParentId],[RootObjectId]) VALUES (1,'SmartTicketDashboard','SmartTicketDashboard','SmartTicketDashboard',1,null,1)

Set IDENTITY_INSERT  [Objects] OFF


Set IDENTITY_INSERT  [AppStates] ON

INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (1,'Registration','Statuses used in application',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (2,'email OTP verification','Categories',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (3,'mobile OTP verification','License Categories',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (4,'vehicle details during registration','Vehicle Groups such as car, ambulance etc.,',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (5,'forgot password','Gender',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (6,'password OTP verification','Frequency',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (7,'change password','Pricing Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (8,'driver profile ','Transaction Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (9,'driver documents display','Applicability',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (10,'driver documents uploading','Fee Category',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (11,'driver documents approval','Transaction Charge Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (12,'driver approval','Vehicle Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (13,'vehicle profile','Vehicle Model',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (14,'vehicle documents display','License Features',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (15,'vehicle documents uploading','Document Types',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (16,'vehicle documents approval','PaymentType',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (17,'vehicle approval','PaymentType',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (18,'driver location tracking','Card Categories',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (19,'vehicle image type','Card Types',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (20,'customer location tracking','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (21,'online and offline','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (22,'assigned vehicles list','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (23,'vehicle details','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (24,'installation','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (25,'upgrading app','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (26,'fleet owner logging','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (27,'admin logging','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (28,'fleet owner landing page','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (29,'admin landing page','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (30,'fleet owner vehilces list','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (31,'fleet owner drivers list','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (32,'vehicle details','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (33,'driver details','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (34,'vehicle approval','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (35,'driver approval','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (36,'admin vehilce list','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (37,'admin driver list','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (38,'admin vehicle approval','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (39,'admin driver approval','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (40,'error handling','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (41,'statemanagement','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (42,'assigning trips','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (43,'accept/reject trips','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (44,'trip otp validation','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (45,'trip confirmation','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (46,'end trip','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (47,'trip tracking','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (48,'customer details','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (49,'customer calling','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (50,'trip statemangament','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (51,'trip feedback','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (52,'payment collection','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (53,'payment updates','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (54,'finalizing trip details','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (55,'trips history','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (56,'pending documents alerts notifications','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (57,'payments of charges','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (58,'charges notifications','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (59,'offers / discounts/ announcements','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (60,'banking for getting payments','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (61,'banking for making payments','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (62,'QR code generation','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (63,'QR code for payments','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (64,'amount generated history','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (65,'SOS numbers configuration','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (66,'SOS messages templates','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (67,'SOS messaging','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (68,'SOS otp verification','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (69,'sos message sending(button/key)','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (70,'SOS history','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (71,'FAQs','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (72,'contact details','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (73,'Help','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (74,'e-wallet management','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (75,'authourization fees','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (76,'overdue charges','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (77,'discounts offers','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'fines','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (79,'Account expiration/renewal','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (80,'payment types preferences','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'payment mode preferences','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'payment gateway integration','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'transaction fee processing','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'trip cancellation','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'SMS gatewat integration','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'email gateway integration','Vehicle Layout Type',1)
INSERT INTO [dbo].[AppStates](ID,[Response],[Description]) VALUES (78,'application logout and logging','Vehicle Layout Type',1)






Set IDENTITY_INSERT  [AppStates] OFF