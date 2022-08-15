using System;
using System.Collections.ObjectModel;

internal class Screen {
    private ObservableCollection<string> ScreenBuffer;

    public Screen() {
        ScreenBuffer = new ObservableCollection<string>();
        ScreenBuffer.CollectionChanged += OnScreenBufferChanged;

        
        SetConsoleSize(120, 40);
        Console.CursorVisible = false;
        Console.Clear();        
    }

    private void OnScreenBufferChanged(object? Sender, EventArgs args) 
    {
        Redraw();
    }

    private void Redraw()
    {
        
    }

    private void SetConsoleSize(int width, int height)
    {
        int currentWindowWidth = Console.WindowWidth;
        int currentWindowHeight = Console.WindowHeight;

        if (width > currentWindowWidth)
        {
            Console.SetBufferSize(width, Console.BufferHeight);
            Console.SetWindowSize(width, Console.WindowHeight);
        }
        else
        {
            Console.SetWindowSize(width, Console.WindowHeight);
            Console.SetBufferSize(width, Console.BufferHeight);
        }

        if (height > currentWindowHeight)
        {
            Console.SetBufferSize(width, height + 1);
            Console.SetWindowSize(width, height);
        }
        else
        {
            Console.SetWindowSize(width, height + 1);
            Console.SetBufferSize(width, height);
        }
    }
}