using System.Globalization;

namespace Chapter05.Exercises.Exercise5_04;

public static class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine($" {DateTime.Now:T} [{Thread.CurrentThread.ManagedThreadId:00}] {message}");
    }
}

public class SlowRunningService
{
    public Task<double> Fetch(TimeSpan delay, CancellationToken token)
        /* Adding the first slow running operation, Fetch that is passed
         a time delay - Thread.Sleep -  and cancellation token passed
         to Task.Run*/
    {
        return Task.Run(() =>
        {
            var now = DateTime.Now;
            Logger.Log("Fetch: Sleeping");
            Thread.Sleep(delay);
            Logger.Log("Fetch: Awake");

            return DateTime.Now.Subtract(now).TotalSeconds;
        }, token);
    }

    public Task<double?> FetchLoop(TimeSpan delay, CancellationToken token)
    {
        return Task.Run(() =>
        {
            const int TimeSlice = 500;
            var iterations = (int)(delay.TotalMilliseconds / TimeSlice);

            Logger.Log($"FetchLoop: Iterations={iterations} token={token.GetHashCode()}");

            var now = DateTime.Now;

            for (var i = 0; i < iterations; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Logger.Log($"FetchLoop: Iteration {i + 1} detected cancellation token={token.GetHashCode()}");
                    //token.ThrowIfCancellationRequested();
                    //break;
                    return (double?)null;
                }

                Logger.Log($"FetchLoop: Iteration {i + 1} Sleeping");
                Thread.Sleep(TimeSlice);
                Logger.Log($"FetchLoop: Iteration {i + 1} Awake");
            }

            Logger.Log("FetchLoop: done");

            return DateTime.Now.Subtract(now).TotalSeconds;
        }, token);
    }
}

public class Program
{
    private static readonly TimeSpan DelayTime = TimeSpan.FromSeconds(3);
    // Test if Fetch will just stop or returns a number

    private static TimeSpan? ReadConsoleMaxTime(string message)
    {
        Console.Write($"{message} Max waiting Time (seconds) : ");

        var input = Console.ReadLine();

        if (int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var intResult))
            return TimeSpan.FromSeconds(intResult);

        return null;
    }

    public static async Task Main()
    {
        var service = new SlowRunningService();

        /*A loop that asks for a maximum delay time. Which allows us to see how different values
         affects cancel token and the values we receive back*/
        Console.WriteLine($"ETA : {DelayTime.TotalSeconds:N} seconds");

        TimeSpan? maxWaitingTime;
        while (true)
        {
            maxWaitingTime = ReadConsoleMaxTime("Fetch");
            if (maxWaitingTime == null)
                break;

            using var tokenSource = new CancellationTokenSource(maxWaitingTime.Value);
            var token = tokenSource.Token; // will trigger cancellation w/o having to call Cancel

            //Logs a message when CancellationToken.Register invokes an Action delegate that signals for cancellation.
            token.Register(() => Logger.Log($"Fetch: Cancelled token = {token.GetHashCode()}"));

            var resultTask = service.Fetch(DelayTime, token);

            try
            {
                await resultTask;

                Logger.Log(resultTask.IsCompletedSuccessfully
                    ? $"Fetch: Result = {resultTask.Result:N0}"
                    : $"Fetch: Status = {resultTask.Status}");
            }
            catch (TaskCanceledException ex)
            {
                Logger.Log($"Fetch: TaskCanceledException {ex.Message}");
            }
        }

        while (true)
        {
            maxWaitingTime = ReadConsoleMaxTime("FetchLoop");
            if (maxWaitingTime == null)
                break;

            using var tokenSource = new CancellationTokenSource(maxWaitingTime.Value);
            var token = tokenSource.Token;
            token.Register(() => Logger.Log($"FetchLoop: Cancelled token={token.GetHashCode()}"));
            var resultTask = service.FetchLoop(DelayTime, token);

            try
            {
                await resultTask;
                Logger.Log(resultTask.IsCompletedSuccessfully
                    ? $"FetchLoop: Result={resultTask.Result:N0}"
                    : $"FetchLoop: Status={resultTask.Status}");
            }
            catch (TaskCanceledException ex)
            {
                Logger.Log($"FetchLoop: TaskCanceledException {ex.Message}");
            }
        }
    }
}