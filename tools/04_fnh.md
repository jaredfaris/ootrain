!SLIDE smbullets small
# FluentNHibernate
* We can replace xml configuration with fluent code.
* Code is easier to read and we get some compile time checking and intellisense.


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
