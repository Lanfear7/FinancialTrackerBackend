﻿using FinancialTracker.Models;
using FinacialTrackerApplication.Models;

namespace FinancialTracker.Interfaces
{
    public interface ITrackerRepository
    {
        public IEnumerable<TrackerTransactionsModel> GetUsersTrackers(int userId);
    }
}