﻿using System;

namespace EwaveLivraria.HostedServices.Extensions
{
    public interface IScheduleConfig<T>
    {
        string CronExpression { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
