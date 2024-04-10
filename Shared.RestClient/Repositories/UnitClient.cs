﻿using Shared.RestClient.Interfaces;

namespace Shared.RestClient.Repositories
{
    internal class UnitClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), IUnitClient
    {
    }
}
