using RoslynPad.UI;

namespace RoslynPad;

[Export(typeof(IAppDispatcher))]
public class AppDispatcher : DispatcherObject, IAppDispatcher
{
    public AppDispatcher()
    {
        Application.Current.DispatcherUnhandledException += (_, args) =>
        {
            if (UnhandledException is { } handler)
            {
                handler(args.Exception);
                args.Handled = true;
            }
        };
    }

    public void InvokeAsync(Action action, AppDispatcherPriority priority = AppDispatcherPriority.Normal,
        CancellationToken cancellationToken = new CancellationToken())
    {
        _ = InternalInvoke(action, priority, cancellationToken);
    }

    public Task InvokeTaskAsync(Action action, AppDispatcherPriority priority = AppDispatcherPriority.Normal,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return InternalInvoke(action, priority, cancellationToken).Task;
    }

    public event Action<Exception>? UnhandledException;

    private DispatcherOperation InternalInvoke(Action action, AppDispatcherPriority priority, CancellationToken cancellationToken)
    {
        return Dispatcher.InvokeAsync(action, ConvertPriority(priority), cancellationToken);
    }

    private DispatcherPriority ConvertPriority(AppDispatcherPriority priority)
    {
        return priority switch
        {
            AppDispatcherPriority.Normal => DispatcherPriority.Normal,
            AppDispatcherPriority.High => DispatcherPriority.Send,
            AppDispatcherPriority.Low => DispatcherPriority.Background,
            _ => throw new ArgumentOutOfRangeException(nameof(priority), priority, null),
        };
    }
}
