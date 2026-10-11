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