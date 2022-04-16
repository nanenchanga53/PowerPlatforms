# Power Apps FX함수 - ShowColumns
> 테이블 형태의 원본에서 원하는 열만은 추려서 가져오는 Power FX 함수 ShowColumns

# 사용법
> 주의할점은 현재 앱에서 생성된 테이블이나 데이터 원본을 통해 가져와 별도의 테이블을 생성하기 때문에 없는 데이터에는 사용할 수 없다.

1. 함수를 사용시에는 ShowColumns 첫번째 인수에는 '테이블의 이름' 두번째 부터는 열의 이름을 사용한다.(없는 열의 이름을 사용하면 에러가 난다.)<br>`ShowColumns({테이블 이름 혹은 데이터 원본의 이름}, [사용하는 열의 이름 1], [사용하는 열의 이름 2].....)`

2. 다음과 같이 새로운 테이블 데이터로 만들어 사용한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163674649-7865d4eb-51ff-4f89-bb01-303d9471ecfc.png)<br>
 
 
    ```
    ClearCollect(ShowCollect,
        ShowColumns(
                        '데모 발주내역 상세',
                        "new_client_name",
                        "new_delivery_date",
                        "new_purchase_tpc"
                        
                    )
        )
    ```


* 이 외로 AddColumns, DropColumns, RenameColumns 함수들이 Table을 이용해서 사용 가능한 함수들이다.
