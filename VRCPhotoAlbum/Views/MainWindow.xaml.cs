﻿using Gatosyocora.VRCPhotoAlbum.Helpers;
using Gatosyocora.VRCPhotoAlbum.Models;
using Gatosyocora.VRCPhotoAlbum.Models.Entities;
using Gatosyocora.VRCPhotoAlbum.Servisies;
using Gatosyocora.VRCPhotoAlbum.ViewModels;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gatosyocora.VRCPhotoAlbum.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public static MainWindow Instance { get; private set; }

        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            Loaded += MainWindow_OnLoaded;
            ContentRendered += MainWindow_OnContentRendered;
        }

        private void MainWindow_OnLoaded(object sender, EventArgs args)
        {
            Title += $" {GetApplicationVersion()}";

            try
            {
                _mainViewModel = new MainViewModel(this);
                Disposable.Add(_mainViewModel);
                DataContext = _mainViewModel;
            }
#pragma warning disable CA1031 // 一般的な例外の種類はキャッチしません
            catch (Exception e)
#pragma warning restore CA1031 // 一般的な例外の種類はキャッチしません
            {
                FileHelper.OutputErrorLogFile(e);
            }
        }

        private void MainWindow_OnContentRendered(object sender, EventArgs args)
        {
            if (Setting.Instance.Data is null)
            {
                WindowHelper.OpenSettingDialog(this);
            }

            _mainViewModel.LoadResourcesCommand.Execute();
        }

        public void Reboot()
        {
            _mainViewModel.RebootCommand.Execute();
        }

        public void DeleteCache()
        {
            _mainViewModel.DeleteCacheCommand.Execute();
        }

        private void PhotoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 選択状態を保たないために選択されると未選択状態に切り替える
            PhotoListBox.SelectedItem = null;
        }

        private void UserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 選択状態を保たないために選択されると未選択状態に切り替える
            UserListView.SelectedItem = null;
        }

        private string GetApplicationVersion()
        {
            return FileVersionInfo.GetVersionInfo(typeof(App).Assembly.Location).FileVersion;
        }

        public void ScrollToTopInPhotoList()
        {
            var border = VisualTreeHelper.GetChild(PhotoListBox, 0) as Border;
            if (border is null) return;
            var scroll = border.Child as ScrollViewer;
            if (scroll is null) return;
            scroll.ScrollToTop();
        }
    }
}
