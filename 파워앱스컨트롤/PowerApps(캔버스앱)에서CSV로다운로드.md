# Power Apps(캔버스앱)에서 CSV로 다운로드
> 캔버스앱에서 CSV파일을 다운로드 받는 방식을 설명한다. 이 문서에서는 Dataverse안에 있는 데이터 원본을 Power Automate를 이용해 원하는 저장소에 파일을 저장하는 과정을 설명한다.

## 캔버스 앱에서 데이터 원본을 JSON 형태의 데이터로 만들기

1. 캔버스 앱에서 데이터 테이블(Dataverse 테이블)을 연결한다. [데이터 연결방법](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/%EB%8D%B0%EC%9D%B4%ED%84%B0%EC%97%B0%EA%B2%B0.md)<br><br>![image](https://user-images.githubusercontent.com/39551265/162657858-ae89cd9f-47dc-4280-80e4-aee843b98ed2.png)<br>

2. 원하는 동작(이벤트)가 포함된 컨트롤을 추가(예제에서는 버튼 컨트롤을 사용한다.)<br><br>![image](https://user-images.githubusercontent.com/39551265/162658280-7222ee47-4add-4519-88dc-8825a031c3f4.png)<br>

3. 사용하는 동작(이벤트)에 다음과 같은 함수를 추가한다.<br>ShowColumns의 첫번째 인자는 원하는 테이블을 사용, 그 후로는 사용하려는 열의 이름을 추가하여 사용한다. [ShowColums 함수 상세설명](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/FX%ED%95%A8%EC%88%98-ShowColumns.md)<br>JSON 함수를 사용해서 테이블을 JSON형식으로 만든다. 이때 이미지등을 포함하려면 JSONFormat은 `IncludeBinaryData` 를 사용한다. [JSON 함수 상세설명](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/Fx%ED%95%A8%EC%88%98-JSON.md)<br>그 후 Set을 이용해 `varJSONOrderDetail` 변수를 만들어 저장한다. [Set 상세설명](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/%EB%B3%80%EC%88%98%201%20-%20%EC%A0%84%EC%97%AD%EB%B3%80%EC%88%98.md)

    ```
    Set(
        varJSONOrderDetail,
        JSON(
            ShowColumns(
                '데모 발주내역 상세',
                "new_client_name",
                "new_delivery_date",
                "new_purchase_tpc",
                "new_purchase_location",
                "new_location_contact_number",
                "new_purchase_contact_number",
                "new_orders_detail_number",
                "new_item_name",
                "new_standard",
                "new_unit",
                "new_unit_price",
                "new_quantity",
                "new_total_price",
                "new_note"
                
            ),
            JSONFormat.IncludeBinaryData
        )
        
    )
    ;
    ```

4. 앱을 실행하여 해당 동작(이벤트)를 발생시키고 Set으로 만든 전역변수에 데이터가 잘 입력됬는지 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/162669076-488ea3ec-af81-49d8-a668-773c8984192a.png)<br>

## Power Automate 흐름 만들기

1. Power Automate에서 'Power Apps' 트리거로 흐름을 생성. [PowerAutomate 실행함수 만들기](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/PowerAutomate%EC%8B%A4%ED%96%89%ED%95%A8%EC%88%98%EB%A7%8C%EB%93%A4%EA%B8%B0.md)

2. 우선 '작성' 단계를 추가해 '입력' 항목에 '동적 값/동적 컨텐츠' 를 추가한다. 이때 PowerApps에서 질문을 한번 클릭해 Power Apps에서 하나의 파라메터 값(JSON 값을 받아오도록 준비한다.)<br><br>![image](https://user-images.githubusercontent.com/39551265/162671513-0277ac62-336c-4cd5-8cf0-86f3117e64d8.png)<br>

3. 그 다음 JSON '콘텐츠' 항목에 작성 단계의 '동적값/동적 컨텐츠' 값인 '출력'을 입력한다. 그 후 '샘플에서 생성'을 클릭해 JSON을 받아오도록 준비한다. [Power Automate JSON 구문분석](https://github.com/nanenchanga53/PowerPlatforms/blob/main/PowerAutomate%EC%A0%95%EB%A6%AC/%EB%8D%B0%EC%9D%B4%ED%84%B0%EC%9E%91%EC%97%85-Json%EA%B5%AC%EB%AC%B8%EB%B6%84%EC%84%9D.md) <br><br>![image](https://user-images.githubusercontent.com/39551265/162672373-e79b2070-cfb1-4173-bb9a-72310738dab4.png)<br>

4. 그 후 한번 테스트를 해서 'JSON 구문 분석' 동작에서 생성하는 '동적값/동적 컨텐츠' 값을 사용 가능 하도록 만든다.

5. 다음 단계에서 'CSV 테이블 만들기' 단계를 추가해 'JSON 구문 분석' 단계에서 생성한 본문을 '보낸 사람'(데이터 원본 from이다) 항목에 집어넣는다. [CSV 테이블 만들기](https://github.com/nanenchanga53/PowerPlatforms/blob/main/PowerAutomate%EC%A0%95%EB%A6%AC/%EB%8D%B0%EC%9D%B4%ED%84%B0%EC%9E%91%EC%97%85-%20CSV%ED%85%8C%EC%9D%B4%EB%B8%94%EB%A7%8C%EB%93%A4%EA%B8%B0.md)<br><br>![image](https://user-images.githubusercontent.com/39551265/162676169-ead1afbf-2cd3-43c1-a99c-2e28ce47aca5.png)
<br>

6. 다음 단계에서 저장할 위치에 콘텐츠를 만들어 저장하는 단계를 만든다.(필자는 OneDrive의 '파일 만들기'를 선택)<br><br>![image](https://user-images.githubusercontent.com/39551265/162677087-65484be0-1d81-4d75-8f60-34a135eb2e68.png)<br>

7. '폴더 경로'를 선택 하고 '파일 이름'을 `{파일이름}.csv` 형식으로 지정한다.

8. '파일 콘텐츠' 항목에 <span style="color:red">Fx</span> 버튼을 눌러 식을 추가한다.<br>식은 다음과 비슷하게 만든다.<br>concat을 추가하여 문자열을 csv테이블에 BOM을 추가하도록 만든다.<br>uriComponentToString을 이용해 UTF-8 형식의 문자열 타입을 지정하는 BOM을 추가한다. concat의 첫번째 항목은 다음과 같이 만든다. `uriComponentToString('%EF%BB%BF')`<br>두번째 항목은 해당 위치에서 '동적값/동적 컨텐츠'에서 선택하면 추가된다. `body('CSV_테이블_만들기')` 와 비슷하게 추가될 것이다.<br>완성된 식은 다음과 같다. `concat(uriComponentToString('%EF%BB%BF'),body('CSV_테이블_만들기'))` <br><br>![image](https://user-images.githubusercontent.com/39551265/162678297-e1c8bc70-d7ff-49e8-8519-d57d3ff3cbcf.png)<br>

* BOM 이란
> BOM 이란 문서의 맨 앞부분에 눈에 보이지 않는 특정 바이트(Byte)를 넣은 다음 해당 문서의 인코딩 방식이 어떠한 인코딩 방식으로 사용되었는지 알아내는 방법을 나타낸다. 이것을 설정하지 않으면 Power Automate에서 파일을 저장시 UTF-8로 저장하는데 엑셀 등에서 파일을 실행할때 한글이 깨지면서 나올 것이다.

## 흐름을 캔버스앱에서 실행

1. 파워 앱스의 흐름을 실행하는 함수를 만들어 추가한다. [PowerAutomate 실행함수 만들기](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/PowerAutomate%EC%8B%A4%ED%96%89%ED%95%A8%EC%88%98%EB%A7%8C%EB%93%A4%EA%B8%B0.md)

2. Power Automate를 실행하는 함수를 추가한 동작(이벤트) 위치에서 Set으로 생성한 변수를 파라메터를 포함한다.<br>![image](https://user-images.githubusercontent.com/39551265/162680716-d8ce0886-d836-4da9-9269-4924a4505029.png)<br>

2. 실행 후 저장위치에서 제대로 파일이 생성됬는지 확인한다.