!SLIDE small smbullets
# StructureMap #
* StructureMap is a tool for Dependency Injection/Inversion of Control
* It makes "doing it right" easier by making it simpler to decouple code.
* If a class is dependent on a bunch of other classes StructureMap magically handles it.
* Get in the habit of writing things stateless and Structure Map will let us easily use singletons.

!SLIDE smaller code
# StructureMap #
    @@@csharp
    public static class CatBootstrapper()
    {
      ObjectFactory.Initialize(x => 
      {
        x.For<IMouse>().Use<Mouse>();
        x.For<ICatPerch>().Use<TopOfBookshelf>();
        x.For<ICat>().Use<Cat>();
      });
    }

    ...

    public class Cat(IMouse mouse, ICatPerch perch) { ... }

    ...

    public void SomeMethodSomewhere()
    {
      // StructureMap will automatically initialize dependencies
      var cat = ObjectFactory.GetInstance<ICat>();
      // Now you have a Cat object 
      cat.ChaseMouse();
    }
