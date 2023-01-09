# Attachment 컨트롤
> Attachment컨트롤은 파일을 업로드하여 관리할 수 있는 컨트롤이다. '가져오기 컨트롤' 같이 파일을 한개씩 가져와 관리하는 것이 아닌 여러개의 파일들을 가져와 관리할 수 있게 한다. 참고로 Power Apps에서 기본적인 삽입 컨트롤 항목에서 찾을 수 없다.

# Attachment 컨트롤 가져오기
1. sharepoint의 목록이나 Dataverse의 테이블에 파일을 입력할 수 있는 부분을 추가한다.<br><br>![화면 캡처 2023-01-05 152617](https://user-images.githubusercontent.com/39551265/210717651-23db9b7c-1813-4943-851a-4976551ff8f6.png)<br>
![화면 캡처 2023-01-05 152648](https://user-images.githubusercontent.com/39551265/210717659-cd140c99-3018-454d-8e82-b8f4ac4b3e06.png)<br>
![화면 캡처 2023-01-05 154010](https://user-images.githubusercontent.com/39551265/210717670-064f734d-6c4c-4f22-bb99-2911716d95fa.png)<br>

2. Power Apps에서 해당 SharePoint 목록이나 Dataverse 테이블을 연결한다.(여기서는 SharePoint를 사용)<br><br>![화면 캡처 2023-01-05 155520](https://user-images.githubusercontent.com/39551265/210720889-f52a2a6f-0705-48fe-b6ff-89575a6de160.png)<br>

3. '폼 컨트롤'의 편집을 선택해 추가한다. 해당 컨트롤의 데이터 원본을 이전에 연결한 원본을 선택한다. 이후 '첨부 파일' 열에 파일을 불러올 수 있는 컨트롤이 Attachment 컨트롤이다.<br><br>![화면 캡처 2023-01-05 160923](https://user-images.githubusercontent.com/39551265/210722220-d9112344-5964-4870-b49d-a28cced91b51.png)<br>

4. Attachment 컨트롤을 복사해 원하는 위치에 붙여넣는다. 해당 컨트롤을 두번 마우스 클릭을 하거나 트리 뷰에서 클립 표시가 있는 컨트롤을 선택한다. 이후 폼 컨트롤이 필요 없다면 삭제한다.<br><br>![화면 캡처 2023-01-05 161844](https://user-images.githubusercontent.com/39551265/210723750-b616d4be-6309-47a7-ba9b-d8f13ee3016d.png)<br>

5. `Parent` 등의 존재하지 않아 생기는 속성들의 값을 전부 제거한다.<br><br>![화면 캡처 2023-01-05 163137](https://user-images.githubusercontent.com/39551265/210725715-9391ff0d-f73b-476b-a93e-5509b7f487c2.png)<br>

6. 디스플레이모드 속성은 편집으로 변경<br><br>![화면 캡처 2023-01-05 163354](https://user-images.githubusercontent.com/39551265/210726100-18d0b58a-529f-4745-924f-42b829ff92b3.png)<br>

7. 해당 컨트롤의 이름도 바꿔준다.<br><br>![화면 캡처 2023-01-05 163832](https://user-images.githubusercontent.com/39551265/210726847-948b2f24-d381-48b0-a81a-b6e1718f24df.png)<br>

# 사용법
1. 갤러리 컨트롤을 추가후 데이터 원본을 `{Attachment컨트롤명}.Attachments`로 변경한다. 레이아웃은 '이미지,제목,부제목'을 추천한다.<br><br>![화면 캡처 2023-01-05 164819](https://user-images.githubusercontent.com/39551265/210728382-b8802a5e-d284-4542-b19e-1d93d2944e6e.png)<br>

2. Attachment 컨트롤의 '파일 첨부'를 클릭해 파일들을 첨부한다. 이후 갤러리 컨트롤에 첨부된 파일의 이름과 원본의 위치가 갤러리 컨트롤 목록에 나오는 것을 확인한다.<br><br>![화면 캡처 2023-01-05 165932](https://user-images.githubusercontent.com/39551265/210730360-a44e0f64-ceb1-4a37-8809-3a3d0df00f58.png)<br>

3. 갤러리 컨트롤을 선택 후 필드 값을 수정한다. image1 의 Image속성은 `ThisItem.Value`로 변경한다. 이후 다시 Attachment 컨트롤에 이미지 파일을 집어넣으면 이미지가 보이는 것을 확인 가능하다.<br><br>![화면 캡처 2023-01-06 083938](https://user-images.githubusercontent.com/39551265/210900627-3695ff8f-0083-44db-9b5b-fd73387c6fc0.png)<br>