﻿namespace JasonShave.Azure.Communication.Service.Interaction.Sdk.Contracts.V2022_11_1.Events;

public record CallConnectionStateChanged(string CallConnectionId, string ServerCallId, string CallConnectionState);