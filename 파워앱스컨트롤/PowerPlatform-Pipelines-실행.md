# PowerPlatform-Pipelines-실행,확인
> 해당 내용은 [PowerPlatform Pipelines 소개](https://nanenchanga.tistory.com/entry/PowerPlatform-Pipelines-%EC%86%8C%EA%B0%9C)의 내용을 알고 있다는 전제로 작성되있다. 

## 파이프라인 실행

1. 개발 환경(Host 환경이 아니다)에서 솔루션을 만들어 배포할 항목을 포함시킨다.(솔루션은 관리형이 '아니요' 상태야한다)

![스크린샷 2023-05-19 105600](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/49dc6541-7893-4d43-921c-78de6d509e43)

2. 솔루션의 상세 페이지로 들어가 좌측의 파이프라인(로켓아이콘) 항목을 연다.

3. '파이프라인' 이전 생성한 파이프라인을 선택한다.

4. 화면에 단계(Stage) 순서로 좌측부터 개발(현재환경) -> 다음단계(QA 등) -> 서비스(Production) 단계로 각 환경이 표시될 것이다. 각 단계별로 배포를 진행한다.

* 참고로 단계(Stage)에서 다음 단계로 배포시 이전 단계에서 마지막으로 배포된 것을 배포하게된다. (QA에 1.01v 배포후 문제가 있어 1.02v가 배포가 되었다면 다음 단계인 서비스에서는 1.02v가 배포되게 된다.)

## 이력확인

1. 파이프라인을 실행한 솔루션의 '파이프 라인'의 '실행 기록' 탭으로 들어가면 파이프라인을 선택후 실행 기록을 볼 수 있다.

![스크린샷 2023-05-23 093758](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/63a159de-ca51-4f84-85ff-e2ba9671d49f)

2. 호스트(Host) 환경 Power Apps 페이지에서 '배포 파이프라인 구성'으로 들어간다. '실행기록'에서 파이프라인의 실행 이력을 확인할 수 있다.

![스크린샷 2023-05-23 103026](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/9370a3bc-5a02-4c01-b86f-ab2d95fd342a)

## 솔루션 아티팩트 확인

1. '배포 파이프라인 구성' 에서 '솔루션 아티팩트'로 들어가면 배포에 사용했던 솔루션들이 버전별로 기록되어 있다. 이곳에서 배포 솔루션의 버전별로 다시 다운로드를 받을 수 있으니 롤백이 필요하다면 해당 솔루션을 받아 사용하면 된다.

![스크린샷 2023-05-23 103845](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/1a890ad6-0c71-4ed5-aca9-e341f004a5fd)

## 오류확인

1. 솔루션을 배포시 해당 솔루션에 포함되어야할 항목이 빠져 있다면 배포를 실행시 오류가 나오는 것을 확인 가능하다(DataFlow와 연결 참조 등 솔루션에서 에러를 반환하는것이 부족한 것은 조심하여 같은 솔루션에 포함시키자)

![스크린샷 2023-05-22 105831](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/892f1442-8548-4c62-a708-895cda4eaf77)

2. '배포 파이프라인 구성'에서 '파이프라인' 의 특정 파이프라인의 상세화면에서 '실행기록' 탭으로 들어간다. 이곳에서 실행에 실패한 행을 여는 것으로 오류에 대한 정보를 알 수 있다.(실행기록에서도 들어가는게 가능)

![스크린샷 2023-05-23 132854](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/7e3d1d7c-34d3-4346-876e-12e36ce1e687)

![스크린샷 2023-05-23 141042](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/9d1e107e-4dd9-4c03-a884-4f3d193182cd)

## 주의사항

1. Power Automate 같이 솔루션에 포함하지 않은체 제작하면 솔루션에 포함하기 힘든 항목들이 있을 수 있으니 모든 항목은 미리 솔루션에 포함해서 만들어 두자

2. DataFlow 같이 실행하는데 연결이 필요해도 솔루션에 연결을 포함하지 않아도 오류없이 배포(관리형 솔루션 만들기)하는 경우가 있다.

3. 배포한 솔루션은 이전버전으로 롤백을 할 수 없다. 만약 필요하다면 이전 단계부터 다시 배포를 한다.