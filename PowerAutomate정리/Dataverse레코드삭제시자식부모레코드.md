# Dataverse 레코드 삭제시 연결된 레코드 불러오는 NoCode 연구

## 문제점 정의

1. Power Automate 등의 Dataverse Api를 사용하여 삭제를 진행할 시 트리거되어 가져오는 데이터에는 연결되어 있던 레코드(1:N 관계 등)이 어떤 것이였는지 반환하지 않는다.<br><br>![스크린샷 2023-03-22 135205](https://user-images.githubusercontent.com/39551265/226805451-f569c26e-acc5-4b58-a0a0-855fba96e367.png)<br>

2. 개발을 진행한다면 플러그인을 FetchXML, c# xrm package 등으로 제작하여 삭제 진행시 미리 연결되었던 것을 검색 하는 동작을 추가하는 것으로 해결할 수 있다.

3. 하지만 가능하면 NoCode로 해결할 수 있을까 시도해보았던 것들을 정리한다.


## 미리 연결된 레코드를 따로 저장

1. 데이터 테이블의 1:N 연결 레코드와 별도로 연결된 레코드를 저장한다.
    * 해당 방법에서 문제가 되는건 연결된 레코드가 업데이트가 일어날때마다 레코드를 업데이트 해야하는 것에 있다. 각 엔티티별로 레코드를 업데이트한는 것을 Power Automate등에 등록을 한다고 하면 연결되어있는 엔티티의 개수만큼 새로 만들어야한다.

2.  