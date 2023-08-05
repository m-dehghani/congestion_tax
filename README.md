## Congestion-tax-calculator
There are three options available for implementing the logic:

1. Using simple conditionals
2. using table-driven programming
3. using the chain of responsibility pattern

__Table-Driven development__:
    it uses lookup arrays instead of using simple sequences of if-then-else blocks. for example, if we want to know the no. of days in a given month a clumsy way is:
```c#
if ( month = 1 )
  days = 31
else if ( month = 2 )
  days = 28
else if ( month = 3 )
  days = 31
else if ( month = 4 )
  days = 30
else if ( month = 5 )
  days = 31
else if ( month = 6 )
  days = 30
else if ( month = 7 )
  days = 31
.
.
.
```
   An easier and more modifiable way to perform the same function is to put the data in
a table:
```C#
int[] daysPerMonth = new int[]
  { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }

days = daysPerMonth[month-1]
```
   we can use a _two-dimensional array_ here for tax calculation. Instead of the array, we can use a _hash table_ which is also faster than arrays.

__chain of responsibilities design pattern__
   Here we can use another way for more complex problems which is also more maintainable than the previous two.  define a base handler class with the _Handle_ method which contains the rule or logic.
For each logic or rule, we implement the base class and override the _Handle_ method. Also, each handler should pass the result of its calculation to the next handler. By using this pattern we can add new rules for calculation for each city on the fly. we can store the city's tax calculation rules in external storage and in the run time create classes that contain some sort of dynamic expressions for the particular city and invoke that expression at the run time. 


   I used the first method(simple conditionals) because the project is small and the logic isn't very complicated. But for the bigger and more complex rules other options might be better. 

   In this project, I've read cities' data from the CSV file which is also a simple and maintainable option.

   I've also used a simplified clean architecture for the project.
