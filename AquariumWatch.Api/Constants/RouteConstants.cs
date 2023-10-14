using System;

namespace AquariumWatch.Api.Constants
{
    internal static class RouteConstants
    {
        public const string Aquariums = "/aquariums";
        public const string AquariumById = Aquariums + "/{id:int}";
    }
}
