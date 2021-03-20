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

namespace App1
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaElement sound;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (sound == null) { 
                sound = new MediaElement();
                var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("한국어 가능?");
                sound.SetSource(stream, stream.ContentType);
            }
            sound.Play();
            // 컴퓨터가 말함. https://docs.microsoft.com/ko-kr/uwp/api/windows.media.speechsynthesis?view=winrt-19041
        }

        private void button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            button.Background = new SolidColorBrush(color: Windows.UI.Color.FromArgb(155, 255, 255, 255));
            //xaml에서 정의된 이름으로 접근
        }

        private void button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            button.Background = new SolidColorBrush(color: Windows.UI.Color.FromArgb(255, 100, 100, 100));
        }

        private void toSub_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SubPage), name.Text);   //이 프레임에 SubPage를 연다(Navigate)
            /*
             Frame 및 Page 클래스 정보
            여기서 코드는 앱의 초기 창 프레임에 대한 탐색이 실패할 경우 Navigate의 반환 값을 사용하여 앱 예외를 throw합니다.
            Navigate 가 true 를 반환하면 탐색이 수행됩니다.
            이제 앱을 빌드하고 실행합니다. "Click to go to page 2"라는 링크를 클릭합니다. 맨 위의 "Page 2"라는 두 번째
            페이지가 로드되어 프레임에 표시됩니다.
            앱이 기능을 추가하기 전에, 지금 추가한 페이지에서 앱의 탐색을 지원하는 방법을 살펴보겠습니다.
            먼저 App.xaml 코드 숨김 파일의 App.OnLaunched 메서드에서 앱에 대해 rootFrame 라는 프레임이 생성됩니다.
            Frame 클래스에서는 Navigate, GoBack, GoForward 등의 다양한 탐색 메서드와 BackStack,ForwardStack,
            BackStackDepth 등의 속성을 지원합니다.
            이 Frame 에 콘텐츠를 표시하려면 Navigate 메서드를 사용합니다. 기본값으로 이 메서드는 MainPage.xaml을
            로드합니다. 이 예제에서 Page1 은 Navigate 메서드로 전달되며, 메서드는 프레임 에 Page1 을 로드합니다.
            Page1 은 Page 클래스의 하위 클래스입니다. Page 클래스에는 Frame 속성이 있는데, 이는 Page 를 포함하는
            Frame 을 가져오는 읽기 전용 속성입니다. Page1 에서 HyperlinkButton 의 Click 이벤트 처리기가
            this.Frame.Navigate(typeof(Page2)) 를 호출할 때,Frame 은 Page2.xaml의 콘텐츠를 표시합니다.
            마지막으로 페이지가 프레임에 로드될 때마다, 이 페이지는 PageStackEntry로 Frame의 BackStack이나
            ForwardStack에 추가되어 기록 및 뒤로 탐색을 사용할 수 있습니다.
             */
        }
    }
}
