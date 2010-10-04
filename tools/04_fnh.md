!SLIDE smbullets small
# FluentNHibernate
* We can replace xml configuration with fluent code.
* Code is easier to read and we get some compile time checking and intellisense.
* A couple things FNH cannot do, fall back on xml if you have to


!SLIDE code smaller
# HBM XML Config
    @@@xml
    <?xml version="1.0" encoding="utf-8" ?>  
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"  
      namespace="QuickStart" assembly="QuickStart">  
 
      <class name="Cat" table="Cat">  
        <id name="Id">  
          <generator class="identity" />  
        </id>  
     
        <property name="Name">  
          <column name="Name" length="16" not-null="true" />  
        </property>  
        <property name="Sex" />  
        <many-to-one name="Mate" />  
        <bag name="Kittens">  
          <key column="mother_id" />  
            <one-to-many class="Cat" />  
          </bag>  
      </class>  
    </hibernate-mapping>


!SLIDE code smaller
# FluentNHibernate Map
    @@@csharp
    public class CatMap : 
      ClassMap<Cat>
    {
      public CatMap()
      {
        Id(x => x.Id);
        Map(x => x.Name)
          .Length(16)
          .Not.Nullable();
        Map(x => x.Sex);
        References(x => x.Mate);
        HasMany(x => x.Kittens);
      }
    }

!SLIDE smaller smbullets
# NHibernate Map Tests #
* We can write nunit integration tests for the NHibernate maps.
* These verify (non-destructively) that our maps work with actual DB objects.
* This is letting us catch more integration issues during testing rather than runtime.
* We should be writing these more often.

!SLIDE code smaller

    @@@csharp
    public class Employee
    {
      public virtual int Id { get; private set; }
      public virtual string FirstName { get; set; }
      public virtual string LastName { get; set; }
    }
 
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }

    [Test]
    public void CanCorrectlyMapEmployee()
    {
        new PersistenceSpecification<Employee>(session)
            .CheckProperty(c => c.Id, 1)
            .CheckProperty(c => c.FirstName, "John")
            .CheckProperty(c => c.LastName, "Doe")
            .VerifyTheMappings();
    }

!SLIDE small code
# NH and stored procs #

    @@@xml
    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" 
        auto-import="true" namespace="Example" 
        assembly="Example">
      <class name="Example.Documents" table="documents" 
             lazy="false">
        <id name="id" access="field">
          <generator class="native" />
        </id>
        <property name="name" column="name" type="String"/>
        <property name="date" column="date" type="date"/>
        <property name="author" column="author" 
                  type="String"/>
        <property name="doclink" column="doclink" 
                  type="String"/>
      </class>
    </hibernate-mapping>
