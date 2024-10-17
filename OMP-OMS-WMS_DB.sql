-- Create database OMS [Added Create Database & Use OMS -- 10/16/2024]

CREATE DATABASE OMS;
USE OMS;

/* 
TO DO

Finish Platform Order

New table to calculate the balance 
based on cost_based and order_based billing

End of To-Do 
(For now)
*/

CREATE TABLE ROLES (
    Role_ID VARCHAR(25),
    Role VARCHAR(25),
    Role_Description VARCHAR(255),
    PRIMARY KEY (Role_ID)
);

CREATE TABLE USERS (
    User_ID VARCHAR(25),
    Username VARCHAR(25),
    Password VARCHAR(25),
    Email VARCHAR(255),
    Date_Created DATE,
    PRIMARY KEY (User_ID)
);

CREATE TABLE User_Roles (
    User_ID VARCHAR(25),
    Role_ID VARCHAR(25),
    FOREIGN KEY (User_ID) REFERENCES USERS(User_ID),
    FOREIGN KEY (Role_ID) REFERENCES ROLES(Role_ID)
);

CREATE TABLE Billing_Account (
    Billing_Account_ID VARCHAR(25),
    User_ID VARCHAR(25),
    Account_Balance DOUBLE,
    PRIMARY KEY (Billing_Account_ID),
    FOREIGN KEY (User_ID) REFERENCES USERS(User_ID)
);

CREATE TABLE Cost_Based_Charges (
    Cost_Charge_ID VARCHAR(25),
    Amount DOUBLE,
    Description VARCHAR(255),
    PRIMARY KEY (Cost_Charge_ID)
);

CREATE TABLE Order_Based_Charges (
    Order_Charge_ID VARCHAR(25),
    Amount DOUBLE,
    Description VARCHAR(255),
    PRIMARY KEY (Order_Charge_ID)
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
    Warehouse_ID VARCHAR(25),
    Warehouse_Name VARCHAR(50),
    Country VARCHAR(50),
    City VARCHAR(50),
    Currency VARCHAR(50),
    PRIMARY KEY (Warehouse_ID)
);

CREATE TABLE Inventory (
    Product_ID VARCHAR(25),
    Warehouse_ID VARCHAR(25), 
    SKU VARCHAR(50),
    Product_Name VARCHAR(255),
    Product_Description VARCHAR(255),
    PRIMARY KEY (Product_ID),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID)
);

CREATE TABLE Inbound_Orders (
    Inbound_Order_ID VARCHAR(25),
    Order_Status VARCHAR(25),
    User_ID VARCHAR(25),
    Warehouse_ID VARCHAR(25),
    Estimated_Arrival DATE, 
    Product_Quantity INT,
    Creation_Date DATE,
    Cost DOUBLE,
    Currency VARCHAR(50),
    Boxes INT,
    Inbound_Type VARCHAR(25),
    Tracking_Number VARCHAR(255),
    Reference_Order_Number VARCHAR(255),
    Arrival_Method VARCHAR(25),
    PRIMARY KEY (Inbound_Order_ID),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID),
    FOREIGN KEY (User_ID) REFERENCES USERS(User_ID)
);

CREATE TABLE Inbound_Product_List (
    Order_ID VARCHAR(25),
    Product_ID VARCHAR(25),
    Quantity INT,
    FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
    FOREIGN KEY (Order_ID) REFERENCES Inbound_Orders(Inbound_Order_ID)
);

CREATE TABLE Freight_Outbound (
    Outbound_Order_ID VARCHAR(25),
    Order_Status VARCHAR(25),
    User_ID VARCHAR(25),
    Warehouse_ID VARCHAR(25),
    Product_Quantity INT,
    Creation_Date DATE,
    Estimated_Delivery_Date DATE, 
    Order_Ship_Date DATE,
    Cost DOUBLE,
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
    PRIMARY KEY (Outbound_Order_ID),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID),
    FOREIGN KEY (User_ID) REFERENCES USERS(User_ID)
);

