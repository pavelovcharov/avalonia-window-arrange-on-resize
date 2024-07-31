using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication32;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ViewModel();
    }

    private void TopLevel_OnOpened(object? sender, EventArgs e)
    {
        // Width = 800;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Width = 800;
    }
}

public class ViewModel : ObservableObject
{
    public IEnumerable<ItemViewModel> Items { get; }

    public ViewModel()
    {
        List<ItemViewModel> items = new();
        Random rand = new(DateTime.Now.Millisecond);
        for (int i = 0; i < 200; i++)
        {
            var r = rand.Next(255);
            var item = new ItemViewModel(i.ToString(), new SolidColorBrush(){ Color = new Color(255, (byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255))});
            items.Add(item);
        }

        Items = items;
    }
    
}

public partial class ItemViewModel : ObservableObject
{
    [ObservableProperty] private IBrush back;
    [ObservableProperty] private string text;
    
    public ItemViewModel(string text, IBrush brush)
    {
        Back = brush;
        Text = text;
    }
}

public class WrapPanelEx : WrapPanel
{
    protected override Size MeasureOverride(Size constraint)
    {
        Debug.WriteLine($"measure: {constraint}");
        return base.MeasureOverride(constraint);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        Debug.WriteLine($"arrange: {finalSize}");
        return base.ArrangeOverride(finalSize);
    }
}