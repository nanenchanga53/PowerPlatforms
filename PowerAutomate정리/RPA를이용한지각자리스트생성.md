# Sharepoint에 올라온 xls 파일을 데스크탑 PowerAutomate를 이용해 지각자 정리 - 1
> xls같이 오래된 엑셀파일은 웹 PowerAutomate에서는 사용할 수 없다. 가장 쉬운 방법은 엑셀을 데스크탑에서 열어서 다시 xlsx형식으로 다시 저장하는 것이다. 여기서는 xls파일을 SharePoint에서 업로드하면 데스크탑 Power Automate에서 다시 저장하고 원하는 데이터를 추출해 웹 PowerAutomate로 보내는 방법을 설명한다.

## 문제점 인식

1. 웹 Power Automate에서 제공하는 기본 엑셀을 읽는 흐름은 xls파일을 읽어올 수 없으며 다음과 같은 에러가 난다.<br><br>![화면 캡처 2023-02-13 133741](https://user-images.githubusercontent.com/39551265/218372172-b797a9d0-6f8b-4fe7-b23d-7865ae6b5efe.png)<br>

2. SharePoint에서 파일을 읽어 올 수 없는 상황이기에 웹 PowerAutomate에서는 처리하기 곤란하다. (MS의 기본제공 커넥터만 사용한다고 가정한다.)

## 해결방법

1. 데스크탑 Power Automate로 xls같이 오래된 엑셀형식을 열어도 쉽게 파일형식을 다시 저장가능하다. 

2. 쉐어포인트에 xls파일이 올라오면 그것을 트리거로 파일의 콘텐츠를 데스크탑으로 전달해서 xls파일을 xlsx파일로 변환하거나 데스크탑에서 데이터를 처리할 후 필요한 데이터만 웹 으로 반환하면 된다.


## 지각자를 체크하는 방법

1. 지각자는 10:01 분 이후에 처음으로 태깅된 사람이여야한다.

2. 만약 모드가 '출근'이 아니라 다른 것이였다고 해도 10:01 분 이전에 들어온적이 있다면 지각이 아니다.

3. 다음은 데이터의 예제

|발생일자|발생시각|단말기ID|이름|모드|
|---|---|---|---|---|
|2023-01-13|00:53:37|0011|김우창|출입|
|2023-01-13|01:42:04|0012|김창|출근|
|2023-01-13|01:50:04|0013|이우창|출입|
|2023-01-13|18:55:04|0014|김우창|퇴근|
|2023-01-13|18:55:07|0015|삼창|출입|
|2023-01-13|18:55:19|0016|사창|출입|

4. 위의 예제에서는 삼창,사창 이 지각자로 체크가 되어야 한다.