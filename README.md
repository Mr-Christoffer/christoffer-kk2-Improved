# christoffer-kk2-Improved
## Error 1:
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ShoppingList.Load() in C:\Code\Christoffer-kk2-robust\ShoppingList.cs:line 90
   at Program.<Main>$(String[] args) in C:\Code\Christoffer-kk2-robust\Program.cs:line 2
* Fixed by adding a try catch to the load method in Shoppinglist class..