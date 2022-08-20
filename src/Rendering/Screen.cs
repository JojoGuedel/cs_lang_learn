using System;
using System.Collections.Generic;

class Screen
{
    public int Width { get => Console.BufferWidth; }
    public int Height { get => Console.BufferHeight; }

    List<ScreenContainer1> ContainerCollection;

    public Screen()
    {
        ContainerCollection = new List<ScreenContainer1>();
        
        // TODO: Make this as setting
        SetConsoleSize(120, 30);

        Console.CursorVisible = false;
        Console.Clear();
    }

    public void SetContainerCollection(List<ScreenContainer1> collection) 
    {
        ContainerCollection = collection;
        
        foreach (ScreenContainer1 sc in ContainerCollection) {
            sc.OnChanged += OnScreenContainerChanged;
            RedrawScreenContainer(sc);
        }
    }

    public void ClearContainerCollection() 
    {
        foreach (ScreenContainer1 sc in ContainerCollection)
            sc.OnChanged -= OnScreenContainerChanged;
        
        ContainerCollection = new List<ScreenContainer1>();
    }

    void RedrawScreenContainer(ScreenContainer1 container)
    {
        for (int y = 0; y < container.Height; y++)
        {
            if (container.Y >= Height)
                break;

            Console.SetCursorPosition(container.X, container.Y + y);

            for (int x = 0; x < container.Width; x++)
            {
                if (container.X >= Width)
                    break;

                ScreenChar screenChar = container.Content[x + y * container.Width];
                
                Console.ForegroundColor = screenChar.Color;
                Console.BackgroundColor = screenChar.BackgroundColor;

                Console.Write(screenChar.Char);
            }
        }
    }

    void OnScreenContainerChanged(ScreenContainer1 container)
    {
        RedrawScreenContainer(container);
    }


    // TODO: Fix this
    void SetConsoleSize(int width, int height)
    {
        if (width > Width)
        {
            Console.SetBufferSize(width, Height);
            // Console.SetWindowSize(width, Height);
        }
        else
        {
            // Console.SetWindowSize(width, Height);
            Console.SetBufferSize(width, Height);
        }

        if (height > Height)
        {
            Console.SetBufferSize(Width, height);
            // Console.SetWindowSize(Width, height);
        }
        else
        {
            // Console.SetWindowSize(Width, height);
            Console.SetBufferSize(Width, height);
        }
    }
}

// internal class Screen1
// {
//     private ObservableCollection<string> ScreenBuffer;

//     public Screen1()
//     {
//         ScreenBuffer = new ObservableCollection<string>();
//         ScreenBuffer.CollectionChanged += OnScreenBufferChanged;


//         SetConsoleSize(120, 40);
//         Console.CursorVisible = false;
//         Console.Clear();
//     }

//     private void OnScreenBufferChanged(object? Sender, EventArgs args)
//     {
//         Redraw();
//     }

//     private void Redraw()
//     {

//     }

//     private void SetConsoleSize(int width, int height)
//     {
//         int currentWindowWidth = Console.WindowWidth;
//         int currentWindowHeight = Console.WindowHeight;

//         if (width > currentWindowWidth)
//         {
//             Console.SetBufferSize(width, Console.BufferHeight);
//             Console.SetWindowSize(width, Console.WindowHeight);
//         }
//         else
//         {
//             Console.SetWindowSize(width, Console.WindowHeight);
//             Console.SetBufferSize(width, Console.BufferHeight);
//         }

//         if (height > currentWindowHeight)
//         {
//             Console.SetBufferSize(width, height + 1);
//             Console.SetWindowSize(width, height);
//         }
//         else
//         {
//             Console.SetWindowSize(width, height + 1);
//             Console.SetBufferSize(width, height);
//         }
//     }
// }