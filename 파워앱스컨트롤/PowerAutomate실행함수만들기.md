# PowerAutomate 실행함수 만들기

## Power Apps에서 흐름 생성

1. Power Apps Studio 화면(앱 편집 화면)에 들어온다. <span style="color:red">작업 메뉴 -> Power Automate -> 새 흐름 만들기</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162572684-f79807c6-aee0-4eca-a035-f739b9de6311.png)<br>

2. <span style="color:red">+ 처음부터 만들기</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162572951-e2b9855e-9464-4d31-b329-386a4e7c9fb3.png)<br>

3. 처음 생성하면 다음과 비슷할 것이다. 흐름의 이름을 변경해두자<br>![image](https://user-images.githubusercontent.com/39551265/162573012-e37b9cfc-6ccd-4b14-9ddb-2587bc562853.png)<br>

## Power Automate에서 흐름 생성

1. Power Automate 에서 '내 흐름' 메뉴로 들어가 <span style="color:red">+ 새 흐름 -> 인스턴트 클라우드 흐름</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162569402-b4287ec4-b9a2-453a-a13d-3657f86efc02.png)<br>

2. '흐름 이름'을 입력한 후 <span style="color:red">Power Apps</span>선택 후 <span style="color:red">만들기</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162569747-b66523b1-1544-456f-8af1-1012bdb53f59.png)<br>

3. 처음 생성하면 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/162570222-93930671-bd5f-4e3b-b521-3b14a3627093.png)<br>


## 흐름에 단계를 추가하고 저장
> 트리거만 있는 상태(가장 처음 단계)에서 저장하면 오류가 난다. 그렇기 때문에 처음 생성하면 적당한 단계를 추가해두자

1. 흐름에서 <span style="color:red">+ 새 단계</span>클릭 하여 새 단계를 추가한다.<br>![image](https://user-images.githubusercontent.com/39551265/162573098-a31122f5-7069-48e5-9fa8-6fafec081be1.png)<br>

2. PowerApps에서 내보내는 값인 파라메터를 추가한다면, 새 단계 안에서 입력 항목에서 <span style="color:red">동적 콘텐츠 추가</span> 혹은 <span style="color:red">번개 이미지 클릭</span> 후 <span style="color:red">PowerApps에서 질문</span> 클릭, Power Apps 트리거의 동적값이 추가된다.<br>2022년 4월 기준 Power Automate의 UI가 변경중이라 여러 다음 이미지들 중에 같은 이미지를 선택하여 추가한다.<br>![image](https://user-images.githubusercontent.com/39551265/162573494-07f7c655-e469-4040-85c4-695a019a08d3.png)<br>![image](https://user-images.githubusercontent.com/39551265/162573521-6440ff50-0e23-4aa2-a533-2f4296ab7f47.png)<br>

3. 동적 값/동적 콘텐츠 를 다시 열면 값이 추가된 것을 확인 가능하다. 파라메터를 받아올 만큼 클릭해 생성한다.(주의할 점은 질문을 클릭시마다 새로 생성되고 지울 수 없다. 지우려면 트리거를 지웠다 다시 생성후 만들어야한다.)<br>![image](https://user-images.githubusercontent.com/39551265/162573853-5e61dba7-4b51-4d4d-b467-6a3ba8cb48da.png)<br>

4. <span style="color:red">저장</span>을 클릭해 흐름을 저장한다.

## Power Apps에서 흐름 실행 함수 추가

1. 만약 Power Apps에서 흐름을 추가했다면 다음과 같이 흐름이 추가된 것을 확인 가능하다.<br><br>

2. 만약 Power Automate에서 흐름을 추가했다면. <span style="color:red">+흐름 추가</span> 후 나오는 리스트에서 실행 시키려는 흐름을 추가한다.<br>![image](https://user-images.githubusercontent.com/39551265/162574493-4d378872-f787-47eb-83d7-4e38cc024037.png)<br>

3. '버튼' 등의 컨트롤을 앱에 추가 후 이벤트를 선택한다. 그 후 Power Fx에 `{흐름의 이름}.Run(파라메터값1,파라메터값2....)` 형식으로 흐름에서 생성한 질문 개수만큼의 값을 넣는다. <br>![image](https://user-images.githubusercontent.com/39551265/162575007-c02b4ed9-eb9b-4cf0-bd55-bd6e1d15a705.png)<br>

4. 그 후 직접 실행해서 이벤트를 실행(버튼의 경우 클릭)하면 Power Automate가 실행된다.

## Power Automate 실행 확인

1. Power Automate 에서 흐름 이름을 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162575185-18ef6a31-000d-4e8a-94d9-47a40698bfcf.png)<br>

2. 흐름에서 실행기록의 시간을 클릭하여 흐름의 실행을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/162576447-5ba6dfa6-a91f-4d9a-9fe2-c95d87cf810f.png)<br>