# Power Apps(캔버스앱)에서 CSV로 다운로드
> 캔버스앱에서 CSV파일을 다운로드 받는 방식을 설명한다. 이 문서에서는 Dataverse안에 있는 데이터 원본을 Power Automate를 이용해 원하는 저장소에 파일을 저장하는 과정을 설명한다.

## 캔버스 앱에서 데이터 원본을 JSON 형태의 파일로 만들기

1. 캔버스 앱에서 데이터 테이블(Dataverse 테이블)을 연결한다. [데이터 연결방법](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/%EB%8D%B0%EC%9D%B4%ED%84%B0%EC%97%B0%EA%B2%B0.md)<br><br>![image](https://user-images.githubusercontent.com/39551265/162657858-ae89cd9f-47dc-4280-80e4-aee843b98ed2.png)<br>

2. 원하는 이벤트가 포함된 컨트롤을 추가(예제에서는 버튼 컨트롤을 사용한다.)<br>![image](https://user-images.githubusercontent.com/39551265/162658280-7222ee47-4add-4519-88dc-8825a031c3f4.png)<br>

3. 