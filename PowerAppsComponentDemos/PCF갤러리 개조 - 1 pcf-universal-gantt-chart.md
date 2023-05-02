# PCF 갤러리 프로젝트 개조 1 - pcf-universal-gantt-chart
> PCF 갤러리에 올라온 프로젝트들을 개조하여 기능을 추가해 본다. 이번에 해볼 것은 [pcf-universal-gantt-chart](https://pcf.gallery/universal-gantt-chart/) 로 모델기반앱과 캔벗 앱에서 사용할 수 있는 간트차트 PCF이다.

## pcf-universal-gantt-chart 소개
1. 간트차트를 모델기반 앱의 뷰, 서브 그리드, 캔버스 앱 등에서 사용할 수 있도록 만든 프로젝트이며 다음 [깃허브](https://github.com/MaTeMaTuK/pcf-universal-gantt-chart) 에서 프로젝트를 확인할 수 있다.

2. 모델기반앱의 뷰 페이지를 기반으로 설명하면 뷰에서 설정된 테이블의 데이터들을 기반으로 간트차트를 표현한다. 다음 이미지에서 볼 수 있듯이 간트 차트의 행의 이름, 시작시간 종료시간 항목을 테이블의 데이터를 가져와 설정할 수 있다.
![ganttchartsmaple](https://raw.githubusercontent.com/MaTeMaTuK/pcf-universal-gantt-chart/master/DocumentationAssets/ganttStandard.gif)

3. 간트 Task 그래프 영역을 드래그하여 옮길 수 있고 옮기면 Table의 데이터에도 반영이 된다.

## 수정 목표

1. 테이블에 추가로 표시할 항목을 추가 항목(선택 레코드의 레이블, 조회 레코드의 하위 항목)을 추가할 수 있어야한다.

![ganttsubimage](https://user-images.githubusercontent.com/39551265/235069249-a282917f-9818-4b3a-9df0-fe3a711e9d55.png)

2. 리소스를 이용해 한국영역의 리소스를 가져와 사용

![ganttkorresx](https://user-images.githubusercontent.com/39551265/235071271-8d97a4f0-4a22-4fce-a723-3a37f7326be5.png)

## 소스코드

1. 원본은 fork 하여 만든 [깃허브](https://github.com/nanenchanga53/pcf-universal-gantt-chart)

2. 우선 `ControlManifest.input.xml` 에서 데이터셋으로 불러들일 레코드를 property를 추가로 지정한다. 추가로 지정할 것들은 옵션셋의 레이블을 보여줄 레코드, 엔티티의 조회 레코드, 조회 레코드가 연결된 테이블과 보여줄 하위 목록들, 그리고 테이블 헤더명들이다.

|   Parameter Name             | Description                                   |
| :--------------------------- | :-------------------------------------------- |
| subOption                    | 추가로 표시할 선택 레코드                      |
| subLookup                    | 추가로 표시할 조회 레코드                      |
| tasksDataset                 | 조회 레코드의 원본 테이블                      |
| taskName                     | 원본 테이블의 표시할 레코드1                   |
| taskName2                    | 원본 테이블의 표시할 레코드2                   |
| taskName3                    | 원본 테이블의 표시할 레코드3                   |
| subOptionHeaderDisplayName   | 추가로 표시할 선택 레코드 헤더명                |
| subLookUpHeaderDisplayName   | 추가로 표시할 조회 레코드 헤더명1               |
| subLookUpHeaderDisplayName2  | 추가로 표시할 조회 레코드 헤더명2               |
| subLookUpHeaderDisplayName3  | 추가로 표시할 조회 레코드 헤더명3               |


3. `ControlManifest.input.xml` 에서 `<resources>` 영역에 `<resx path="strings/UniversalGanttChartComponent.1042.resx" version="1.0.0" />`를 추가한 후 string 폴더 안에 'UniversalGanttChartComponent.1042.resx' 파일을 추가한 후 리소스 파일 형식으로 추가한다.(다른 리소스파일을 복사한후 뒤의 숫자만 1042로 변경하자) 그후 파일에서 리소스를 변경한다.

4. 프로젝트를 깃허브에서 클론하면 'node_modules'폴더가 존재하지 않을 것이다. 우선 `npm install` 명령어를 터미널에서 실행한다.

5. `npm run build` 명령어를 실행해 제대로 빌드가 되는지 확인한다. (`UniverslGanttChartComponent\generated\ManifestTypes.d.ts` 파일이 이전 `ControlManifest.input.xml`에 정의한 형식으로 새로 생성될 것이다.)

6. `chagedfiled\public-type.d.ts` 파일을 `UniverslGanttChartComponent\generated\ManifestTypes.d.ts`에 덮어씌운다. (props 등의 정의를 추가된 항목에 맞게 수정한다.)

7. `index.ts` 파일에서 `UniversalGanttChartComponent` 클래스에서 추가한 property와  props 파라메터를 추가하여 데이터셋에서 읽어들이는 데이터를 전달할 수 있도록 정의한다.

8. `index.ts` 파일의 `updateView` 함수에서 데이터셋을 refresh하는 것을 확인할 수 있을 것이다. 해당작업은 PCF를 모델기반앱에서 페이지에 접속할시 처음에는 기본 가져오는 개수 50개만 가져오는 상황을 피하기 위해 추가하였다.

8. `UniversalGanttChartComponent\components\universal-gantt.tsx` 에서 간트 차트 react를 구성시 추가된 정의들과 필요한 파라메터 값을 추가한다. 파라메터는 테이블의 헤더,리스트 등을 구성하는 값을 정의하고 원작자의 [간트차트 리엑트](https://github.com/MaTeMaTuK/gantt-task-react)를 구성하도록 정의하게 된다.

9. 추가된 값을 이용해 `UniversalGanttChartComponent\components\task-list-header.tsx`에서 추가된 헤더의 값을 `UniversalGanttChartComponent\components\task-list-table.tsx`에서 테이블의 값을 각각 추가한다.

## 결론

위의 작업들을 통해 기존 간트차트 PCF에 추가된 테이블 값을 가져와 사용할 수 있게 되었다. [깃허브](https://github.com/MaTeMaTuK/pcf-universal-gantt-chart)에서 소스코드를 볼 수 있으며 이후 다른 PCF등을 조금 개조하여 사용하거나 설명을 추가하는 작업을 할 것이다.