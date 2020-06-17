﻿using Gatosyocora.VRCPhotoAlbum.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Gatosyocora.VRCPhotoAlbum.Views
{
    /// <summary>
    /// SettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : WindowBase
    {
        private SettingViewModel _settingViewModel;

        public SettingWindow()
        {
            InitializeComponent();
            Loaded += SettingWindow_OnLoaded;
        }

        private void SettingWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _settingViewModel = new SettingViewModel();
            Disposable.Add(_settingViewModel);
            DataContext = _settingViewModel;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            _settingViewModel.ApplySettingData();
            Close();
        }
    }
}
