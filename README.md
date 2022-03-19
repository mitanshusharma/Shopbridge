# Shopbridge
This is the Assignment submission for ThinkBridge

## Steps to run the Project:
1) Open the "shopbridge_base.sln" solution under the "\\Shopbridge\shopbridge_base" project folder. This should open the Main WebApi Project and the UnitTests Project

2) Restore the database "Shopbridge_Context" in Database folder and change the Connection String in the appsettings.json file under the "\\Shopbridge\shopbridge_base" project folder to connect to the database.

Note: The Original Azure connection string were having issues logging in , so created a new Database.

3) Run the Project with Shopbridge_base as the startup solution and the Swagger UI will be open with all the available methods that can be invoked and tested.

Note: Product model has the following structure, and any value can be passed in the request body for these properties of Product:
{
  "id": 0,
  "name": "string",
  "description": "string",
  "price": 0
}


## Following data values can be used to test the functionalities:
1) Get: /api/Products
	Just invoke the method from Swagger UI and all the Products available in the database will be returned.
	
	Example Result:	
	Request URL : https://localhost:44344/api/Products
	Server Response: Code 200 OK
	Response Body: 
	[
  {
    "name": "Battery",
    "description": "Mobile Battery",
    "price": 20,
    "id": 1
  },
  {
    "name": "Cable",
    "description": "2mm cable",
    "price": 250,
    "id": 2
  },
  {
    "name": "Motor",
    "description": "450Hr motor",
    "price": 2631.12,
    "id": 3
  }
]

2) Get: /api/Products/{id}
	Insert any id as the input and then invoke the method. The product with that id will be returned if exists, otherwise NotFound response.
	
	Example Result:
	Input Id: 2
	Request URL : https://localhost:44344/api/Products/2
	Server Response: Code 200 OK
	Response Body: 
	{
	  "name": "Cable",
	  "description": "2mm cable",
	  "price": 250,
	  "id": 2
	}

3) Post: /api/Products
	Add a new Product in json format without id column(It is auto incremented in the database) in the request body and invoke the method. This new product will be added to the database and added product will be returned back.
	
	Example Result:	
	Input Request body: 
	{
	  "name": "Regulator",
	  "description": "Circuit board",
	  "price": 560.00
	}
	
	Request URL : https://localhost:44344/api/Products	
	Server Response: Code 201 Created
	Response Body: 
	{
	  "name": "Regulator",
	  "description": "Circuit board",
	  "price": 560,
	  "id": 5
	}
	
4) Put: /api/Products/{id}
	Insert an Id in the input and add the updated product in the request body and invoke the method. The product with the given id will be updated with the updated Product,and updated product will be returned back.
	
	Example Result:
	Input id: 5
	Input Request body: 
	{
	  "name": "Regulator",
	  "description": "Circuit board",
	  "price": 630.00
	}
	
	Request URL : https://localhost:44344/api/Products/5	
	Server Response: Code 200 OK
	Response Body: 
	{
	  "name": "Regulator",
	  "description": "Circuit board",
	  "price": 630,
	  "id": 5
	}
	
5) Delete: /api/Products/{id}
	Insert the id of the product which needs to be deleted and invoke the method. The product with the mentioned id will be deleted and returned back.
	
	Example Result:
	Input id: 5
	
	Request URL : https://localhost:44344/api/Products/5	
	Server Response: Code 200 OK
	Response Body: 
	{
	  "name": "Regulator",
	  "description": "Circuit board",
	  "price": 630,
	  "id": 5
	}
	