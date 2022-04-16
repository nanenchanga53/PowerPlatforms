# Power Apps FX함수 - JSON
> JSON 형태의 데이터로 변환하는 Power FX 함수 JSON


## 사용법

1. JSON 함수는 다음과 같은 형태를 같는다.<br>`JSON({데이터원본},JSONFormat.{데이터형식})`

2. JSON의 첫번째 인자는 JSON 형태로 변환할 데이터 원본을 사용하면된다. 데이터 원본은 데이터 변수(전역변수,레코드(테이블 행),테이블(컬렉션)) 혹은 미디어 데이터를 사용가능하다. 데이터 원본은 변수로 변환해서 사용해야한다.

3. 데이터 형식은 5가지가 있다. 가장 많이 사용되는건 JSON형식을 기독성 좋게 만드는 `IndentFour`, 통신에서 사용되며 데이터 처리시 사용하며 미디어 데이터를 포함하는 `IncludeBinaryData`가 있다.


4. JSONFormat 데이터 형식의 종류는 다음과 같다.


|데이터형식|용도|
|---|---|
|Compact|공백이나 줄 바꿈을 추가하지 않은 출력이 간결한 형태|
|IndentFour|가독성을 높인 위한 형태|
|IncludeBinaryData|이미지, 비디오 및 오디오 클립 열이 포함 형태. 앱 성능을 저하시킬 수 있지만 바이너리 데이터를 포함하는 데이터사용시엔 필요|
|IgnoreBinaryData|결과에는 이미지, 비디오 및 오디오 클립 열이 미포함. 바이너리 데이터를 포함하는 데이터사용시엔 필요.|
|IgnoreUnsupportedTypes|지원되지 않는 데이터 유형은 허용되지만 결과에는 포함되지 않는다. 기본적으로 지원되지 않는 데이터 유형은 오류를 생성|

5. IdentFour 예제<br><br>![image](https://user-images.githubusercontent.com/39551265/163679859-df517a0c-a8e6-45ab-b677-796c01ef1018.png)<br>


    ```
    Set(
        CompactJson,
        JSON(
            ClearCollect( CityPopulations,
            { clientname: "김시은",    deliverydate: "2022-03-31T00:00:00.000Z", Everage: 8615000 },
            { clientname: "피오씨",    deliverydate: "2022-03-30T00:00:00.000Z", Everage: 3562000 },
            { clientname: "테스트",    deliverydate: "2022-03-29T00:00:00.000Z", Everage: 3165000 }
            ),
            JSONFormat.IdentFour
            )
        )
    ```

6. IncludeBinaryData 예제 <br><br>![image](https://user-images.githubusercontent.com/39551265/163679935-b76e7028-9b32-419e-82c1-97779f98c562.png)<br>


    ```
    Set(
        IdenfFourJson,
        JSON(
            ClearCollect( CityPopulations,
            { clientname: "김시은",    deliverydate: "2022-03-31T00:00:00.000Z", Everage: 8615000 },
            { clientname: "피오씨",    deliverydate: "2022-03-30T00:00:00.000Z", Everage: 3562000 },
            { clientname: "테스트",    deliverydate: "2022-03-29T00:00:00.000Z", Everage: 3165000 }
            ),
            JSONFormat.IndentFour
            )
        )
    ```

## 미디어 데이터

1. 이미지나 비디오 같은 데이터는 base64 형태를 가진다.

2. 이미지를 변화하면 다음과 같이 사용 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163677612-7e180c38-a0d1-4f7d-ad61-b795140738d6.png)<br>

3. 이미지는 다음과 비슷하게 JSON값이 만들어진다.


    ```
    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOcAAADpCAIAAABQnLcHAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAABqOSURBVHhe7Z35c51Xecf7rxQv2qXQbQ=
    ```