!SLIDE bullets
# TDD Kata #

* Adopting Roy Osherove's <a href='http://osherove.com/tdd-kata-1/'>TDD Kata</a>
* Only bother testing for correct inputs, ignore invalids for now
* <span style='color: red'>Red</span> &#8594;
<span style='color: green'>Green</span> &#8594; Refactor

!SLIDE bullets
# Create a simple string calculator #

* Should have `int Add(string numbers)`
* `numbers` can contain 0 to 2 numbers
* values will be comma seperated
* method will return the sum of values in `numbers`
* Start with `string.Empty` test case, then 1 number, then 2

!SLIDE
# `Add` should support any number of values in `numbers`

!SLIDE bullets
# `Add` should support newline as seperator

* Ex: "1\n2,3" okay
* Ex: "1,\n" not okay

!SLIDE bullets
# `Add` can discover delimiter from `numbers`

* "//[delimiter]\n[numbers]"
* Every existing test should still pass
* Ex: "//;\n1;2;3" = 6

!SLIDE bullets
# Negative values in `numbers` will cause an exception

* Exception message: Negatives not allowed
* List all negatives in the exception

!SLIDE bullets
# Ignore values greater than 1000

* Ex: "1001,2" = 2
* Ex: "999,2" = 1001
* Ex: "1001,1002" = 0

!SLIDE bullets
# Do this reguarlly

* It helps focus on testing first
* It helps discovers better, faster ways of using the existing tools
