### download mongo docker image
```docker pull mongo```

### Create docker container and run
```docker run -d -p 27017:27017 --name catalog-mongo mongo```
where catalog-mongo is the name you want to assign to your container and mongo or mongo:tag is the tag specifying the MongoDB version

### Check docker container is running
docker ps


### Open interactive terminal for mongo
docker exec -it catalog-mongo /bin/bash


### Run mongo commands
- create database
- create collection
- add items into collection
- list collection

```
ls
mongosh
show dbs

--> for create db on mongo
use CatalogDb

--> for create people collection
db.createCollection('Products')  

--> Insert mock items
db.Products.insertMany([{ 'Name':'Asus Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':54.93 }, { 'Name':'HP Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':88.93 } ])

--> Remove all items
db.Products.remove({})

show databases
show collections
db.Products.find({}).pretty()
```
