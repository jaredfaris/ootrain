!SLIDE small
# Bringing Code Parts Together #


!SLIDE bullets
# Separation of concerns #

* Descriptions shouldn't have "and"
* Complexity normally means it's time to break things apart
* Side effects means break things apart
* If testing isn't obvious, often too much is happening

!SLIDE bullets
# Spaghetti code #

* Side effects!
* Testing isn't obvious
* A sympton of lack of separation of concerns

!SLIDE code
# Bad Stuff #
    @@@csharp
    public void Process(Order order)
    {
      // retrieve stuff from db
      
      // apply some buiness rule to order

      // retrieve more stuff from db

      // mash it all together

      // apply more business rules
    }

!SLIDE code
# Better stuff #
    @@@csharp
    public void Process(Order order)
    {
      var stuff1 = _stuff1DataService.Get();
      _rulesService.Apply(order, stuff1);

      var stuff2 = _stuff2DataService.Get();
      _mashupService.Mash(order, stuff2);
    }

!SLIDE bullets
# Class Types #

* Last word(s) in the class name should describe it
* DataService: accesses data, often the db, VisitDataService, Dao isn't as descrive
* Service: provides business logic functionality to entities, often with the help of other services, helpers, and/or data services
* Extentions: provides extention methods to some type(s) of objects - i.e. StringExtentions

!SLIDE bullets
# Class Types #

* Controller: only used in the MVC framework, avoid uses elsewhere
* Provider: factory classes
* entities, who should not contain any real business logic, just property bags, do not need a descriptor

!SLIDE bullets
# State #
* Only entities should really contain state
* Services, DataServices, etc are stateless, 
they might ask for state but do not retain it

!SLIDE bullets
# Interfaces #

* Interfaces are contracts, we assume using them that we are working with black boxes
* examples of this behavior
