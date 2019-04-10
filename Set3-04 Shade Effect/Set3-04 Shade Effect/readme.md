## Shade Effect
요소에 그림자 효과를 만드는 방법에 대한 코드이다
이 경우에는 Visual Studio 로고에 해당 효과를 적용한다.

## Summary
이 예제는 Windows 10의 November Anniversary Update에서 추가된 Composition feature들을 사용한다.
여기서는 그 중 SpriteVisual을 사용한다.
가장 먼저 Visual Studio 로고의 SpriteVisual을 얻은 다음 Compositor을 사용하여 지정된 색상의 DropShadow를 만든다.
예제에서는 색을 Black으로 설정하고, effect의 위치를 설정하는 Offset을 설정한다.
그리고 Shadow Effect를 받지 않을 부분을 Mask에 정의한다.
이후 SpriteVisual은 Child Visual Element를 DropShadow로 설정한다.