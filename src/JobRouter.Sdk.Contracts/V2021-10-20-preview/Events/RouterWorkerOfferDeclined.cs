﻿namespace JasonShave.Azure.Communication.Service.JobRouter.Sdk.Contracts.V2021_10_20_preview.Events
{
    [Serializable]
    public class RouterWorkerOfferDeclined
    {
        public string WorkerId { get; set; }

        public string JobId { get; set; }

        public string ChannelReference { get; set; }

        public string ChannelId { get; set; }

        public string QueueId { get; set; }

        public string OfferId { get; set; }
    }
}