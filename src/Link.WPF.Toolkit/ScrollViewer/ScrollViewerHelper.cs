using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Link.WPF.Toolkit
{
    /// <summary>
    /// Route Nesting ScrollViewer Scroll Event
    /// ScrollViewer Scroll Horizontal
    /// </summary>
    public static class ScrollViewerHelper
    {
        #region Scroll Parent
        /// <summary>
        /// Route Nesting ScrollViewer Scroll Event
        /// </summary>
        public static readonly DependencyProperty ScrollParentProperty = DependencyProperty.RegisterAttached("ScrollParent", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(OnScollParentChanged));

        public static void SetScrollParent(DependencyObject o, bool value)
        {
            o.SetValue(ScrollParentProperty, value);
        }

        public static bool GetScrollParent(DependencyObject o)
        {
            return (bool)o.GetValue(ScrollParentProperty);
        }

        private static void OnScollParentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool ignoreScoll = (bool)e.NewValue;
            UIElement element = d as UIElement;

            if (element == null)
                return;

            if (ignoreScoll)
            {
                element.PreviewMouseWheel += Element_PreviewMouseWheel;
            }
            else
            {
                element.PreviewMouseWheel -= Element_PreviewMouseWheel;
            }
        }

        private static void Element_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            UIElement element = sender as UIElement;

            if (element != null)
            {
                e.Handled = true;

                var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                e2.RoutedEvent = UIElement.MouseWheelEvent;
                element.RaiseEvent(e2);
            }
        }
        #endregion

        #region Scroll Horizontal
        /// <summary>
        /// Set ScrollViewer Scroll Horizontal
        /// </summary>
        public static readonly DependencyProperty ScrollHorizontalProperty = DependencyProperty.RegisterAttached("ScrollHorizontal", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(OnScrollHorizontalChanged));

        public static void SetScrollHorizontal(DependencyObject o, bool value)
        {
            o.SetValue(ScrollHorizontalProperty, value);
        }

        public static bool GetScrollHorizontal(DependencyObject o)
        {
            return (bool)o.GetValue(ScrollHorizontalProperty);
        }

        private static void OnScrollHorizontalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool ignoreScoll = (bool)e.NewValue;
            UIElement element = d as UIElement;

            if (element == null)
                return;

            if (ignoreScoll)
            {
                element.PreviewMouseWheel += ElementScrollHorizontal_PreviewMouseWheel;
            }
            else
            {
                element.PreviewMouseWheel -= ElementScrollHorizontal_PreviewMouseWheel;
            }
        }

        private static void ElementScrollHorizontal_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ItemsControl items = (ItemsControl)sender;
            ScrollViewer scroll = FindVisualChild<ScrollViewer>(items);
            if (scroll != null)
            {
                int d = e.Delta;
                if (d < 0)
                {
                    scroll.LineRight();
                }
                if (d > 0)
                {
                    scroll.LineLeft();
                }
                scroll.ScrollToTop();
            }
        }

        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            if (obj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }
                    T childItem = FindVisualChild<T>(child);
                    if (childItem != null) return childItem;
                }
            }
            return null;
        }

        #endregion

    }
}
