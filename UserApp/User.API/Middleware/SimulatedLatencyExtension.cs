namespace User.API.Middleware
{
    public static class SimulatedLatencyExtension
    {
        public static IApplicationBuilder UseSimulatedLatency(
            this IApplicationBuilder app,
            TimeSpan                 min,
            TimeSpan                 max
        )
        {
            return app.UseMiddleware(
                typeof(SimulatedLatencyMiddleware),
                min,
                max
            );
        }
    }
}