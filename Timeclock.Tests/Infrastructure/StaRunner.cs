using System;
using System.Threading;
using Xunit.Sdk;

namespace Dangerwolf.Timeclock.Tests.Infrastructure;

/// <summary>
/// xUnit Fact that runs on an STA thread, required for WinForms UserControl instantiation.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
[XunitTestCaseDiscoverer("Xunit.Sdk.FactDiscoverer", "xunit.execution.{Platform}")]
public sealed class StaFactAttribute : FactAttribute { }

/// <summary>
/// Runs an action on a dedicated STA thread and rethrows any exception on the calling thread.
/// </summary>
public static class StaRunner
{
    public static void Run(Action action)
    {
        Exception? caught = null;

        var thread = new Thread(() =>
        {
            try { action(); }
            catch (Exception ex) { caught = ex; }
        });

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();

        if (caught != null)
            System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(caught).Throw();
    }
}
