﻿using System.Text.Json;
using AutoFixture;
using JasonShave.Azure.Communication.Service.Interaction.Sdk.EventHandler;
using JasonShave.Azure.Communication.Service.Interaction.Sdk.EventHandler.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Interaction.Sdk.Tests;

public class CallingServerEventSenderTests
{
    [Fact(DisplayName = "Sending works")]
    public void Should_Send()
    {
        // arrange
        var fixture = new Fixture();
        var startEvent = fixture.Create<StartEvent>();
        var startEventJson = JsonSerializer.Serialize(startEvent);

        var mockEventCatalog = new Mock<IEventCatalog>();
        var mockEventConverter = new Mock<IEventConverter>();
        var mockEventDispatcher = new Mock<IEventDispatcher>();
        var mockLogger = new Mock<ILogger<InteractionEventPublisher>>();

        mockEventCatalog.Setup(c => c.Get(It.IsAny<string>())).Returns(typeof(StartEvent));
        mockEventConverter.Setup(c => c.Convert(It.IsAny<BinaryData>(), It.IsAny<Type>())).Returns(startEvent);
        mockEventDispatcher.Setup(d => d.Dispatch(It.IsAny<object>(), It.IsAny<Type>(), It.IsAny<string>()));

        var subject = new InteractionEventPublisher(
            mockLogger.Object,
            mockEventCatalog.Object, 
            mockEventDispatcher.Object,
            mockEventConverter.Object);

        // act
        subject.Publish(new BinaryData(startEvent), nameof(StartEvent), "test");

        // assert
        mockEventCatalog.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
        mockEventConverter.Verify(x => x.Convert(It.IsAny<BinaryData>(), It.IsAny<Type>()), Times.Once);
        mockEventDispatcher.Verify(x => x.Dispatch(It.IsAny<object>(), It.IsAny<Type>(), It.IsAny<string>()), Times.Once);
    }
}