CREATE TABLE Freight_Product_List (
    Order_ID VARCHAR(25),
    Product_ID VARCHAR(25),
    Quantity INT,
    FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
    FOREIGN KEY (Order_ID) REFERENCES Freight_Outbound(Outbound_Order_ID)
);

CREATE TABLE Parcel_Outbound (
    Order_ID VARCHAR(25),
    Order_Status VARCHAR(25),
    Warehouse_ID VARCHAR(25),
    User_ID VARCHAR(25),
    Platform VARCHAR(50),
    Estimated_Delivery_Date DATE,
    Ship_Date DATE,
    Transport_Days INT,
    Cost DOUBLE,
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
    PRIMARY KEY (Order_ID),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID),
    FOREIGN KEY (User_ID) REFERENCES USERS(User_ID)
);

CREATE TABLE Parcel_Product_List (
    Order_ID VARCHAR(25),
    Product_ID VARCHAR(25),
    Quantity INT,
    FOREIGN KEY (Product_ID) REFERENCES Inventory(Product_ID),
    FOREIGN KEY (Order_ID) REFERENCES Parcel_Outbound(Order_ID)
);

CREATE TABLE Platform_Order (
    Order_ID VARCHAR(25),
    Platform VARCHAR(50),
    PRIMARY KEY (Order_ID)
);

# Populate tables with dummy data.

INSERT INTO USERS VALUES
    ('U001', 'johndoe', 'password123', 'john.doe@gmail.com', '2024-01-01'),
    ('U002', 'janedoe', 'password456', 'jane.doe@gmail.com', '2024-01-02'),
    ('U003', 'alyssajones', 'password789', 'alicejones@hotmail.com', '2024-01-03'),
    ('U004', 'robertsmith', 'password321', 'rsmith@outlook.com', '2024-01-04'),
    ('U005', 'carlysimon', 'password654', 'charlie.white@gmail.com', '2024-01-05');
    
INSERT INTO Warehouse VALUES
    ('W001', 'NYC Warehouse', 'United States', 'New York', 'USD'),
    ('W002', 'Berlin Supply', 'Germany', 'Berlin', 'EUR'),
    ('W003', 'TokyoStorage', 'Japan', 'Tokyo', 'JPY'),
    ('W004', 'IN Storage Center', 'United States', 'Evansville', 'USD'),
    ('W005', 'TopAus Warehouse', 'Australia', 'Sydney', 'AUD');
    
INSERT INTO Inventory VALUES
	('P001', 'W001', 'blb12345', 'Dish Soap', 'Dawn dish soap'),
    ('P002', 'W002', 'CS456321', 'Doormat', 'Welcome doormat'),
    ('P003', 'W003', 'gk001', 'Water Bottle', 'Multi-color water bottle'),
    ('P004', 'W004', '1123555', 'Phone Case', 'Otter mobile phone case'),
    ('P005', 'W005', '456787651', 'Sneakers', 'Black and white sneakers');
    
INSERT INTO Billing_Account VALUES
    ('BA001', 'U001', '500'),
    ('BA002', 'U002', '750'),
    ('BA003', 'U003', '400'),
    ('BA004', 'U004', '150'),
    ('BA005', 'U005', '600');
    
INSERT INTO Cost_Based_Charges VALUES
    ('CC001', '50', 'Charge 1'),
    ('CC002', '20', 'Charge 2'),
    ('CC003', '15', 'Charge 3'),
    ('CC004', '30', 'Charge 4'),
    ('CC005', '45', 'Charge 5');

INSERT INTO Cost_Based_Billing VALUES
    ('BA001', 'CC001'),
    ('BA002', 'CC002'),
    ('BA003', 'CC003'),
    ('BA004', 'CC004'),
    ('BA005', 'CC005');


