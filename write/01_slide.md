!SLIDE 
# My Presentation #

!SLIDE 
# Readability #

* Guide Lines - conventions not contracts
* Naming - variables, methods, classes
* Resharper is pretty much our style cop
* Break up long sets of logic into descriptive parts
 -- examples
  -- LINQ stuff
  -- long code chains into method with reason names
  -- ?: condition operator, do not chain, ?? null collas..
  -- etc



!SLIDE center
# Crazy LINQ Chaining Mania #

<img src="crazy_linq_chaining.png" width="100%" alt="Ugh" />

Insane in da membrain

(Crazy insane, got no brain)

<span style="font-size: .7em;">Yes it's a Cyprus Hill reference. No we aren't sorry.</span>




!SLIDE center
# Cleaner LINQ #

![Readable](readable_linq_chaining.png)

!SLIDE 
# Size and complexity #

* if doesn't fit on your screen completely, it's too long
* if it's so complex that it needs to be tested seperatly, it should be an seperate class -- i.e. don't try to test private methods
* high cyclomatic complexity are candiates for refactoring (too many if's)
* if explaining the method is longer than the method, refactor to
  - name variabling more meaningful
  - add submethod calls that have meaningful names
* if you have to use "and" to describe what a method of class does, split it (i.e. x and y and z) -- move into doing one thing well

!SLIDE 
# Commenting Complexity #

* Empty xml comments are worse than no comments
* Using naming
* use block comments that are meaningful to what is happening - not change logs
* we have SVN history, use it
* Don't preserve old code
* If anyone can't tell what's happen at first glance, needs more comments/better naming/less magic
  - such as we hire a new person, they shouldn't be fumbling for meaning when looking at code
* clever does not mean maintainable

!SLIDE 
# Doing one thing well #

* Type descriptions...
* be able to easily describe any classes in english before you start
  - put in xml comment
* Describe a class' purpose without using "and", should be descriptive and simple to understand exactly what side effects will happen when you use it
* additional side effects mean it doesn't one thing only
* side effects shouldn't exist at the data service level; but at the business logic level
* Isolation should just "happen" and testing shouldn't be "hard"

!SLIDE 
# Clean up after yourself #
# We are not your mom #

* Delete unused code
* remove unneeded comments
* remove unused files from the solution, SVN
* always review and refactor what you have written when it's done to clean up
  - everything can use the extra love
