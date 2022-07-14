# EidtForm 팁 - SubmitForm 후 원하는 페이지 이동 설정
> EditForm에서 SubmitForm 후 원하는 페이지로 가지 않고 이전 페이지로 갈 것이다. 이것을 원하는 페이지로 변경해보자.


## SubmitFrom 후 원하는 페이지 설정

1. EditForm의 내용을 실행하는 `SubmitForm(EditForm)` 실행후 해당 페이지 이전 페이지로 이동될 것이다.

2. EditForm의 속성 중 OnSuccess의 속성값을 `Back()`에서 `Navigate(페이지,None)` 를 입력해 원하는 페이지로 변경한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/178995769-7c7557cd-295d-4e05-92b4-1efda4eccd99.png)<br>

3. 실패했을 경우 페이지를 변경하려면 OnFailure 속성값을 `Navigate(페이지,None)`을 입력하거나 `Notify("실패",NotificationType.Error);` 이런 알림을 실행하게 만들 수 있다.

4. EditForm이 Create 수정 혹은 새로 생성인지 확인하려면 If문에 EditForm이름.Mode = FormMode.Edit 을 비교하여 사용한다. `If(EditForm이름.Mode = FormMode.Edit, 수정인경우, 생성인경우)` 