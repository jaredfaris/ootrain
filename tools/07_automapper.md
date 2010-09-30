!SLIDE small smbullets
# Automapper

* Converts objects of one type to another
* Easy to use: `Mapper.Map<TFrom, TTo>(TFrom source)`
* Will try to automap properties that match names
* Easy to add own mappings

!SLIDE code smaller
    @@@csharp
    // Model
    var calendarEvent = new CalendarEvent
      {
        EventDate = new DateTime(2008, 12, 15, 20, 30, 0),
        Title = "Company Holiday Party"
      };

    // Configure AutoMapper
    Mapper.CreateMap<CalendarEvent, CalendarEventForm>()
      .ForMember(dest => dest.EventDate, 
                 opt => opt.MapFrom(src => src.EventDate.Date))
      .ForMember(dest => dest.EventHour, 
                 opt => opt.MapFrom(src => src.EventDate.Hour))
      .ForMember(dest => dest.EventMinute, 
                 opt => opt.MapFrom(src => src.EventDate.Minute));

    // Perform mapping
    CalendarEventForm form = 
      Mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);

    form.EventDate.ShouldEqual(new DateTime(2008, 12, 15));
    form.EventHour.ShouldEqual(20);
    form.EventMinute.ShouldEqual(30);
    form.Title.ShouldEqual("Company Holiday Party");
