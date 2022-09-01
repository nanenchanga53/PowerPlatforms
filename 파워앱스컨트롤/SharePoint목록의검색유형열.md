# Power Apps - SharePoint의 검색 유형 열
> 캔버스앱에서 SharePoint의 검색(LookUp) 형식 항목의 값이 어떻게 구성되고 사용할 수 있는지 알아보자

1. 아래 이미지와 같은 쉐어포인트의 목록을 만들어보자 이중 '검색열' 열은 유형(타입)이 검색(LookUp)으로 설정한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/187955691-31f10648-463b-4fc5-a374-2288510c9f31.png)<br>

2. '수정 폼' 컨트롤을 만들고 쉐어포인트의 목록을 원본으로 연결하자(Items속성까지 설정한다.)

3. '수정 폼' 컨트롤에서 검색항목은 '콤보상자' 컨트롤 생기는 것을 확인 가능하다. 해당 컨트롤을 선택하고 'DisplayFields' 속성과 'SearchFields' 항목을 'Value'로 변경한다. <br><br>![image](https://user-images.githubusercontent.com/39551265/187958173-6caede67-7831-442c-ab3b-e7aa20760df1.png)<br>

4. SahrePoint의 검색 유형의 열에서 선택할 수 있는 열이 목록으로 나오는 것을 볼 수 있다. <br><br>![image](https://user-images.githubusercontent.com/39551265/187960684-a82d3997-bccc-4036-8a6b-0b0bedd613f4.png)<br>

5. '콤보상자'에서 선택이 가능하다는 것은 해당 Collect형식으로 되어 있다는 것을 알 수 있다. 버튼 컨트롤을 만들고 OnSelect에서 `Collect(test,{데이터카드내의콤보상자컨트롤이름}.Selected)`를 입력하고 실행해본다.

6. 생성된 컬렉션을 확인해보면 'Id'와 'Value'로 구성되어 있는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/187969241-df41caab-6c45-4f79-b359-6ccfacfc1314.png)<br>

7. 'Value'는 SharePoint 목록에서 '위 목록에서 열 선택' 항목엣 선택항 항목이다. 'Id'는 원본 목록의 ID에 해당한다.

8. 실제 ID와 같은지 확인하기 위해 '표시 폼' 컨트롤을 생성하고 데이터 원본은 검색 대상으로 선택한 원본 목록을 선택한다.
9. Items 속성에는 `First(Filter({검색 유형의 열에서 선택한 원본 목록의 데이터 원본이름},ID = {데이터카드내의콤보상자컨트롤이름}.Selected.Id))` 이런식으로 연결된 원본의 값 하나와 연결한다.

10. 이후 기존 항목에서 선택을 변경하면 새로 생성된 컨트롤에서 연결되는 값에 때라 변경되는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/187970638-c49aa495-d603-413a-ae82-605ad30377d5.png)<br>