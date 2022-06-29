﻿using JasonShave.Azure.Communication.Service.Interaction.Sdk.EventHandler.Interfaces;

namespace JasonShave.Azure.Communication.Service.Interaction.Sdk.EventHandler;

internal class EventCatalogService : IEventCatalog
{
    private const string _eventPrefix = "Microsoft.Communication.";
    private readonly Dictionary<string, Type> _eventCatalog = new();

    public IEventCatalog Register<TEvent>()
    {
        _eventCatalog.Add(typeof(TEvent).Name, typeof(TEvent));
        return this;
    }

    public Type? Get(string eventName)
    {
        _eventCatalog.TryGetValue(eventName.Replace(_eventPrefix, ""), out var eventType);
        return eventType;
    }
}