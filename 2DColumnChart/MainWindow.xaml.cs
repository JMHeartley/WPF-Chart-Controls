﻿using Controls.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2DColumnChart
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Items = TestColumnItems.Case4;

            Paint();
        }

        private List<ColumnItem> Items { get; }

        private void Paint()
        {
            try
            {
                float chartWidth = 1200,
                      chartHeight = 700,
                      axisMargin = 100,
                      yAxisInterval = 100,
                      blockWidth = 70,
                      blockMargin = 25;
                MainCanvas.Width = chartWidth;
                MainCanvas.Height = chartHeight;

                var yAxisEndPoint = new Point(axisMargin, axisMargin);
                var origin = new Point(axisMargin, chartHeight - axisMargin);
                var xAxisEndPoint = new Point(chartWidth - axisMargin, chartHeight - axisMargin);

                // for illustration
                //Ellipse yAxisEndPointEllipse = new Ellipse()
                //{
                //    Fill = Brushes.Red,
                //    Width = 10,
                //    Height = 10,
                //};
                //mainCanvas.Children.Add(yAxisEndPointEllipse);
                //Canvas.SetLeft(yAxisEndPointEllipse, yAxisEndPoint.X - 5);
                //Canvas.SetTop(yAxisEndPointEllipse, yAxisEndPoint.Y - 5);

                //Ellipse originEllipse = new Ellipse()
                //{
                //    Fill = Brushes.Red,
                //    Width = 10,
                //    Height = 10,
                //};
                //mainCanvas.Children.Add(originEllipse);
                //Canvas.SetLeft(originEllipse, origin.X - 5);
                //Canvas.SetTop(originEllipse, origin.Y - 5);

                //Ellipse xAxisEndPointEllipse = new Ellipse()
                //{
                //    Fill = Brushes.Blue,
                //    Width = 10,
                //    Height = 10,
                //};
                //mainCanvas.Children.Add(xAxisEndPointEllipse);
                //Canvas.SetLeft(xAxisEndPointEllipse, xAxisEndPoint.X - 5);
                //Canvas.SetTop(xAxisEndPointEllipse, xAxisEndPoint.Y - 5);

                //Line yAxisStartLine = new Line()
                //{
                //    Stroke = Brushes.LightGray,
                //    StrokeThickness = 1,
                //    X1 = yAxisEndPoint.X,
                //    Y1 = yAxisEndPoint.Y,
                //    X2 = origin.X,
                //    Y2 = origin.Y,
                //};
                //mainCanvas.Children.Add(yAxisStartLine);

                //Line yAxisEndLine = new Line()
                //{
                //    Stroke = Brushes.LightGray,
                //    StrokeThickness = 1,
                //    X1 = xAxisEndPoint.X,
                //    Y1 = xAxisEndPoint.Y,
                //    X2 = xAxisEndPoint.X,
                //    Y2 = yAxisEndPoint.Y,
                //};
                //mainCanvas.Children.Add(yAxisEndLine);


                double yValue = 0;
                var yAxisValue = origin.Y;
                while (yAxisValue >= yAxisEndPoint.Y)
                {
                    // for illustration
                    //Ellipse lEllipse = new Ellipse()
                    //{
                    //    Fill = Brushes.Red,
                    //    Width = 10,
                    //    Height = 10,
                    //};

                    //Ellipse rEllipse = new Ellipse()
                    //{
                    //    Fill = Brushes.Blue,
                    //    Width = 10,
                    //    Height = 10,
                    //};

                    //mainCanvas.Children.Add(lEllipse);
                    //mainCanvas.Children.Add(rEllipse);

                    //Canvas.SetLeft(lEllipse, origin.X - 5);
                    //Canvas.SetTop(lEllipse, yAxisValue - 5);

                    //Canvas.SetLeft(rEllipse, xAxisEndPoint.X - 5);
                    //Canvas.SetTop(rEllipse, yAxisValue - 5);


                    var yLine = new Line
                    {
                        Stroke = Brushes.LightGray,
                        StrokeThickness = 1,
                        X1 = origin.X,
                        Y1 = yAxisValue,
                        X2 = xAxisEndPoint.X,
                        Y2 = yAxisValue
                    };
                    MainCanvas.Children.Add(yLine);

                    var yAxisTextBlock = new TextBlock
                    {
                        Text = $"{yValue}",
                        Foreground = Brushes.Black,
                        FontSize = 16
                    };
                    MainCanvas.Children.Add(yAxisTextBlock);

                    Canvas.SetLeft(yAxisTextBlock, origin.X - 35);
                    Canvas.SetTop(yAxisTextBlock, yAxisValue - 12.5);


                    yAxisValue -= yAxisInterval;
                    yValue += yAxisInterval;
                }


                var margin = origin.X + blockMargin;
                foreach (var item in Items)
                {
                    var block = new Rectangle
                    {
                        Fill = Brushes.Gold,
                        //Fill = new SolidColorBrush(Color.FromRgb(68, 114, 196)),
                        Width = blockWidth,
                        Height = item.Value
                    };

                    MainCanvas.Children.Add(block);
                    Canvas.SetLeft(block, margin);
                    Canvas.SetTop(block, origin.Y - block.Height);

                    var blockHeader = new TextBlock
                    {
                        Text = item.Header,
                        FontSize = 16,
                        Foreground = Brushes.Black
                    };
                    MainCanvas.Children.Add(blockHeader);
                    Canvas.SetLeft(blockHeader, margin + 10);
                    Canvas.SetTop(blockHeader, origin.Y + 5);


                    margin += blockWidth + blockMargin;
                }
            }
            catch (Exception exception)
            {
            }
        }
    }
}