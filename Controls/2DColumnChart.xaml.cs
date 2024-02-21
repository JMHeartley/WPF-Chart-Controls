﻿using Controls.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    ///     Interaction logic for _2DColumnChart.xaml
    /// </summary>
    public partial class _2DColumnChart : UserControl
    {
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(List<ColumnItem>), typeof(_2DColumnChart));

        public static readonly DependencyProperty ColumnBrushProperty =
            DependencyProperty.Register(nameof(ColumnBrush), typeof(SolidColorBrush), typeof(_2DColumnChart));

        public static readonly DependencyProperty ForegroundBrushProperty =
            DependencyProperty.Register(nameof(ForegroundBrush), typeof(SolidColorBrush), typeof(_2DColumnChart));

        public static readonly DependencyProperty StrokeBrushProperty =
            DependencyProperty.Register(nameof(StrokeBrush), typeof(SolidColorBrush), typeof(_2DColumnChart));

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(_2DColumnChart));

        public _2DColumnChart()
        {
            ColumnBrush = Brushes.Gold;
            ForegroundBrush = Brushes.Black;
            StrokeBrush = Brushes.LightGray;
            StrokeThickness = 1;

            InitializeComponent();
        }

        public List<ColumnItem> Items
        {
            get => (List<ColumnItem>)GetValue(ItemsProperty);
            set
            {
                SetValue(ItemsProperty, value);

                if (Items is null)
                {
                    return;
                }

                Paint();
            }
        }

        public SolidColorBrush ColumnBrush
        {
            get => (SolidColorBrush)GetValue(ColumnBrushProperty);
            set => SetValue(ColumnBrushProperty, value);
        }

        public SolidColorBrush ForegroundBrush
        {
            get => (SolidColorBrush)GetValue(ForegroundBrushProperty);
            set => SetValue(ForegroundBrushProperty, value);
        }

        public SolidColorBrush StrokeBrush
        {
            get => (SolidColorBrush)GetValue(StrokeBrushProperty);
            set => SetValue(StrokeBrushProperty, value);
        }

        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        private void Paint()
        {
            float chartWidth = 1200;
            float chartHeight = 700;
            float chartPadding = 100;
            float yAxisInterval = 50;
            const float originalBlockWidthRatio = 0.583333f;
            var blockWidth = chartWidth / Items.Count * originalBlockWidthRatio;
            var blockMargin = (chartWidth / Items.Count - blockWidth) / 2;
            MainCanvas.Width = chartWidth;
            MainCanvas.Height = chartHeight;

            var yAxisEndPoint = new Point(chartPadding, chartPadding);
            var origin = new Point(chartPadding, chartHeight - chartPadding);
            var xAxisEndPoint = new Point(chartWidth - chartPadding, chartHeight - chartPadding);

            var yAxisStartLine = new Line
            {
                Stroke = StrokeBrush,
                StrokeThickness = StrokeThickness,
                X1 = yAxisEndPoint.X,
                Y1 = yAxisEndPoint.Y,
                X2 = origin.X,
                Y2 = origin.Y
            };
            MainCanvas.Children.Add(yAxisStartLine);

            var yAxisEndLine = new Line
            {
                Stroke = StrokeBrush,
                StrokeThickness = StrokeThickness,
                X1 = xAxisEndPoint.X,
                Y1 = xAxisEndPoint.Y,
                X2 = xAxisEndPoint.X,
                Y2 = yAxisEndPoint.Y
            };
            MainCanvas.Children.Add(yAxisEndLine);

            double yValue = 0;
            var yAxisValue = origin.Y;
            while (yAxisValue >= yAxisEndPoint.Y)
            {
                var yLine = new Line
                {
                    Stroke = StrokeBrush,
                    StrokeThickness = StrokeThickness,
                    X1 = origin.X,
                    Y1 = yAxisValue,
                    X2 = xAxisEndPoint.X,
                    Y2 = yAxisValue
                };
                MainCanvas.Children.Add(yLine);

                var yAxisTextBlock = new TextBlock
                {
                    Text = $"{yValue}",
                    Foreground = ForegroundBrush,
                    FontSize = FontSize,
                    Width = 30,
                    TextAlignment = TextAlignment.Right
                };
                MainCanvas.Children.Add(yAxisTextBlock);

                Canvas.SetLeft(yAxisTextBlock, origin.X - yAxisTextBlock.Width - 10);
                Canvas.SetTop(yAxisTextBlock, yAxisValue - 12.5);

                yAxisValue -= yAxisInterval;
                yValue += yAxisInterval;
            }

            var margin = origin.X + blockMargin;
            foreach (var item in Items)
            {
                var block = new Rectangle
                {
                    Fill = ColumnBrush,
                    Width = blockWidth,
                    Height = item.Value
                };

                MainCanvas.Children.Add(block);
                Canvas.SetLeft(block, margin);
                Canvas.SetTop(block, origin.Y - block.Height);

                var blockHeader = new TextBlock
                {
                    Text = item.Header,
                    FontSize = FontSize,
                    Foreground = ForegroundBrush,
                    TextAlignment = TextAlignment.Center,
                    Width = blockWidth,
                    TextWrapping = TextWrapping.Wrap
                };
                MainCanvas.Children.Add(blockHeader);
                Canvas.SetLeft(blockHeader, margin);
                Canvas.SetTop(blockHeader, origin.Y + 5);

                margin += blockWidth + blockMargin;
            }
        }
    }
}