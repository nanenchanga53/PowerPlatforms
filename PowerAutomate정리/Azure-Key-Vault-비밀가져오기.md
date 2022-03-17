# Power Apps 작업 : Azure Key Vault - 비밀 가져오기
> Azure Key Vault는 비밀번호를 안전하게 보호하기에 최적화된 서비스이다. [공식문서](https://docs.microsoft.com/ko-kr/azure/key-vault/general/)에서 자세한 설명을 확인하는게 좋고 여기서는 Key Vault에 저장된 비밀번호를 Power Apps에 가져오는 것을 설명한다.


## Key Vault 비밀 만들기(비밀번호 생성)
1. 우선 애저포털에 접속한다.

2. 리소스 만들기 -> key vault를 선택한다.<br>![image](https://user-images.githubusercontent.com/39551265/158330685-81d172a0-62aa-4d44-bf46-1fdddfea6d76.png)<br>

3. 이후 기본 사항과 정책등을 사용자의 필요성에 따라 선택하고 만든다.

4. 만들어진 Key Vault 리소스로 들어간다.

5. 비밀 항목으로 들어간다.<br>![image](https://user-images.githubusercontent.com/39551265/158330976-a11f34b2-432f-4134-9cdf-77b70a5f05ab.png)<br>

6. '+ 생성/가져오기'를 클릭한다.

7. 비밀의 이름과 값을 적고 '만들기' 로 생성한다.<br>![image](https://user-images.githubusercontent.com/39551265/158331304-70a28cd7-c76f-4df5-9358-9b796fb0da9d.png)<br>

## Power Automate 커넥터 연결 설정
> 보통 같은 계정의 커넥터는 자동으로 생성되는데 Key Vault는 어떤 버그가 있는지 직접 설정해주어야 한다.

1. Power Automate 페이지로 간다.

2. <span style="color:red">연결 -> +새 연결</span> 을 클릭한댜.<br>![image](https://user-images.githubusercontent.com/39551265/158331923-607200d6-449b-40c1-9a17-010a8c129de3.png)<br>

3. 우측 상단에서 key vault를 검색하고 목록에서 key vault를 클릭한다.<br>![image](https://user-images.githubusercontent.com/39551265/158332363-21fb84ea-630f-4311-9212-cd5b5f9678c0.png)<br>

4. 팝업된 화면에서 자신의 Key Vault 리소스 이름을 적는다.(로그인 화면이 먼저 나왔다면 Key vault가 있는 계정으로 로그인해야한다.)<br>![image](https://user-images.githubusercontent.com/39551265/158332601-8c0e1715-38c6-4504-a9f2-f380334895d3.png)<br>

5. '만들기'를 클릭해 연결을 생성한다.

6. 셍상힌 연결은 목록에서 확인 가능하다<br>![image](https://user-images.githubusercontent.com/39551265/158332899-4de9f0dd-794a-4828-b170-a323b4351703.png)<br>

## Azure Key Vault 비밀 가져오기 작업 만들기

1. 파일 콘텐츠를 가져오는 작업 이후의 위치에 **새 단계(+ 아이콘) -> 작업 추가**<br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. <span style="color:red">Azure Key Vault</span> 아이콘 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158333351-a7e19200-7afe-427b-a31a-434193bfb245.png)<br>

3. <span style="color:red">비밀 가져오기</span> 를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158333441-90de6346-6908-4932-be3d-993648844981.png)<br>


4. 일단 <span style="color:red">...</span> 을 클릭해 '내 연결'에서 에러없이 연결되었는지 확인한다. 오류가 있다면 방금 생성한 연결로 변경한다.<br>![image](https://user-images.githubusercontent.com/39551265/158334092-df4e0284-3871-41c0-822d-8bfa7eac9cc7.png)<br>


5. '비밀 이름'을 리스트에서 선택한다.<br>![image](https://user-images.githubusercontent.com/39551265/158334419-3bc1aa9e-8736-4bd0-ad09-a1d0e7b08eef.png)<br>

## 실행 결과 확인
1. <span style="color:red">저장 -> 테스트</span> 를 클릭하여 테스트를 실행

2. 작업 결과를 살펴보자

3. '입력'에서는 불러오는 비밀의 이름을 확인 가능하고 '출력'에서는 비밀로 지정한 값을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/158334711-f979c0bb-cb34-40fa-9bcd-83b42ba2f01d.png)<br>


## 팁 보안구성 설정으로 비밀 보이지 않게 만들기
> 비밀번호인데 이대로 비밀번호가 로그에 그대로 노출되는건 곤란하다. 이런 문제점을 해결하기 위해 Power Automate는 값이 보이지 않게 하는 설정이 있다.

1. Key Vault 비밀 가져오기 작업의 <span style="color:red">... -> 설정</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158335566-877dd8b0-dcc0-4948-82c4-99935194b9e3.png)<br>

2. '보안 입력' 과 '보안 출력'의 설정을 켜기(on)으로 변경한다.<br>![image](https://user-images.githubusercontent.com/39551265/158335812-a03d210d-24d1-43e8-85a9-eddca46ac578.png)<br>

3. 테스트를 실행하여 제대로 볼 수 없게 되었는지 확인한다.<br>![image](https://user-images.githubusercontent.com/39551265/158335274-8dba49ea-e192-4f6a-9632-042097ef38d0.png)<br>