----insert default data
INSERT INTO [POSDashboard].[dbo].[Company]
([Name],[Code],[Desc],[Address],[ContactNo1],[EmailId],[Active])
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

INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (1,'Status','Statuses used in application',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (2,'Categories','Categories',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (3,'License Categories','License Categories',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (4,'Vehicle Group','Vehicle Groups such as car, ambulance etc.,',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (5,'Gender','Gender',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (6,'Frequency','Frequency',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (7,'Pricing Type','Pricing Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (8,'Transaction Type','Transaction Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (9,'Applicability','Applicability',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (10,'Fee Category','Fee Category',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (11,'Transaction Charge Type','Transaction Charge Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (12,'Vehicle Type','Vehicle Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (13,'Vehicle Model','Vehicle Model',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (14,'Vehicle Make','License Features',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (15,'Document Type','Document Types',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (16,'PaymentType','PaymentType',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (17,'Miscellaneous Types','PaymentType',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (18,'Card Categories','Card Categories',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (19,'Card Types','Card Types',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (20,'Vehicle Layout Type','Vehicle Layout Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (21,'License Features','License Features',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (22,'Card Models','Card Models',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (23,'Cards','For Transactions',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (24,'Transactions','To Make a Payment',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (25,'User Type','User types',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (26,'Applicable Type','To make Charge or Discount',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (27,'Authentication Type','Authentication Type',1)
INSERT INTO [POSDashboard].[dbo].[TypeGroups](ID,[Name],[Description],[Active]) VALUES (28,'State','Defines which state',1)


Set IDENTITY_INSERT  [TypeGroups] OFF
----btpos status
Set IDENTITY_INSERT  [Types] ON
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (1,'Accepted',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (2,'Activated',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (3,'Active',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (4,'Appropriate',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (5,'Approved',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (6,'Blocked',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (7,'Completed',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (8,'Deactivated',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (9,'Disabled',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (10,'Enabled',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (11,'Failed',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (12,'In Appropriate',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (13,'In progress',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (14,'InActive',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (15,'New',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (16,'No Response',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (17,'Offline',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (18,'OnHold',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (19,'Online',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (20,'OnTrip',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (21,'Rejected',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (22,'Resolved',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (23,'Success',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (24,'Suspended',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (25,'To be activated',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (26,'Trip Completed',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (27,'Verified',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (28,'Waiting',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (29,'Withdrawn',null,1,1,null,null)

---categories
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (30,'Inventory Category',null,1,2,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (31,'Fleet Owner License',null,1,3,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (32,'Advertisement License',null,1,3,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (33,'BTPOS License',null,1,3,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (34,'Hailing Car',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (35,'Metered taxi',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (36,'Ambulance',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (37,'Towing vehicle',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (38,'Parcel van',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (39,'Bus',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (40,'Train',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (41,'Cruise',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (42,'Aeroplane',null,1,4,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (43,'Hire vehicle',null,1,4,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (44,'Male',null,1,5,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (45,'Female',null,1,5,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (46,'Daily',null,1,6,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (47,'Weekly',null,1,6,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (48,'Monthly',null,1,6,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (49,'Quarterly',null,1,6,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (50,'Half Yearly',null,1,6,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (51,'Yearly',null,1,6,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (112,'Once',null,1,6,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (52,'PerUnitPricing',null,1,7,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (53,'Fixed pricing',null,1,7,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (54,'Debit',null,1,8,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (55,'Credit',null,1,8,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (56,'Refund',null,1,8,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (57,'Reversal',null,1,8,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (58,'Percentage',null,1,9,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (59,'Total',null,1,9,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (60,'AuthourizationFee',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (61,'TransactionFee',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (62,'CancellationFee',null,1,10,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (63,'AdditionalFee',null,1,10,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (64,'Charge',null,1,11,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (65,'Discount',null,1,11,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (66,'Sedan',null,1,12,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (67,'SUV',null,1,12,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (68,'Hatchback',null,1,12,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (69,'Vehicle Insurance',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (70,'Driver Insurance',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (71,'Vehicle Fitness ',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (72,'Passenger Insurance',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (73,'Medical certificate',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (74,'Route Authourity',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (75,'Operations certificate',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (76,'Vehicle registration',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (77,'driver license',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (78,'Road permit',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (79,'Road certificate',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (80,'TV/Radio license',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (81,'Pollution certificate',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (82,'Receipt',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (83,'Invoice',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (84,'Quotation',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (85,'Address proof',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (86,'Id proof',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (87,'Passport',null,1,15,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (107,'Photo',null,1,21,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (88,'Card',null,1,16,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (89,'Cash',null,1,16,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (90,'Netbanking',null,1,16,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (91,'Paypal',null,1,16,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (92,'e-wallet',null,1,16,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (93,'Mobile Money',null,1,16,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (94,'QR Code',null,1,16,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (95,'Credit',null,1,18,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (96,'debit',null,1,18,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (97,'custom',null,1,18,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (98,'Master',null,1,18,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (99,'Visa',null,1,18,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (100,'Mastero',null,1,18,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (101,'contact card',null,1,19,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (102,'contactless card',null,1,19,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (103,'Number of POS Units',null,1,21,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (104,'Number of travel tickets',null,1,21,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (105,'Support',null,1,21,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (106,'Number of Vehicles',null,1,21,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (108,'Fleet Owner',null,1,25,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (109,'Driver',null,1,25,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (110,'Supervisor',null,1,25,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (111,'Customer',null,1,25,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (112,'Application User',null,1,25,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (113,'Percentage',null,1,26,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (114,'Fixed',null,1,26,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (115,'string',null,1,27,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (116,'biometric',null,1,27,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (117,'Accepted',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (118,'Activated',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (119,'Active',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (120,'Appropriate',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (121,'Approved',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (122,'Blocked',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (123,'Completed',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (124,'Deactivated',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (125,'Disabled',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (126,'Enabled',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (127,'Failed',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (128,'In Appropriate',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (129,'In progress',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (130,'InActive',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (131,'New',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (132,'No Response',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (133,'Offline',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (134,'OnHold',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (135,'Online',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (136,'OnTrip',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (137,'Rejected',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (138,'Resolved',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (139,'Success',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (140,'Suspended',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (141,'To be activated',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (142,'Trip Completed',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (143,'Verified',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (144,'Waiting',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (145,'Withdrawn',null,1,1,null,null)

INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (146,'Customer App',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (147,'Driver App',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (148,'Web Portal',null,1,1,null,null)
INSERT INTO [POSDashboard].[dbo].[Types] (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue]) VALUES (149,'Admin Website',null,1,1,null,null)
Set IDENTITY_INSERT  [Types] OFF

----sub category btpos
Set IDENTITY_INSERT  [SubCategory] ON

INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (1,'BT POS',null,6,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (2,'Customer',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (3,'Driver',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (4,'Account',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (5,'Ewallet',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (6,'Payments',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (7,'Refunds',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (8,'Cancellation',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (9,'Bookings',null,146,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (10,'Customer',null,147,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (11,'Driver',null,147,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (12,'Account',null,147,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (13,'Ewallet',null,147,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (14,'Payments',null,147,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (15,'Refunds',null,147,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (16,'Cancellation',null,147,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (17,'Bookings',null,147,1)

INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (18,'Licenses',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (19,'Products',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (20,'Payments',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (21,'Renewals',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (22,'Bookings',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (23,'Refunds',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (24,'Cancellation',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (25,'Contact',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (26,'Advertisement',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (27,'User Profile',null,148,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (28,'User Account',null,148,1)

INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (28,'Driver',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (29,'Customer',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (30,'Vehicle',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (31,'Fleetowner',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (32,'User profile',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (33,'User Account',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (34,'Routes',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (35,'Charges',null,149,1)
INSERT INTO [POSDashboard].[dbo].[SubCategory](Id,[Name],[Description],[CategoryId],[Active]) VALUES (36,'Payments',null,149,1)

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