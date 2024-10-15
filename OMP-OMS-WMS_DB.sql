-- Create database OMS


/* 
TO DO

Finish Platform Order

New table to calculate the balance 
based on cost_based and order_based billing

End of To-Do 
(For now)
*/



CREATE TABLE ROLES(
Role_ID varchar (25),
Role varchar(25),
Role_Description varchar(255),
PRIMARY KEY(Role_ID));

CREATE TABLE USERS(
User_ID varchar(25),
Username varchar(25),
Password varchar (25),
Email varchar (255),
Date_Created date,
PRIMARY KEY(User_ID));

CREATE TABLE User_Roles(
User_ID varchar(25),
Role_ID varchar (25),
FOREIGN KEY(User_ID) REFERENCES User(User_ID),
FOREIGN KEY(Role_ID) REFERENCES ROLES(Role_ID));

CREATE TABLE Billing_Account(
Billing_Account_ID varchar (25),
User_ID varchar(25),
Account_Balance double,
PRIMARY KEY(Billing_Account_ID),
FOREIGN KEY(User_ID) REFERENCES User(User_ID));

CREATE TABLE Cost_Based_Charges(
Cost_Charge_ID varchar (25),
Amount double,
Description varchar (255),
PRIMARY KEY(Cost_Charge_ID));

CREATE TABLE Order_Based_Charges(
Order_Charge_ID varchar (25),
Amount double,
Description varchar (255),
PRIMARY KEY(Order_Charge_ID));

CREATE TABLE Cost_Based_Billing(
Billing_Account_ID varchar (25),
Cost_Charge_ID varchar (25),
FOREIGN KEY (Cost_Charge_ID) REFERENCES Cost_Based_Charges(Cost_Charge_ID),
FOREIGN KEY(Billing_Account_ID) REFERENCES Billing_Account(Billing_Account_ID));

CREATE TABLE Order_Based_Billing(
Billing_Account_ID varchar (25),
Order_Charge_ID varchar (25),
FOREIGN KEY (Order_Charge_ID) REFERENCES Order_Based_Charges(Order_Charge_ID),
FOREIGN KEY(Billing_Account_ID) REFERENCES Billing_Account(Billing_Account_ID));

CREATE TABLE Warehouse(
Warehouse_ID varchar(25),
Warehouse varchar(50),
Country varchar (50),
City varchar(50),
Currency varchar (50),
PRIMARY KEY(Warehouse_ID));

CREATE TABLE Inventory(
Product_ID varchar(25),
Warehouse_ID varchar (25), 
SKU varchar(50),
Product_Name varchar(255),
Product_Description varchar(255),
FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID),
PRIMARY KEY(Product_ID));

CREATE TABLE Inbound_Orders(
Inbound_Order_ID varchar(25),
Order_Status varchar(25),
Creator varchar (50),
Warehouse varchar(50),
Estimated_Arrival date, 
Product_Quantity int,
Creation_Date date,
Cost double,
Currency varchar (50),
boxes int,
Inbound_Type varchar(25),
Tracking_Number varchar(255),
Reference_Order_Number varchar(255),
Arrival_Method varchar(25),
PRIMARY KEY(Inbound_order_ID),
FOREIGN KEY(Warehouse) REFERENCES Warehouse(Warehouse_ID),
FOREIGN KEY (Creator) REFERENCES Users(User_ID));

CREATE TABLE Inbound_Product_List(
Order_ID varchar (25),
Product_ID varchar (25),
Quantity int,
FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
FOREIGN KEY (Order_ID) REFERENCES Inbound_Orders(Order_ID));

CREATE TABLE Freight_Outbound(
Outbound_Order_ID varchar(25),
Order_Type varchar(25),
Order_Status varchar(25),
Creator varchar (50),
Warehouse varchar(50),
Product_Quantity int,
Creation_Date date,
Estimated_Delivery_Date date, 
Order_Ship_date date,
Cost double,
Currency varchar (50),
Recipient varchar(100),
Recipient_Post_Code varchar(50),
Destination_Type varchar(50),
Platform varchar(50),
Shipping_company varchar(50),
Transport_Days int,
Related_adjustment_Order varchar(25),
Tracking_Number varchar(255),
Reference_Order_Number varchar(255),
FBA_shipment_ID varchar(25),
FBA_Tracking_Number varchar(25),
Outbound_Method varchar(25),
PRIMARY KEY(Inbound_order_ID),
FOREIGN KEY(Warehouse) REFERENCES Warehouse(Warehouse_ID),
FOREIGN KEY (Creator) REFERENCES Users(User_ID));

CREATE TABLE Freight_Product_List(
Order_ID varchar (25),
Product_ID varchar (25),
Quantity int,
FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
FOREIGN KEY (Order_ID) REFERENCES Freight_Outbound(Order_ID));

CREATE TABLE Parcel_Outbound(
Order_ID varchar(25),
Order_Type varchar(25),
Order_status varchar(25),
Warehouse_ID  varchar(25),
Creator varchar(25),
Platform varchar(50),
Estimated_Delivery_Date date,
Ship_Date date,
Transport_days int,
Cost double,
Currency varchar(25),
Recipient varchar (50),
Country varchar(50),
Postcode varchar (25),
Tracking_Number varchar(25),
Reference_Order_Number varchar(25),
Creation_Date date,
boxes int,
Shipping_Company varchar(50),
Latest_Information varchar(255),
Tracking_Update_Time datetime,
INternet_Posting_Time datetime,
Delivery_Time datetime,
Related_Adjustment_Order varchar(25),
PRIMARY KEY(Order_ID),
FOREIGN KEY(Warehouse) REFERENCES Warehouse(Warehouse_ID),
FOREIGN KEY (Creator) REFERENCES Users(User_ID));

CREATE TABLE Parcel_Product_List(
Order_ID varchar (25),
Product_ID varchar (25),
Quantity int,
FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
FOREIGN KEY (Order_ID) REFERENCES Parcel_Outbound(Order_ID));

CREATE TABLE Platform_Order(
Order_ID varchar(25),
Platfom varchar(50),
Platfom varchar(50),
PRIMARY KEY(Order_ID));