# Child Development TimeLine

#### C# Group Project for Epicodus, 12/20/2018

### **By Kaveh, Stuard, Glen and Gulzat**

## Description
Child Development Timeline website geared toward parents to learn their child's development timeline from birth to 5 years old. The user needs to create an account to login and fill the form statistic information about their child. The result shows in line chart and parent can compare the result with other kids result by choosing specific parts of the form. Also parent can modify child's information.

## Specifications

1. The user is able to create an account.

2. The user is able to login with exist account and log out.

3. The user can fill the form and get the result in Line Chart.

4. The user can edit child's information

5. The user can delete child's information.

6. The use can compare the result with other's result.

7. The user can select specific question to compare their result with others.


## Setup/Installation Requirements

1. Clone this repository: https://github.com/gulzatk/ChildDevelopment.git

2. Create a database needed for this application.
  * CREATE DATABASE child_development;
  * USE child_development;
  * CREATE TABLE children (id serial PRIMARY KEY, name VARCHAR(255), gender BOOLEAN, weight INT, height INT, birthdate DATETIME, breastfeeding BOOLEAN;
  * CREATE TABLE events (id serial PRIMARY KEY, name VARCHAR(255));
  * CREATE TABLE login (username serial PRIMARY KEY, password VARCHAR(255), child_id INT)
  * CREATE TABLE child_events (id serial PRIMARY KEY, child_id INT, event_id INT, time DATETIME)

3. Start your local server using MAMP.
4. Navigate to $ cd ChildDevelopment.Solution/ChildDevelopment folder in your terminal.
5. Type 'dotnet run' to run a localhost. Navigate to 'http://localhost:5000/' to interact with the website.

## Support and contact details

If you have any questions or suggestions please feel free to email:
* gulzat.karimova@gmail.com
* glen_sale@yahoo.com
*
*

## Technologies Used
* VS Code
* C#
* .NET Core
* Google Chart
* MySql
* MAMP
* GitHub
* HTML
* CSS


## License
This software is licensed under the MIT license
Copyright (c) 2018 (Gulzat Karimova)
