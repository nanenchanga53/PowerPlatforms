# Power Apps 공유 2 - 게스트 사용자 구성원과 공유
> 파워 플랫폼에서 만든 앱이나 구성요소들은 같은 구성원이나 게스트, 혹은 파일로 내보내거나 솔루션에 포함시켜 공유가 가능하다. Power Apps에서 만든 앱,라이브러리 구성요소를 공유해보자 여기서는 게스트 사용자 구성원과 공유하는 법을 설명하겠다. 참고로 게스트 사용자는 수정이 불가능하다.

## 게스트 사용자 초대
> Azure Active Directory에서 게스트 사용자를 등록하여 사용 가능하다. Active Directory에 관한 설정은 추후에 별도 페이지에서 자세히 설명하셌다.

1. Microsoft 365 관리 센터에서 <span style="color:red"> 사용자 -> 게스트 사용자</span> 에서 <span style="color:red"> '게스트 사용자 추가'</span> 클릭하면 Azure Active Directory로 넘어간다.<br>![image](https://user-images.githubusercontent.com/39551265/161465138-cfc34561-bd54-4bfd-97a9-b80be9c44e55.png)<br>

2. <span style="color:red">사용자 초대</span>를 선택, ID에서 사용자의 정보를 입력 하고, <span style="color:red">'역할'</span> 을 클릭<br>![image](https://user-images.githubusercontent.com/39551265/161465582-a77a3a42-8029-4460-8ac2-aae8d97274e7.png)<br>

3. <span style="color:red">초대</span> 클릭

4. 초대받은 대상자는 다음과 같은 이메일을 받게 될 것이다. 이때 <span style="color:red">초대 수락</span>을 클릭하고 로그인하면 초대가 완료된다.<br>![image](https://user-images.githubusercontent.com/39551265/161467450-9b781012-f81b-4fad-89b1-8f6ac3e1ab8d.png)<br>

## 앱, 구성 요소 라이브러리를 조직의 사용자와 공유
> 앱, 구성 요소 라이브러리를 공유하기 전에 꼭 현재 공유하려는 버전이 '게시'가 완료 되었는지 확인하자. 공유는 '게시'가 최종적으로 된 버전을 공유한다.

1. 앱을 공유하는 첫번째 방법은 파워앱스 포털에서 '앱' 메뉴에서 '앱' 혹은 '구성 요소 라이브러리'를 선택 후 <span style="color:red">공유</span>를 상단에서 클릭하거나 해당 공유하려는 곳 오른쪽에 <span style="color:red">... -> 공유</span> 를 선택하면 공유대상자를 선택하는 화면으로 넘어간다.<br>![image](https://user-images.githubusercontent.com/39551265/161429082-262c5471-b542-4fa3-aff8-c3b52d5e037c.png)<br>

2. 앱을 공유하는 두번째 방법은 파워앱스 포털에서 공유하려는 앱의 편집창에서 '저장' 메뉴로 가면(저장과 게시를 하는 화면) <span style="color:red">공유</span>를 클릭</span> 를 선택하면 공유대상자를 선택하는 화면으로 넘어간다<br>![image](https://user-images.githubusercontent.com/39551265/161428928-7d426b9e-160d-40c5-baaf-dbe7dbc91539.png)<br>

3. 그다음 앱을 공유하는 사용자를 선택창이 뜰 것이다. 이곳에서 '이름, 이메일 주소 입력'이라고 쓰여진 영역에 공유하려는 사용자의 이름이나 이메일 주소를 넣으면 해당 사용자의 정보가 보일 것이다. 이곳에서 사용자를 선택 하여 추가한 후 <span style="color:red">공유</span> 를 클릭한다.<br>![파워앱스공유](https://user-images.githubusercontent.com/39551265/161429807-79368bf3-c88b-4fe8-8ec3-8210a3b42438.gif)<br>

4. 공유한 계정에서 해당 앱이 '앱' 메뉴에서 리스트에 포함되어 있는지 확인한다.<br>![image](https://user-images.githubusercontent.com/39551265/161430374-26993bc2-17e4-41d4-b46c-00591b07a9e7.png)<br>

