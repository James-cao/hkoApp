# hkoApp
Oracle + Dapper (with repository pattern) + Web API

This is a project showing usage of Dapper micro ORM on Oracle database and RESTfull web service made with ASP.NET Web API 2. Most of the operations are Read so speed was the main concern here and Dapper is chosen for data layer implementation.

The goal was to create modular, flexible and loosely coupled solution with layered architecture using clean code principles and SOLID. 

MicroOrm.Pocos.SqlGenerator is used to create generic SQL queries. 

All DAL methods are covered with unit tests.

As soon as frontend is finished URL will be added here to present the final product.

(Eventually, Automapper will be used to map Models classes to DTOs)
