﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Professorweb_6_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThirdPage : SaveStatePage

    {
        Color clr;
        IAsyncOperation<IUICommand> asyncOpTobeCanceled;

        public ThirdPage()
        {
            this.InitializeComponent();

        }
        private async void ButtonChangeColor_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgdlg = new MessageDialog("Виберіть колір тла");
            msgdlg.Commands.Add(new UICommand("Червоний", null, Colors.Red));
            msgdlg.Commands.Add(new UICommand("Зелений", null, Colors.Green));
            msgdlg.Commands.Add(new UICommand("Синій", null, Colors.Blue));
            grid2.Background = new SolidColorBrush((Color)(await msgdlg.ShowAsync()).Id);
        }

        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            if (args.NavigationMode != NavigationMode.New)
            {
                // Створити ключ словника
                int pageKey = this.Frame.BackStackDepth;

                // отримати словник стану для поточної сторінки
                pageState = pages[pageKey];

                // Отримати стан сторінки зі словника
                txt.Text = pageState["TextBoxText"] as string;
            }
            // !!!
            base.OnNavigatedTo(args);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs args)
        {
            pageState.Clear();

            // Зберегти стан сторінки в словнику
            pageState.Add("TextBoxText", txt.Text);

            base.OnNavigatedFrom(args);
        }
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void SecondPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SecondPage));
        }
        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoForward();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
