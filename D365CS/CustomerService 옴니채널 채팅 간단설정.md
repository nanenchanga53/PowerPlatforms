# CustomerService 옴니채널 채팅 간단 생성
> 옴니채널 생성에 관해서 [다음](https://nanenchanga.tistory.com/entry/D365-Customer-Service-%EC%97%90%EC%84%9C-%EC%98%B4%EB%8B%88%EC%B1%84%EB%84%90-%EC%82%AC%EC%9A%A9%EC%84%A4%EC%A0%95) 참조

## 옴니채널 보안 역할 관리
> 옴니채널을 사용하려면 환경 사용자에게 별도의 보안 역할을 할당해야한다.(시스템 관리자 권한이 있어도 할당해야한다)

1. 옴내채널을 설치한 환경의 사용자 설정 페이지로 이동한다.

2. 옴니채널을 사용할 사용자를 선택 후 '보안 역할 관리' 클릭

![스크린샷 2023-06-27 141208](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/0f29d180-e674-4db2-8487-71c104723181)

3. 필요한 옴니채널 보안역할을 할당한다.(Omnichannel administrator 로 관리자권한을 agent 역할을 담당해 옴니채널의 에이전트로 사용할 수 있도록 할 수 있다.)

![스크린샷 2023-06-27 141304](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/377636c9-cf13-416d-ba4a-7f4a283a5611)

## 옴니채널 채팅(chat) 생성

1. 'Customer Service 관리 센터' 에서 '채널' 페이지의 '관리' 로 이동한다.

![스크린샷 2023-06-27 094731](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/735a025d-8869-4e5e-a0c4-c8aa4a1936a6)

2. '+ 채팅 채널 추가'를 클릭해 채널을 추가한다.

![스크린샷 2023-06-27 110613](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/89773788-63b6-4cda-b1ea-52843094019c)

3. 채널의 이름을 입력, 기본 언어를 선택한다.

![스크린샷 2023-06-27 110740](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/2531e02d-e212-4c98-888e-80e466b8e5ca)

4. 작업스트림을 새로 생성하거나 선택한다. 채팅의 경우 '작업 배포 모드'에서 자동으로 에이전트에 할당되는 '푸시'를 설정하는 것이 좋다. 이후 폴벡 큐를 선택하고 다음

![스크린샷 2023-06-27 111327](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/db431165-49c4-439a-8e6b-956cb9369a98)

5. 채팅 위젯 페이지지에서는위젯의 모양과 표시 설정을 할 수 있다.<br>'직함'(위젯에 표시되는 제목)<br>'부제목'<br>'테마 색상'<br>'로고 URL'<br>'에이전트 표시이름'(채팅시 에이전트로 등록되어 있는 사용자 이름을 가져온다)<br>'위젯 위치'(스크립트를 수정해서도 위치를 변경 가능하다) 각 설정을 이용해서 위젯의 형태를 지정할 수 있다.<br>'사전 채팅'에서는 스크립트를 수정하여 채팅에 대한 조건을 줄 수 있다. 예를 들어 웹페이지를 고객이 지속적으로 이용시 채팅이 시작되도록 유도할 수 있다.<br>'이전 채팅에 다시 연결' 은 재접속시에 채팅을 지속적으로 이어질 수 있도록 설정할 수 있다.<br>'작업 시간에 위젯 표시' 지정된 작업시간에만 위젯이 나타내도록 표시할 수 있다.<br>'제공된 도메인에만 위젯 표시' 도메인 URL을 입력해 해당 도메인에만 위젯이 나타내도록 설정할 수 있다.<br>

![스크린샷 2023-06-27 150726](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/5b157797-9b1e-4701-9e1a-a3652b2f69d6)

![스크린샷 2023-06-27 152238](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/7f03d6a9-6f8f-4712-99f7-5a5983175f96)

6. '동작' 페이지에서는 고객이 채팅중에 자동으로 수행할 기능을 설정 가능하다.<br>'자동 메시지 사용자 지정'에서는 특정 트리거에 따라 메시지를 자동으로 보내도록 설정할 수 있다.<br>'대화 전 설문' 고객이 채팅하기 전 작성하는 정보를 설정 가능하다. 이름(name), 이메일(emailaddress1), 전화번호(telephone1), 문제(ticketnumber) 를 설정하면 자동으로 고객을 옴니채널에서 식별할 수 있다.<br>'대화 후 설문 조사'는 D365 Customer Voice와 연동하여 대화가 종료 후 고객의 설문조사를 사용할 수 있다.<br>'인증 설정' 영구적으로 채팅을 유지하려면 인증설정을 사용해야한다.<br>'고객 대기 시간' 큐에서의 위치와 평균 대기 시간을 바탕으로 고객에게 자동 메시지를 보낸다.<br>'고객 위치 검색' 고객 위치 검색을 허용할지 고객에게 묻는 메시지가 표시된다.

![스크린샷 2023-06-27 170200](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/bb2ba39c-2522-415a-bcc1-ed4e7a4b1a62)

7. '사용자 기능' 페이지에서는 채팅을 사용하는 에이전트와 사용자가 사용 가능한 추가 기능을 설정할 수 있다.<br>'첨부파일'<br>'고객 알림' 에이전트가 보내는 메시지에 대한 알림을 받오록 허용'<br>'대화록' 대화내역을 다운 혹은 이메일 발송을 허용<br>'음성 및 영상 통화' 에이전트에게 음성 또는 화상 통화를 허용<br>'화면 공유' 화면 공유기능(App Source에서 공급자를 설치해야한다)<br>'공동 검색' 웹 페이지를 에이전트가 함께 사용할 수 있도록 허용(App Source에서 공급자를 설치해야한다.) '화면 공유'와 함께 사용 불가

![스크린샷 2023-06-27 170221](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/bb9311d2-51cb-4f6a-a07e-89c849b466e0)

8. 이후 검토 후 '옴니 채널 채팅'이 생성된다.