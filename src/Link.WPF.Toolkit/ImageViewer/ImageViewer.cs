using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Image Viewer
    /// add zoom drag;
    /// </summary>
    [TemplatePart(Name = PART_ScrollViewer, Type = typeof(ScrollViewer))]
    [TemplatePart(Name = PART_Panel, Type = typeof(Grid))]
    [TemplatePart(Name = PART_ScaleTransform, Type = typeof(ScaleTransform))]
    public class ImageViewer : Control
    {

        private const string PART_ScrollViewer = "PART_ScrollViewer";
        private const string PART_Panel = "PART_Panel";
        private const string PART_ScaleTransform = "PART_ScaleTransform";

        static ImageViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageViewer), new FrameworkPropertyMetadata(typeof(ImageViewer)));
        }


        /// <summary>
        /// Image Source
        /// </summary>        
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// Zoom Scale
        /// </summary>
        public double ZoomScale
        {
            get { return (double)GetValue(ZoomScaleProperty); }
            set
            {
                SetValue(ZoomScaleProperty, value);
                if (scaleTransformForImage != null && value > 0)
                {
                    scaleTransformForImage.ScaleX = value;
                    scaleTransformForImage.ScaleY = value;
                }
            }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof(ImageSource), typeof(ImageViewer),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ZoomScaleProperty = DependencyProperty.Register(
           "ZoomScale", typeof(double), typeof(ImageViewer), new PropertyMetadata(1.0));


        private Grid panelOfImage;
        private ScaleTransform scaleTransformForImage;
        private ScrollViewer scrollViewerForImage;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            scrollViewerForImage = GetTemplateChild(PART_ScrollViewer) as ScrollViewer;
            panelOfImage = GetTemplateChild(PART_Panel) as Grid;
            scaleTransformForImage = GetTemplateChild(PART_ScaleTransform) as ScaleTransform;
            if (scrollViewerForImage != null)
            {
                scrollViewerForImage.ScrollChanged -= OnScrollViewerScrollChanged;
                scrollViewerForImage.ScrollChanged += OnScrollViewerScrollChanged;
            }
        }

        #region Drag Move Image
        /// <summary>
        /// Mouse Point Last Time
        /// </summary>
        Point? lastDragPoint;

        protected override void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
        {
            var currMousePosition = e.GetPosition(scrollViewerForImage);
            if (currMousePosition.X <= scrollViewerForImage.ViewportWidth
                && currMousePosition.Y <= scrollViewerForImage.ViewportHeight)
            {
                scrollViewerForImage.Cursor = Cursors.SizeAll;
                lastDragPoint = currMousePosition;
                Mouse.Capture(scrollViewerForImage);
            }

            base.OnPreviewMouseRightButtonDown(e);
        }

        protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
        {
            scrollViewerForImage.Cursor = Cursors.Arrow;
            scrollViewerForImage.ReleaseMouseCapture();
            lastDragPoint = null;

            base.OnPreviewMouseRightButtonUp(e);
            //e.Handled = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed && lastDragPoint.HasValue)
            {
                Point currMousePosition = e.GetPosition(scrollViewerForImage);

                double offsetX = currMousePosition.X - lastDragPoint.Value.X;
                double offsetY = currMousePosition.Y - lastDragPoint.Value.Y;

                lastDragPoint = currMousePosition;

                scrollViewerForImage.ScrollToHorizontalOffset(scrollViewerForImage.HorizontalOffset - offsetX);
                scrollViewerForImage.ScrollToVerticalOffset(scrollViewerForImage.VerticalOffset - offsetY);
            }

            base.OnMouseMove(e);
        }
        #endregion

        #region Scroll Zoom
        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                lastMousePositionOnTarget = Mouse.GetPosition(panelOfImage);

                if (e.Delta > 0)
                {
                    if (ZoomScale + ZoomScale * 0.1 < 100)
                        ZoomScale += ZoomScale * 0.1;
                }
                else if (e.Delta < 0)
                {
                    if (ZoomScale - ZoomScale * 0.1 > 0)
                        ZoomScale -= ZoomScale * 0.1;
                }

                var centerOfViewport = new Point(scrollViewerForImage.ViewportWidth / 2, scrollViewerForImage.ViewportHeight / 2);
                lastCenterPositionOnTarget = scrollViewerForImage.TranslatePoint(centerOfViewport, panelOfImage);

                e.Handled = true;
            }

            base.OnPreviewMouseWheel(e);
        }

        void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewerForImage.ViewportWidth / 2, scrollViewerForImage.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewerForImage.TranslatePoint(centerOfViewport, panelOfImage);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(panelOfImage);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / panelOfImage.ActualWidth;//.Width;
                    double multiplicatorY = e.ExtentHeight / panelOfImage.ActualHeight;//.Height;

                    double newOffsetX = scrollViewerForImage.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewerForImage.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewerForImage.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewerForImage.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }
        #endregion

    }
}
