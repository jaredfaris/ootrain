!SLIDE small smbullets
# Moq

* Moq is a mocking framework for testing.
* We use it for isolation so we can test individual elements.
* You can only mock interfaces, virtuals, or abstracts.
* Good DI makes it easy to mock things.


!SLIDE code smaller
# A Simple Mocked Object #
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
