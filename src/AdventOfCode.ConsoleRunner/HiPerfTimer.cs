using System.Runtime.InteropServices;

namespace AdventOfCode;

/// <summary>
///     High performance timer class
/// </summary>
public class HiPerfTimer
{
    private const string DurationMsTemplate = "Duration: {0} ms";
    public const int MsConversionFactor = 1000;
    private readonly long _freq;
    private long _startTime, _stopTime;

    /// <summary>
    ///     Constructor
    /// </summary>
    public HiPerfTimer()
    {
        try
        {
            _startTime = 0;
            _stopTime = 0;

            if (QueryPerformanceFrequency(out _freq) == false)
                // high-performance counter not supported
                throw new Exception("high-performance counter not supported");
        }
        catch (Exception)
        {
            throw new Exception("high-performance counter not supported");
        }
    }


    /// <summary>
    ///     Returns the duration of the timer (in milliseconds)
    /// </summary>
    public double Duration => (_stopTime - _startTime) / (double)_freq * MsConversionFactor;

    /// <summary>
    ///     Returns the duration of the timer (in milliseconds)
    /// </summary>
    public string DurationMs =>
        string.Format(DurationMsTemplate, (_stopTime - _startTime) / (double)_freq * MsConversionFactor);

    /// <summary>
    ///     Returns the duration of the timer, formatted as a single string.
    /// </summary>
    public string DurationFormatted
    {
        get
        {
            var totalMilliseconds = (_stopTime - _startTime) / (double)_freq * MsConversionFactor;
            var totalSeconds = totalMilliseconds / MsConversionFactor;
            var totalMinutes = totalSeconds / 60;

            return string.Format("{0:0.####} ms, {1:0.####} sec, {2:0.####} min", totalMilliseconds, totalSeconds,
                totalMinutes);
        }
    }

    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceFrequency(out long lpFrequency);

    /// <summary>
    ///     Start the timer
    /// </summary>
    public void Start()
    {
        Reset();

        // lets do the waiting threads there work
        Thread.Sleep(0);
        QueryPerformanceCounter(out _startTime);
    }

    /// <summary>
    ///     Stops the timer.
    /// </summary>
    public void Stop()
    {
        QueryPerformanceCounter(out _stopTime);
    }

    public void Reset()
    {
        _startTime = 0;
        _stopTime = 0;
    }
}