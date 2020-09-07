# A boat rental project

To set up this project- Run the following commands on "Package Manger Console" in order to setup Database.

1. Add-Migration BoatProject.Data.BoatProjectContext
2. update-database
If u face any issue after running above command please updatethe server/host name in "appsetting.json" file.


# User story 1: 
Follow these stpes: 
User will get "Create New Boat" link at the top.

User will get two input boxes where they can register a boat.
User inputs: Boat Name and Boat Hourly Rate.
Result: On Success user will be redirected to list view page
where they can see a new row is added with a BOat Numebr.

# User Story 2:
Follow these stpes: 
User will get link "Register boat to a customer" at the top of List view page.

User can record a boat as rented to the customer.
User Inputs: Customer Name, Boat Number
Result: 1. On Success user will be redirect to listview page where the row will reflect customer 	   associated with it and iscurrently rented.
        2. On Error:user will get a msg as "Boat is not available".
