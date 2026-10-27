using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace TemperatureConverter;

public partial class App : Application
{
    public App()
    {
        // ចាប់រាល់ Error ដែលកើតមានឡើងពេលចាប់ផ្ដើម
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            File.WriteAllText("crash_error.txt", e.ExceptionObject.ToString());
        };

        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        try
        {
            return new Window(new MainPage());
        }
        catch (Exception ex)
        {
            File.WriteAllText("crash_error.txt", ex.ToString());
            throw;
        }
    }
}