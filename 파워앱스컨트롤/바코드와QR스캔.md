# Power Apps 컨트롤 - 바코드 스캐너
> 바코드 스캐너 컨트롤은 바코드와 QR코드를 읽어 올 수 있는 컨트롤이다. 여기서는 간단한 사용법에 대해 알아본다.

## 컨트롤 삽입

1. 캔버스 앱 편집창에 들어와 '삽입' 탭에서 <span style="color:red">미디어 -> 바코드 스캐너</span> 컨트롤을 삽입한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180693965-1f09ce1c-2a1c-4297-acd4-d15f40a28d58.png)<br>


2. 삽입하면 위의 이미지 아래와 같이 버튼 컨트롤과 비슷한 형태의 컨트롤이 삽입될 것이다.

3. 텍스트 컨트롤을 만들어 텍스트를 보여줄 수 있는 속성(레이블의 경우 Text, 텍스트 입력의 경우 Default)에 `{바코드 스캐너 컨트롤의 이름}.Value`를 입력한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180694229-65deff10-738e-40f2-9f75-8651e811ef6f.png)<br>

4. 스캔한 바코드의 타입을 추가하려면 텍스트 컨트롤에 `{바코드 스캐너 컨트롤의 이름}.Type`을 입력한다.


## 실행

1. 이전에 만든 앱을 저장하고 '게시'한다.

2. 휴대전화 혹은 테블릿의 Power Apps 앱을 실행한다(없다면 Apps Store에서 다운받는다). 그 후 게시한 앱을 실행한다.

3. 바코드 스캐너 컨트롤을 실행하면(앱의 카메라 허용을 해야한다.) 바코드, QR코드에 카메라를 이동시킨다.(자동으로 읽는다.)

4. 이후 입력되는 항목과 바코드의 값이 같은지 확인한다. <br><br>![image](https://user-images.githubusercontent.com/39551265/180697330-c3c93e80-600a-44d7-94f3-3d0a01fcb950.png)<br>

* 만약 적당한 바코드가 없다면 다음 [사이트를 참조하자](https://wepplication.github.io/tools/barcodeGen/)


## 갤러리 컨트롤에 스캔이력 쌓기
> 컨트롤을 이용해 스캔직후 실행하는 이벤트 속성인 `OnSelect`속성을 이용하여 이력을 만들어본다.

1. 바코드 스캐너 컨트롤을 선택한 후 `OnSelect` 속성에 `colScannedItems` Collect 배열에 추가한다. 여기에 현재 읽어들인 값과 현재 시간을 입력하여 배열에 값이 쌓이도록 설정한다. 해당 속성의 값은 다음과 비슷한 형태이다.

```
// colScannedItems 배열을 만들고
// ScannedItem 에는  스캔한 값
// ScannedTime 에는 현재 시간의 값을 입력한다.
Collect(
    colScannedItems,
    {ScannedItem: BarcodeScanner1.Value, ScannedTime: Now()}
)
```

2. 위의 상황은 이미지로는 같다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180695968-f28f4605-1b29-4aad-be71-a050a3b4f145.png)<br>

3. 갤러리 컨트롤을 추가 한 후 텍스트 컨트롤을 추가한다. 이후 텍스트 속성에 Collect배열의 값을 입력한다.  <br><br>![image](https://user-images.githubusercontent.com/39551265/180696724-71820205-e597-41ef-8272-c25492c782af.png)<br>

```
ThisItem.ScannedItem // 스캔한 값
```

```
ThisItem.ScannedTime // 스캔한 시간
```

4. 이후 휴대전화 혹은 태블릿에서 해당 앱에서 스캔이 제대로 작동하는지 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/180697390-70ba4895-905b-448e-8eca-5656080475f7.png)<br>