<h1 align="center">
    📈 WPF Chart Controls 📊
</h1>

<p align="center">
    <i>A WPF control library for responsive column, line, and pie charts.</i>
</p>

<p align="center">
    <a href="https://www.nuget.org/packages/WPF-Chart-Controls/">
        <img alt="NuGet Version" src="https://img.shields.io/nuget/v/WPF-Chart-Controls?color=red">
    </a>
    <a href="https://github.com/JMHeartley/WPF-Chart-Controls/graphs/contributors">
        <img alt="GitHub contributors" src="https://img.shields.io/github/contributors/jmheartley/wpf-chart-controls?color=green">
    </a>
    <a href="https://github.com/JMHeartley/WPF-Chart-Controls/commits/master/">
        <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/jmheartley/wpf-chart-controls?color=blue">
    </a>
    <a href="/LICENSE">
        <img alt="MIT License" src="https://img.shields.io/github/license/jmheartley/wpf-chart-controls?color=yellow">
    </a>
</p>

# 🖥️ Demo
Kareem has a [video demoing and explaining functionality](https://www.youtube.com/watch?v=PRM0cax5eJw) or you can download and check out the charts in the [Example](https://github.com/JMHeartley/WPF-Chart-Controls/tree/master/Example) project.


# 📊 2D Column Chart
## Usage
1. Import the namespace
``` xaml
xmlns:wpfChartControls="clr-namespace:WPFChartControls;assembly=WPFChartControls"
```
2. Add chart
``` xaml
<wpfChartControls:_2DColumnChart />
```
3. Bind data to Items property
    * using code-behind
    ``` xaml
    <wpfChartControls:_2DColumnChart x:Name="ColumnChart" />
    ```
    ``` csharp
    ColumnChart.Items = TestColumnItems.Case4;
    ```
    * using attribute binding
    ``` xaml
    <wpfChartControls:_2DColumnChart Items="{Binding Items}" />
    ```

## Properties
* `Items` - collection of `ColumnItem` items to be displayed in the chart
* `ColumnBrush` - brush used for the `ColumnItem` items
* `Stroke` - brush used to draw the axis and lines
* `StrokeThickness` - thickness of the axis and lines
* `IntervalCount` - number of intervals to be displayed on the Y-axis
* `InnerPadding` - inner padding of the chart area

## Related Objects
* `ColumnItem` - an item in the column chart with a `Header` and `Value`
* `TestColumnItems` - provides test case collections of `ColumnItem` instances


# 🥧 2D Pie Chart
## Usage
1. Import the namespace
``` xaml
xmlns:wpfChartControls="clr-namespace:WPFChartControls;assembly=WPFChartControls"
```
2. Add chart
``` xaml
<wpfChartControls:_2DPieChart />
```
3. Bind data to Items property
    * using code-behind
    ``` xaml
    <wpfChartControls:_2DPieChart x:Name="PieChart" />
    ```
    ``` csharp
    PieChart.Categories = TestPieCategories.Case6;
    ```
    * using attribute binding
    ``` xaml
    <wpfChartControls:_2DPieChart Categories="{Binding Categories}" />
    ```

## Properties
* `Categories` - collection of `PieCategory` items to be displayed in the chart
* `StrokeBrush` - brush used to draw the strokes of the pie slices
* `StrokeThickness` - thickness of the strokes of the pie slices
* `LegendPosition` - position of the legend relative to the chart

## Related Objects
* `PieCategory` - a category in a pie chart with a `Percentage`, `Title`, and `ColorBrush`
* `LegendPosition` - position of the legend (values: `Top`, `Left`, `Right`, `Bottom`)
* `TestPieCategories` - provides test case collections of `PieCategory` instances


# 📈 Line Chart
## Usage
1. Import the namespace
``` xaml
xmlns:wpfChartControls="clr-namespace:WPFChartControls;assembly=WPFChartControls"
```
2. Add chart
``` xaml
<wpfChartControls:LineChart />
```
3. Bind data to Items property
    * using code-behind
    ``` xaml
    <wpfChartControls:LineChart x:Name="LineChart" />
    ```
    ``` csharp
    LineChart.Values = TestLineValues.Case3;
    ```
    * using attribute binding
    ``` xaml
    <wpfChartControls:LineChart Values="{Binding Values}" />
    ```

## Properties
* `Values` - collection of `LineValue` items to be displayed in the chart
* `AxisStrokeBrush` - brush used to draw the axis strokes
* `AxisStrokeThickness` - thickness of the axis strokes
* `GridLineStrokeBrush` - brush used to draw the grid lines
* `GridLineStrokeThickness` - thickness of the grid lines
* `GridLineOpacity` - opacity of the grid lines
* `InnerPadding` - inner padding of the chart area
* `ValueLineStrokeBrush` - brush used to draw the value line
* `ValueLineStrokeThickness` - thickness of the value line
* `XIntervalCount` - number of intervals to be displayed on the X-axis
* `YIntervalCount` - number of intervals to be displayed on the Y-axis

## Related Objects
* `LineValue` -  a value in a line chart with `X` and `Y` coordinates
* `TestLineValues` - provides test case collections of `LineValue` instances


# 💪🏾 Credits
Thank you to [Kareem Sulthan](https://github.com/kareemsulthan07), who shared [the code](https://github.com/kareemsulthan07/Charts) that became the foundation of WPF Chart Controls.

From there I did lots of refactoring, made each chart adjust sizing when the window height/width is changed, and added documentation comments to increase reusability.


## 📃 License
[The MIT License (MIT)](/LICENSE)

Copyright (c) 2024 Kareem Sulthan, Justin M Heartley
