using Microsoft.AspNetCore.Components.Web;

namespace Typist.WasmApp;

public class EventBus
{
    public event Action<KeyboardEventArgs>? OnKeyDown;
    public event Action<string>? OnTextInput;

    public void RaiseKeyDownEvent(KeyboardEventArgs args)
    {
        OnKeyDown?.Invoke(args);
    }

    public void RaiseTextInputEvent(string text)
    {
        OnTextInput?.Invoke(text);
    }
}
