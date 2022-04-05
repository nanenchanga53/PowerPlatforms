# Power Apps 공유 3 - 앱 파일로 공유
> Power Apps Studio 에서 앱을 만들고 클라우드에 저장이 가능하지만 공유할 시, 제약사항이 존재한다. 앱을 파일로 데스크톱에 저장 후 공유하는 방법을 알아보겠다. 하지만 이 방법은 원본이 바뀐다고 같이 업데이트가 되는 것이 아니라 직접 수정해야한다. Git 허브로 따지면 기존 공유 방법은 Clone(원본이 수정되면 영향) 이번에 소개할 방법은 Fork(원본 수정에 영향이 없음)에 해당되는 것이라 보면된다.


## 앱 파일 다운
> 앱을 데스크탑에 최종게시버전을 다운 받는다. 이 파일을 공유하면 된다.

1. 공유하려는 앱을 '편집'을 클릭해 Power Apps Studio 로 들어간다.

2. 상단의 <span style="color:red">'파일'</span> 메뉴를 클릭 후 <span style="color:red">'다른 이름으로 저장'</span> 탭을 연다. 해당 화면에서 <span style="color:red">'이 컴퓨터'</span>를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/161661559-0ea21b3a-fc16-470a-a5e5-6d230b0a8ffe.png)<br>

3. <span style="color:red">다운로드</span> 를 클릭해 파일을 다운받는다.<br>![image](https://user-images.githubusercontent.com/39551265/161662352-31f2dd85-2cc4-411d-99cb-2b2e605b329a.png)<br>

4. `{앱이름}.msapp` 파일이 다운로드 될 것이다.

## 앱 불러오기
> 불러오기를 할때 데스크탑에서 접속이 가능한 폴더에 위치해야한다.

1. 별도 계정에서 적당한 앱의 '편집'을 클릭해 Power Apps Studio로 들어간다.

2. 상단의 <span style="color:red">'파일'</span> 메뉴를 클릭 후 <span style="color:red">'열기'</span> 탭을 연다. 해당 화면에서 <span style="color:red">'찾아보기'</span>를 클릭 <br>![image](https://user-images.githubusercontent.com/39551265/161663336-54244ce1-8596-4bc9-abb3-264fdb354a93.png)<br>

3. 다운로드 받은 파일 `{앱이름}.msapp` 을 업로드한다.

4. 이제 업로드한 앱이 열릴 것이다. 반드시 한번 '저장'을 하자.

5. Power Apps 에 해당 앱을 확인할 수 있을 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/161663817-7f8594e9-5bc1-4bf1-9adf-46a4d4ef5e8a.png)<br>