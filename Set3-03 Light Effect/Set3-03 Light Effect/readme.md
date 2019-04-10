## Light Effect
요소에 PointLight효과를 만드는 방법을 보여준다.
이 경우에는 Visual Studio 로고를 사용하고 로고를 통과하는 효과를 보여주는 애니메이션을 사용한다.
PointLight 효과는 Accept로 트리거되고, Clear로 지워진다.


## Summary
이 예제에서는 윈도우10의 November Anniversary update에서 추가된 Composition기능을 이용한다.
여기서는 그 중 PointLight를 이용한다.
우선 Visual Studio 로고 Visual을 얻은 다음 Composer을 사용하여 주어진 색상의 PointLight를 만든다.
이 예제에서는 색을 White로 지정하였고, CoordinateSpace은 광원의 경계를 정의하는 Visual로 설정되었으며,
Target은 로고로 설정하였다.
이후 Offset이 설정되었다.
이를 통해 PointLight가 로고 위로 지나가는 것처럼 보이는 애니메이션이 설정되며 이는 loop로 발생한다.