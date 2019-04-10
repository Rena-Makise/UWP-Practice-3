using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace Set3_03_Light_Effect
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Windows.UI.Composition.PointLight _light;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private Windows.UI.Composition.Compositor Compositor
        {
            get
            {
                return Windows.UI.Xaml.Hosting.ElementCompositionPreview.GetElementVisual(Logo).Compositor;
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            // PointLight 효과를 주기 위해서 GetElementVisual을 사용하여 Logo 엘리먼트를 가져온다.
            Windows.UI.Composition.Visual visual = Windows.UI.Xaml.Hosting.ElementCompositionPreview.GetElementVisual(Logo);
            _light = Compositor.CreatePointLight();
            _light.Color = Windows.UI.Colors.White;
            _light.CoordinateSpace = visual;
            _light.Targets.Add(visual);
            _light.Offset = new System.Numerics.Vector3(-(float)Logo.ActualWidth * 2, (float)Logo.ActualHeight / 2, (float)Logo.ActualHeight);

            // PointLight가 로고를 이동하는 ScalarKeyFrameAnimation 애니메이션을 설정한다.
            Windows.UI.Composition.ScalarKeyFrameAnimation animation = Compositor.CreateScalarKeyFrameAnimation();
            animation.InsertKeyFrame(1, 2 * (float)Logo.ActualWidth);
            animation.Duration = TimeSpan.FromSeconds(5.0f);
            animation.IterationBehavior = Windows.UI.Composition.AnimationIterationBehavior.Forever;
            _light.StartAnimation("Offset.X", animation);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // NullReferenceException을 방지하기 위해서 null 체킹을 먼저 한다.
            if (_light != null)
            {
                // Light Effect를 클리어한다.
                _light.Targets.RemoveAll();
            }
        }
    }
}
