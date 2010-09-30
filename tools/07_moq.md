!SLIDE bullets
# Moq

* Mocking framework for testing
* Used for isolation
* Needs interfaces, virtuals, or abstracts to mock

!SLIDE code smaller
    @@@csharp
    var mock = new Mock<IMagic>();

    mock.Setup(framework => framework.HatHasRabbit())
      .Returns(true)
      .AtMostOnce();

    // Hand mock.Object as a collaborator and exercise it, 
    // like calling methods on it...
    IMagic magic = mock.Object;
    bool needToFindRabbit = magic.HatHasRabbit();

    // Verify that the given method was indeed called 
    // with the expected value
    mock.Verify(framework => framework.HasHatRabbit());
