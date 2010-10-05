!SLIDE smbullets small
# TDD Kata #

* Adopting Roy Osherove's <a href='http://osherove.com/tdd-kata-1/'>TDD Kata</a>
* Only bother testing for correct inputs, ignore invalids for now
* <span style='color: red'>Red</span> &#8594;
<span style='color: green'>Green</span> &#8594; Refactor


!SLIDE smbullets small
# Create A Simple String Calculator #

* Should have one public method `int Add(string numbers)`
* `Add` will accept a blank string or a string containing up to 2 numbers separated by commas
* `Add` will return the sum of input numbers 
* Start with `string.Empty` test case, then 1 number, then 2
* String.Empty == 0
* "1" == 1
* "1,2" == 3

!SLIDE small smbullets
# First tests:
* `Add_TakesBlankString_Returns0()`
* `Add_TakesOneNumber_ReturnsNumber()`
* `Add_TakesTwoCsNumbers_ReturnsSum()`


!SLIDE small smbullets
# New Requirement:
* `Add` should support any amount of numbers in the input string.
* `Add_TakesMultipleNumbers_ReturnsSum()`


!SLIDE smbullets small
# New Requirement:
* `Add` should support the newline character as an additional delimiter 
* `Add_TakesNumbersWithCommaOrNewline_ReturnsSum()`

* Ex: "1\n2,3" = 6


!SLIDE smbullets small
# New Requirement:
* `Add` should support an optional new delimiter given in the input string
* `Add_TakesNumbersWithCustomDelimiter_ReturnsSum()`
* "//[delimiter]\n[numbers]"
* Every existing test should still pass

* Ex: "//;\n1;2;3" = 6


!SLIDE smbullets small
# New Requirement:
* `Add` should throw an exception if a negative number is input
* `Add_TakesNegativeNumbers_ThrowsException()`
* Exception message: Negatives not allowed
* List all negatives in the exception

* Ex: "1\n2,-3,-4" should return an exception with a message "negatives not allowed: -3, -4" 


!SLIDE smbullets small
# New Requirement:
* `Add` should ignore input values greater than 1000
* `Add_TakesNumberOver1000_IgnoresNumber()`

* Ex: "1001,2" = 2
* Ex: "999,2" = 1001
* Ex: "1001,1002" = 0


!SLIDE smbullets small
# New Requirement:
* Add an overload to `Add` that takes an `IPrinter` and in the method calls the `Print()` method.
* Don't worry about how `IPrinter` works since it's a dependency.  Mock it.  Verify it is called.
* `Add_TakesNumbersAndIPrinter_CallsPrint`


!SLIDE smaller code
    @@@csharp
    public interface IPrinter
    {
      void Print(int number);
    }


!SLIDE smbullets small
# Check Coverage!
* DotCover should show 100%.


!SLIDE smbullets small
# Add The TDD Kata To Your Routine

* It helps focus on testing first
* It helps discovers better, faster ways of using the existing tools (e.g. live templates)
