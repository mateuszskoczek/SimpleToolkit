using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToolkit.UI.WinUI.Controls
{
    public class TimeSpanControl : ContentControl
    {
        #region FIELDS

        protected NumberBox _hours;
        protected NumberBox _minutes;
        protected NumberBox _seconds;

        #endregion



        #region PROPERTIES

        protected new ContentControl Content { get; set; }

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
            StackPanel baseControl = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Spacing = 4
            };

            _hours = new NumberBox
            {
                SpinButtonPlacementMode = NumberBoxSpinButtonPlacementMode.Compact,
                Minimum = 0,
                Value = 0,
            };
            _hours.ValueChanged += ValueChanged;
            baseControl.Children.Add(_hours);

            baseControl.Children.Add(new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(0, 0, 0, 5),
                Text = ":"
            });

            _minutes = new NumberBox
            {
                SpinButtonPlacementMode = NumberBoxSpinButtonPlacementMode.Compact,
                Minimum = 0,
                Maximum = 59,
                Value = 0,
            };
            _minutes.ValueChanged += ValueChanged;
            baseControl.Children.Add(_minutes);

            _seconds = new NumberBox
            {
                SpinButtonPlacementMode = NumberBoxSpinButtonPlacementMode.Compact,
                Minimum = 0,
                Maximum = 59,
                Value = 0,
            };
            _seconds.ValueChanged += ValueChanged;
            baseControl.Children.Add(_seconds);

            baseControl.Children.Add(new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(0, 0, 0, 5),
                Text = ":"
            });

            base.Content = baseControl;
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
