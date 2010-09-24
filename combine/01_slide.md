!SLIDE 
# Separation of concerns #

* Descriptions shouldn't have "and"
* Complexity normally means it's time to break things apart
* Side effects means break things apart
* If testing isn't obvious, often too much is happening

!SLIDE
# Spaghetti code #

* Side effects!
* Testing isn't obvious
* A sympton of lack of separation of concerns

!SLIDE 
# Class Types #

* Last word(s) in the class name should describe it
* DataService: accesses data, often the db, VisitDataService, Dao isn't as descrive
* Service: provides business logic functionality to entities, often with the help of other services, helpers, and/or data services
* Extentions: provides extention methods to some type(s) of objects - i.e. StringExtentions
* Controller: only used in the MVC framework, avoid uses elsewhere
* Provider: factory classes
* entities, who should not contain any real business logic, just property bags, do not need a descriptor

!SLIDE 
# Interfaces #

* Interfaces are contracts, we assume using them that we are working with black boxes
* examples of this behavior
