!SLIDE 
# Why do we test #

Because we mess shit up

* Promotes writing better code from the start
* catch regressions, esp. edge cases
* provides confidence that new features are non-destructive
* "Will this refactoring breaking something"
* increases quality of delivered product

!SLIDE

# Why TDD #

* It's a buzzword, duh
* Demonstrates understand of requirements from the start
* Includes test coverage from the start
* reduces false positives
* Allows easily refactoring
* prevents overdevelopment
* promotes good OO

!SLIDE

# Mocking & Isolation #

* Isolating code for testing is easy with SOC
* Makes refactoring easier
* Isolation locations of business logic allows changes to happen in one place
* Mocking allows the unit of code under test to not have to worry about other units it interacts with
* Mocking simplifies and speeds up test writing

!SLIDE
# Test Types #

* Integration: Testing the interaction of code vs something external (db, external web services, etc)
  - NHibernate map tests are a type of integration test
* Unit: Tests a single unit of code (a single method in a class)

!SLIDE
# How I learned to quit worrying and love CI #

* We should be running full test suites localy
* CI ensures code is always building
* Forces us to not leave code in a broken state, which can hamper others work
* Better than waiting until someone does a build/release before QA or production release
* public humliation encouages faster repair from a broken state

!SLIDE
# Code Coverage #

* CI provides coverage reports
* Can use dotCover locally
* If your tests are overlooking code, it's possible you haven't throught through all the conditions
* A good overall goal is on the order of 80% coverage - not all code needs it but all business logic should have it
