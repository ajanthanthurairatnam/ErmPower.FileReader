# ErmPower.FileReader
ErmPower.FileReader is a complete solution for reading CSV files and providing the desired output

# Overview.
The solution is constructed following clean architecture patterns with high potential for extendibility. The SOLID discipline is applied throughout the system. 

# Layers
The System is designed in a Multilayered Architecture.

Infrastructure
-------------
The infrastructure layer is how the data that is initially held in domain entities. This layer consists with three Class Libraries.

ErmPower.FileReader.Core - Base infrastructure of the Project starts here. Most important domain entities and services are declared     here.  
  
ErmPower.FileReader.DataAccessFramework - DataFramework - The framework used to retrieve the CSV files.
Dependencies -  ErmPower.FileReader.Core, 
                nuget package CsvHelper is used here as a dependency - https://joshclose.github.io/CsvHelper/.
This framework can be replaced when required.
  
ErmPower.FileReader.Data
Generic data layer which provides the encapsulated data. Maintains a repository of data which is registed with the DI framework.
Dependencies - ErmPower.FileReader.DataAccessFramework
    
ApplicationCore
---------------
The core business logic is preserved here. 
 
ErmPower.FileReader.Business
Business rules are applied with the potential to extension. 
Dependencies - ErmPower.FileReader.Data


Presentation
------------
The presentation logic of the application is maintained here.

ErmPower.FileReader.ConsoleUserInterface
A console application with different services providing the desired output. All the dependencies are registered in the Main method.
Dependencies - ErmPower.FileReader.Business

Test
----
Unit tests for System Under Test.

ErmPower.FileReader.Tests
Covers six important unit tests.

Dependencies - ErmPower.FileReader.Business, ErmPower.FileReader.Data
               nuget package - MOQ, XUnit

 
-------------------------------------------------------------------------------------------------------------------------------------- 
 
