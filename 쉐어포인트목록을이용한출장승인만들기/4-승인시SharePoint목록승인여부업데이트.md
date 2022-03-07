# 승인시 SharePoint 목록 승인여부 업데이트
> 여기서는 승인이 되었을시 SharePoint의 새로 생성했던 목록에서 승인여부가 예(체크표시)로 변경해보자<br>![image](https://user-images.githubusercontent.com/39551265/156521977-91dcbdfc-5159-4bf1-a4b6-6ab83be9f830.png)<br>

## SharePoint 목록 업데이트 작업 만들기
1. '승인 요청만들기'에서 만들던 흐름을 계속하거나 '내 흐름' 창에서 편집하려는 항목의 마우스 커서를 가져가 '연필 이미지'를 클릭해서 편집을 시작<br>![image](https://user-images.githubusercontent.com/39551265/155634975-02332e62-638f-4d0c-8c1e-bacc70538044.png)<br>

2. 화면에서 condition을 클릭하여 하위 항목을 본다(아래에 예,아니요 항목이 있다면 나둔다)<br>![image](https://user-images.githubusercontent.com/39551265/155635253-c39cfabc-071e-4b05-bd59-97883d7c90be.png)<br>

3. '예' 안에 저번에 만든 <span style="color:red">각각의 적용</span> 아래의 <span style="color:red">작업 추가</span> 클릭(각각의 적용 안에 있는걸 클릭하면 안된다)<br>![image](https://user-images.githubusercontent.com/39551265/156520755-58111395-d1ef-4848-ac41-12c710a0cfd4.png)<br>

4. '작업 선택' 에서 <span style="color:red">SharePoint</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/156522967-717d48ea-14e7-44f9-8070-2d884151e9a1.png)<br>

5. <span style="color:red">항목 업데이트</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/156525556-1d86a67b-6fee-41e1-b33e-b2dab530b59a.png)<br>

## 항목 업데이트

1. '사이트 주소' 에서 업데이트 하려는 목록이 있는 SharePoint를 선택

2. '목록 이름' 에서 업데이트 하려는 목록을 선택

3. 'ID' 에서 항목을 선택하면 '동적 콘텐츠' 창이 보일 것이다. 이곳에서 'When a new item is created' 아래의 <span style="color:red">ID</span> 를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/156526594-e28b9bba-ea71-405e-abb7-99cd715763c1.png)<br>

4. 'Title' 에는 '동적 콘텐츠' 에서 'When a new item is created' 아래의 <span style="color:red">TITLE</span> 를 클릭
5. '승인여부'를 '예'로 변경<br>![image](https://user-images.githubusercontent.com/39551265/156533322-f83d6fcf-43b6-476c-8901-1b2354812f3d.png)<br>

6. 저장 -> 테스트 를 실행하여 SharePoint목록에서 새로 만들고 승인을 해보자

7. 새로 생성한 항목에 승인이 체크가 되어있는 것을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/156533883-967ef77c-5659-4fa9-93b0-fdb73de251a5.png)<br>

## 결론
* 이것으로 목록에서 생성한 것들 중 어떤것이 승인되었는지 확인할 수 있게 되었다. 다음에는 보안 설정을 통해 관리자는 모든 목록의 내용을 볼 수 있고 사용자는 자신이 생성한 데이터만 볼 수 있도록 변경해보자.