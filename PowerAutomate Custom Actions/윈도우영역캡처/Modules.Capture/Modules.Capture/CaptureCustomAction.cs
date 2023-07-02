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
