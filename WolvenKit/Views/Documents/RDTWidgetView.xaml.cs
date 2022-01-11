using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI;
using Splat;
using WolvenKit.Common.Services;
using WolvenKit.Functionality.Layout;
using WolvenKit.Functionality.Layout.inkWidgets;
using WolvenKit.RED4.Archive.Buffer;
using WolvenKit.RED4.Types;
using WolvenKit.ViewModels.Documents;

namespace WolvenKit.Views.Documents
{
    /// <summary>
    /// Interaction logic for RDTWidgetView.xaml
    /// </summary>
    public partial class RDTWidgetView : ReactiveUserControl<RDTWidgetViewModel>
    {
        public RDTWidgetView()
        {
            InitializeComponent();
            SetupWidgetPreview();

            this.WhenActivated(disposables =>
            {
                this.ViewModel.WhenAnyValue(x => x.library).Subscribe(library =>
                {
                    var stack = new StackPanel();
                    WidgetPreview.Children.Clear();
                    WidgetPreview.Children.Add(stack);
                    foreach (var item in library.LibraryItems)
                    {
                        if (item.PackageData == null || item.PackageData.Data is not Package04 pkg)
                        {
                            item.Package.Buffer.Decompress();
                            if (item.Package.Data is not Package04 pkg2)
                                return;
                            pkg = pkg2;
                        }

                        if (pkg.RootChunk is not inkWidgetLibraryItemInstance inst)
                            return;

                        if (inst.RootWidget.GetValue() is not inkWidget root)
                            return;

                        stack.Children.Add(root.CreateControl());
                    }
                });
            });
        }

        // Image Preview

        private System.Windows.Point origin;
        private System.Windows.Point start;
        private System.Windows.Point end;

        private void SetupWidgetPreview()
        {
            TransformGroup group = new TransformGroup();


            ScaleTransform xform = new ScaleTransform();
            //xform.ScaleY = -1;
            group.Children.Add(xform);

            TranslateTransform tt = new TranslateTransform();
            group.Children.Add(tt);

            //TranslateTransform zoomCenter = new TranslateTransform();
            //group.Children.Add(zoomCenter);

            WidgetPreview.SetCurrentValue(RenderTransformProperty, group);

            WidgetPreviewCanvas.PreviewMouseWheel += WidgetPreview_MouseWheel;
            WidgetPreviewCanvas.MouseDown += WidgetPreview_MouseLeftButtonDown;
            WidgetPreviewCanvas.MouseUp += WidgetPreview_MouseLeftButtonUp;
            WidgetPreviewCanvas.MouseMove += WidgetPreview_MouseMove;
        }

        private void WidgetPreview_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
            {
                WidgetPreviewCanvas.ReleaseMouseCapture();
                WidgetPreviewCanvas.SetCurrentValue(CursorProperty, Cursors.Arrow);
                TranslateTransform tt = (TranslateTransform)((TransformGroup)WidgetPreview.RenderTransform).Children[1];
                end = new System.Windows.Point(Math.Round(tt.X), Math.Round(tt.Y));
            }
        }

        private void WidgetPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (!WidgetPreviewCanvas.IsMouseCaptured)
                return;

            TranslateTransform tt = (TranslateTransform)((TransformGroup)WidgetPreview.RenderTransform).Children[1];
            Vector v = start - Mouse.GetPosition(WidgetPreviewCanvas);
            tt.X = Math.Round(origin.X - v.X);
            tt.Y = Math.Round(origin.Y - v.Y);
        }

        private void WidgetPreview_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            start = Mouse.GetPosition(WidgetPreviewCanvas);
            if (e.ChangedButton == MouseButton.Middle)
            {
                WidgetPreviewCanvas.CaptureMouse();
                // resets when children are hittble? idk
                TranslateTransform tt = (TranslateTransform)((TransformGroup)WidgetPreview.RenderTransform).Children[1];
                origin = end;
                tt.X = Math.Round(origin.X);
                tt.Y = Math.Round(origin.Y);
                WidgetPreviewCanvas.SetCurrentValue(CursorProperty, Cursors.ScrollAll);
            }
        }

        private void WidgetPreview_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TransformGroup transformGroup = (TransformGroup)WidgetPreview.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];
            TranslateTransform pan = (TranslateTransform)transformGroup.Children[1];

            double zoom = e.Delta > 0 ? 1.189207115 : (1 / 1.189207115);

            var CursorPosCanvas = e.GetPosition(WidgetPreviewCanvas);
            pan.X += Math.Round(-(CursorPosCanvas.X - WidgetPreviewCanvas.RenderSize.Width / 2.0 - pan.X) * (zoom - 1.0));
            pan.Y += Math.Round(-(CursorPosCanvas.Y - WidgetPreviewCanvas.RenderSize.Height / 2.0 - pan.Y) * (zoom - 1.0));
            end.X = pan.X;
            end.Y = pan.Y;

            transform.ScaleX = zoom * transform.ScaleX;
            transform.ScaleY = transform.ScaleX;
            UpdateZoomText(transform.ScaleX);
        }

        public void UpdateZoomText(double scale)
        {
            ZoomText.SetCurrentValue(TextBlock.TextProperty, $"{(scale*100).ToString("F1")}%");
        }

        public void SetRealPixelZoom(object sender, RoutedEventArgs e)
        {
            TransformGroup transformGroup = (TransformGroup)WidgetPreview.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];
            TranslateTransform pan = (TranslateTransform)transformGroup.Children[1];

            //double zoom = ViewModel.Image.Width / WidgetPreview.RenderSize.Width;
            //double zoomQuot = zoom / transform.ScaleX;
            ////WidgetPreview.SetCurrentValue(WidthProperty, ViewModel.Image.Width);
            ////WidgetPreview.SetCurrentValue(HeightProperty, ViewModel.Image.Height);
            //var CursorPosCanvas = start;
            //pan.X += -(CursorPosCanvas.X - WidgetPreviewCanvas.RenderSize.Width / 2.0 - pan.X) * (zoomQuot - 1.0);
            //pan.Y += -(CursorPosCanvas.Y - WidgetPreviewCanvas.RenderSize.Height / 2.0 - pan.Y) * (zoomQuot - 1.0);
            //transform.ScaleX = zoom;
            //transform.ScaleY = zoom;

            transform.ScaleX = 1;
            transform.ScaleY = 1;
            UpdateZoomText(transform.ScaleX);
            pan.X = 0;
            pan.Y = 0;
            end.X = 0;
            end.Y = 0;
        }

        public void ResetZoomPan(object sender, RoutedEventArgs e)
        {
            TransformGroup transformGroup = (TransformGroup)WidgetPreview.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];
            TranslateTransform pan = (TranslateTransform)transformGroup.Children[1];

            transform.ScaleX = 1;
            transform.ScaleY = 1;
            UpdateZoomText(transform.ScaleX);
            pan.X = 0;
            pan.Y = 0;
            end.X = 0;
            end.Y = 0;
        }
    }
}
