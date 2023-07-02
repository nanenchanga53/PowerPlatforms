# Power Automate Custom Action - 윈도우 영역 캡처
> Power Automate Desktop 에서 사용자가 직접 작성한 코드로 데스크탑 흐름을 제작할 수 있도록 공개되었다. .NetFramework로만 제작이 가능하다(이후 Core이상도 지원을 기대한다. - .NetFrameWork만 지원으로 타 OS 실행을 막을 가능성도 있다) [정식문서](https://learn.microsoft.com/ko-kr/power-automate/desktop-flows/create-custom-actions)에서 자세한 설명을 볼 수 있다.

## 요구사항

* .NetFrameWork 4.7.2 이상
* Visual Studio 2022 이상의 IDE
* Power Automate for Desktop 버전 2.32 이상
* [Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK](https://www.nuget.org/packages/Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK/)
* 프리미엄 라이선스



## Visual Studio용 템플릿 설치 후 프로젝트 작성

1. Visual Studio 패키지 관리자에서 다음 면령을 실행하여 템플릿을 설치(설치시 한글이 깨져나온다.)

```
dotnet new -i Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.Templates
```

![스크린샷 2023-06-29 160755](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/0ebd3302-8a13-40ac-99e4-1f9f0d13de88)

2. 처음 만드는 것이면 Power Automate Sample Module을 선택

![스크린샷 2023-06-29 162443](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/ef9f1ad5-7e38-458c-9c35-352f774e832b)

3. 프로젝트 이름과 경로를 지정(경로에 한글이 없는것을 추천)

![스크린샷 2023-06-29 163530](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/f468ed80-abea-4faa-b6c9-85d1dd1e0859)

4. 흐름 내에서 사용할 단계의 모듈 ID를 입력하고 'Create Test Project'는 해제하자(2023.06.30 기준으로는 해제하는 것이 좋다. 이후 달라질 수 있다), .resx file 사용은 리소스로 설명등을 관리할 것이면 체크 아니면 소스코드에 직접 작성하면 된다.

![스크린샷 2023-06-29 164309](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/083651da-a26d-4189-8086-e6b19681dac1)

5. 우선 프로젝트 파일에서 `Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK` 버전을 지정해줘야한다.(현제 지정하지 않으면 어떤 버전을 사용해야하는지 알지 못한다) 버전은 `1.4.232.23122-rc` 지정한다.(기존 페키지레퍼런스 설정은 삭제하고 다음으로 대체)

```xml
<ItemGroup>
	<PackageReference Include="Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK" Version="1.4.232.23122-rc" />
</ItemGroup>
```

6. cs파일을 연다.

7. 주요한 특성(Attributes)을 살펴보면<br>Action : 단계를 정의한다<br>Throws : 에러시 이름<br>InputArgument : 단계의 입력값 정의<br>OutputArgument : 단계의 출력값 정의

8. 현재 만드려는건 윈도우에서 영역을 캡처하는 것을 만드려 한다. 우선 입력 특성을 포함하는 특성들을 추가한다. 다음 코드를 기존 프로퍼티를 삭제하고 Excute 함수 위에 추가한다. 캡처를 시작하는 위치의 x,y 값 그리고 가로세로 길이, 저장하는 디렉토리 위치를 지정한다.

```c#

/// <summary>
/// 캡처 좌상단 위치 X값
/// </summary>
[InputArgument(Order = 1)]
public int LeftX { get; set; }

/// <summary>
/// 캡처 좌상단 위치 Y값
/// </summary>
[InputArgument(Order = 2)]
public int LeftY { get; set; }

/// <summary>
/// 캡처 가로크기
/// </summary>
[InputArgument(Order = 3)]
public int Width{ get; set; }

/// <summary>
/// 캡처 세로크기
/// </summary>
[InputArgument(Order = 4)]
public int Hight { get; set; }

/// <summary>
/// 저장위치
/// </summary>
[InputArgument(Order = 5)]
public string Dir { get; set; }

```

9. 이미지를 캡처하는 작업을 하는 클래스를 생성한다. 소스코드는 다음과 같다 같은 namespace안에 넣자(따로 파일을 관리하고 싶으면 분리) 이때 최상단에 `using System.Drawing`, `using System.Drawing.Imaging`을 추가한다.

```csharp
/// <summary>
/// 이미지 저장 클래스
/// </summary>
public class ImgCapture
{
    /// <summary>
    /// 이미지 저장을 위한 시작위치 X
    /// </summary>
    private int StartX { get; set; } = 0;

    /// <summary>
    /// 이미지 저장을 위한 시작위치 Y
    /// </summary>
    private int StartY { get; set; } = 0;

    /// <summary>
    /// 이미지 저장을 위한 길이
    /// </summary>
    private int ImageWidth { get; set; } = 0;

    /// <summary>
    /// 이미지 저장을 위한 높이
    /// </summary>
    private int ImageHight { get; set; } = 0;

    private string filePath = null;

    /// <summary>
    /// Core 이상을 사용할 수 있게되면 튜플로 변경하자
    /// </summary>
    /// <param name="startX">시작위치X</param>
    /// <param name="startY">시작위치Y</param>
    /// <param name="imgWidth">이미지 너비</param>
    /// <param name="imgHight">이미지 높이</param>
    public ImgCapture(int startX = 0, int startY = 0, int imageWidth = 0, int imageHight = 0)
    {
        StartX = startX;
        StartY = startY;
        ImageWidth = ImageWidth;
        ImageHight = ImageHight;
    }

    /// <summary>
    /// 저장위치
    /// </summary>
    /// <param name="path">저장위치경로(파일 이름,형식까지)</param>
    public void SetPath(string path)
    {
        filePath = path;
    }

    /// <summary>
    /// 
    /// </summary>
    public void CaptureWindow()
    {
        if (filePath != null)
        {
            if (StartX == 0 || StartY == 0)
                return;

            using (Bitmap bitmap = new Bitmap((int)ImageWidth, (int)ImageHight))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(StartX, StartY, 0, 0, bitmap.Size);
                }

                bitmap.Save(filePath, ImageFormat.Png);
            }
        }
    }
}


```

10. 최종적인 소스코드는 다음과 같다.

```csharp
using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK.Attributes;
using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace Modules.Capture
{

    /// <summary>
    /// 이미지 저장 클래스
    /// </summary>
    public class ImgCapture
    {
        /// <summary>
        /// 이미지 저장을 위한 시작위치 X
        /// </summary>
        private int StartX { get; set; } = 0;

        /// <summary>
        /// 이미지 저장을 위한 시작위치 Y
        /// </summary>
        private int StartY { get; set; } = 0;

        /// <summary>
        /// 이미지 저장을 위한 길이
        /// </summary>
        private int ImageWidth { get; set; } = 0;

        /// <summary>
        /// 이미지 저장을 위한 높이
        /// </summary>
        private int ImageHight { get; set; } = 0;

        private string filePath = null;

        /// <summary>
        /// Core 이상을 사용할 수 있게되면 튜플로 변경하자
        /// </summary>
        /// <param name="startX">시작위치X</param>
        /// <param name="startY">시작위치Y</param>
        /// <param name="imgWidth">이미지 너비</param>
        /// <param name="imgHight">이미지 높이</param>
        public ImgCapture(int startX = 0, int startY = 0, int imageWidth = 0, int imageHight = 0)
        {
            StartX = startX;
            StartY = startY;
            ImageWidth = ImageWidth;
            ImageHight = ImageHight;
        }

        /// <summary>
        /// 저장위치
        /// </summary>
        /// <param name="path">저장위치경로(파일 이름,형식까지)</param>
        public void SetPath(string path)
        {
            filePath = path;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CaptureWindow()
        {
            if (filePath != null)
            {
                if (StartX == 0 || StartY == 0)
                    return;

                using (Bitmap bitmap = new Bitmap((int)ImageWidth, (int)ImageHight))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(StartX, StartY, 0, 0, bitmap.Size);
                    }

                    bitmap.Save(filePath, ImageFormat.Png);
                }
            }
        }
    }

    
    [Action(Id = "CaptrueCustom", Order = 1)]
    [Throws("CaptureError")] // TODO: change error name (or delete if not needed)
    public class CaptureCustomAction : ActionBase
    {
        /// <summary>
        /// 캡처 좌상단 위치 X값
        /// </summary>
        [InputArgument(Order = 1)]
        public int LeftX { get; set; }

        /// <summary>
        /// 캡처 좌상단 위치 Y값
        /// </summary>
        [InputArgument(Order = 2)]
        public int LeftY { get; set; }

        /// <summary>
        /// 캡처 가로크기
        /// </summary>
        [InputArgument(Order = 3)]
        public int Width{ get; set; }

        /// <summary>
        /// 캡처 세로크기
        /// </summary>
        [InputArgument(Order = 4)]
        public int Hight { get; set; }

        /// <summary>
        /// 저장위치
        /// </summary>
        [InputArgument(Order = 5)]
        public string Dir { get; set; }

        public override void Execute(ActionContext context)
        {
            
            try
            {
                ImgCapture imgCapture = new ImgCapture(LeftX, LeftY, Width, Hight);

                imgCapture.SetPath(Dir);

                imgCapture.CaptureWindow();

            }
            catch (Exception e)
            {
                if (e is ActionException) throw;

                throw new ActionException("ActionError", e.Message, e.InnerException);
            }

        }
    }
}

```

11. 이후 빌드 후 생성된 net472 폴더안에 dll 이 생성된 것을 확인한다.

![스크린샷 2023-06-30 154801](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/d28285de-d78a-43a7-b645-ff4aedc83809)

## 인증서 작성과 설치
> 커스텀 액션은 cab파일로 만들어야한다. 그전에 DLL파일을 조직에서 신뢰하는 인증서로 서명되하고 설치해야한다.(서명은 각 사용하는 장치마다 설치해야한다.)

1. Power Shell 을 실행한다.

2. 다음 코드를 복사하여 붙여넣고 실행한다. 이때 파일위치와 암호는 적당히 변경한다.

```
$certname = "Self-Signed Certificate"
$cert = New-SelfSignedCertificate -CertStoreLocation Cert:\CurrentUser\My -Type CodeSigningCert  -Subject "CN=$certname" -KeyExportPolicy Exportable -KeySpec Signature -KeyLength 2048 -KeyAlgorithm RSA -HashAlgorithm SHA256 -NotAfter (Get-Date).AddYears(30)
$mypwd = ConvertTo-SecureString -String "{비밀번호}" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath "{파일위치변경}\cert.pfx" -Password $mypwd
```

3. 위 명령어로 생성된 서명파일을 실행한다.

![스크린샷 2023-06-30 162544](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/0443bcdb-6afb-4105-9283-19f803fd15c2)

![스크린샷 2023-06-30 163456](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/24960fb2-4d73-4e26-a790-652314c9b33e)

4. 인증서 생성시 입력한 비밀번호를 입력후 아래 이미지에 해당되는 항목들을 체크한다.

![스크린샷 2023-06-30 163526](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/e87ef78d-9756-45a4-bf61-85b961043bd2)

5. '모든 인증서를 다음 저장소에 저장'을 선택 후 '인증서 저장소'를 '신뢰할 수 있는 루트 인증 기관'으로 선택

![스크린샷 2023-06-30 163622](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/6890448d-e1f7-44ef-88ff-6ef0d303c305)

6. 인증서 가져오기 마법사를 완료한다.

![스크린샷 2023-06-30 163707](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/772feac8-5844-4dfe-b395-adacb33f7591)

7. 경고가 표시되면 '예'

## DLL 파일서명

1. Visual Studio의 개발자 명령 프롬프트에서 다음 명령을 실행하여 DLL에 서명, 경로를 적절하게 변경한다.(한글이 있다면 제대로 안될 수 있다. 한글이 없는 경로로 옮겨서 실행한다.)

```powershell	
Signtool sign /f "{서명위치}\cert.pfx" /p "{비밀번호}" /fd SHA256 "{dll 생성 파일경로}\Modules.Module1.dll"
```

## cab 파일로 패키징

1. 생성된 DLL 파일은 종속 파일과 함께 CAB 파일로 패키지되어야 한다.

2. 아래 PowerShell 스크립트(makeCabFromDirectory.ps1)를 만들어 저장한다.

```powershell
param(

    [ValidateScript({Test-Path $_ -PathType Container})]
	[string]
	$sourceDir,
	
	[ValidateScript({Test-Path $_ -PathType Container})]
    [string]
    $cabOutputDir,

    [string]
    $cabFilename
)

$ddf = ".OPTION EXPLICIT
.Set CabinetName1=$cabFilename
.Set DiskDirectory1=$cabOutputDir
.Set CompressionType=LZX
.Set Cabinet=on
.Set Compress=on
.Set CabinetFileCountThreshold=0
.Set FolderFileCountThreshold=0
.Set FolderSizeThreshold=0
.Set MaxCabinetSize=0
.Set MaxDiskFileCount=0
.Set MaxDiskSize=0
"
$ddfpath = ($env:TEMP + "\customModule.ddf")
$sourceDirLength = $sourceDir.Length;
$ddf += (Get-ChildItem $sourceDir -Filter "*.dll" | Where-Object { (!$_.PSIsContainer) -and ($_.Name -ne "Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK.dll") } | Select-Object -ExpandProperty FullName | ForEach-Object { '"' + $_ + '" "' + ($_.Substring($sourceDirLength)) + '"' }) -join "`r`n"
$ddf | Out-File -Encoding UTF8 $ddfpath
makecab.exe /F $ddfpath
Remove-Item $ddfpath
```

3. 이후 PowerShell 스크립트에 dll경로, cab 파일이 생성될 경로, cab 파일이름을 입력하여 실행

```powershell
{powershell 스크립트 위치}makeCabFromDirectory.ps1 "{dll경로}" "{cab파일생성위치}" "{cab파일이름}.cab"
```


## cab파일서명

1. 패키지된 cab 파일과 dll 파일도 서명해야 한다.

```powershell
Signtool sign /f "{서명경로}\cert.pfx" /p "{비밀번호}" /fd SHA256 "{cab파일경로}.cab"
```

## 사용자 지정 작업 업로드

1. Power Automate 웹으로 로그인한다.

2. '데이터' -> '사용자 지정 작업' -> '+ 사용자 지정 작업 업로드' 클릭

![스크린샷 2023-07-03 083324](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/3c6b6077-58ce-4c49-857b-f8fede09be2c)

3. 사용자 지정 작업의 이름을 입력하고 cab파일을 선택하여 업로드한다.

![스크린샷 2023-07-03 083551](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/420ce7a8-0106-4f6e-93ec-78c9c379b37e)

4. 작업목록에 추가된것을 확인한다.

![스크린샷 2023-07-03 083757](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/6aa45b4a-dc79-49a9-948c-9721a058045e)


## 사용자 지정 작업을 사용하는 방법

1. Power Automate for Desktop을 연다. 흐름을 새로 생성하거나 수정을 선택하여 디자이너를 연다.

2. 좌측 작업 탭에서 '추가 작업 표시'를 클릭

![스크린샷 2023-07-03 084024](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/aa3c09fb-d0d5-46e6-ba04-01693cceb3fc)

3. 자산 라이브러리에서 추가한 사용자 지정 작업을 선택히여 추가한다.

![스크린샷 2023-07-03 084224](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/6db2624f-b95c-4930-8999-5458161a26a3)

4. 이후 흐름내부에 작업을 추가해서 사용할 수 있게된다.(사용하는 데스크탑에 서명이 제대로 설치되어있다면 공유가 가능하다)

![스크린샷 2023-07-03 084358](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/a3f577c3-902e-45eb-95ee-e64fcb11eede)


5. 생성한 사용자 지정 작업을 실행해 본다.

![스크린샷 2023-07-03 084543](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/99930abc-ac60-4122-85c7-c53c846fae1a)


6. 이후 경로에 파일이 제대로 생성되었다면 성공이다.