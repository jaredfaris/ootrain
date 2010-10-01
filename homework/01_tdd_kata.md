!SLIDE smbullets small
# TDD Kata #

* Adopting Roy Osherove's <a href='http://osherove.com/tdd-kata-1/'>TDD Kata</a>
* Only bother testing for correct inputs, ignore invalids for now
* <span style='color: red'>Red</span> &#8594;
<span style='color: green'>Green</span> &#8594; Refactor

!SLIDE smbullets small
# Create a simple string calculator #

* Should have one public method `int Add(string numbers)`
* `Add` will accept a blank string or a string containing up to 2 numbers separated by commas
* `Add` will return the sum of input numbers 
* Start with `string.Empty` test case, then 1 number, then 2

!SLIDE small smbullets
# New requirement:
* `Add` should support any amount of numbers in the input string.

!SLIDE smbullets small
# New requirement:
* `Add` should support the newline character as an additional delimiter 

* Ex: "1\n2,3" okay
* Ex: "1,\n" not okay

!SLIDE smbullets small
# New requirement:
* `Add` should support an optional new delimiter given in the input string

* "//[delimiter]\n[numbers]"
* Every existing test should still pass
* Ex: "//;\n1;2;3" = 6

!SLIDE smbullets small
# New requirement:
* `Add` should throw an exception if a negative number is input

* Exception message: Negatives not allowed
* List all negatives in the exception

!SLIDE smbullets small
# New requirement:
* `Add` should ignore input values greater than 1000

* Ex: "1001,2" = 2
* Ex: "999,2" = 1001
* Ex: "1001,1002" = 0

!SLIDE smbullets small
# Add The TDD Kata To Your Routine

* It helps focus on testing first
* It helps discovers better, faster ways of using the existing tools (e.g. live templates)
