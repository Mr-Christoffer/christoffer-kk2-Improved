# christoffer-kk2-Improved
## Error 1:
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ShoppingList.Load() in C:\Code\Christoffer-kk2-robust\ShoppingList.cs:line 90
   at Program.<Main>$(String[] args) in C:\Code\Christoffer-kk2-robust\Program.cs:line 2
* Fixed by adding a try catch to the load method in Shoppinglist class..

## Error 2:
If user types a non-number character as price, the program will crash.
* Fixed by adding a try catch. Also put input price in a whileloop so when prohibited character is used, user will be asked to input price again. *

## Error 3:
Items from file doesnt show their name when printed.
* Fixed by changing split to ReadAllLines in Load-method

## Error 4:
Program crashes when user tries to delete a non-existing item
* Fixed by adding a try catch in program.cs

## Error 5:
Program crashes if user enters a character which is not a choice (1-5)
* Fixed by putting the whole meny under an if-block

## Error 6:
Program crashes if "items.txt" doesnt exist (or has a different namne)
* Fixed by checking if the file exists before it gets loaded. If it doesnt exists, program will create one.

## Error 7:
Calculation of total sum is incorrect. First item doesn't included in calculation.
* Fixed by changing int i = 1 to int i = 0 in Shoppinglist Total-method

# Design choices
Added a fixed budget to shoppinglist class. When trying to add item, the add-method will check if the budget allows for it. A error message will be shown if the budget does not allow a new item.