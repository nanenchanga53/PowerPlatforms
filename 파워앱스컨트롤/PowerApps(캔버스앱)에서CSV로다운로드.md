# Power Apps(캔버스앱)에서 CSV로 다운로드
> 캔버스앱에서 CSV파일을 다운로드 받는 방식을 설명한다. 이 문서에서는 Dataverse안에 있는 데이터 원본을 Power Automate를 이용해 원하는 저장소에 파일을 저장하는 과정을 설명한다.

## 캔버스 앱에서 데이터 원본을 JSON 형태의 파일로 만들기

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

5. 

## 흐름을 캔버스앱에서 실행

1. 파워 앱스의 흐름을 실행하는 함수를 만들어 추가한다. [PowerAutomate 실행함수 만들기](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%ED%8C%8C%EC%9B%8C%EC%95%B1%EC%8A%A4%EC%BB%A8%ED%8A%B8%EB%A1%A4/PowerAutomate%EC%8B%A4%ED%96%89%ED%95%A8%EC%88%98%EB%A7%8C%EB%93%A4%EA%B8%B0.md)
