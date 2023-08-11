# Power FX 로우코드 플러그인
> Dataverse에서 새로운 프러그인 방식을 제공하게 되었다. 기존에는 .NetFramework로 제작한 플러그인을 통하여만 Dataverse를 조작할 수 있는 플러그인을 제작할 수 있었는데 이제 Power FX 수식을 이용해 만들 수 있도록 추가된다. 현제 간단한 사용방법에 대하여 알아보자. Power Apps나 Power Automate에서 사용했던 사람이라면 크게 어려움없이 사용할 수 있을것이다. 현재는 Power Apps, Power Automate 웹, 그리고 api를 이용해 사용할 수 있다. [공식문서](https://learn.microsoft.com/ko-kr/power-apps/maker/data-platform/low-code-plug-ins)

## 사용설정

1. [AppSource](https://appsource.microsoft.com/en-us/product/dynamics-365/microsoftpowercatarch.dataversekit1?exp=kyyw)에서 로그인 후 'Get it now' 클릭 그후 팝업창에서도 'Get it now'를 다시 클릭

![스크린샷 2023-07-17 100701](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/7608fabe-28eb-4bb7-b867-b288b88f9927)


2. 사용하려는 환경울 선택후 클릭

![스크린샷 2023-07-17 104925](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/d3cadba6-18a0-44f4-a1db-57ca2ebe241a)

3. 'Dataverse Accelerator' 가 설치되는것을 확인 

![스크린샷 2023-07-17 110225](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/8a2c1537-ff2b-4512-a213-fed98499937b)


4. 이후 Power Apps 앱에서 'Dataverse 가속기 앱'이 설치된 것을 확인한다.

![스크린샷 2023-07-17 112853](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/ca5921d2-8d48-4450-910e-6cc6f7a21a72)

* 환경변수의 값을 업데이트하라고 뜨는데 Dataverse 플러그인을 작성시 만들어지는 환경변수 등이 저장되는 솔루션의 이름 값을 입력하자(없는 값을 입력하면 기본 솔루션에 저장된다).

![스크린샷 2023-07-17 111305](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/9d181466-7319-40cb-851b-dc45ff15ae6a)
![스크린샷 2023-07-17 111450](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/4bdf00d5-be84-47c4-b069-2ac376689f2b)


## 인스턴트 플러그인 생성
> 인스턴트 플러그인은 Power Platfrom에서 사용할 수 있는 API를 생성한다. 직접 호출해서 사용하거나 캔버스앱, Power Automate 등에서 사용할 수 있다.

1. 'Dataverse 가속기 앱'을 열고 '인스턴트 플러그인' 에서 '+ 새 플러그 인' 클릭

![스크린샷 2023-07-17 140255](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/5ef91730-4f15-4a09-9fc6-a1befb215bdc)

2. 사용될 이름과 설명을 입력한다. (고급 옵션에서는 외부 데이터 원본을 연결 참조를 통해 사용할 수 있게 하는데 현제는 Azure DB만 사용이 가능하다.)

![스크린샷 2023-07-17 163718](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/8c2499e6-357e-4cab-8e39-66ebb4d07025)

3. 매개 변수의 입출력, 그리고 사용할 식을 입력한다.<br>입력 매개변수에서 레이블에 입력변수의 이름을 입력하고 데이터 형식을 선택한다. 예제에서는 VarContactId 를 String으로 생성<br>Out 매개변수에서 레이블에 출력변수의 이름을 입력하고 데이터 형식을 선택한다. 예제에서는 OutName, OutEmail, OutPhone 3개의 매개 변수를 생성하고 String형으로 선택<br>식에서는 Power FX식을 입력한다. 주의할점은 Set등을 아직 사용할 수 없기때문에 변수를 새로 생성 할 수 없고 마지막 줄에는 대괄호로 묶은 컬렉션 형식으로 만들어놔야 반환값을 지정할 수 있다. (컬렉션이 여러개여도 반환되는건 마지막 컬렉션 뿐이다.)<br>아래식은 입력받은 GUID를 이용해 '연락처' 테이블에서 이름,메일주소,전화번호를 반환해주는 식이다. 다음으로 넘어간다.

```powerfx
{
    OutName: LookUp([@'연락처 '], 연락처 = GUID(VarContactId)).'전체 이름',
    OutEmail: LookUp([@'연락처 '], 연락처 = GUID(VarContactId)).'전자 메일',
    OutPhone: LookUp([@'연락처 '], 연락처 = GUID(VarContactId)).'근무처 전화'
};
```

![스크린샷 2023-07-17 170501](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/662a865b-817b-473a-acdd-32d45c4cc536)

4. 검토를 진행한 후 저장을 한다. 이후 테스트로 넘어간다.

5. 입력 매개 변수에 값을 입력한다. 예제에서는 VarContactid에 사용자 GUID를 입력하였다. 그후 '실행'을 클릭한다. 이후 응답에 어떻게 값이 반환되는지 확인이 가능하다.

![스크린샷 2023-07-20 160956](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/8413fe92-e066-4b9f-a7fa-ad431197b1c6)

6. 이후 '통합' 탭으로 넘으가면 Power Apps와 Power Automate에서 사용방법에 대해 확인이 가능하다. 

![스크린샷 2023-07-20 165157](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/44a7f00f-90b9-416b-ae6e-3003025513cd)

## 인스턴트 플러그인을 Power Apps에서 사용

1. 캔버스앱을 열어 '버튼'과 '레이블' 컨트롤을 각각 배치한다.

2. 데이터 원본을 추가한다. 추가하는 원본은 Microsoft Dataverse의 'Enviroment' 를 추가한다. 

![스크린샷 2023-07-24 092912](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/e461e3e6-03ce-4209-8465-8905d193540a)

3. 버튼 컨트롤의 OnSelect 속성에서 인스턴트 플러그인의 '테스트 및 통합' 페이지의 '통합' 탭에서 확인한 Power Apps에서 사용가능한 코드를 복사해서 붙여넣는다. 그후 Set로 반환되는 값을 변수에 저장한다.

```
Set(result, Environment.crf8f_ReturnContactInfo({VarContactId:"입력값"}))
```

![스크린샷 2023-07-24 133318](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/b3bfed6c-c708-4b1a-ab4e-fb0d16d84eda)

4. 이후 반환된 값을 다른 속성에서 사용이 가능하다.

![스크린샷 2023-07-24 140216](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/37f42beb-8c46-4df9-8fa0-9947267cd5d5)


## 인스턴트 플러그인을 Power Automate에서 사용

1. Power Automate 흐름을 생성하고 편집창에 접속한다.

2. 새로운 단계를 생성한다. 이때 Dataverse의 '바인딩되지 않은 작업 수행'을 선택한다.

![스크린샷 2023-07-24 150315](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/78142add-4db3-4edc-99e2-aa42e32b851f)

3. 이후 추가한 플러그인을 선택한후 입력 파라메터에 값을 입력하여 실행한다.

![스크린샷 2023-07-24 152925](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/67dfeae3-4d68-4ddc-884b-16c9a2d917d8)

4. 실행 결과로 원하는 값이 반환되는지 확인한다.

![스크린샷 2023-07-24 153935](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/c02de99e-665a-45bb-8c1c-20a68c03d4dc)



## 자동화된 플러그인 생성
>Dataverse에서 특정 테이블에 레코드가 추가,삭제,업데이트시 동작하는 플러그인을 제작 가능하다. 기존 C# .NetFramework로 제작이 가능했던 것과 비슷한 역할을 갖는다.

1. 우선 테스트를 진행할 2개의 테이블을 준비한다. 하나는 데이터가 입력될 메인 테이블이고 하나는 메인테이블에 데이터가 입력되면 자동으로 데이터가 생성될 서브테이블이다.

![스크린샷 2023-07-24 163455](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/0c8469f0-3817-4435-bc43-d1325074dcf6)


2. 각 테이블에 레코드를 추가한다. 메인테이블에는 새로운 레코드가 생성될시 입력될 필드를 추가, 서브테이블에는 메인테이블에 새로운 레코드가 생서될시 생성할 필드와 어떤레코드를 조회(Lookup)하는지 확인하는 필드를 생성한다.

![스크린샷 2023-07-25 104132](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/becb93ca-3d4e-41b1-8b8f-38fb8de05133)

![스크린샷 2023-07-25 104247](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/5764fc42-f360-4b11-b3e3-7073615c82b4)

3. 'Dataverse 가속기 앱'을 열고 '자동화된 플러그 인'에서 '+ 새 플러그 인' 클릭

![스크린샷 2023-07-24 155502](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/ec9189f4-a815-4a91-93e4-dc17839a6c9b)

4. '이름' 항목에서 플러그인의 이름을 입력<br>'테이블' 항목에서 어떤 테이블의 이벤트를 감지할지 선택한다.(같은 환경의 Dataverse 테이블이여야한다.)<br> 그다음 레코드가 생성,업데이트,삭제 의 3가지 동작중 어떤 동작시 플러그인이 시작할지 결정한다.

![스크린샷 2023-07-25 132342](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/dbaaa631-dbc6-4309-8c19-06043d72690b)

5. Power FX 수식을 입력한다. 현재 Plugin에서 사용할 수 없는건 [공식문서](https://learn.microsoft.com/ko-kr/power-apps/maker/data-platform/low-code-plug-ins-powerfx#formulas-not-currently-supported-with-low-code-plug-ins) 참조하자<br>아래 수식은 메인테이블에 레코드가 생성시 name 필드를 이용해 새로운 텍스트를 생성해 별도 필드에 입력한다. 이후 서브테이블에 이름과 레코드 GUID를 이용해 새로운 레코드를 만든 후 입력한다. 이때 현재 Plugin에서는 Defaults를 사용할 수 없어서 Collect를 조합하여 실행한다.

```powerfx
If( IsBlank( ThisRecord.crf8f_textrecord ), 
    Patch([@테스트_메인테이블], 
    ThisRecord, { 
        TextRecord:Concatenate(ThisRecord.crf8f_name," 텍스트자동생성")
    }
));


Patch([@테스트_서브테이블],
    Collect([@테스트_서브테이블],
        {
            Name:Concatenate(ThisRecord.crf8f_name," 복사본"),
            LookUpRecord:ThisRecord
        }
    ),
    {
        TextRecord:"새로생성"
    }
);
```

6. 수식 아래에 '고급 옵션'에서는 수식이 레코드 이벤트가 생성되기 사전 혹은 사후에 실행할지를 결정할 수 있다.

7. '저장' 후 메인테이블에서 새로운 레코드를 생성하며 동작이 실행되는지 확인한다.

![스크린샷 2023-07-25 145201](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/ef2a13ca-282a-4af5-b3e7-480ea9e4597c)

![스크린샷 2023-07-25 145245](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/2db1b608-72d5-489d-a5f8-70bc7d15cb1c)

## 정리
현재 Power FX Plugin 은 많은 제약사항이 있어서 아쉬운 점이 있다. 하지만 Dataverse내에서 이벤트나 테이터처리를 하는 것이라면 기존 .NetFramework 방식에 비해 쉽게 접근하여 생성할 수 있다는 것이 큰 장점이다.
