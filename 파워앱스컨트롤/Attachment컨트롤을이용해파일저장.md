# Attachment 컨트롤을 이용한 이미지파일 한번에 저장
> Power Apps가 현재 제공하는 가져오기 컨트롤이나 이미지 컨트롤 같이 한개씩 파일을 가져올 수 있다. Attachment컨트롤을 이용해 한꺼번에 이미지파일들을 가져오고 SharePoint에 저장까지하는 과정을 설명한다. Attachment컨트롤의 기본설명은 [Attachment컨트롤](https://nanenchanga.tistory.com/entry/Attachment-%EC%BB%A8%ED%8A%B8%EB%A1%A4)을 참고하자

## 컨트롤의 속성 분석
1. [Attachment컨트롤](https://nanenchanga.tistory.com/entry/Attachment-%EC%BB%A8%ED%8A%B8%EB%A1%A4)을 참고하여 Attachment 컨트롤을 생성 후 갤러리 컨트롤을 만들어 갤러리 컨트롤의 데이터 원본을 `{Attachment컨트롤명}.Attachments`로 변경한다.(Items 속성)

2. `MaxAttachments` 속성은 파일을 해당 컨트롤에 입력할 수 있는 최대 개수를 정한다. 많은 파일의 개수를 업로드 하려면 넉넉한 숫자로 변경한다. `MaxAttachmentSize`를 변경하여 파일크기 제한(MB)를 변경한다.<br><br>![화면 캡처 2023-01-06 111736](https://user-images.githubusercontent.com/39551265/210917226-3ddb2b9a-7840-4ea7-ace1-1d0cdf6d922e.png)<br>

3. Attachment 컨트롤의 Attachments 속성 값이 어떻게 디어 있는지 확인하기 위해 콜렉션으로 만들어 본다. OnAddFile 속성에 `ClearCollect(attachmentFiles,{Attachment컨트롤명}.Attachments);` 이런식의 FX함수를 입력하면 attachmentFiles라는 콜렉션에 값이 입력된다.<br><br>![화면 캡처 2023-01-06 154439](https://user-images.githubusercontent.com/39551265/210946128-f0c394ce-06d9-4f01-8685-532193e6b732.png)<br>

4. 파일을 추가하고 만들어진 콜렉션을 확인해보자. Name Key에는 파일의 이름 Value Key에는 URL이 들어가 있는 것을 확인 가능하다. URL값이 어느위치에서나 접속 가능한 값이 아닌 해당 앱 자체에서만 접속 가능한 내부 Blob 주소라 해당 주소로 파일을 저장 할 수 없다.<br><br>![화면 캡처 2023-01-06 155907](https://user-images.githubusercontent.com/39551265/210947693-2c6a863b-951f-4bc2-9ddd-882ebf97f4fd.png)<br>

5. 갤러리 컨트롤을 만들고 그 안의 Image 컨트롤의 Image속성값은 ThisItem.Value로 사용한다.

## PowerAutomate 통신을 위한 이미지 이름과 DataStream 으로 Json생성
1. 버튼(단추) 컨트롤을 생성해서 적당한 위치에 놓는다.

2. 버튼 컨트롤의 OnSelect 속성에 다음과 같은 FX함수를 추가한다. 그리고 클릭하여 실행해 본다.<br>`Clear(AttachmentJson);`<br>`ForAll(ImageGallery.AllItems,Collect(AttachmentJson,{Name : ImageName.Text, DataStream : ImagePicture.Image }));`<br>![화면 캡처 2023-01-09 144318](https://user-images.githubusercontent.com/39551265/211247088-a50aa69a-f200-403e-8959-0915dae8ca93.png)<br>

3. 컬렉션에서 새로 생성한 컬렉션 AttachmentJson을 확인해 보자 여기서 DataStream Key값이 이미지로 변경한 것을 확인 가능하다. 기존 URL형태에서 DataStream형태로 변환되어 저장되었기 때문에 컬렉션에서 이미지 미리보기가 가능해졌다. 이미지를 저장할때도 이를 이용하면 된다. <br><br>![화면 캡처 2023-01-06 165756](https://user-images.githubusercontent.com/39551265/210956403-fc5b976a-3000-4575-a871-b951d450cecd.png)<br>


## 이미지 저장 Power Automate 흐름 생성

1. 새로운 Power Automate 흐름을 생성하여 적당한 이름으로 변경한 후 트리거 단계를 `PowerApp(V2)`로 변경한다. 그 후 '입력 추가'를 텍스트 형식으로 추가한다.<br><br>![화면 캡처 2023-01-09 094701](https://user-images.githubusercontent.com/39551265/211227148-2f3fc49e-dba1-4fdc-9693-db8c378bcbe5.png)<br>

2. `JSON 구문 분석` 단계를 추가 후([참조](https://nanenchanga.tistory.com/entry/PowerAutomate-%EC%9E%91%EC%97%85-%EB%8D%B0%EC%9D%B4%ED%84%B0%EC%9E%91%EC%97%85-Json%EA%B5%AC%EB%AC%B8-%EB%B6%84%EC%84%9D))<br>스키마를 아래와 같이 입력하면 된다.(만약 Key값이 다르다면 변경해주어야한다.) <br>![화면 캡처 2023-01-09 101355](https://user-images.githubusercontent.com/39551265/211228592-b9dba6c0-542e-4a83-8caf-8b287c65085b.png)<br>
```json
{
    "type": "array",
    "items": {
        "type": "object",
        "properties": {
            "Name": {
                "type": "string"
            },
            "DataStream": {
                "type": "string"
            }
        },
        "required": [
            "Name",
            "DataStream"
        ]
    }
}
```


3. 'SharePoint -> 파일 만들기'를 추가한 후<br>'사이트주소' 항목에서 쉐어포인트 사이트를 선택<br>'폴더 경로'항목에서 파일을 저장할 폴더 선택<br>'파일 이름' 항목에서 JSON구문 분석의 동적 콘텐츠 Name을 선택(Name이 아닌 다른 Key값을 사용했다면 그것을 선택)<br>'파일 컨텐츠' 항목에는 다음과 같은 식을 입력한다.(만약 DataStream이 아닌 다른 Key값을 갖는다면 변경) `dataUriToBinary(items('각각에_적용')['DataStream'])`<br><br>![화면 캡처 2023-01-09 101432](https://user-images.githubusercontent.com/39551265/211228595-c425c22e-94e8-4df9-a753-961f1e659ee0.png)<br>


## 이미지 업로드 실행버튼 만들기

1. 방금 제작한 이미지 업로드를 위한 PowerAutomate흐름을 실행하기 위해 버튼의 OnSelect 속성에 추가해야한다.<br><br>![화면 캡처 2023-01-09 144318](https://user-images.githubusercontent.com/39551265/211247088-a50aa69a-f200-403e-8959-0915dae8ca93.png)<br>

2. 흐름 추가 를 통해 방금 생성한 PowerAutomate흐름을 추가한다.<br><br>![화면 캡처 2023-01-09 144859](https://user-images.githubusercontent.com/39551265/211247582-6cb89f97-c28c-4356-8de6-30f34e1ad1c6.png)<br>

3. 기존 식에 다음의 식을 추가한다. 만약 흐름의 이름이 다르다면 .Run 앞의 이름을 변경한다. `ImageUplaod.Run(JSON(AttachmentJson,JSONFormat.IncludeBinaryData))`

4. 이후 직접 실행하여 파일이 업로드 되는지 확인한다.