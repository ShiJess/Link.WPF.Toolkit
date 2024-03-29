﻿using System;
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
    /// ScrollViewer Scroll Mode:Vertical,Horizontal etc.
    /// </summary>
    public static class ScrollViewerHelper
    {
        #region Scroll Mode
        /// <summary>
        /// Set ScrollViewer Scroll Mode
        /// </summary>
        public static readonly DependencyProperty ScrollModeProperty = DependencyProperty.RegisterAttached("ScrollMode", typeof(ScrollMode), typeof(ScrollViewerHelper), new PropertyMetadata(ScrollMode.None, OnScrollModeChanged));

        public static void SetScrollMode(DependencyObject o, ScrollMode value)
        {
            o.SetValue(ScrollModeProperty, value);
        }

        public static ScrollMode GetScrollMode(DependencyObject o)
        {
            return (ScrollMode)o.GetValue(ScrollModeProperty);
        }

        private static void OnScrollModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            if (element == null)
                return;

            element.PreviewMouseWheel -= ElementScroll_PreviewMouseWheel;
            element.PreviewMouseWheel += ElementScroll_PreviewMouseWheel;
        }
        #endregion

        #region Scroll Parent
        /// <summary>
        /// Route Nesting ScrollViewer Scroll Event
        /// </summary>
        public static readonly DependencyProperty ScrollParentProperty = DependencyProperty.RegisterAttached("ScrollParent", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(false, OnScollParentChanged));

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
            UIElement element = d as UIElement;

            if (element == null)
                return;

            element.PreviewMouseWheel -= ElementScroll_PreviewMouseWheel;
            element.PreviewMouseWheel += ElementScroll_PreviewMouseWheel;
        }
        #endregion

        #region Scroll Parent Delay
        /// <summary>
        /// Scroll Parent Delay
        ///     * Depend ScrollParent = true
        /// </summary>
        public static readonly DependencyProperty ScrollParentDelayProperty = DependencyProperty.RegisterAttached("ScrollParentDelay", typeof(int), typeof(ScrollViewerHelper), new PropertyMetadata(1));

        public static void SetScrollParentDelay(DependencyObject o, int value)
        {
            o.SetValue(ScrollParentDelayProperty, value);
        }

        public static int GetScrollParentDelay(DependencyObject o)
        {
            return (int)o.GetValue(ScrollParentDelayProperty);
        }


        /// <summary>
        /// Scroll Parent Delay Temp Count
        /// </summary>
        private static readonly DependencyProperty DelayCountProperty = DependencyProperty.RegisterAttached("DelayCount", typeof(int), typeof(ScrollViewerHelper), new PropertyMetadata(1));

        private static void SetDelayCount(DependencyObject o, int value)
        {
            o.SetValue(DelayCountProperty, value);
        }

        private static int GetDelayCount(DependencyObject o)
        {
            return (int)o.GetValue(DelayCountProperty);
        }

        #endregion

        private static void ElementScroll_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                DependencyObject items = (DependencyObject)e.Source;//sender
                int d = e.Delta;
                var scrollmode = GetScrollMode(items);
                var scrollparent = GetScrollParent(items);
                var delay = GetScrollParentDelay(items);
                var count = GetDelayCount(items);
                ScrollViewer scroll = FindVisualChild<ScrollViewer>(items);
                if (scroll != null)
                {
                    e.Handled = true;

                    switch (scrollmode)
                    {
                        case ScrollMode.None:
                        case ScrollMode.VerticalOnly:
                            {
                                if (d < 0)
                                {
                                    scroll.LineDown();

                                    if (scrollparent && (scroll.VerticalOffset >= scroll.ScrollableHeight))
                                    {
                                        e.Handled = false;
                                        SetDelayCount(items, ++count);
                                    }
                                    else
                                    {if(count>0)
                                        SetDelayCount(items, --count);
                                    }
                                }
                                else if (d > 0)
                                {
                                    scroll.LineUp();
                                    if (scrollparent && (scroll.VerticalOffset <= 0))
                                    {
                                        e.Handled = false;
                                        SetDelayCount(items, ++count);
                                    }
                                    else
                                    {
                                        if (count > 0)
                                            SetDelayCount(items, --count);
                                    }
                                }
                            }
                            break;
                        case ScrollMode.HorizontalOnly:
                            {
                                if (d < 0)
                                {
                                    scroll.LineRight();
                                    if (scrollparent && (scroll.HorizontalOffset >= scroll.ScrollableWidth))
                                    {
                                        e.Handled = false;
                                        SetDelayCount(items, ++count);
                                    }
                                    else
                                    {
                                        if (count > 0)
                                            SetDelayCount(items, --count);
                                    }
                                }
                                else if (d > 0)
                                {
                                    scroll.LineLeft();
                                    if (scrollparent && (scroll.HorizontalOffset <= 0))
                                    {
                                        e.Handled = false;
                                        SetDelayCount(items, ++count);
                                    }
                                    else
                                    {
                                        if (count > 0)
                                            SetDelayCount(items, --count);
                                    }
                                }
                            }
                            break;
                        case ScrollMode.VerticalFirst:
                            {
                                if (d < 0)
                                {
                                    scroll.LineDown();
                                    if ((scroll.VerticalOffset >= scroll.ScrollableHeight))
                                    {
                                        scroll.LineRight();
                                        if (scrollparent && (scroll.HorizontalOffset >= scroll.ScrollableWidth))
                                        {
                                            e.Handled = false;
                                            SetDelayCount(items, ++count);
                                        }
                                    }
                                    else
                                    {
                                        if (count > 0)
                                            SetDelayCount(items, --count);
                                    }
                                }
                                else if (d > 0)
                                {
                                    scroll.LineUp();
                                    if (scroll.VerticalOffset <= 0)
                                    {
                                        scroll.LineLeft();
                                        if (scrollparent && (scroll.HorizontalOffset <= 0))
                                        {
                                            e.Handled = false;
                                            SetDelayCount(items, ++count);
                                        }
                                    }
                                    else
                                    {
                                        if (count > 0)
                                            SetDelayCount(items, --count);
                                    }
                                }
                            }
                            break;
                        case ScrollMode.HorizontalFirst:
                            {
                                if (d < 0)
                                {
                                    scroll.LineRight();
                                    if (scroll.HorizontalOffset >= scroll.ScrollableWidth)
                                    {
                                        scroll.LineDown();
                                        if (scrollparent && (scroll.VerticalOffset >= scroll.ScrollableHeight))
                                        {
                                            e.Handled = false;
                                            SetDelayCount(items, ++count);
                                        }
                                    }
                                    else
                                    {
                                        if (count > 0)
                                            SetDelayCount(items, --count);
                                    }
                                }
                                else if (d > 0)
                                {
                                    scroll.LineLeft();
                                    if (scroll.HorizontalOffset <= 0)
                                    {
                                        scroll.LineUp();
                                        if (scrollparent && (scroll.VerticalOffset <= 0))
                                        {
                                            e.Handled = false;
                                            SetDelayCount(items, ++count);
                                        }
                                    }
                                    else
                                    {
                                        if (count > 0)
                                            SetDelayCount(items, --count);
                                    }
                                }
                            }
                            break;
                        default:
                            e.Handled = false;
                            break;
                    }
                }

                //UIElement element = e.Source as UIElement;
                UIElement element = sender as UIElement;
                if (scrollparent && element != null && !e.Handled)
                {
                    e.Handled = true;

                    if (count >= delay)
                    {
                        var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                        //e2.Source = sender;
                        if (e.Source == sender)
                        {
                            // e2.RoutedEvent =UIElement.MouseWheelEvent;
                            e2.RoutedEvent = Mouse.MouseWheelEvent;
                            var parentScrollViewer = FindVisualParent<ScrollViewer>(element);
                            if (parentScrollViewer != null)
                                parentScrollViewer.RaiseEvent(e2);
                        }
                        else
                        {
                            //e2.RoutedEvent = UIElement.PreviewMouseWheelEvent;
                            e2.RoutedEvent = Mouse.PreviewMouseWheelEvent;
                            element.RaiseEvent(e2);
                        }
                    }
                }
            }
            catch { }
        }

        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            if (obj != null)
            {
                if (obj is T)
                {
                    return (T)obj;
                }
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }
                    T childItem = FindVisualChild<T>(child);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }
            return null;
        }

        public static T FindVisualParent<T>(DependencyObject reference) where T : class
        {
            var parent = VisualTreeHelper.GetParent(reference);
            if (parent == null)
                return null;
            else
            {
                if (parent is T)
                {
                    return parent as T;
                }
                else
                {
                    return FindVisualParent<T>(parent);
                }
            }
        }

    }

    /// <summary>
    /// Scroll Viewer Scroll Mode
    /// </summary>
    public enum ScrollMode
    {
        /// <summary>
        /// Default: Disable Scroll / UnSet
        /// </summary>
        None = 0,
        /// <summary>
        /// 
        /// </summary>
        VerticalOnly,
        HorizontalOnly,

        VerticalFirst,
        HorizontalFirst,
    }

}
