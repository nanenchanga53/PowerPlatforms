# 모델기반앱에 캔버스앱 삽입 2 - Iframe으로 만들어 대시보드에 삽입
> 모델기반앱에서 캔버스 앱을 삽입하여 사용하는 방법 중 Iframe으로 만들어 삽입하는 방법을 다룬다. 여기서 사용하는 페이지는 대시보드를 사용한다.

## 캔버스 앱 웹 링크 확인
1. Power Apps의 '앱' 메뉴에서 삽입하려는 앱을 선택. 우상단 <span style="color:red">자세히</span> 를 클릭 혹은 <span style="color:red">... -> 자세히</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/163081310-fa48a02d-e7ca-4a3d-ad54-f8d4491314ba.png)<br>

2. '웹 링크' 항목의 값을 복사한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163294972-398e6f04-8f1f-4a51-bf51-582801f53897.png)<br>


## 대시보드 만들기

1. 파워앱스에서 대시보드를 만들고 관리할 솔루션 페이지로 들어간다. 만약 없다면 새로 생성하자<br><br>![image](https://user-images.githubusercontent.com/39551265/163296112-4565bde9-3365-4ee0-836d-127f5bb484c6.png)<br>

2. <span style="color:red">+신규 -> 대시보드 -> {원하 열의 개수}개요</span>. (필자는 2열 개요를 선택) <br><br>![image](https://user-images.githubusercontent.com/39551265/163296465-e0ea1f23-a68e-4c85-9782-8235df3b814c.png)<br>

3. 대시보드의 '이름'을 입력후 '섹션'에서 한개의 영역을 선택 후 <span style="color:red">Ifrmae</span>을 클릭하거나 아이콘을 클릭한다.<br>![image](https://user-images.githubusercontent.com/39551265/163297979-860cc4e5-f4d4-4c23-9944-d12193e8649b.png)<br>

4. 'URL' 항목에 복사한 '캠버스 앱 웹 링크'를 입력한다. <br>그 후 캔버스 앱의 스크립트 기능을 제한하지 않도록 '보안' 항목을 체크해제 한다.<br>만약 모바일에서도 보이게 하려면 더 아래로 내려 '표시영역'의 '모바일에서 사용'을 체크 한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163298775-46189fb5-99db-4ec3-8fa7-d50e8433920e.png)<br>

5. 대시보드를 저장하고 닫는다. <br><br>![image](https://user-images.githubusercontent.com/39551265/163299248-c08696bd-21ec-4296-80e6-d29d91275183.png)<br>

6. 만든 대시보드를 선택 후 <span style="color:red">게시</span>를 클릭하거나 <span style="color:red">... -> 게시</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/163299429-9d4d447e-0529-4bab-864a-77c498a65a33.png)<br>

7. 게시가 완료되는것을 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163302685-5c11db61-d33a-4565-9d64-40d67d7488bb.png)<br>

## 모델 기반 앱에 대시보드 추가

1. 모델 기반 앱 편집창(프리뷰)에서 <span style="color:red">+ 페이지 추가</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/163303201-fe10efc5-ff0e-4e21-bcad-0251669be0ca.png)<br>


2. '페이지 유형 선택' 항목에서 <span style="color:red">대시보드</span>를 선택 후 <span style="color:red">다음</span><br><br>![image](https://user-images.githubusercontent.com/39551265/163308367-58817a9f-a005-4960-9127-39176a75130c.png)<br> 


3. '대시보드 선택'에서 새로 만들었던 대시보드를 선택 후 <span style="color:red">추가</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/163308621-a7be7f57-8719-47d7-899f-efe82fb6af4b.png)<br>


4. 그 후 '대시보드'가 추가되며 캔버스 앱이 포함되어 있는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163308998-63314264-ce0a-4f1b-95a2-6d8e32cc81b1.png)<br>