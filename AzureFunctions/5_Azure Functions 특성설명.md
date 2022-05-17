# Azure Functions - Azure Functions 특성 설명(OpenAPI 포함)
> Azure Fucntions에서 함수를 제작시 함수의 특성을 설정시 각 어떤 특성(사전 정의된 속성)이 어떤 역할을 하는지 알아보자.

## FunctionName

1. FunctionsName은 Azure Functions를 사용시 반드시 정의해야한다. 
2. `[FunctionNme("{함수이름}")]` 형식으로 사용된다.
3.  파일이름이 달라도 해당 특성으로 정의된 이름으로 Azure Functions에 함수이름으로 등록된다. 다른 함수와 이름이 겹치지 않도록 주의하자<br><br>![image](https://user-images.githubusercontent.com/39551265/168721734-6d99ca9e-4f79-4c52-98ea-f014726c5987.png)<br>

4. swagger의 JSON은 path key값 안의 value값 에 해당된다.

## OpenApiOperation

1. 해당 함수의 실행에 대한 설명과 태그 등을 정의한다.

2. `[OpenApiOperation(operationId:"{ID 이름}" ~ 이외 설정)]`<br><br>![image](https://user-images.githubusercontent.com/39551265/168722302-67bb3644-f2a9-47c5-88bd-0f6531a084d0.png)<br>

    |특성 파라메터|설명|
    |---|---|
    |operationId|OpenAPI 함수 ID|
    |tags|함수를 분류하기 위한 태그|
    |Summary|함수의 간단한 설명|
    |Description|함수의 자세한 설명|
    |Visibility|Logic 앱이나 Power Platform 등에서 사용하기 위한 설정|

## OpenApiSecurity

1. 함수의 인증에 대한 설정을 정의한다.

2. `[OpenApiSecurity("인증이름", ~ 인증에 따라 다른 설정)]`<br><br>![image](https://user-images.githubusercontent.com/39551265/168723368-2cec89b1-9563-43da-8b73-b16f7dcea941.png)<br>

3. 만약 설정을 여러개 사용하려면 '인증이름'을 여러개 정의해야 한다.


## OpenApiResponseWithBody

1. 함수의 입출력 정의

2. `[OpenApiResponseWithBody(statusCode: {반환코드종류}, contentType: {타입 정의}, bodyType: {body값 타입}, Description = {함수의 반환값 설명} ~ 이외 설정)]`<br><br>![image](https://user-images.githubusercontent.com/39551265/168723892-87cd1445-2d8e-4dd0-8de1-357c30ce3aaf.png)<br>

    |특성 파라메터|설명|
    |---|---|
    |statusCode|반환 코드값 정의|
    |contentType|content의 type 값 정의|
    |bodyType|body의 type값 정의|
    |Summary|함수의 반환값의 간단한 설명|
    |Description|함수의 반환값의 대한 설명|