using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace App5
{
    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<string> sessionHistory;

        public MainWindow()
        {
            this.InitializeComponent();
            sessionHistory = new ObservableCollection<string>();
            SessionHistoryDropdown.ItemsSource = sessionHistory;
            LoadSessionHistory();
        }

        private void AccelerateButton_Click(object sender, RoutedEventArgs e)
        {
            // Simulate acceleration
            AccelerationBar.Height = 0;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
            timer.Tick += (s, args) =>
            {
                if (AccelerationBar.Height < 280)
                {
                    AccelerationBar.Height += 14; // Increment height
                }
                else
                {
                    timer.Stop();
                }
            };
            timer.Start();

            // Button animation
            var button = sender as Button;
            var animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.5,
                Duration = new Duration(TimeSpan.FromMilliseconds(200)),
                AutoReverse = true
            };
            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, button);
            Storyboard.SetTargetProperty(animation, "Opacity");
            storyboard.Begin();
        }

        private void LoadSessionHistory()
        {
            // Load session history (this is just a placeholder)
            sessionHistory.Add("Session 1: 2024-08-30 10:00 AM");
            sessionHistory.Add("Session 2: 2024-08-31 09:00 AM");
        }

        private void SessionHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            SessionHistoryDropdown.Visibility = SessionHistoryDropdown.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void SessionHistoryDropdown_DropDownOpened(object sender, object e)
        {
            // Refresh session history
            sessionHistory.Clear();
            sessionHistory.Add("Session 1: 2024-08-30 10:00 AM");
            sessionHistory.Add("Session 2: 2024-08-31 09:00 AM");
            sessionHistory.Add($"Session {sessionHistory.Count + 1}: {DateTime.Now}");
        }
    }
}
