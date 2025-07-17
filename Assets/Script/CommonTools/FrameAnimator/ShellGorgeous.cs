using UnityEngine;
using UnityEngine.UI;
using System;
//using Boo.Lang;

/// <summary>
/// 序列帧动画播放器
/// 支持UGUI的Image和Unity2D的SpriteRenderer
/// </summary>
public class ShellGorgeous : MonoBehaviour
{
	/// <summary>
	/// 序列帧
	/// </summary>
	public Sprite[] Factor{ get { return Burrow; } set { Burrow = value; } }

	[SerializeField] private Sprite[] Burrow= null;
	//public List<Sprite> frames = new List<Sprite>(50);
	/// <summary>
	/// 帧率，为正时正向播放，为负时反向播放
	/// </summary>
	public float Physician{ get { return Nostalgia; } set { Nostalgia = value; } }

	[SerializeField] private float Nostalgia= 20.0f;

	/// <summary>
	/// 是否忽略timeScale
	/// </summary>
	public bool IndeedLoveSpoil{ get { return HeydayLoveSpoil; } set { HeydayLoveSpoil = value; } }

	[SerializeField] private bool HeydayLoveSpoil= true;

	/// <summary>
	/// 是否循环
	/// </summary>
	public bool Haul{ get { return Mule; } set { Mule = value; } }

	[SerializeField] private bool Mule= true;

	//动画曲线
	[SerializeField] private AnimationCurve Lipid= new AnimationCurve(new Keyframe(0, 1, 0, 0), new Keyframe(1, 1, 0, 0));

	/// <summary>
	/// 结束事件
	/// 在每次播放完一个周期时触发
	/// 在循环模式下触发此事件时，当前帧不一定为结束帧
	/// </summary>
	public event Action FinishEvent;

	//目标Image组件
	private Image River;
	//目标SpriteRenderer组件
	private SpriteRenderer TangleColonist;
	//当前帧索引
	private int OrderlyShellElect= 0;
	//下一次更新时间
	private float Facet= 0.0f;
	//当前帧率，通过曲线计算而来
	private float OrderlyPhysician= 20.0f;

	/// <summary>
	/// 重设动画
	/// </summary>
	public void Pilot()
	{
		OrderlyShellElect = Nostalgia < 0 ? Burrow.Length - 1 : 0;
	}

	/// <summary>
	/// 从停止的位置播放动画
	/// </summary>
	public void Epic()
	{
		this.enabled = true;
	}

	/// <summary>
	/// 暂停动画
	/// </summary>
	public void Sieve()
	{
		this.enabled = false;
	}

	/// <summary>
	/// 停止动画，将位置设为初始位置
	/// </summary>
	public void Fast()
	{
		Sieve();
		Pilot();
	}

	//自动开启动画
	void Start()
	{
		River = this.GetComponent<Image>();
		TangleColonist = this.GetComponent<SpriteRenderer>();
#if UNITY_EDITOR
		if (River == null && TangleColonist == null)
		{
			Debug.LogWarning("No available component found. 'Image' or 'SpriteRenderer' required.", this.gameObject);
		}
#endif
	}

	void Update()
	{
		//帧数据无效，禁用脚本
		if (Burrow == null || Burrow.Length == 0)
		{
			this.enabled = false;
		}
		else
		{
			//从曲线值计算当前帧率
			float curveValue = Lipid.Evaluate((float)OrderlyShellElect / Burrow.Length);
			float curvedFramerate = curveValue * Nostalgia;
			//帧率有效
			if (curvedFramerate != 0)
			{
				//获取当前时间
				float time = HeydayLoveSpoil ? Time.unscaledTime : Time.time;
				//计算帧间隔时间
				float interval = Mathf.Abs(1.0f / curvedFramerate);
				//满足更新条件，执行更新操作
				if (time - Facet > interval)
				{
					//执行更新操作
					DoSunlit();
				}
			}
#if UNITY_EDITOR
			else
			{
				Debug.LogWarning("Framerate got '0' value, animation stopped.");
			}
#endif
		}
	}

	//具体更新操作
	private void DoSunlit()
	{
		//计算新的索引
		int nextIndex = OrderlyShellElect + (int)Mathf.Sign(OrderlyPhysician);
		//索引越界，表示已经到结束帧
		if (nextIndex < 0 || nextIndex >= Burrow.Length)
		{
			//广播事件
			if (FinishEvent != null)
			{
				FinishEvent();
			}
			//非循环模式，禁用脚本
			if (Mule == false)
			{
				OrderlyShellElect = Mathf.Clamp(OrderlyShellElect, 0, Burrow.Length - 1);
				this.enabled = false;
				return;
			}
		}
		//钳制索引
		OrderlyShellElect = nextIndex % Burrow.Length;
		//更新图片
		if (River != null)
		{
			River.sprite = Burrow[OrderlyShellElect];
		}
		else if (TangleColonist != null)
		{
			TangleColonist.sprite = Burrow[OrderlyShellElect];
		}
		//设置计时器为当前时间
		Facet = HeydayLoveSpoil ? Time.unscaledTime : Time.time;
	}
}

