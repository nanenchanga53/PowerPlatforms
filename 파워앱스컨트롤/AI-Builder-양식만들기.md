# AI Builder - 양식 처리
> 양식처리는 정형화된 문서에서 사용자가 미리 지정한 항목의 데이터를 가져온다. 이미지나 PDF파일에서 데이터를 가져오며 가능하면 같은 파일의 항목에 기입된 내용만 달라진 것을 사용하는 것이 좋다.(파일이 스캔이나 화질 문제로 위치가 틀려지고 하면 정확도가 떨어질 수 밖에 없다.) 최소 5개의 학습 데이터(문서파일)이 필요하며 해다위치의 값은 어떤 항목인지는 직접 지정해주어야 한다. 자세한 설명은 [공식문서](https://docs.microsoft.com/ko-kr/ai-builder/form-processing-model-overview)에서 확인하자. 사용하려면 AI Builder를 사용 가능한 계정이 필요하다.



## AI Builder 양식 처리 모델 만들기

1. [파워앱스 사이트](https://make.powerapps.com/)로 이동한다.

2. <span style="color:red">AI Bilder -> 살펴보기</span> 를 클릭

3. <span style="color:red">문서에서 사용자 지정 정보 추출</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158506984-0a5b44ac-f225-4feb-bf75-6191b9ac570b.png)<br>

4. '시작'을 클릯해 양식 처리 모델을 만든다.<br>![image](https://user-images.githubusercontent.com/39551265/158507348-eaebbe29-c3f4-4c40-b458-c138648dace9.png)<br>

5. 현재 양식 처리 모델 페이지에 있을태지만 해당 페이지가 잘 만들었는지 확이하려면 '저장 후 닫기'로 페이지에서 벗어나자

6. <span style="color:red">AI Builder -> 모델</span> 로 들어가 새로 생성한 양식 처리 모델을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/158507745-aa413308-33c5-4ce1-9c84-c37da4da1bae.png)<br>


## AI Builder 양식 처리 모델 - 추출할 정보 선택

1. 새로 생성한 AI Builder 모델을 클릭해 편집 페이지로 이동한다.

2. 우선 우측 상단의 <span style="color:red">연필 아이콘</span>을 클릭해 해당 모델의 이름을 변경한다.<br>![image](https://user-images.githubusercontent.com/39551265/158518286-1b85c298-3525-4f7a-b4ad-9ee190fa4eb0.png)<br>

3. '추출할 정보 선택' 페이지 안에 있는, <span style="color:red">+추가</span>를 클릭해 양식에서 추출할 정보를 추가한다.<br>![image](https://user-images.githubusercontent.com/39551265/158518468-cf20bae4-9f60-4f92-8b39-11bdc31ee8d1.png)<br>

4. 4가지의 형식이 있으며 보통은 '필드'를 사용하여 추출하게 될 것이다. 추출 형식을 선택하고 '다음'을 클릭한다.<br>![image](https://user-images.githubusercontent.com/39551265/158518778-889a9d3f-5074-4809-85f3-b5e30ae4701a.png)<br>

* 추출 형식
    |형식 이름|용도|
    |---|---|
    |필드|문서에서 특정 위치의 텍스트를 불러오는데 사용(가장 많이 사용)|
    |확인란|문서에서 특정 위치의 체크 표시를 불러오는데 사용|
    |한 페이지 테이블|단일 페이지에 있는 테이블의 텍스트를 불러오는데 사용(생성시 열의 이름도 지정해야한다)|
    |여러 페이지 테이블|여러 페이지에 이어지는 테이블의 텍스트를 불러오는데 사용(생성시 열의 이름도 지정해야한다)|


5. 추출할 형식의 이름을 입력하고 '완료' 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158520364-a06b8ac3-6b6a-4816-9167-301d36ad8e6b.png)<br>

6. 양식에서 추출하고 싶은 만큼의 정보 형식을 만들고 아래쪽에 있는 '다음'을 클릭


## AI Builder 양식 처리 모델 - 문서 모음 추가

1. '문서 모음 추가' 페이지가 열릴 것이다.

2. <span style="color:red">새 컬렉션</span>을 클릭

3. '문서 추가' 아래에 있는 새로 추가된 컬렉션 클릭

4. 오른쪽에서 <span style="color:red">문서 추가</span>를 클릭 <br>![image](https://user-images.githubusercontent.com/39551265/158521577-3c1cfec9-f541-4951-af59-330ad85ad72f.png)<br>

5. 학습 시키려는 문서 PDF 파일이 있는 위치를 선택하고 업로드한다.(한 컬렉션에 최소 5개 이상 업로드 해야한다.)<br>![image](https://user-images.githubusercontent.com/39551265/158521705-68ff775d-2f49-4557-a3ce-15fd02d59926.png)<br>

6. 무사히 업로드하면 컬렉션에서 업로드한 파일을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/158522010-6a649240-1ea9-4926-9220-d3f5d7ef3ac5.png)<br>

## AI Builder 양식 처리 모델 - 태그 문서

1. '태그 문서' 페이지가 열릴 것이다.

2. 컬렉션에 업로드 했던 문서가 보일 것이다. 해당 문서에서 검출하려는 텍스트를 드래그하여 범위를 정하고 형식을 지정한다. 이때 값을 잘 확인하고 추출할 정보를 선택한다. 아래 이미지는 '사업자등록증'이라는 글자를 '필드 사업자 등록증'으로 등록하는 샘플이다.<br>![image](https://user-images.githubusercontent.com/39551265/158524089-e24f3ea9-8344-4ebe-b702-cd313d367569.png)<br>

3. 테이블의 경우 테이블에 해당되는 범위의 필드를 전부 선택하고 테이블 형식의 정보를 선택한다. 그 후 오른쪽의 정보 리스트에서 테이블 정보의 오른쪽에 <span style="color:red">... -> 테이블 편집</span>을 클릭한다.<br>![image](https://user-images.githubusercontent.com/39551265/158524550-2bc5df69-d33c-414c-ad4c-7596084f10cd.png)<br>


4. 마우스 왼쪽 클릭으로 행을 추가하고 컨트롤을 같이 눌르면 열을 추가한다. 테이블의 행, 열 만큼 추가하고 '고급 태그 지정 모드'를 설정한다.<br>![image](https://user-images.githubusercontent.com/39551265/158525111-9277ed69-7918-4489-baf8-171650b8c009.png)<br>![image](https://user-images.githubusercontent.com/39551265/158525426-e279d912-4e5f-4917-9889-a6964e041a58.png)


5. '고급 태그 지정 모드'로 들어 왔을시 만약 이상한 텍스트가 입력되어 있다면 각 셀에서 '태그 제거'를 하여 모든 태그를 제거한다.

6. 좌상단의 첫 셀을 클릭하여 태그 범위를 선택할 준비를 한다.<br>![image](https://user-images.githubusercontent.com/39551265/158526678-0913e5be-6436-4f81-b7b1-c8c37530534a.png)<br>

7. 각셀에 해당되는 텍스트를 드래그하여 지정하여 태그를 추가한다.<br>![image](https://user-images.githubusercontent.com/39551265/158526877-050a1cd8-204b-49ec-8320-ffd7393318e0.png)<br>

8. 모든 셀에 태그를 추가하고 아래에 있는 '완료'를 클릭한다.<br>![image](https://user-images.githubusercontent.com/39551265/158527047-03061cd7-9821-4568-b4f4-02452b09a8f9.png)<br>

9. 만약 문서에 태그를 추가할 텍스트가 없다면 오른쪽의 정보 리스트에서 텍스트가 없는 부분의 오른쪽 <span style="color:red">
... -> 컬렉션에 사용 불가</span>를 클릭한다.<br>![image](https://user-images.githubusercontent.com/39551265/158527586-75f0fafc-93e3-4444-bf95-1c63aded9fc9.png)<br>

10. 모든 양식에 태그를 선택하였으면 오른쪽 상단의 다른 문서를 선택해 다시 같은 작업을 반복한다. 아래 이미지는 완료 했을시의 이미지다.<br>![image](https://user-images.githubusercontent.com/39551265/158527290-334ecaaa-f8ca-479c-8641-9cd671563910.png)<br>

11. 모두 완료했으면 페이지 아래의 '다음'을 클릭한다.

## AI Builder 양식 처리 모델 - 모델 요약

1. '모델 요약' 페이지에서는 지금까지 만든 모델의 요약본을 볼 수 있다.

2. 아래에 있는 '기차' 버튼을 눌러 학습을 실행한다. (번역이 잘못됬다. 학습이다.)

3. 잠시 기다리면 학습이 완료된다. 이후 '세부 정보 페이지로 이동' 버튼을 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158528035-43a385ef-775a-49f0-9d6a-1b16a9f2242e.png)<br>

## AI Builder 양식 처리 모델 - 세부 정보

1. '세부 정보' 페이지에서는 현재 학습시킨 모델의 간략한 정보와 테스트가 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/158528399-4b0bffae-771d-48c0-a3aa-ca497553aeb5.png)<br>

2. '빠른 테스트'를 클릭하면 같은 양식의 문서 파일을 테스트할 수 있다.<br>![image](https://user-images.githubusercontent.com/39551265/158528549-371a6d8e-1765-4d0e-a109-2e9ce8334880.png)<br>

3. '게시' 를 클릭해 현재 학습된 모델을 다른 파워 플랫폼 내에서 사용 가능한 상태로 만들 수 있다.<br>![image](https://user-images.githubusercontent.com/39551265/158529009-b8a4138c-28b3-46ff-a6f0-07d1c0bd6dbb.png)<br>