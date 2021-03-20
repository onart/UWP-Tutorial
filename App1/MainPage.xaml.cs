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
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("한국어 가능?");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
            // 컴퓨터가 말함. https://docs.microsoft.com/ko-kr/uwp/api/windows.media.speechsynthesis?view=winrt-19041
        }

        private void button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            button.Background = new SolidColorBrush(color: Windows.UI.Color.FromArgb(155, 255, 255, 255));
        }

        private void button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            button.Background = new SolidColorBrush(color: Windows.UI.Color.FromArgb(255, 100, 100, 100));
        }

        private void toSub_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SubPage));   //이 프레임에 SubPage를 연다(Navigate)
        }
    }
}
