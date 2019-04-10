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

namespace Set3_04_Shade_Effect
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Windows.UI.Composition.SpriteVisual _visual;

        private Windows.UI.Composition.Compositor Compositor
        {
            get
            {
                return Windows.UI.Xaml.Hosting.ElementCompositionPreview.GetElementVisual(Logo).Compositor;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            // SpriteVisual의 Shadow 속성에 적용될 음영효과를 형성하는 DropShadow를 설정한다.
            _visual = Compositor.CreateSpriteVisual();
            _visual.Size = new System.Numerics.Vector2((float)Logo.ActualWidth, (float)Logo.ActualHeight);
            Windows.UI.Composition.DropShadow shadow = Compositor.CreateDropShadow();
            shadow.Color = Windows.UI.Colors.Black;
            shadow.Offset = new System.Numerics.Vector3(10, 10, 0);
            shadow.Mask = Logo.GetAlphaMask();
            _visual.Shadow = shadow;


            // 설정한 _visual을 xaml의 ShadowElement에 연결되도록 설정을 한다.
            Windows.UI.Xaml.Hosting.ElementCompositionPreview.SetElementChildVisual(ShadowElement, _visual);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // SpriteVisual의 Shadow 속성을 null값으로 초기화시킨다.
            _visual.Shadow = null;
        }
    }
}
