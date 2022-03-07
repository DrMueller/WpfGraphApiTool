using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.Grids.SearchGrids.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.Grids.SearchGrids.Components
{
    public partial class SearchGrid : INotifyPropertyChanged
    {
        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.Register(
                nameof(DataGrid),
                typeof(DataGrid),
                typeof(SearchGrid),
                new PropertyMetadata(OnDataGridChanged));
        public static readonly DependencyProperty FilterCallbackProperty =
            DependencyProperty.Register(
                nameof(FilterCallback),
                typeof(Func<object, bool>),
                typeof(SearchGrid));
        public static readonly DependencyProperty GridEntriesProperty =
            DependencyProperty.Register(
                nameof(GridEntries),
                typeof(IEnumerable<object>),
                typeof(SearchGrid),
                new PropertyMetadata(OnGridEntriesChanged));
        public static readonly DependencyProperty SearchExpressionProperty =
            DependencyProperty.Register(
                nameof(SearchExpression),
                typeof(GridSearchExpression),
                typeof(SearchGrid),
                new PropertyMetadata(OnSearchExpressionChanged));
        private ICollectionView _gridEntriesView;

        public DataGrid DataGrid
        {
            get => (DataGrid)GetValue(DataGridProperty);
            set => SetValue(DataGridProperty, value);
        }

        public Func<object, bool> FilterCallback
        {
            get => (Func<object, bool>)GetValue(FilterCallbackProperty);
            set => SetValue(FilterCallbackProperty, value);
        }

        public IEnumerable<object> GridEntries
        {
            get => (IEnumerable<object>)GetValue(GridEntriesProperty);
            set => SetValue(DataGridProperty, value);
        }

        public GridSearchExpression SearchExpression
        {
            get => (GridSearchExpression)GetValue(SearchExpressionProperty);
            set => SetValue(SearchExpressionProperty, value);
        }

        public string SearchText
        {
            get => SearchExpression?.SearchText ?? string.Empty;
            set
            {
                if (SearchExpression != null && SearchExpression.SearchText == value)
                {
                    return;
                }

                SearchExpression = GridSearchExpression.CreateFrom(value);
            }
        }

        private ICollectionView GridEntriesView
        {
            get => _gridEntriesView;
            set
            {
                if (_gridEntriesView == value)
                {
                    return;
                }

                _gridEntriesView = value;
                _gridEntriesView.Filter += OnFilterRequested;
            }
        }

        public SearchGrid()
        {
            InitializeComponent();
        }

        private static void OnDataGridChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var searchGrid = (SearchGrid)d;
            searchGrid.BindDataGrid();
        }

        private static void OnGridEntriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var searchGrid = (SearchGrid)d;
            searchGrid.BindDataGrid();
        }

        private static void OnSearchExpressionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var searchGrid = (SearchGrid)d;
            searchGrid.OnPropertyChanged(nameof(SearchText));
            searchGrid.GridEntriesView.Refresh();
        }

        private void BindDataGrid()
        {
            var dataGrid = DataGrid;
            var gridEntries = GridEntries;

            if (dataGrid == null || gridEntries == null)
            {
                return;
            }

            GridEntriesView = CollectionViewSource.GetDefaultView(gridEntries);
            dataGrid.ItemsSource = GridEntriesView;
        }

        private bool OnFilterRequested(object obj)
        {
            if (SearchExpression != null && FilterCallback != null)
            {
                return FilterCallback(obj);
            }

            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}