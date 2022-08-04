# Power Apps 함수 - Collection, 데이터 원본의 중복을 하나로 만드는 GroupBy
> Power Apps에서 Collection 등의 데이터에서 중복을 제거하고 싶은 경우가 있을 것이다. 이때 사용하는 GroupBy를 이용해서 하나로 만들어보자.

## GrupBy 사용

1. PowerApps에 엑셀의 데이터 원본을 연결한 데이터 테이블 '도시구'가 있다고 가정한다. 테이블 안에는 대한민국의 도,시,구 의 구역의 정보가 들어가 있다.<br><br>![image](https://user-images.githubusercontent.com/39551265/182850080-c4863c15-8800-4b33-bd62-78793f1cf820.png)<br>

2. 특별시들은 '도'구역이 비어있고 '시'구역의 서울특별시의 경우 여러개의 '구' 데이터를 갖고 있기에 중복이 생긴다. 드롭다운 컨트롤의 아이템에 집어넣어보면 쓸데없는 중복이 생기는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/182852599-a248acac-7a56-4691-90f4-9a7811e4e7c6.png)<br>

3. 일단 '도' 구역의 중복을 제거해보자 GroupBy 함수를 사용하면 되는데 `GroupBy(데이터원본, 중복을제거해 하나로합칠 기준의 열,... 기준은 여러개 사용 가능, 합치고 생성할 그룹의이름 )` 형식으로 사용한다. 기준은 복수개의 열이 전부 맞으면 합치는 것도 가능하지만 보통 한개를 사용할 것이다. '도시구'에서 '도'를 기준으로 하나로 만들면 다음과 같은 값을 드롭다운 컨트롤 Items 속성에 입력하면된다. `GroupBy(도시구, "도" , "도그룹")` <br><br>![image](https://user-images.githubusercontent.com/39551265/182853742-5647c012-955a-41c5-b98c-5fd883924a55.png)<br>