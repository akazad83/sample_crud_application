using System;
using CovidClinic.Application.Common.Interfaces;

namespace CovidClinic.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
