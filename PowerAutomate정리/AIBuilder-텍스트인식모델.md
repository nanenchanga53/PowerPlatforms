# Power Autoamte 작업 : AI Builder - 텍스트 인식 모델
> AI Builder의 텍스트 인식 모델을 이용해 이미지나 PDF에서 텍스트를 인식해보자. 데스크탑 버전에도 OCR이 있기는 하지만 인식률이 너무나 떨어진다. 그래서 비싼 AI Builder를 사용해서 웹 버전에서 진행하는 것이 낫다.

## 이미지 가져오기

1. 우선 Share Point 등에서 이미지의 콘텐츠를 불러온다.<br>![image](https://user-images.githubusercontent.com/39551265/158016247-2f282d61-b776-4fa3-86dd-3d32001ad30c.png)<br>

* 예시에 사용할 이미지 <br>![image](https://user-images.githubusercontent.com/39551265/158016342-6f281383-efc0-4438-8e17-c0a11437b334.png)<br>

## 텍스트 인식 모델 작업 만들기

1. 파일 콘텐츠를 가져오는 작업 이후의 위치에 **새 단계(+ 아이콘) -> 작업 추가**<br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. <span style="color:red">AI Builder</span> 아이콘 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158016397-44a03eec-868d-41e7-beb9-15e4bf9d407b.png)<br>

3. <span style="color:red">이미지 또는 PDF 문서에 텍스트를 인식합니다.</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158016511-97ebc19a-b26d-4961-a117-ed4ca5e297ef.png)<br>

4. '이미지' 항목에 전 단계에서 가져온 이미지 콘텐츠를 동적 콘텐츠로 삽입<br>![image](https://user-images.githubusercontent.com/39551265/158016567-dbc0a1aa-7c56-4122-b31e-1d0decffc43f.png)<br>

## 실행 결과 확인
1. <span style="color:red">저장 -> 테스트</span> 를 클릭하여 테스트를 실행

2. 텍스트 인식 모델의 작업 결과를 살펴보자

3. '입력' 에는 '다운로드 하려면 클릭' 을 클릭하여 입력된 값을 확인 가능하다.

4. '출력' 안의 'result'의 값에서 값을 확인 가능하다. 결과값은 아래와 같은 형식으로 들어올 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/158016683-989fe6ea-a9b9-4e6c-a788-15ca2efeb020.png)<br>

```json
    [
        {
            "@odata.type": "#Microsoft.Dynamics.CRM.expando",
            "page": 1,
            "lines@odata.type": "#Collection(Microsoft.Dynamics.CRM.crmbaseentity)",
            "lines": [
            {
                "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                "text": "셀트리온클래리트로마이신정250mm((제규감염증 치료제)",
                "boundingBox": {
                "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                "left": 0.005666666666666667,
                "top": 0,
                "width": 0.974,
                "height": 0.04075,
                "polygon": {
                    "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                    "coordinates@odata.type": "#Collection(Microsoft.Dynamics.CRM.crmbaseentity)",
                    "coordinates": [
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.005666666666666667,
                        "y": 0.0005
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.9796666666666667,
                        "y": 0
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.9796666666666667,
                        "y": 0.04025
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.005666666666666667,
                        "y": 0.04075
                    }
                    ]
                }
                }
            },
            {
                "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                "text": "노랑색 정제 (상온보관(15~30℃))",
                "boundingBox": {
                "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                "left": 0.404,
                "top": 0.04525,
                "width": 0.5379999999999999,
                "height": 0.040999999999999995,
                "polygon": {
                    "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                    "coordinates@odata.type": "#Collection(Microsoft.Dynamics.CRM.crmbaseentity)",
                    "coordinates": [
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.404,
                        "y": 0.04875
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.9416666666666667,
                        "y": 0.04525
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.942,
                        "y": 0.08425
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.404,
                        "y": 0.08625
                    }
                    ]
                }
                }
            },
            {
                "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                "text": "· 항균작용을 통해 각종 세균감염",
                "boundingBox": {
                "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                "left": 0.4086666666666667,
                "top": 0.08225,
                "width": 0.5716666666666665,
                "height": 0.051250000000000004,
                "polygon": {
                    "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                    "coordinates@odata.type": "#Collection(Microsoft.Dynamics.CRM.crmbaseentity)",
                    "coordinates": [
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.4086666666666667,
                        "y": 0.089
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.979,
                        "y": 0.08225
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.9803333333333333,
                        "y": 0.128
                    },
                    {
                        "@odata.type": "#Microsoft.Dynamics.CRM.expando",
                        "x": 0.4086666666666667,
                        "y": 0.1335
                    }
                    ]
                }
                }
            },
            ##### 생략
            ]
        }
    ]   
```
|KEY값|용도|
|---|---|
|page|PDF 사용시 페이지 번호|
|lines|인식한 텍스트 값들의 모음|
|text|인식한 텍스트 값|
|boundingBox|좌표값의 데이터 모음|
|left|인식한 해당 텍스트의 사각형 값의 좌측 하단 좌표의 left 값|
|top|인식한 해당 텍스트의 사각형 값의 좌측 하단 좌표의 top 값|
|width|인식한 해당 텍스트의 사각형의 width값|
|height|인식한 해당 텍스트의 사각형의 height값|
|polygon|인식한 해당 텍스트의 사각형을 구성하는 폴리곤 좌표 구성 모음|
|coordinates|인식한 해당 텍스트의 사각형을 구성하는 폴리곤 좌표 모음|
|x|사각형 폴리곤의 x 좌표|
|y|사각형 폴리곤의 y 좌표|

## 결과 텍스트 가져오기

1. '변수 초기화' 작업을 만들고 유형은 '문자열'을 선택한다.
2. 각각에 적용 작업을 만들고 값에는 문자열 인식 작업의 'results 동적 콘텐츠' 를 선택한다.
3. 각각에 적용 작업을 다시 만들고 값에는 문자열 인식 작업 'lines 동적 콘텐츠' 를 선택한다.
4. '문자열 변수에 추가' 작업을 만들고 값에는 '텍스트 동적 콘텐츠'를 선택 후 줄 바꿈을 한번한다.
5. 위의 작업을 따르면 아래 이미지와 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/158017274-0b9f9f84-cc7a-4df0-8064-feaf9120f0e4.png)<br>

6. 이후에는 원하는 작업에 문자열을 사용하면 된다.<br>![image](https://user-images.githubusercontent.com/39551265/158017587-fa38a83a-de51-44a3-b495-eae0d705ea61.png)<br>

* 데스크톱 버전과 비교적 좋은 인식률을 가진다는 것을 확인 가능하다.