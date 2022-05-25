# Azure 큐 - 큐에 메시지 배치
> Azure Stroage 큐를 작동시키는 작업을 Power Automate에서 간단히 할 수 있다. 사용하려면 프리미엄 커넥터를 사용할 수 있는 구독이 필요하다. 여기서는 큐에 새로 메시지를 추가하는 '큐에 메시지 배치' 작업에 대해 설명한다.

## Azure Storage Queue 준비
> 자세한건 [공식문서](https://docs.microsoft.com/ko-kr/azure/storage/common/storage-account-create?tabs=azure-portal) 참조

1. Azure Stroage를 만들기 위해 Azure Potal에서 <span style="color:red">+ 리소스 만들기 -> 스토리지 계정 만들기</span> 선택<br><br>![image](https://user-images.githubusercontent.com/39551265/166225859-b6cd9d8c-e40e-4053-bda2-57ec1bb2926f.png)<br>

2. 필수 항목을 기입하고 <span style="color:red">검토+만들기</span> 클릭 하여 새로 만든다.

3. 만들어진 리소스(Azure Storage)로 이동한다.

4. '큐' 메뉴로 들어과 <span style="color:red">+큐</span> 클릭한다. 이름을 입력하여 새로 생성한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/166227023-960d7413-02ce-43b3-85e0-24c6e2373bc1.png)<br>


5. '액세스 키' 메뉴를 연다. '스토리지 계정 이름', '키'를 복사해 둔다. 이후 Power Autoamte의 연결시 사용한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/166227922-dd01fa2f-04d3-4be7-9db7-956cd41431f8.png)<br>

## 큐에 메시지 배치 작업 만들기
1. 파일 콘텐츠를 가져오는 작업 이후의 위치에 **새 단계(+ 아이콘) -> 작업 추가**<br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. <span style="color:red">Azure 큐</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/169966385-965d49ae-67e4-43dc-98ec-fc9c7267349c.png)<br>

3. <span style="color:red">큐에 메시지 배치</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/169983442-f576a632-4b2b-4e08-9be9-33655a7a3dc8.png)<br>

4. 만약 처음 작업을 만드는 것이라면 Queue Storage에 대한 새로운 연결을 만들어야 할 것이다.<br>'연결 이름' 항목엔 임의이 이름을 입력<br>'스토리지 계정 이름' 항목엔 이전에 복사한 스토리지 계정 이름을 입력<br>'공유 스토리지 키'에는 이전 복사한 키 값을 입력한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/166228543-210ff10f-bf64-410e-a199-355885fe8c8e.png)<br>

5. 그후 '스토리지 계정 이름'과 '큐 이름'을 선택하고 '메시지' 항목에 메시지를 입력한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/169986441-34fc2fa1-6c93-406b-a5c4-0b4296a41347.png)<br>

6. 이후 Azure Stroage Queue에 입력된 것을 확인한다. <br><br>![image](https://user-images.githubusercontent.com/39551265/169986994-f0e34863-a88e-4a71-af74-22273311f4f4.png)<br>