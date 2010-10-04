!SLIDE small
# Bringing Code Parts Together #


!SLIDE small smbullets
# Separation Of Concerns #
* SOC is separating the application into distinct parts that overlap as little as possible.
* If when describing a part of an application you say "and", it does too much.
* Complexity normally means it's time to break things apart.
* Side effects means something is doing multiple things. 
* If how to test a class isn't obvious, this is probably also the case. 

!SLIDE small smbullets
# Spaghetti Code #
* Spaghetti code is a symptom of lack of SOC.
* When A calls B and B calls A and C and then C gets a headache it's time to refactor.
* Spaghetti code almost always comes with a heap of side effects.
* Breaking the functionality into smaller units will let you untangle it.

!SLIDE code small
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

!SLIDE code small
# Better Stuff #
    @@@csharp
    public void Process(Order order)
    {
      var stuff1 = _stuff1DataService.Get();
      _rulesService.Apply(order, stuff1);

      var stuff2 = _stuff2DataService.Get();
      _mashupService.Mash(order, stuff2);
    }

!SLIDE small smbullets
# Class Types #

* Last word(s) in the class name should describe it
* DataService: accesses data, often the db, VisitDataService, Dao isn't as descrive
* Service: provides business logic functionality to entities, often with the help of other services, helpers, and/or data services
* Extentions: provides extention methods to some type(s) of objects - i.e. StringExtentions

!SLIDE small smbullets
# Class Types #

* Controller: only used in the MVC framework, avoid uses elsewhere
* Provider: factory classes
* Entities: should not contain any real business logic (just property bags) and do not need a descriptor

!SLIDE small smbullets
# State #
* Only entities should contain state.
* Services, DataServices, etc are stateless, they might ask for state but do not retain it
* If you find yourself setting public properties on classes a lot something is wrong.

!SLIDE small smbullets
# Interfaces #
* Interfaces are contracts.  
* We assume when we use them that we are working with black boxes.  
* We shouldn't care what they do internally.  That's their concern.
* If we have an IGeoMapProvider the caller shouldn't care if it uses the GoogleMapProvider or the MapQuestProvider.


!SLIDE smaller code
    @@@csharp

    interface IGeoMapProvider
    {
      MapObject GetMap(double lat, double long);
    }

    public class GoogleMapProvider : IGeoMapProvider
    {
      public MapObject GetMap(double lat, double long)
      {
        ...
        return googleMapObject;
      }
    }
    
    
    public class MapQuestMapProvider : IGeoMapProvider
    {
      public MapObject GetMap(double lat, double long)
      {
        ...
        return mapQuestMapObject;
      }
    }


!SLIDE small smbullets
# Control Statements

* `else` can be avoided, avoid it
* `finally` should be replaced with `using`
* `try` ... `catch` is not a control statement

!SLIDE smaller code
# '`else`' Doesn't Provide Value

    @@@csharp
    if (foo == string.Empty)
    {
      return magicValue;
    }
    else
    {
      return foo;
    }

# Better
    @@@csharp
    if (foo == string.Empty)
    {
      return magicValue;
    }
    return foo;

!SLIDE smaller code

    @@@csharp
    if (theDate == DateTime.MinValue)
    {
      foo = string.Empty;
    }
    else
    {
      foo = theDate.ToString();
    }

# Simplify!

    @@@csharp
    foo = string.Empty;
    if (theDate != DateTime.MinValue)
    {
      foo = theDate.ToString();
    }
