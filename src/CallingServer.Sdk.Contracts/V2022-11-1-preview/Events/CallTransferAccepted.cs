﻿// Copyright (c) 2022 Jason Shave. All rights reserved.
// Licensed under the MIT License.

namespace JasonShave.Azure.Communication.Service.CallingServer.Sdk.Contracts.V2022_11_1_preview.Events;

public class CallTransferAccepted : BaseCallingEvent
{
    public string OperationContext { get; }

    public ResultInformation ResultInformation { get; }

    public CallTransferAccepted(string operationContext, ResultInformation resultInformation, string callConnectionId, string? serverCallId, string correlationId)
        : base(callConnectionId, serverCallId, correlationId)
    {
        OperationContext = operationContext;
        ResultInformation = resultInformation;
    }
}