!SLIDE smbullets small 
# Why do we test? #

* Promotes writing better code and thinking about your code
* Allows us to easily catch regressions and edge case concerns
* Answers "Will this refactoring break something"
* Increases quality of delivered product for very little investment

!SLIDE smbullets small
# Testing for better code #

* Testing aspects of the code, in isolation, increase confidence that the
code will perform as expected and meet its requirements. 
* Write tests before hand matching the stated requirements.
* The basic testing methodology is:
* <span style='color: red'>Red</span> &#8594;
<span style='color: green'>Green</span> &#8594; Refactor

!SLIDE smbullets small
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

!SLIDE smbullets small
# Magnum.TestFramework Assertions (Extentions) #

* `ShouldBeTrue()`
* `ShouldBeFalse()`
* `ShouldBeEmpty<T>(ICollection<T>)`
* `ShouldNotBeEmpty<T>(ICollection<T>)`
* `ShouldBeEqual<T>(T obj)`
* etc
* All extension methods, should be discoverable if the namespace is added.

!SLIDE code smaller
    @@@csharp
    [Scenario]
    public class Order_Test
    {
      [Given]
      public void An_order()
      {
        Order = new Order();
      }

      public Order Order { get; set; }
    }

    [Scenario]
    public class Future_orders_should_be_invalid :
      Order_Test
    {
      [When]
      public void A_future_date_is_given()
      {
        Order.OrderDate = DateTime.Now.AddDays(3);
      }
    
      [Then]
      public void Should_be_invalid()
      {
        Order.IsValid.ShouldBeFalse();
      }
    }

!SLIDE small
# Add A New Requirement To The Statement #

!SLIDE code smaller
    @@@csharp
    [Scenario]
    public class Future_orders_should_be_invalid :
      Order_Test
    {
      [When]
      public void A_future_date_is_given()
      {
        Order.OrderDate = DateTime.Now.AddDays(3);
      }
    
      [Then]
      public void Should_be_invalid()
      {
        Order.IsValid.ShouldBeFalse();
      }

      [Then]
      public void Should_have_message()
      {
        Order.ValidMessages
          .ShouldContain("Order Date is in the future.");
      }
    }

!SLIDE smbullets small
# More Testing #

* Tests that are just plain unit tests can still use NUnit attributes.
* Many defects can be just normal tests.
* This provides value for behaviors, used when testing is driving development.

!SLIDE smbullets small

# Why TDD? #

* Forces understanding of requirements the start
* Assumes full test coverage
* Reduces false positives
* Allows easily refactoring
* Prevents over-development
* Promotes good OO

!SLIDE smbullets small

# Mocking & Isolation #

* Isolating code for testing is easy with SOC
* Makes refactoring easier
* Isolation locations of business logic allows changes to happen in one place
* Mocking allows the unit of code under test to not have to worry about what it interacts with 
* Mocking simplifies and speeds up test writing

!SLIDE smbullets small
# Test Types #

* Integration: Testing the interaction of code vs something external (db, external web services, etc)
* NHibernate map tests are a type of integration test
* Unit: Tests a single unit of code (a single method in a class)

!SLIDE smbullets small
## How I Learned To Quit Worrying And Love CI ##

* We should be running full test suites locally.
* CI ensures our code is always building.
* It forces us to not leave code in a broken state, which can hamper other devs
* It's better than waiting until someone does a build/release before a QA or production release
* Public humiliation encourages faster repair from a broken state!

!SLIDE smbullets small
# Code Coverage #
* We generate code coverage reports in our CI process.  Look at them.
* You can also run dotCover locally while you write your code.
* If your tests are overlooking code, it's possible you haven't thought through all the complications.
* A good goal is 80%+ coverage - not all code needs it but all business logic should have it.
