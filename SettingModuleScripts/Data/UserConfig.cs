public static class UserConfig
{
	public static string FirstRunGameName = "DigitalWall";

	/// <summary>
	/// 布局方式
	/// </summary>
	public static int RowCountMax = 20;
	/// <summary>
	/// 最大显示列数
	/// </summary>
	public static int ColumnCountMax = 40;
	/// <summary>
	/// 最大显示行数
	/// </summary>
	public static float RowCountRangeScale = 0.5f;
	/// <summary>
	/// 显示列数范围
	/// </summary>
	public static float ColumnCountRangeScale = 0.5f;
	/// <summary>
	/// 浏览圈数量上限
	/// </summary>
	public static int ViewCircleCount = 6;
	/// <summary>
	/// 浏览圈直径
	/// </summary>
	public static int ViewCircleRadius = 1000;
	/// <summary>
	/// 切场时间间隔
	/// </summary>
	public static int ReLoadIntervalSecond = 20;
	/// <summary>
	/// 无人操作浏览圈自动关闭
	/// </summary>
	public static int NoTouchCloseCircleSecond = 60000;
	/// <summary>
	/// 当前屏幕图片个数不足数时，不避让，默认：50
	/// </summary>
	public static int NonSpreadPhotoCount = 100;
	/// <summary>
	/// 标题和描述字体大小
	/// </summary>
	public static int DescriptionFontSize = 45;
	/// <summary>
	/// 小图间隔宽度
	/// </summary>
	public static int BlackBorderSize = 20;
	/// <summary>
	/// 加载待场图片睡眠间隔
	/// </summary>
	public static int LoadStandbyItemSleepMilliSecond = 200;
	/// <summary>
	/// 浏览圈轮播加载图片数量
	/// </summary>
	public static int ViewCircleScrollItemCount = 10;
	/// <summary>
	/// 模型旋转幅度
	/// </summary>
	public static int ModelTransformRange = 20;
	/// <summary>
	/// 模型缩放幅度
	/// </summary>
	public static int ModelScaleRange = 5;
	/// <summary>
	///  浏览圈发生重叠时，弹到指定位置所用时间
	/// </summary>
	public static float CoverCicleMoveSpeed = 0.2f;
	/// <summary>
	///  浏览圈发生重叠时，弹到指定位置所用时间
	/// </summary>
	public static float TextureMinPixelPerScale = 0.095f;
	/// <summary>
	/// 两次点击若发生在X秒内识别为双击
	/// </summary>
	public static float DoublePressInterval = 0.5f;
	/// <summary>
	/// 小图进场后横向移动，每帧移动的位移，
	/// </summary>
	public static float MovePerOffsetX = 1f;
	/// <summary>
	///  小图进场后纵向移动，每帧移动的位移
	/// </summary>
	public static float MovePerOffsetY = 1f;
	/// <summary>
	/// 布局小图时屏幕外加载宽度：小图高度*此值，默认4
	/// </summary>
	public static float OutOfScreenWidthScale = 1.3f;
	/// <summary>
	/// 布局小图时屏幕外加载高度：小图宽度*此值，默认2
	/// </summary>
	public static float OutOfScreenHeightScale = 1.7f;
	/// <summary>
	/// 原图转小图缩略图，设定宽度，默认256
	/// </summary>
	public static int TextureScaleWidth = 256;

	// Token: 0x04000718 RID: 1816
	public static bool IsMovePerOffset = true;

	// Token: 0x04000719 RID: 1817
	public static float SpreadSpeed = 0.13f;

	// Token: 0x0400071A RID: 1818
	public static float RebackSpeed = 0.07f;

	// Token: 0x0400071B RID: 1819
	public static float ItemBorderSizeScaleByFixHeight = 0.08f;
	/// <summary>
	/// 是否打开背景音乐
	/// </summary>
	public static bool isOpenBgMusic = false;
	/// <summary>
	/// 是否使用密码
	/// </summary>
	public static bool UsePassword = true;
	/// <summary>
	/// 安全设置中的密码
	/// </summary>
	public static string PassWord = "1234";
	/// <summary>
	/// 是否打开设计模式
	/// </summary>
	public static bool DesginMode = false;




}