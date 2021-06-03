using System;

namespace ARHome.GenericSubDomain.Background
{
    public interface IPollingServiceOptions
    {
        TimeSpan MaxPollingInterval { get; set; }
        TimeSpan PollingIntervalFade { get; set; }
        int MaxThreadCount { get; set; }
    }
    
    public class PollingServiceOptions : IPollingServiceOptions
    {
        public TimeSpan MaxPollingInterval { get; set; }
        public TimeSpan PollingIntervalFade { get; set; }
        public int MaxThreadCount { get; set; }
    }
}