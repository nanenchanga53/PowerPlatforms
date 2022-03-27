# Power Automate 설정 : 웹 PA를 데스크탑 PA와 연결 3 - 데스크톱 흐름 동작 추가
> 이제 웹 파워 오토메이트에서 데스크탑 파워오토메이트 작업을 실행시키는 동작을 추가하고 실행해보자

## 데스크톱 버전 흐름 생성
1. 데스크톱에서 실행시킬 샘플 흐름을 만든다.(필자는 'test_WebStart'라는 흐름을 만들었다.)

2. '메시지 표시' 작업을 추가하고 '메시지 상자를 항상 위에 유지'를 설정한다.(윈도우 메시지의 경우 항상 위에 유지 설정을 하지 않으면 실행이 되지 않는다.)<br>![image](https://user-images.githubusercontent.com/39551265/160233761-3039b13a-4214-4936-9067-179021292c4e.png)<br>

3.  오른쪽 상단의 입출력 변수 칸이 존재할 것이다. 여기서 <span style="color:red">+</span> 아이콘을 클릭하자<br>![image](https://user-images.githubusercontent.com/39551265/160233803-6378e13d-0445-48e4-a305-78704c6caade.png)<br>

4. <span style="color:red">입력</span>과 <span style="color:red">출력</span> 이 나올 것이다. 여기서는 출력을 선택<br>![image](https://user-images.githubusercontent.com/39551265/160233828-a12ccbc1-1eda-4fdc-b3d8-1c12fc01dfd1.png)<br>

5. 변수의 이름과 외부이름을 원하는대로 변경하고 <span style="color:red">만들기</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/160233929-6ed73bfc-1e84-48e6-a728-f00967cf87aa.png)<br>

6. '변수 설정' 작업을 추가하고 해당 작업의 설정에서 '변수:' 항목 옆의 <span style="color:red">{x}</span> 클릭하여 이전에 생성한 출력 변수 선택 그리고 값에는 원하는 값으로 채운다<br>![image](https://user-images.githubusercontent.com/39551265/160234079-35783c70-e71a-416e-ad01-71e611bd6cff.png)<br>

7. 필자가 생성한 흐름의 작업은 다음과 같다.<br>![image](https://user-images.githubusercontent.com/39551265/160234182-5f6ef183-d646-447b-a978-4c09d30fac5f.png)<br>

8. 저장을 하고 한번 실행해 본다. 다음과 같은 메시지가 보일 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/160234215-0d411c1b-d5b9-4445-82fc-4b3422b77e65.png)<br>


## 웹 버전 작업 생성

1. 웹 파워오토메이트에서도 흐름을 생성한다.(필자는 트리거를 수동으로 Flow 트리거를 사용한다.)

2. <span style="color:red">**+새 단계**</span> 혹은 원하는 위치에서 <span style="color:red">**새 단계 삽입 아이콘 -> 작업 추가**</span>

3. <span style="color:red">Desktop flows</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/160234303-bde5be1b-48f1-4daa-b65b-8d468c7643f6.png)<br>

4. <span style="color:red">데스크톱용 Power Automate로 빌드된 흐름 실행</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/160234348-8d51009f-72f6-4bf7-aa39-7606aa14fa97.png)<br>

5. 연결을 처음 생성시 다음과 같은 연결을 추가하는 화면이 보일 것이다. <br>'연결' 항목은 '온-프레미스 데이터 게이트웨이 사용' 선택<br>'게이트웨이 이름' 항목에서는 'Power Automate 설정 : 웹 PA를 데스크탑 PA와 연결 1'에서 설정했던 게이트웨이의 이름 선택<br>'도메인 및 사용자 이름'에서는 'Power Automate 설정 : 웹 PA를 데스크탑 PA와 연결 2'에서 확인 했던 도메인, 사용자 이름을 입력한다.<br>'암호' 항목에서는 연결하려는 데스크톱 PC의 비밀번호를 입력한다.<br><span style="color:red">만들기</span>를 클릭하여 연결을 생성한다. <br>![image](https://user-images.githubusercontent.com/39551265/160234779-60222619-663d-42a7-8feb-bd14c37cece2.png)<br>

6. 작업 설정 화면으로 변경이 될 것이다.<br>'데스크톱 흐름' 항목에서는 이전 '데스크톱 버전 흐름 생성'에서 생성한 흐름을 선택<br>'실행 모드' 항목에서는 '유인(로그인했을 때 실행'을 선택한다.<br>![image](https://user-images.githubusercontent.com/39551265/160234976-e4124e91-16a0-4df2-ad6c-9214ff2a5c98.png)<br>


## 실행 결과

1. 흐름을 저장하고 테스트를 실행해보자. 테스트 결과는 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/160235130-4e3633e9-e555-404f-806a-bde1d0e0fbbb.png)<br>

2. <span style="color:red">원시 입력 표시</span>에서 데스크톱 통신의 입력값을 확인 가능

3. <span style="color:red">다운로드 하려면 클릭</span>에서 테스크톱 통신의 반환값을 확인 가능하다.

4. 'body' 값에는 데스크톱에서 설정한 출력 변수를 확인 가능하다. 해당 작업 이후에 'Json 구문 분석' 작업을 추가하여 사용하면 된다.<br>![image](https://user-images.githubusercontent.com/39551265/160235288-9f963a5b-f1d4-4dfa-94d6-ad1e7d471a46.png)<br>