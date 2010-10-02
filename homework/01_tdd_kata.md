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

* Ex: "1\n2,3" okay
* Ex: "1,\n" not okay (don't test for an explicit failure)


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
* New method `TranslateNumber` which takes an `ITranslator` engine and returns the given number as a string.
* Don't worry about how `ITranslator` works since it's a dependancy.  Mock it.
* `TranslateNumber_TakesNumberAndTranslator_ReturnsString`
* Copy this ITranslator code:

!SLIDE smbullets small
# Add The TDD Kata To Your Routine

* It helps focus on testing first
* It helps discovers better, faster ways of using the existing tools (e.g. live templates)
