# Power Apps 팁 - 매개변수(Param)
> Power Apps에서 만든 앱에서 매개변수(query 문자열)를 사용할 수 있다. 이를 이용해 모델 기반 앱이나 다른 사이트에서 해당앱을 열때 매개변수를 이용해 데이터를 미리 가져와 사용 가능하다.

## 쿼리 문자열

1. 웹 사이트에서 검색등을 사용시 ? 뒤에 여러가지 문자가 붙어지는것을 확인 가능할 것이다. 다음의 경우 naver에서 abc마트를 검색했을 경우의 url이다. 이때 ? 듸에 매개변수로 'sm', 'where', 'oquery'가 있으며 변수의 값이 뒤에 = 뒤에 같이 있는것을 확인 가능하다.<br>`https://search.naver.com/search.naver?sm=tab_hty.top&where=nexearch&query=abc%EB%A7%88%ED%8A%B8&oquery=abc&tqi=ho3flsp0YihssP573MdssssssFC-116178`

2. 만약 매개 변수가 url에 붙더라도 서버나 웹앱에서 매개 변수를 찾지 않으면 무시가 된다.(딱히 에러를 반환하지 않음)

## 캔버스 앱에서 매개변수 사용

1. 캔버스앱의 편집창에 들어가 'Label 컨트롤'을 생성하고 'Text' 속성에 `Param("MyID")`입력<br><br>![image](https://user-images.githubusercontent.com/39551265/170203475-04b91c2d-31c7-44f7-a569-0f282e9c6a22.png)<br>

2. 웹앱의 실행 Url 뒤에 `?MyID=ABC123`을 더해 접속한다. 'Label 컨트롤'에 매개변수 값이 추가된 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/170204926-7e27291b-db42-4738-a8a1-0ba94171e733.png)<br>

3. 만약 화면을 열었을시의 화면을 매개변수를 사용해서 정하고 싶다면 Onscreen 에서 IF문을 사용해 매개변수값을 검사하여 열게될 스크린을 정할 수 있을 것이다.<br>`If( Param("Screen") = "2",Screen2 )`<br>![image](https://user-images.githubusercontent.com/39551265/170213807-26ae4bf9-cf8c-47a6-89a4-7d98ebf3615f.png)<br><br>![image](https://user-images.githubusercontent.com/39551265/170214154-85052ebc-3e3c-4b84-9286-7122987aa263.png)<br>

4. 이런식으로 Power Apps에서도 매개변수를 받아서 사용 가능하다.