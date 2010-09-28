!SLIDE bullets 
# Why do we test #

* Promotes writing better code from the start
* Easily catch regressions and edge case concerns
* "Will this refactoring breaking something"
* Increases quality of delivered product

!SLIDE bullets
# Testing for better code #

* Testing aspects of the code, in isolation, increase confidence that the
things will perform as expected and met the requirements. 
* Write tests before hand matching the stated requirements 
* <span style='color: red'>Red</span> &#8594;
<span style='color: green'>Green</span> &#8594; Refactor

!SLIDE smbullets
# Magnum.TestFramework Attributes #

* `[TestFixture]` &#8594; `[Scenario]` 
* `[TestFixtureSetup]` &#8594; `[Given]`, `[When]`
* `[Test]` &#8594; `[Then]`
* `[TestFixtureTearDown]` &#8594; `[After]`, `[Finally]`

* `[Category("Database")]` &#8594; `[Database]`
* `[Category("Slow")]` &#8594; `[Slow]`
* `[Category("Integration")]` &#8594; `[Integration]`
* `[Category("NotWorking")]` &#8594; `[NotWorking]`

* `[Explicit("Not Yet Implemented")]` &#8594; `[NotYetImplemented]`

!SLIDE smbullets
# Magnum.TestFramework Assertions (Extentions) #

* `ShouldBeTrue()`
* `ShouldBeFalse()`
* `ShouldBeEmpty<T>(ICollection<T>)`
* `ShouldNotBeEmpty<T>(ICollection<T>)`
* `ShouldBeEqual<T>(T obj)`
* etc
* All extention methods, should be discoverable if the namespace is added

!SLIDE code smaller
    @@@csharp
    [Scenario]
    public class Future_orders_should_be_invalid
    {
      Order _order;
      
      [Given]
      public void An_order_with_a_future_date()
      {
        _order = new Order();
        _order.OrderDate = 
          DateTime.Now.AddDays(3);
      }
    
      [Then]
      public void Should_return_invalid()
      {
        _order.IsValid.ShouldBeFalse();
      }
    }

!SLIDE bullets
# More Testing #

* Tests that are just plain unit tests can still use NUnit attributes
* Also, many defects can be just normal tests
* This provides value for behaviors, used when testing is driving development

!SLIDE bullets

# Why TDD #

* Forces understanding of requirements the start
* Includes test coverage from the start
* Reduces false positives
* Allows easily refactoring
* Prevents overdevelopment
* Promotes good OO

!SLIDE bullets

# Mocking & Isolation #

* Isolating code for testing is easy with SOC
* Makes refactoring easier
* Isolation locations of business logic allows changes to happen in one place
* Mocking allows the unit of code under test to not have to worry about other units it interacts with
* Mocking simplifies and speeds up test writing

!SLIDE bullets
# Test Types #

* Integration: Testing the interaction of code vs something external (db, external web services, etc)
* NHibernate map tests are a type of integration test
* Unit: Tests a single unit of code (a single method in a class)

!SLIDE bullets
# How I learned to quit worrying and love CI #

* We should be running full test suites localy
* CI ensures code is always building
* Forces us to not leave code in a broken state, which can hamper others work
* Better than waiting until someone does a build/release before QA or production release
* public humliation encouages faster repair from a broken state

!SLIDE bullets
# Code Coverage #

* CI provides coverage reports
* Can use dotCover locally
* If your tests are overlooking code, it's possible you haven't throught through all the conditions
* A good overall goal is on the order of 80% coverage - not all code needs it but all business logic should have it
