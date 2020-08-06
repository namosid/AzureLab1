# AzureLab1
Azure Lab 1 will discuss about Real-time order processing using IoT and SignalR including below Azure Components:

IoT Hub

IoT Device Client

Azure WebApp

Azure Service Bus

Azure Function

Cosmos DB 

SignalR 

Through 3 Paths:
1.	Process Order - Client Panel to Admin Panel which includes (Azure WebApp, Azure Service Bus, Azure Function, Cosmos DB and SignalR)
2.	Update Order Status - Admin Panel to Client Panel (Azure WebApp, Azure Service Bus, Azure Function, Cosmos DB and SignalR)
3.	Process Order - IoT Device to Admin Panel (IoT Hub, IoT Device Client, Azure WebApp, Azure Service Bus, Azure Function, Cosmos DB and SignalR)

We are going to create application based on below architecture:

![alt tag](https://github.com/namosid/AzureLab1/blob/master/AzureLab1%20-%20Architecture.png)

You can get complete code here https://github.com/namosid/AzureLab1, Download and start experiencing live learning by following below steps.

Path 1 (Client Panel to Admin Panel) Setup:
1.	Create SignalR service on Azure portal.
2.	Deploy SignalRNegotiate Function on Azure from your visual studio IDE.
3.	Add Application Setting for “AzureSignalRConnectionString” as per below images:

![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%201.png)

![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%202.png)
 
4.	Create Azure Service Bus
5.	Add Queue => orders and orderstatus

![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%203.png)

6.	Open OrderDemo =>Controller=> HomeController.cs
Change service bus connection string in PlaceOrder function

![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%204.png)

7.	Open OrderDemo=>Views=>Home=>View.cshtml
Change .withUrl("https://sidsignalrnegotiate.azurewebsites.net/api/") highlighted url with SiganlR Negotiate Function Hostname.

![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%205.png)

8.	Open Admin=>Views=>Home=>OrderList.cshtml
Change .withUrl("https://sidsignalrnegotiate.azurewebsites.net/api/") highlighted url with SiganlR Negotiate Function Hostname.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%206.png)
 

9.	Create Azure CosmosDB.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%207.png)

10.	Publish ProcessingOrder Function app on Azure portal.
Add below 3 application settings in this function app as per below image:
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%208.png)
  

DocDbEndPoint :
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%209.png)

DocDbMasterKey:
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2010.png)

AzureSignalRConnectionString same as point 3.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2011.png)

11.	In SignalRNegotiate Function app enable and add below settings:
Currently our Admin and Client Panel both are running on localhost so we have added localhost URL for live applications we can change URL accordingly.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2012.png)

12.	Set Admin & Order Demo as a Multiple Startup Project like below:
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2013.png)

13.	Run Application and add Product through Client Panel and magic happen you got notification through SignalR on Admin Panel.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2014.png)

Path 2 (Admin Panel to Client Panel) Setup:
1.	Open Admin=>Controller=>HomeController.cs
In ChangeOrderStatus function update endpoint and masterkey variable of your CosmosDB
In UpdateServiceBus function add azure service bus connection string.

2.	Publish UpdateOrderStatus Function App on Azure portal.
Add AzureSignalRConnectionString same as point 3.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2015.png)
 
3.	Run Admin & OrderDemo Application. On Admin panel Accept\Reject Order which notification through our process comes on OrderDemo application as per below.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2016.png)
 
Path 3 (IoT Device to Admin Panel) Setup:
1.	Create IoT Hub.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2017.png)
2.	Add IoT Device in IoT hub component
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%218.png) 

3.	Open IoTDevice ConsoleApp => Program.cs
In Main function change connection as per below image from IoT Hub.
var conn = "HostName=SidTestIoT.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=VKOYPRPIAnmcAptRG2F/012KPvuE4LgddUS9kHT/2D8=;DeviceId=SidIoTDevice";

Note * - Please add DeviceId in connection string at the end.
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2019.png)

DeviceId:
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2020.png)

4.	Open ProcessIoTData Function App =>ProcessIoTData.cs
Update your Azure Service bus connection string.

5.	Publish ProcessIotData Function App on Azure portal.
Add below Application settings in that.

IoTHubEndPoint :
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2021.png)

![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2022.png)

6.	Run IoTDevice Console Application that placed order and data float through IoTHub to CosmosDb and AdminPanel.

![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2023.png)
![alt tag](https://github.com/namosid/AzureLab1/blob/master/Images/Image%2024.png)
 
Hope that article helps you to understand Azure components (IoT Hub, IoT Device Client, Azure WebApp, Azure Service Bus, Azure Function, Cosmos DB and SignalR) integration and configuration with working example.

You can get complete code here https://github.com/namosid/AzureLab1.

In Next Azure Lab we will discuss about other new and exciting Azure components.

