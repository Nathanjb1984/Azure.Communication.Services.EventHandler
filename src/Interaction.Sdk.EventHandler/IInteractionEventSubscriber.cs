﻿using JasonShave.Azure.Communication.Service.Interaction.Sdk.Contracts.V2022_11_1_preview.Events;

namespace JasonShave.Azure.Communication.Service.Interaction.Sdk.EventHandler;

public interface IInteractionEventSubscriber
{
    event Func<IncomingCall, string, Task>? OnIncomingCall;
    event Func<CallConnectedEvent, string, Task>? OnCallConnected;
    event Func<CallDisconnectedEvent, string, Task>? OnCallDisconnected;
    event Func<CallConnectionStateChanged, string, Task>? OnCallConnectionStateChanged;
}