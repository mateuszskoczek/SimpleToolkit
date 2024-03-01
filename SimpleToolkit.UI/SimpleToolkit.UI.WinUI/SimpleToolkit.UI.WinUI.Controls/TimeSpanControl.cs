using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToolkit.UI.WinUI.Controls
{
    public class TimeSpanControl : Grid
    {
        #region FIELDS

        protected NumberBox _hours;
        protected NumberBox _minutes;
        protected NumberBox _seconds;

        #endregion



        #region PROPERTIES

        public TimeSpan Value
        {
            get => (TimeSpan)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(TimeSpan), typeof(TimeSpanControl), new PropertyMetadata(TimeSpan.Zero, new PropertyChangedCallback(ValuePropertyChanged)));

        public TimeSpan Maximum
        {
            get => (TimeSpan)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(TimeSpan), typeof(TimeSpanControl), new PropertyMetadata(TimeSpan.MaxValue, new PropertyChangedCallback(RangePropertyChanged)));

        public TimeSpan Minimum
        {
            get => (TimeSpan)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(TimeSpan), typeof(TimeSpanControl), new PropertyMetadata(TimeSpan.Zero, new PropertyChangedCallback(RangePropertyChanged)));

        #endregion



        #region CONSTRUCTORS

        public TimeSpanControl()
        {
            this.Build();
            base.Loaded += this.OnLoaded;
        }

        #endregion



        #region PRIVATE METHODS

        protected void Build()
        {
            this.ColumnSpacing = 4;
            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            _hours = new NumberBox
            {
                SpinButtonPlacementMode = NumberBoxSpinButtonPlacementMode.Compact,
                Minimum = 0,
                Value = 0,
            };
            _hours.ValueChanged += ValueChanged;
            Children.Add(_hours);
            SetColumn(_hours, 0);

            TextBlock sep1 = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(0, 0, 0, 5),
                Text = ":"
            };
            Children.Add(sep1);
            SetColumn(sep1, 1);

            _minutes = new NumberBox
            {
                SpinButtonPlacementMode = NumberBoxSpinButtonPlacementMode.Compact,
                Minimum = 0,
                Maximum = 59,
                Value = 0,
            };
            _minutes.ValueChanged += ValueChanged;
            Children.Add(_minutes);
            SetColumn(_minutes, 2);

            TextBlock sep2 = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(0, 0, 0, 5),
                Text = ":"
            };
            Children.Add(sep2);
            SetColumn(sep2, 3);

            _seconds = new NumberBox
            {
                SpinButtonPlacementMode = NumberBoxSpinButtonPlacementMode.Compact,
                Minimum = 0,
                Maximum = 59,
                Value = 0,
            };
            _seconds.ValueChanged += ValueChanged;
            Children.Add(_seconds);
            SetColumn(_seconds, 4);
        }

        protected void UpdateOnChanges()
        {
            if (this.IsLoaded)
            {
                TimeSpan hoursTimeSpan = TimeSpan.FromHours(_hours.Value);
                TimeSpan minutesTimeSpan = TimeSpan.FromMinutes(_minutes.Value);
                TimeSpan secondsTimeSpan = TimeSpan.FromSeconds(_seconds.Value);
                TimeSpan value = secondsTimeSpan + minutesTimeSpan + hoursTimeSpan;
                if (value >= Maximum)
                {
                    _hours.Value = Math.Floor(Maximum.TotalHours);
                    _minutes.Value = Maximum.Minutes;
                    _seconds.Value = Maximum.Seconds;
                }
                else if (value <= Minimum)
                {
                    _hours.Value = Math.Floor(Minimum.TotalHours);
                    _minutes.Value = Minimum.Minutes;
                    _seconds.Value = Minimum.Seconds;
                }
                Value = value;
            }
        }

        protected void UpdateOnValueChange()
        {
            if (this.IsLoaded)
            {
                TimeSpan value = Value;
                if (value > Maximum)
                {
                    value = Maximum;
                }
                else if (value < Minimum)
                {
                    value = Minimum;
                }
                _hours.Value = Math.Floor(value.TotalHours);
                _minutes.Value = value.Minutes;
                _seconds.Value = value.Seconds;
            }
        }

        protected void ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args) => UpdateOnChanges();

        protected static void ValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e) => ((TimeSpanControl)obj).UpdateOnValueChange();

        protected static void RangePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e) => ((TimeSpanControl)obj).UpdateOnChanges();

        protected void OnLoaded(object sender, RoutedEventArgs e) => UpdateOnValueChange();

        #endregion
    }
}
