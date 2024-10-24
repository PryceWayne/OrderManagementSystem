CREATE DATABASE OMS;
USE OMS;

﻿CREATE TABLE ROLES (
    Role_ID VARCHAR(25) PRIMARY KEY,
    Role VARCHAR(25),
    Role_Description VARCHAR(255)
);

CREATE TABLE USERS (
    User_ID VARCHAR(25) PRIMARY KEY,
    Username VARCHAR(25),
    Password VARCHAR(25),
    Email VARCHAR(255),
    Date_Created DATE
);

CREATE TABLE User_Roles (
    User_ID VARCHAR(25),
    Role_ID VARCHAR(25),
    FOREIGN KEY (User_ID) REFERENCES USERS(User_ID),
    FOREIGN KEY (Role_ID) REFERENCES ROLES(Role_ID)
);

CREATE TABLE Billing_Account (
    Billing_Account_ID VARCHAR(25) PRIMARY KEY,
    User_ID VARCHAR(25),
    Account_Balance FLOAT,
    FOREIGN KEY (User_ID) REFERENCES USERS(User_ID)
);

CREATE TABLE Cost_Based_Charges (
    Cost_Charge_ID VARCHAR(25) PRIMARY KEY,
    Amount FLOAT,
    Description VARCHAR(255)
);

CREATE TABLE Order_Based_Charges (
    Order_Charge_ID VARCHAR(25) PRIMARY KEY,
    Amount FLOAT,
    Description VARCHAR(255)
);

CREATE TABLE Cost_Based_Billing (
    Billing_Account_ID VARCHAR(25),
    Cost_Charge_ID VARCHAR(25),
    FOREIGN KEY (Cost_Charge_ID) REFERENCES Cost_Based_Charges(Cost_Charge_ID),
    FOREIGN KEY (Billing_Account_ID) REFERENCES Billing_Account(Billing_Account_ID)
);

CREATE TABLE Order_Based_Billing (
    Billing_Account_ID VARCHAR(25),
    Order_Charge_ID VARCHAR(25),
    FOREIGN KEY (Order_Charge_ID) REFERENCES Order_Based_Charges(Order_Charge_ID),
    FOREIGN KEY (Billing_Account_ID) REFERENCES Billing_Account(Billing_Account_ID)
);

CREATE TABLE Warehouse (
    Warehouse_ID VARCHAR(25) PRIMARY KEY,
    Warehouse VARCHAR(50),
    Country VARCHAR(50),
    City VARCHAR(50),
    Currency VARCHAR(50)
);

CREATE TABLE Inventory (
    Product_ID VARCHAR(25) PRIMARY KEY,
    Warehouse_ID VARCHAR(25),
    SKU VARCHAR(50),
    Product_Name VARCHAR(255),
    Product_Description VARCHAR(255),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID)
);

CREATE TABLE Inbound_Orders (
    Inbound_Order_ID VARCHAR(25) PRIMARY KEY,
    Order_Status VARCHAR(25),
    Creator VARCHAR(50),
    Warehouse_ID VARCHAR(25),
    Estimated_Arrival DATE, 
    Product_Quantity INT,
    Creation_Date DATE,
    Cost FLOAT,
    Currency VARCHAR(50),
    Boxes INT,
    Inbound_Type VARCHAR(25),
    Tracking_Number VARCHAR(255),
    Reference_Order_Number VARCHAR(255),
    Arrival_Method VARCHAR(25),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID),
    FOREIGN KEY (Creator) REFERENCES USERS(User_ID)
);

CREATE TABLE Inbound_Product_List (
    Order_ID VARCHAR(25),
    Product_ID VARCHAR(25),
    Quantity INT,
    FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
    FOREIGN KEY (Order_ID) REFERENCES Inbound_Orders(Inbound_Order_ID)
);

CREATE TABLE Freight_Outbound (
    Outbound_Order_ID VARCHAR(25) PRIMARY KEY,
    Order_Type VARCHAR(25),
    Order_Status VARCHAR(25),
    Creator VARCHAR(50),
    Warehouse_ID VARCHAR(25),
    Product_Quantity INT,
    Creation_Date DATE,
    Estimated_Delivery_Date DATE, 
    Order_Ship_Date DATE,
    Cost FLOAT,
    Currency VARCHAR(50),
    Recipient VARCHAR(100),
    Recipient_Post_Code VARCHAR(50),
    Destination_Type VARCHAR(50),
    Platform VARCHAR(50),
    Shipping_Company VARCHAR(50),
    Transport_Days INT,
    Related_Adjustment_Order VARCHAR(25),
    Tracking_Number VARCHAR(255),
    Reference_Order_Number VARCHAR(255),
    FBA_Shipment_ID VARCHAR(25),
    FBA_Tracking_Number VARCHAR(25),
    Outbound_Method VARCHAR(25),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID),
    FOREIGN KEY (Creator) REFERENCES USERS(User_ID)
);

CREATE TABLE Freight_Product_List (
    Order_ID VARCHAR(25),
    Product_ID VARCHAR(25),
    Quantity INT,
    FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
    FOREIGN KEY (Order_ID) REFERENCES Freight_Outbound(Outbound_Order_ID)
);

CREATE TABLE Parcel_Outbound (
    Order_ID VARCHAR(25) PRIMARY KEY,
    Order_Type VARCHAR(25),
    Order_Status VARCHAR(25),
    Warehouse_ID VARCHAR(25),
    Creator VARCHAR(25),
    Platform VARCHAR(50),
    Estimated_Delivery_Date DATE,
    Ship_Date DATE,
    Transport_Days INT,
    Cost FLOAT,
    Currency VARCHAR(25),
    Recipient VARCHAR(50),
    Country VARCHAR(50),
    Postcode VARCHAR(25),
    Tracking_Number VARCHAR(25),
    Reference_Order_Number VARCHAR(25),
    Creation_Date DATE,
    Boxes INT,
    Shipping_Company VARCHAR(50),
    Latest_Information VARCHAR(255),
    Tracking_Update_Time DATETIME,
    Internet_Posting_Time DATETIME,
    Delivery_Time DATETIME,
    Related_Adjustment_Order VARCHAR(25),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID),
    FOREIGN KEY (Creator) REFERENCES USERS(User_ID)
);

CREATE TABLE Parcel_Product_List (
    Order_ID VARCHAR(25),
    Product_ID VARCHAR(25),
    Quantity INT,
    FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
    FOREIGN KEY (Order_ID) REFERENCES Parcel_Outbound(Order_ID)
);

CREATE TABLE Platform_Order (
    Order_ID VARCHAR(25) PRIMARY KEY
);
