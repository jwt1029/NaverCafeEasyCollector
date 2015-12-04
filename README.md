# NaverCafeEasyCollector
Can search&amp;download article in Naver cafe with naming rule.

## Development Language
  C# (Windows Forms Application)
 
## Target Framework
  .NET Framework 4.0
 
## Target Platform
  Windows (x64, x86)

## Manual
1. Login 버튼을 클릭하여 네이버 계정으로 로그인 합니다.<br />
    Click ``` Login ``` button and login with your Naver account.

2. 검색을 시행할 타겟 카페 주소를 입력합니다.<br />
    Set target cafe link where you'll search.

3. 검색할 문서들의 게시 허용 기간을 설정합니다.<br />
    Set articles' search duration.

4. 검색될 문서들의 제목 규칙 (Naming Rule)을 설정해줍니다.<br />
    Set articles' ``` Naming Rule ```.
 
5. Search 버튼을 클릭하여 게시글을 검색합니다.<br />
    Click ``` Search ``` button to search articles.

6. 현재 설정되어있는 Naming Rule을 저장 할  수 있습니다.<br />
    (저장된 템플릿은 Open Template 버튼을 클릭하여 열 수 있습니다.)<br />
    You can save ``` Naming Rule ``` currently set.<br />
    (Saved template can open with ``` Open Template ``` button.)

7. 검색이 완료 된 후에 [ ![alt tag](https://cloud.githubusercontent.com/assets/14898993/11578695/1a84425a-9a6b-11e5-9df3-22ddb35cdcd8.png) ]  버튼을 클릭하여 설정환경을 변경합니다.<br />
    After search finished, click [ ![alt tag](https://cloud.githubusercontent.com/assets/14898993/11578695/1a84425a-9a6b-11e5-9df3-22ddb35cdcd8.png) ] button to change setting environment.

8. 파일이 저장될 이름 형식을 지정합니다.  (Naming Rule에 등록된 텍스트 + 사용자 입력 텍스트)<br />
    Set ``` Naming Rule ``` of saved files. (Registed text in ``` Naming Rule ``` + User entered text)

9. 파일이 저장될 로컬 위치를 설정 합니다.<br />
    Set local directory of saved files.

10. Download 버튼을 클릭하여 파일을 다운로드 합니다.<br />
    Click download button and download files.

## Additional Functions
1. Text Viewer
    다운로드 된 "body.txt" 파일을 기존 Windows 내장 메모장 ``` Notepad ``` 로 열 경우, 폼 크기에 따른 개행이 자동으로 이루어지지않아
    좌-우 스크롤을 사용해야해서 가독성이 떨어지는 문제가 있었다. 이를 고려하여 보다 가독성을 높인 Text Viewer를 프로그램에 내장시켰다.<br />
    If you open downloaded "body.txt" with usual ``` Notepad ```, it doesn't make newline automatically so we need to use
    ``` Horizontal Scrollbar ```. With this in mind and created a ``` Text Viewer ``` that more increase readability.<br />

2. Comment
    글을 확인하고 바로 댓글을 달고 싶은 경우, 카페에 들어가지 않고 바로 댓글을 달 수 있도록 Comment 기능을 추가하였다.
    If you want directly comment after read article, you can use ``` Comment ``` function to comment directly.
