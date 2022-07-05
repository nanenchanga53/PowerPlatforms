# C# - ConfigurationBuilder 4 - 원하는 하위 속성들의 모음을 가져오기
> JSON등으로 속성값을 가져올시 ':'를 계속 추가해서 찾지 말고 하나의 영역을 가져오고 싶을 경우가 있을 것이다. 가장 많이 사용하는 경우는 Logging 설정일 것인데 콘솔, App Insights, 파일 등에서 저장할 로깅 작업의 레벨 등을 달리 설정할 것이다. 여기서는 하위 속성들을 가져오는 방법을 살펴본다.

## 예제 JSON 파일

```json
{
  "TestSetting": {
    "Test1": "Test1_True",
    "Test2": "설정2_True",
    "Test3": "속성3_True"
  },
  "TestSet": "setting_True",
  "ConnectionStrings": {
    "default": "asfdwefsdxsfdsafwerasrasdfzxcfser",
    "defualt2": "asdfasfefselkfjasklflzk;jsdfkl;jzsdf"
  }
}

```
## ConnecntionsString

1. 하위 속성의 Value 값을 가져오려면 `builder.GetContext().Configuration["TestSetting:Test1"]` 이런식으로 `["상위Key값:하위Key값"]` 형식으로 가져와야만한다.

2. 설정 파일 중 `"ConnectionsStrings"` 로 Key 값을 갖는 것은 `builder.GetContext().Configuration.GetConnectionString("default");` 이런식으로 `("하위Key값")` 형식으로 가져올 수 있다.

3. 같은 방식으로 다른 값을 가져오려해도 .GetConnectionString 같은 함수가 없어서 가져올 수가 없다.

4. ConnecntionString의 경우에는 연결문자열의 모음을 대부분의 프로젝트에서 사용하기에 기본적으로 여러개의 속성을 관리하기 위해 제공해 준다.



## GetSection()

1. 하위 속성을 한번에 저장하기 위해서는 `GetSection("하위 속성들을 가지고 있는 Key 값")`을 사용한다.

2. `IConfigurationSection getSection = builder.GetContext().Configuration.GetSection("TestSetting");` 이런식으로 IConfigurationSection 인터페이스로 변수를 만들어 사용할 수 있다.

3. 한개의 값을 가져올 시 `getSection.GetValue<string>("{하위 Key값})` 이런 형식으로 사용이 가능하며 모든 값을 검색할 시에는 `foreach(var t in getSection.GetChildren())`이런식으로 검색할 수는 있다. 