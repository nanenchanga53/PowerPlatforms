# EidtForm 팁 - 토글컨트롤 대신 확인란(체크박스컨트롤) 사용
> EditForm에서 예/아니요(Bool값)을 사용시 토글 컨트롤이 기본적으로 생성될 것이다. 토글 컨트롤 대신에 체크박스를 이용해 예/아니요(Bool 값)에 해당되는 값으로 연결되도록 설정해 본다.



## 체크박스컨트롤 사용

1. 다음과 같이 EditForm(편집 폼 컨트롤)의 데이터 필드 중 예/아니요(Bool값)을 생성하면 다음 이미지와 같이 기본적으론 토글 컨트롤로 생성된다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180237419-41ecbb91-4c71-420b-bff3-0050b3912fa4.png)<br>


2. 토글 컨트롤을 포함하는 해당 데이터 카드를 선택해 속성 창에서 '고급' 탭에서 <span style="color:red">'속성을 변경하려면 잠금 해제합니다'</span>를 클릭하여 잠금해제 한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180238465-2c6bb5cb-ff95-40a7-95c6-4ac4b2a07d8f.png)<br>

3. 이후 토글 컨트롤을 삭제하고 확인란(체크박스컨트롤)을 삽입한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180239107-7e0d31b5-bc2e-4147-aef2-8b4883035df8.png)<br>

4. 데이터 카드 위에 나타나는 에러를 클릭 후 <span style="color:red">수식 입력줄에서 편집</span>을 클릭한다. 그 중 레이블 컨트롤 'ErrorMessage' 이라면 Y값 속성값은 지운다.

5. 데이터 카드 위에 나타나는 에러를 클릭 후 <span style="color:red">수식 입력줄에서 편집</span>을 클릭한다. 그 중 데이터카드의 'Update'속성 이라면 Update  속성값을 `{Checkbox의 이름}.Value` 로 변경한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180240232-9f668022-d1f7-4885-87bb-10d09db2e834.png)<br>