SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([id], [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES (1, N'Meril Soap', 25, 5, 5, NULL, NULL)
INSERT INTO [dbo].[Products] ([id], [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES (3, N'Lux', 25, 6, 5, NULL, NULL)
INSERT INTO [dbo].[Products] ([id], [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES (4, N'Dove', 35, 100, 5, NULL, NULL)
INSERT INTO [dbo].[Products] ([id], [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES (5, N'Cadberry', 100, 7, 7, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
